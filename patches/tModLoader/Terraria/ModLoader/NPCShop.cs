using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;
using Entry = Terraria.ModLoader.NPCShop.Entry;

namespace Terraria.ModLoader
{
	// todo: allow custom slot indexes, custom shops

	

	public partial class NPCShop
	{
		internal readonly Dictionary<string, Page> pages = new Dictionary<string, Page>();
		public readonly Page DefaultPage;
		private int type;

		public bool EvaluateOnOpen = true;

		internal NPCShop(int type)
		{
			this.type = type;
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

		public EntryItem AddEntry(int type) => DefaultPage.AddEntry(type);

		public EntryItem AddEntry<T>() where T : ModItem => AddEntry(ModContent.ItemType<T>());

		public T AddEntry<T>(T entry) where T : Entry
		{
			DefaultPage.AddEntry(entry);
			return entry;
		}

		internal void Evaluate()
		{
			NPCShopManager.entryCache[type].Clear();

			foreach (Entry entry in DefaultPage.entries)
			{
				NPCShopManager.entryCache[type].AddRange(entry.GetItems());
			}
		}
	}
}