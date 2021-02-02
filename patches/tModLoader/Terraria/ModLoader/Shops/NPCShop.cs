using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.UI;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.ModLoader
{
	// todo: allow custom slot indexes, custom shops
	public partial class NPCShop
	{
		internal readonly Dictionary<string, Page> pages = new Dictionary<string, Page>();
		public readonly Page DefaultPage;
		private int type;

		public bool EvaluateOnOpen = true;

		internal NPCShop(int type) {
			this.type = type;
			DefaultPage = new Page(NetworkText.FromLiteral("Default"));
			pages.Add("Default", DefaultPage);
		}

		public Page AddPage(string key, NetworkText name) {
			Page page = new Page(name);
			pages.Add(key, page);
			return page;
		}

		public Page GetPage(string key) => pages.ContainsKey(key) ? pages[key] : null;

		public EntryItem CreateEntry(int type) => DefaultPage.AddEntry(type);

		public EntryItem CreateEntry<T>() where T : ModItem => CreateEntry(ModContent.ItemType<T>());

		public T AddEntry<T>(T entry) where T : Entry {
			DefaultPage.AddEntry(entry);
			return entry;
		}

		internal void Evaluate() {
			List<Item> l = new List<Item>();
			foreach (Entry entry in DefaultPage.entries) l.AddRange(entry.GetItems());

			int size = Math.Max(40, (l.Count / 10 + 1) * 10);
			NPCShopManager.entryCache[type] = new Item[size];
			for (int i = 0; i < size; i++)
			{
				if (i < l.Count) NPCShopManager.entryCache[type][i] = l[i];
				else NPCShopManager.entryCache[type][i] = new Item();
			}
		}

		private static int npcShopRowIndex;
		private static string currentPage = "Default";

		public virtual void Open() {
			npcShopRowIndex = 0;
			currentPage = "Default";
			
			if (EvaluateOnOpen) Evaluate();
		}

		public virtual void Draw(SpriteBatch spriteBatch) {
			ref float inventoryScale = ref Main.inventoryScale;
			float mouseX = Main.mouseX;
			float mouseY = Main.mouseY;
			Vector2 slotSize = TextureAssets.InventoryBack.Size() * inventoryScale;
			int invBottom = Main.instance.invBottom;
			var inv = NPCShopManager.entryCache[type];

			Utils.DrawBorderStringFourWay(spriteBatch, FontAssets.MouseText.Value, Language.GetText("LegacyInterface.28").Value, 504f, invBottom, Color.White * (Main.mouseTextColor / 255f), Color.Black, Vector2.Zero);
			ItemSlot.DrawSavings(spriteBatch, 504f, invBottom);
			inventoryScale = 0.755f;
			if (mouseX > 73 && mouseX < (int)(73f + 560f * inventoryScale) && mouseY > invBottom && mouseY < (int)(invBottom + 224f * inventoryScale) && !PlayerInput.IgnoreMouseInterface)
				Main.LocalPlayer.mouseInterface = true;

			int pageButtonX = 33;
			int height = (int)(4 * 56f * inventoryScale);
			int pageButtonY = invBottom + height / 2;
			int pageButtonSizeX = 14;
			int pageButtonSizeY = 22;
			int rows = (int)Math.Ceiling(inv.Length / 10f);
			int maxRowIndex = rows - 4;

			Rectangle upButton = new Rectangle(pageButtonX, pageButtonY - 20 - pageButtonSizeY, pageButtonSizeX, pageButtonSizeY);
			Rectangle downButton = new Rectangle(pageButtonX, pageButtonY + 12, pageButtonSizeX, pageButtonSizeY);

			spriteBatch.Draw(UICommon.ButtonPreviousPage.Value, upButton, Color.White);
			spriteBatch.Draw(UICommon.ButtonNextPage.Value, downButton, Color.White);

			string rowText = $"{npcShopRowIndex * 10 + 1}-{(npcShopRowIndex + 4) * 10}";
			Vector2 rowTextOrigin = FontAssets.MouseText.Value.MeasureString(rowText);
			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, rowText, new Vector2(pageButtonX + pageButtonSizeX / 2, pageButtonY), Color.White, 0f, rowTextOrigin * 0.5f, Vector2.One);

			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, pages[currentPage].DisplayName.ToString(), new Vector2(73f, 426f), Color.White, 0f, Vector2.Zero, Vector2.One);

			if (upButton.Contains(Main.MouseScreen))
			{
				if (Main.mouseLeft && Main.mouseLeftRelease)
				{
					if (npcShopRowIndex > 0)
					{
						npcShopRowIndex--;
						SoundEngine.PlaySound(SoundID.MenuTick);
					}
				}

				Main.hoverItemName = "Previous row";
				Main.LocalPlayer.mouseInterface = true;
			}
			else if (downButton.Contains(Main.MouseScreen))
			{
				if (Main.mouseLeft && Main.mouseLeftRelease)
				{
					if (npcShopRowIndex < maxRowIndex)
					{
						npcShopRowIndex++;
						SoundEngine.PlaySound(SoundID.MenuTick);
					}
				}

				Main.hoverItemName = "Next row";
				Main.LocalPlayer.mouseInterface = true;
			}

			for (int column = 0; column < 10; column++)
			{
				for (int row = npcShopRowIndex; row < npcShopRowIndex + 4; row++)
				{
					int x = (int)(73f + column * 56 * inventoryScale);
					int y = (int)(invBottom + (row - npcShopRowIndex) * 56 * inventoryScale);
					int slotIndex = column + row * 10;

					if (mouseX >= x && mouseX <= x + slotSize.X && mouseY >= y && mouseY <= y + slotSize.Y && !PlayerInput.IgnoreMouseInterface)
					{
						ItemSlot.OverrideHover(ref inv[slotIndex], 15);
						Main.LocalPlayer.mouseInterface = true;
						ItemSlot.LeftClick(ref inv[slotIndex], 15);
						ItemSlot.RightClick(ref inv[slotIndex], 15);
						ItemSlot.MouseHover(ref inv[slotIndex], 15);
					}

					ItemSlot.Draw(spriteBatch, ref inv[slotIndex], 15, new Vector2(x, y));
				}
			}
		}
	}
}