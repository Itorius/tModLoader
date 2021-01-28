using System.Collections.Generic;
using Terraria.Localization;

namespace Terraria.ModLoader
{
	public partial class NPCShop
	{
		internal readonly Dictionary<string, Page> pages = new Dictionary<string, Page>();
		public readonly Page DefaultPage;

		public NPCShop()
		{
			DefaultPage = new Page(NetworkText.FromLiteral("Default"));
			pages.Add("Default", DefaultPage);
		}

		public Page AddPage(string key, NetworkText name)
		{
			Page page = new Page(name);
			pages.Add(key, page);
			return page;
		}

		public Page GetPage(string key) => pages.ContainsKey(key) ? pages[key] : null;

		public Entry CreateEntry(int type)
		{
			Item item = new Item(type) { isAShopItem = true };
			Entry entry = new Entry(item);
			DefaultPage.entries.Add(entry);
			return entry;
		}
		
		public Entry CreateEntry<T>() where T: ModItem => CreateEntry(ModContent.ItemType<T>());
	}
}