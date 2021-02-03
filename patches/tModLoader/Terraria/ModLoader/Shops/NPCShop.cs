﻿using System;
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
	// todo: allow custom slot indexes
	public abstract partial class NPCShop : ModType
	{
		public abstract int NPCType { get; }

		public int Type { get; internal set; }

		public virtual bool EvaluateOnOpen => true;

		protected sealed override void Register() {
			ModTypeLookup<NPCShop>.Register(this);

			NPCShopManager.RegisterShop(this);
		}

		internal readonly Dictionary<string, Tab> tabs = new Dictionary<string, Tab>();
		public Tab DefaultTab { get; private set; }

		public sealed override void SetupContent() {
			DefaultTab = AddPage("Default", NetworkText.FromKey("ShopTab.Default"));

			SetDefaults();
		}

		public virtual void SetDefaults() {
		}

		public Tab AddPage(string key, NetworkText name) {
			Tab tab = new Tab(name) { Name = key };
			tabs.Add(key, tab);

			NPCShopManager.entryCache[Type].Add(key, new List<Item>());

			return tab;
		}

		public Tab GetTab(string key) => tabs.ContainsKey(key) ? tabs[key] : null;

		public EntryItem CreateEntry(int type) => DefaultTab.AddEntry(type);

		public EntryItem CreateEntry<T>() where T : ModItem => CreateEntry(ModContent.ItemType<T>());

		public int SellItem(Item newItem) {
			int num = ItemShopSellbackHelper.Remove(newItem);

			if (num >= newItem.stack)
				return 0;

			Item clone = newItem.Clone();
			clone.favorited = false;
			clone.buyOnce = true;

			int rows = Math.Max(4, (int)Math.Ceiling(NPCShopManager.entryCache[Type][currentTab.Name].Count / 10f));
			int maxRowIndex = rows - 4;

			int index = NPCShopManager.entryCache[Type][currentTab.Name].FindIndex(x => x.IsAir);
			if (index != -1)
			{
				NPCShopManager.entryCache[Type][currentTab.Name][index] = clone;
				npcShopRowIndex = Math.Min(maxRowIndex, index / 10);

				return index;
			}

			NPCShopManager.entryCache[Type][currentTab.Name].Add(clone);
			index = NPCShopManager.entryCache[Type][currentTab.Name].Count - 1;

			npcShopRowIndex = maxRowIndex;
			if (index % 10 == 0) npcShopRowIndex++;

			return index;
		}

		public T AddEntry<T>(T entry) where T : Entry {
			DefaultTab.AddEntry(entry);
			return entry;
		}

		public void Evaluate() {
			var cache = NPCShopManager.entryCache[Type];

			foreach (var pair in tabs)
			{
				cache[pair.Key].Clear();

				foreach (Entry entry in pair.Value.Entries)
				{
					cache[pair.Key].AddRange(entry.GetItems());
				}
			}
		}

		private static int npcShopRowIndex;
		internal static Tab currentTab;

		public virtual Rectangle GetDimensions() {
			return new Rectangle(73, Main.instance.invBottom, (int)(560 * 0.755f), (int)(224 * 0.755f));
		}

		public virtual void OnScroll(int delta) {
			var inv = NPCShopManager.entryCache[Type][currentTab.Name];
			int rows = Math.Max(4, (int)Math.Ceiling(inv.Count / 10f));
			int maxRowIndex = rows - 4;
			
			npcShopRowIndex = Utils.Clamp(npcShopRowIndex + delta, 0, maxRowIndex);

			if (!PlayerInput.IgnoreMouseInterface)
			{
				Main.LocalPlayer.mouseInterface = true;
			}
		}
		
		public virtual void Open() {
			npcShopRowIndex = 0;
			currentTab = DefaultTab;

			if (EvaluateOnOpen) Evaluate();
		}

		public virtual void Draw(SpriteBatch spriteBatch) {
			ref float inventoryScale = ref Main.inventoryScale;
			inventoryScale = 0.755f;

			float mouseX = Main.mouseX;
			float mouseY = Main.mouseY;
			Vector2 slotSize = TextureAssets.InventoryBack.Size() * inventoryScale;
			int invBottom = Main.instance.invBottom;
			var inv = NPCShopManager.entryCache[Type][currentTab.Name];
			int rows = Math.Max(4, (int)Math.Ceiling(inv.Count / 10f));

			Rectangle shopRect = new Rectangle(73, invBottom, (int)(560 * inventoryScale), (int)(224 * inventoryScale));

			Utils.DrawBorderStringFourWay(spriteBatch, FontAssets.MouseText.Value, Language.GetText("LegacyInterface.28").Value, 504f, invBottom, Color.White * (Main.mouseTextColor / 255f), Color.Black, Vector2.Zero);
			ItemSlot.DrawSavings(spriteBatch, 504f, invBottom);

			// todo: add tab selection
			if (tabs.Count > 1)
				ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.MouseText.Value, "Tab: " + currentTab.DisplayName, new Vector2(73f, 426f), Color.White, 0f, Vector2.Zero, Vector2.One);

			// todo: better scrollbar visuals
			spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(shopRect.Right, invBottom, 4, shopRect.Height), new Color(79, 91, 39));
			spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(shopRect.Right, (int)(invBottom + npcShopRowIndex * (shopRect.Height / (float)rows)), 4, (int)(shopRect.Height * (4f / rows))), new Color(110, 128, 54));

			for (int column = 0; column < 10; column++)
			{
				for (int row = npcShopRowIndex; row < npcShopRowIndex + 4; row++)
				{
					int x = (int)(73f + column * 56 * inventoryScale);
					int y = (int)(invBottom + (row - npcShopRowIndex) * 56 * inventoryScale);
					int slotIndex = column + row * 10;

					Item item = slotIndex < inv.Count ? inv[slotIndex] : new Item();

					if (mouseX >= x && mouseX <= x + slotSize.X && mouseY >= y && mouseY <= y + slotSize.Y && !PlayerInput.IgnoreMouseInterface)
					{
						ItemSlot.OverrideHover(ref item, 15);
						Main.LocalPlayer.mouseInterface = true;
						ItemSlot.LeftClick(ref item, 15);
						ItemSlot.RightClick(ref item, 15);
						ItemSlot.MouseHover(ref item, 15);
					}

					ItemSlot.Draw(spriteBatch, ref item, 15, new Vector2(x, y));

					// todo: fix this
					// inv[slotIndex] = item;
				}
			}
		}
	}
}