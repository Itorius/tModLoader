using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.ModLoader
{
	public partial class NPCShop
	{
		public class Tab
		{
			public string Name { get; internal set; }
			
			public readonly NetworkText DisplayName;
			public readonly List<Entry> Entries = new List<Entry>();

			public Tab(NetworkText displayName)
			{
				DisplayName = displayName;
				
				// DisplayName = Mod.GetOrCreateTranslation($"Mods.{Mod.Name}.ItemName.{Name}");
			}

			public EntryItem AddEntry(int type)
			{
				Item item = new Item(type) { isAShopItem = true };
				EntryItem entry = new EntryItem(item);
				Entries.Add(entry);
				return entry;
			}

			public EntryItem AddEntry<T>() where T : ModItem => AddEntry(ModContent.ItemType<T>());
			
			public T AddEntry<T>(T entry) where T : Entry
			{
				Entries.Add(entry);
				return entry;
			}
		}
	}
}