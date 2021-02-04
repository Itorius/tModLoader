using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Terraria.ID;
using Terraria.Localization;

namespace Terraria.ModLoader
{
	public static class ItemShopSellbackHelper
	{
		private class ItemMemo
		{
			public readonly int itemNetID;
			public readonly int itemPrefix;
			public int stack;

			public ItemMemo(Item item) {
				itemNetID = item.netID;
				itemPrefix = item.prefix;
				stack = item.stack;
			}

			public bool Matches(Item item) {
				if (item.netID == itemNetID)
					return item.prefix == itemPrefix;

				return false;
			}
		}

		private static List<ItemMemo> _memos = new List<ItemMemo>();

		public static void Add(Item item) {
			ItemMemo itemMemo = _memos.Find(x => x.Matches(item));
			if (itemMemo != null)
				itemMemo.stack += item.stack;
			else
				_memos.Add(new ItemMemo(item));
		}

		public static void Clear() {
			_memos.Clear();
		}

		public static int GetAmount(Item item) => _memos.Find(x => x.Matches(item))?.stack ?? 0;

		public static int Remove(Item item) {
			ItemMemo itemMemo = _memos.Find(x => x.Matches(item));
			if (itemMemo == null)
				return 0;

			int stack = itemMemo.stack;
			itemMemo.stack -= item.stack;
			if (itemMemo.stack <= 0)
			{
				_memos.Remove(itemMemo);
				return stack;
			}

			return stack - itemMemo.stack;
		}
	}

	public class CacheList : IEnumerable<Item>
	{
		private Item[] data;
		public int Count { get; private set; }
		public int Capacity { get; private set; }

		public CacheList(int size = 40) {
			Capacity = size;

			data = new Item[size];
			for (int i = 0; i < size; i++)
			{
				data[i] = new Item();
			}
		}

		public void Clear() {
			data = new Item[40];
			Count = 0;
			Capacity = 40;

			for (int i = 0; i < 40; i++)
			{
				data[i] = new Item();
			}
		}

		public int Add(Item item) {
			Count++;

			int nextEmpty = -1;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].IsAir)
				{
					nextEmpty = i;
					break;
				}
			}

			if (nextEmpty == -1)
			{
				Capacity += 10;
				nextEmpty = data.Length;

				Array.Resize(ref data, data.Length + 10);

				for (int i = data.Length - 10; i < data.Length; i++)
					data[i] = new Item();
			}

			data[nextEmpty] = item;
			return nextEmpty;
		}

		public void Remove(int index) {
			data[index] = new Item();
			Count--;
		}
		
		public void RemoveEmptyRows() {
			for (int i = data.Length / 10 - 1; i >= 0; i--)
			{
				for (int j = i * 10; j < i * 10 + 10; j++)
				{
					if (!data[j].IsAir) return;
				}
				
				Array.Resize(ref data, data.Length - 10);
				Capacity -= 10;
			}
		}

		public IEnumerator<Item> GetEnumerator() => (IEnumerator<Item>)data.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public Item this[int index] {
			get => data[index];
			set => data[index] = value;
		}

		public void AddRange(IEnumerable<Item> items) {
			foreach (Item item in items)
			{
				Add(item);
			}
		}
	}

	public static class NPCShopManager
	{
		internal static List<NPCShop> shops = new List<NPCShop>();

		internal static Dictionary<int, Dictionary<string, CacheList>> entryCache = new Dictionary<int, Dictionary<string, CacheList>>();

		internal static int NextTypeID;

		public static NPCShop CurrentShop => Main.npcShop > 0 ? GetShop(ShopIDToNPCID(Main.npcShop)) : null;

		public static NPCShop GetShop(int type) => shops[type];

		internal static void RegisterShop(NPCShop shop) {
			shop.Type = NextTypeID++;
			shops.Add(shop);

			entryCache.Add(shop.Type, new Dictionary<string, CacheList>());
		}

		public static NPCShop GetShop<T>() where T : NPCShop => GetShop(ShopType<T>());

		public static int ShopType<T>() where T : NPCShop => ModContent.GetInstance<T>()?.Type ?? -1;

		internal static int ShopIDToNPCID(int type) {
			type = type switch
			{
				1 => NPCID.Merchant,
				2 => NPCID.ArmsDealer,
				3 => NPCID.Dryad,
				4 => NPCID.Demolitionist,
				5 => NPCID.Clothier,
				6 => NPCID.GoblinTinkerer,
				7 => NPCID.Wizard,
				8 => NPCID.Mechanic,
				9 => NPCID.SantaClaus,
				10 => NPCID.Truffle,
				11 => NPCID.Steampunker,
				12 => NPCID.DyeTrader,
				13 => NPCID.PartyGirl,
				14 => NPCID.Cyborg,
				15 => NPCID.Painter,
				16 => NPCID.WitchDoctor,
				17 => NPCID.Pirate,
				18 => NPCID.Stylist,
				19 => NPCID.TravellingMerchant,
				20 => NPCID.SkeletonMerchant,
				21 => NPCID.DD2Bartender,
				22 => NPCID.Golfer,
				23 => NPCID.BestiaryGirl,
				24 => NPCID.Princess,
				_ => type
			};

			return shops.First(x => x.NPCType == type).Type;
		}

		internal static void Initialize() {
			// note: allow modded NPC to sell pylons?
			foreach (NPCShop shop in shops)
			{
				if (shop.Type > 23) continue;

				if (shop is TravellingMerchantShop || shop is SkeletonMerchantShop || Main.LocalPlayer.currentShoppingSettings.PriceAdjustment > 0.8500000238418579) continue;
				if (Main.LocalPlayer.ZoneCrimson || Main.LocalPlayer.ZoneCorrupt) continue;

				shop.CreateEntry(4876).AddCondition(
					!NPCShop.Entry.Condition.InSnow, !NPCShop.Entry.Condition.InDesert, !NPCShop.Entry.Condition.InBeach, !NPCShop.Entry.Condition.InJungle, !NPCShop.Entry.Condition.Halloween, !NPCShop.Entry.Condition.InGlowshroom,
					new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.PlayerPosY"), () => Main.LocalPlayer.position.Y < Main.worldSurface * 16.0));

				shop.CreateEntry(4920).AddCondition(NPCShop.Entry.Condition.InSnow);

				shop.CreateEntry(4919).AddCondition(NPCShop.Entry.Condition.InDesert);

				shop.CreateEntry(4917)
					.AddCondition(
						!NPCShop.Entry.Condition.InSnow, !NPCShop.Entry.Condition.InDesert, !NPCShop.Entry.Condition.InBeach, !NPCShop.Entry.Condition.InJungle, !NPCShop.Entry.Condition.Halloween, !NPCShop.Entry.Condition.InGlowshroom,
						new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.PlayerPosY"), () => Main.LocalPlayer.position.Y >= Main.worldSurface * 16.0));

				shop.CreateEntry(4918).AddCondition(NPCShop.Entry.Condition.InBeach, new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.PlayerPosY"), () => Main.LocalPlayer.position.Y < Main.worldSurface * 16.0));

				shop.CreateEntry(4875).AddCondition(NPCShop.Entry.Condition.InJungle);

				shop.CreateEntry(4916).AddCondition(NPCShop.Entry.Condition.InHallow);

				shop.CreateEntry(4921).AddCondition(NPCShop.Entry.Condition.InGlowshroom);
			}

			// foreach (KeyValuePair<int,NPCShop> pair in shops)
			// {
			// 	Logging.tML.Debug(Lang.GetNPCNameValue(pair.Key));
			// 	
			// 	foreach (NPCShop.Entry entry in pair.Value.pages.SelectMany(x=>x.Value.entries))
			// 	{
			// 		Logging.tML.Debug("\t"+entry.GetItems(false).Select(x=>x.HoverName).Aggregate((x,y)=>x + ", "+y));
			//
			// 		foreach (NPCShop.Entry.Condition condition in entry.Conditions)
			// 		{
			// 			Logging.tML.Debug("\t\t" + condition.Description);
			// 		}
			// 	}
			// }
		}

		public static void Unload() {
			shops.Clear();
			entryCache.Clear();
		}
	}
}