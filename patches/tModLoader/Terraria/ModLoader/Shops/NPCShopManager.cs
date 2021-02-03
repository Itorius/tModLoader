using System.Collections.Generic;
using Terraria.ID;

namespace Terraria.ModLoader
{
	public static partial class NPCShopManager
	{
		internal static Dictionary<int, NPCShop> shops = new Dictionary<int, NPCShop>();
		internal static Dictionary<int, Item[]> entryCache = new Dictionary<int, Item[]>();

		public static NPCShop GetShop(int type) => shops.ContainsKey(type) ? shops[type] : null;

		public static NPCShop GetShop<T>() where T : ModNPC => GetShop(ModContent.NPCType<T>());

		public static NPCShop RegisterShop(int npcType) {
			NPCShop shop = new NPCShop { Type = npcType };

			shops.Add(npcType, shop);
			entryCache.Add(npcType, new Item[0]);

			return shop;
		}

		internal static int ShopIDToNPCID(int type) {
			switch (type)
			{
				case 1: return NPCID.Merchant;
				case 2: return NPCID.ArmsDealer;
				case 3: return NPCID.Dryad;
				case 4: return NPCID.Demolitionist;
				case 5: return NPCID.Clothier;
				case 6: return NPCID.GoblinTinkerer;
				case 7: return NPCID.Wizard;
				case 8: return NPCID.Mechanic;
				case 9: return NPCID.SantaClaus;
				case 10: return NPCID.Truffle;
				case 11: return NPCID.Steampunker;
				case 12: return NPCID.DyeTrader;
				case 13: return NPCID.PartyGirl;
				case 14: return NPCID.Cyborg;
				case 15: return NPCID.Painter;
				case 16: return NPCID.WitchDoctor;
				case 17: return NPCID.Pirate;
				case 18: return NPCID.Stylist;
				case 19: return NPCID.TravellingMerchant;
				case 20: return NPCID.SkeletonMerchant;
				case 21: return NPCID.DD2Bartender;
				case 22: return NPCID.Golfer;
				case 23: return NPCID.BestiaryGirl;
				case 24: return NPCID.Princess;
				default: return type;
			}
		}

		internal static void Initialize() {
			SetupShop_Merchant();
			SetupShop_ArmsDealer();
			SetupShop_Dryad();
			SetupShop_Demolitionist();
			SetupShop_Clothier();
			SetupShop_GoblinTinkerer();
			SetupShop_Wizard();
			SetupShop_Mechanic();
			SetupShop_SantaClaus();
			SetupShop_Truffle();
			SetupShop_Steampunker();
			SetupShop_DyeTrader();
			SetupShop_PartyGirl();
			SetupShop_Cyborg();
			SetupShop_Painer();
			SetupShop_WitchDoctor();
			SetupShop_Pirate();
			SetupShop_Stylist();
			SetupShop_TravellingMerchant();
			SetupShop_SkeletonMerchant();
			SetupShop_Bartender();
			SetupShop_Golfer();
			SetupShop_Zoologist();
			SetupShop_Princess();
			SetupShop_Pylons();

			NPCShop shop = GetShop(NPCID.Merchant);

			for (int i = 0; i < 50; i++)
			{
				shop.CreateEntry(ItemID.DirtBlock);
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