using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.ModLoader
{
	public partial class NPCShop
	{
		public class Page
		{
			public readonly NetworkText DisplayName;
			public readonly List<Entry> entries = new List<Entry>();

			public Page(NetworkText displayName)
			{
				DisplayName = displayName;
			}

			public Entry CreateEntry(int type)
			{
				Item item = new Item(type) { isAShopItem = true };
				Entry entry = new Entry(item);
				entries.Add(entry);
				return entry;
			}
		}
	}
}