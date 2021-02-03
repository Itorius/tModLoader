using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.ModLoader
{
	// todo: allow custom slot indexes, custom shops
	public partial class NPCShop
	{
		public int Type { get; internal set; }

		internal readonly Dictionary<string, Tab> tabs = new Dictionary<string, Tab>();
		public readonly Tab DefaultTab;

		public bool EvaluateOnOpen = true;

		internal NPCShop() {
			DefaultTab = new Tab(NetworkText.FromLiteral("Default"));
			tabs.Add("Default", DefaultTab);
		}

		public Tab AddPage(string key, NetworkText name) {
			Tab tab = new Tab(name);
			tabs.Add(key, tab);
			return tab;
		}

		public Tab GetPage(string key) => tabs.ContainsKey(key) ? tabs[key] : null;

		public EntryItem CreateEntry(int type) => DefaultTab.AddEntry(type);

		public EntryItem CreateEntry<T>() where T : ModItem => CreateEntry(ModContent.ItemType<T>());

		public T AddEntry<T>(T entry) where T : Entry {
			DefaultTab.AddEntry(entry);
			return entry;
		}

		public virtual void Evaluate() {
			// this sucks
			
			List<Item> l = new List<Item>();
			foreach (Entry entry in DefaultTab.entries) l.AddRange(entry.GetItems());

			int size = Math.Max(40, (l.Count / 10 + 1) * 10);
			NPCShopManager.entryCache[Type] = new Item[size];
			for (int i = 0; i < size; i++)
			{
				if (i < l.Count) NPCShopManager.entryCache[Type][i] = l[i];
				else NPCShopManager.entryCache[Type][i] = new Item();
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
			inventoryScale = 0.755f;

			float mouseX = Main.mouseX;
			float mouseY = Main.mouseY;
			Vector2 slotSize = TextureAssets.InventoryBack.Size() * inventoryScale;
			int invBottom = Main.instance.invBottom;
			var inv = NPCShopManager.entryCache[Type];
			int rows = (int)Math.Ceiling(inv.Length / 10f);
			int maxRowIndex = rows - 4;

			Rectangle shopRect = new Rectangle(73, invBottom, (int)(560 * inventoryScale), (int)(224 * inventoryScale));

			Utils.DrawBorderStringFourWay(spriteBatch, FontAssets.MouseText.Value, Language.GetText("LegacyInterface.28").Value, 504f, invBottom, Color.White * (Main.mouseTextColor / 255f), Color.Black, Vector2.Zero);
			ItemSlot.DrawSavings(spriteBatch, 504f, invBottom);

			// bug: also scrolls recipes
			if (shopRect.Contains(Main.MouseScreen))
			{
				int delta = -Player.GetMouseScrollDelta();
				npcShopRowIndex = Utils.Clamp(npcShopRowIndex + delta, 0, maxRowIndex);

				if (!PlayerInput.IgnoreMouseInterface)
				{
					Main.LocalPlayer.mouseInterface = true;
				}
			}

			ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, "Tab: " + tabs[currentPage].DisplayName, new Vector2(73f, 426f), Color.White, 0f, Vector2.Zero, Vector2.One);

			spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(shopRect.Right, invBottom, 4, shopRect.Height), new Color(79, 91, 39));
			spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(shopRect.Right, (int)(invBottom + npcShopRowIndex * (shopRect.Height / (float)rows)), 4, (int)(shopRect.Height * (4f / rows))), new Color(110, 128, 54));

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