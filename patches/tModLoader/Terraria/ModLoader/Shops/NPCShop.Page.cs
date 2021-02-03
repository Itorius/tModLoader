using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.ModLoader
{
	public partial class NPCShop
	{
		public class Tab
		{
			public readonly NetworkText DisplayName;
			public readonly List<Entry> entries = new List<Entry>();

			public Tab(NetworkText displayName)
			{
				DisplayName = displayName;
			}

			public EntryItem AddEntry(int type)
			{
				Item item = new Item(type) { isAShopItem = true };
				EntryItem entry = new EntryItem(item);
				entries.Add(entry);
				return entry;
			}

			public EntryItem AddEntry<T>() where T : ModItem => AddEntry(ModContent.ItemType<T>());
			
			public T AddEntry<T>(T entry) where T : Entry
			{
				entries.Add(entry);
				return entry;
			}
		}
	}
}