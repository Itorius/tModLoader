using System.Collections.Generic;
using Terraria.Enums;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Container;

namespace Terraria.ModLoader
{
	public static class NPCShopManager
	{
		internal static Dictionary<int, NPCShop> shops = new Dictionary<int, NPCShop>();

		public static NPCShop GetShop(int type) => shops.ContainsKey(type) ? shops[type] : null;

		public static NPCShop GetShop<T>() where T : ModNPC
		{
			int type = ModContent.NPCType<T>();
			return shops.ContainsKey(type) ? shops[type] : null;
		}

		internal static int ShopIDToNPCID(int type)
		{
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

		internal static void Initialize()
		{
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

			NPCShop travellingMerchant = new NPCShop();
			shops.Add(NPCID.TravellingMerchant, travellingMerchant);
			// todo: travelling merchant poop

			SetupShop_SkeletonMerchant();
			SetupShop_Bartender();
			SetupShop_Golfer();
			SetupShop_Zoologist();
			SetupShop_Princess();

			// 	case 19:
			// 	{
			// 		for (int n = 0; n < 40; n++)
			// 		{
			// 			if (Main.travelShop[n] != 0)
			// 			{
			// 				array[num].netDefaults(Main.travelShop[n]);
			// 				
			// 			}
			// 		}
			//
			// 		break;
			// 	}

			// pylons
// 			if (type != 19 && type != 20 && flag && !Main.player[Main.myPlayer].ZoneCorrupt && !Main.player[Main.myPlayer].ZoneCrimson) {
// 				if (!Main.player[Main.myPlayer].ZoneSnow && !Main.player[Main.myPlayer].ZoneDesert && !Main.player[Main.myPlayer].ZoneBeach && !Main.player[Main.myPlayer].ZoneJungle && !Main.player[Main.myPlayer].ZoneHallow && !Main.player[Main.myPlayer].ZoneGlowshroom && (double)(Main.player[Main.myPlayer].Center.Y / 16f) < Main.worldSurface && num < 39)
// 					array[num++].SetDefaults(4876);
//
// 				if (Main.player[Main.myPlayer].ZoneSnow && num < 39)
// 					array[num++].SetDefaults(4920);
//
// 				if (Main.player[Main.myPlayer].ZoneDesert && num < 39)
// 					array[num++].SetDefaults(4919);
//
// 				if (!Main.player[Main.myPlayer].ZoneSnow && !Main.player[Main.myPlayer].ZoneDesert && !Main.player[Main.myPlayer].ZoneBeach && !Main.player[Main.myPlayer].ZoneJungle && !Main.player[Main.myPlayer].ZoneHallow && !Main.player[Main.myPlayer].ZoneGlowshroom && (double)(Main.player[Main.myPlayer].Center.Y / 16f) >= Main.worldSurface && num < 39)
// 					array[num++].SetDefaults(4917);
//
// 				if (Main.player[Main.myPlayer].ZoneBeach && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16.0 && num < 39)
// 					array[num++].SetDefaults(4918);
// i
// 				if (Main.player[Main.myPlayer].ZoneJungle && num < 39)
// 					array[num++].SetDefaults(4875);
//
// 				if (Main.player[Main.myPlayer].ZoneHallow && num < 39)
// 					array[num++].SetDefaults(4916);
//
// 				if (Main.player[Main.myPlayer].ZoneGlowshroom && num < 39)
// 					array[num++].SetDefaults(4921);
// 			}
		}

		private static void SetupShop_Zoologist()
		{
			NPCShop zoologist = new NPCShop();
			shops.Add(NPCID.BestiaryGirl, zoologist);

			BestiaryUnlockProgressReport bestiaryProgressReport = Main.GetBestiaryProgressReport();

			zoologist.CreateEntry(4776).AddCondition(NetworkText.FromLiteral("FairyTorch"), _ =>
			{
				static bool DidDiscoverBestiaryEntry(int npcId) => Main.BestiaryDB.FindEntryByNPCID(npcId).UIInfoProvider.GetEntryUICollectionInfo().UnlockState > BestiaryEntryUnlockState.NotKnownAtAll_0;

				return DidDiscoverBestiaryEntry(585) && DidDiscoverBestiaryEntry(584) && DidDiscoverBestiaryEntry(583);
			});

			zoologist.CreateEntry(4767);
			zoologist.CreateEntry(4759);

			static NPCShop.Entry.Condition Completion(float value) => new NPCShop.Entry.Condition(NetworkText.FromLiteral("BestiaryCompletion"), _ => Main.GetBestiaryProgressReport().CompletionPercent >= value);

			zoologist.CreateEntry(4672).AddCondition(Completion(0.1f));
			zoologist.CreateEntry(4829).AddCondition(NetworkText.FromLiteral("Cat"), _ => !NPC.boughtCat);
			zoologist.CreateEntry(4830).AddCondition(new NPCShop.Entry.Condition(NetworkText.FromLiteral("Dog"), _ => !NPC.boughtDog), Completion(0.25f));
			zoologist.CreateEntry(4910).AddCondition(new NPCShop.Entry.Condition(NetworkText.FromLiteral("Bunny"), _ => !NPC.boughtBunny), Completion(0.45f));

			zoologist.CreateEntry(4871).AddCondition(Completion(0.3f));
			zoologist.CreateEntry(4907).AddCondition(Completion(0.4f));

			zoologist.CreateEntry(4677).AddCondition(NPCShop.Entry.Condition.DownedSolarTower);

			zoologist.CreateEntry(4676).AddCondition(Completion(0.1f));
			zoologist.CreateEntry(4762).AddCondition(Completion(0.3f));
			zoologist.CreateEntry(4716).AddCondition(Completion(0.25f));
			zoologist.CreateEntry(4785).AddCondition(Completion(0.3f));
			zoologist.CreateEntry(4786).AddCondition(Completion(0.3f));
			zoologist.CreateEntry(4787).AddCondition(Completion(0.3f));
			zoologist.CreateEntry(4788).AddCondition(Completion(0.3f), NPCShop.Entry.Condition.Hardmode);
			zoologist.CreateEntry(4955).AddCondition(Completion(0.4f));

			zoologist.CreateEntry(4736).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.BloodMoon);
			zoologist.CreateEntry(4701).AddCondition(NPCShop.Entry.Condition.DownedPlantera);

			zoologist.CreateEntry(4765).AddCondition(Completion(0.5f));
			zoologist.CreateEntry(4766).AddCondition(Completion(0.5f));
			zoologist.CreateEntry(4777).AddCondition(Completion(0.5f));
			zoologist.CreateEntry(4763).AddCondition(Completion(0.6f));
			zoologist.CreateEntry(4735).AddCondition(Completion(0.7f));
			zoologist.CreateEntry(4751).AddCondition(Completion(1f));

			zoologist.CreateEntry(4768).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			zoologist.CreateEntry(4769).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);

			zoologist.CreateEntry(4770).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			zoologist.CreateEntry(4771).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);

			zoologist.CreateEntry(4772).AddCondition(NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			zoologist.CreateEntry(4773).AddCondition(NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);

			zoologist.CreateEntry(4560).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			zoologist.CreateEntry(4775).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_Golfer()
		{
			NPCShop golfer = new NPCShop();
			shops.Add(NPCID.Golfer, golfer);

			golfer.CreateEntry(4587);
			golfer.CreateEntry(4590);
			golfer.CreateEntry(4589);
			golfer.CreateEntry(4588);
			golfer.CreateEntry(4083);
			golfer.CreateEntry(4084);
			golfer.CreateEntry(4085);
			golfer.CreateEntry(4086);
			golfer.CreateEntry(4087);
			golfer.CreateEntry(4088);

			static NPCShop.Entry.Condition GolfScore(int count) => new NPCShop.Entry.Condition(NetworkText.FromKey("ShopConditions.GolfScore"), _ => Main.LocalPlayer.golferScoreAccumulated > count);

			golfer.CreateEntry(4039).AddCondition(GolfScore(500));
			golfer.CreateEntry(4094).AddCondition(GolfScore(500));
			golfer.CreateEntry(4093).AddCondition(GolfScore(500));
			golfer.CreateEntry(1092).AddCondition(GolfScore(500));

			golfer.CreateEntry(4089);
			golfer.CreateEntry(3979);
			golfer.CreateEntry(4095);
			golfer.CreateEntry(4040);
			golfer.CreateEntry(4319);
			golfer.CreateEntry(4320);

			golfer.CreateEntry(4591).AddCondition(GolfScore(1000));
			golfer.CreateEntry(4594).AddCondition(GolfScore(1000));
			golfer.CreateEntry(4593).AddCondition(GolfScore(1000));
			golfer.CreateEntry(4592).AddCondition(GolfScore(1000));

			golfer.CreateEntry(4135);
			golfer.CreateEntry(4138);
			golfer.CreateEntry(4136);
			golfer.CreateEntry(4137);
			golfer.CreateEntry(4049);

			golfer.CreateEntry(4265).AddCondition(GolfScore(500));

			golfer.CreateEntry(4595).AddCondition(GolfScore(2000));
			golfer.CreateEntry(4598).AddCondition(GolfScore(2000));
			golfer.CreateEntry(4597).AddCondition(GolfScore(2000));
			golfer.CreateEntry(4596).AddCondition(GolfScore(2000));
			golfer.CreateEntry(4264).AddCondition(GolfScore(2000), NPCShop.Entry.Condition.DownedSkeletron);

			golfer.CreateEntry(4599).AddCondition(GolfScore(500));
			golfer.CreateEntry(4600).AddCondition(GolfScore(999));
			golfer.CreateEntry(4601).AddCondition(GolfScore(1999));

			golfer.CreateEntry(4658).AddCondition(GolfScore(1999), NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			golfer.CreateEntry(4659).AddCondition(GolfScore(1999), NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			golfer.CreateEntry(4660).AddCondition(GolfScore(1999), NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			golfer.CreateEntry(4661).AddCondition(GolfScore(1999), NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_Princess()
		{
			NPCShop princess = new NPCShop();
			shops.Add(NPCID.Princess, princess);

			princess.CreateEntry(5071);
			princess.CreateEntry(5072);
			princess.CreateEntry(5073);
			princess.CreateEntry(5076);
			princess.CreateEntry(5077);
			princess.CreateEntry(5078);
			princess.CreateEntry(5079);
			princess.CreateEntry(5080);
			princess.CreateEntry(5081);
			princess.CreateEntry(5082);
			princess.CreateEntry(5083);
			princess.CreateEntry(5084);
			princess.CreateEntry(5085);
			princess.CreateEntry(5086);
			princess.CreateEntry(5087);
			princess.CreateEntry(5044).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMoonLord);
		}

		private static void SetupShop_Bartender()
		{
			NPCShop bartender = new NPCShop();
			shops.Add(NPCID.DD2Bartender, bartender);
			NPCShop.Entry.Condition condition1 = NPCShop.Entry.Condition.Hardmode & NPCShop.Entry.Condition.DownedAnyMechBoss;
			NPCShop.Entry.Condition condition2 = NPCShop.Entry.Condition.Hardmode & NPCShop.Entry.Condition.DownedGolem;

			bartender.CreateEntry(353);

			// 		bool flag2 = Main.hardMode && NPC.downedMechBossAny;
			// 		bool num7 = Main.hardMode && NPC.downedGolemBoss;
			// 		array[num].SetDefaults(353);
			// 		
			// 		array[num].SetDefaults(3828);
			// 		if (num7)
			// 			array[num].shopCustomPrice = Item.buyPrice(0, 4);
			// 		else if (flag2)
			// 			array[num].shopCustomPrice = Item.buyPrice(0, 1);
			// 		else
			// 			array[num].shopCustomPrice = Item.buyPrice(0, 0, 25);
			bartender.CreateEntry(3828).SetPrice();

			bartender.CreateEntry(3816);

			bartender.CreateEntry(3813).SetPrice(CustomCurrencyID.DefenderMedals, 75);
			bartender.CreateEntry(3818).SetPrice(CustomCurrencyID.DefenderMedals, 5);
			bartender.CreateEntry(3824).SetPrice(CustomCurrencyID.DefenderMedals, 5);
			bartender.CreateEntry(3832).SetPrice(CustomCurrencyID.DefenderMedals, 5);
			bartender.CreateEntry(3829).SetPrice(CustomCurrencyID.DefenderMedals, 5);

			bartender.CreateEntry(3819).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3825).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3833).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3830).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);

			bartender.CreateEntry(3820).SetPrice(CustomCurrencyID.DefenderMedals, 100).AddCondition(condition2);
			bartender.CreateEntry(3826).SetPrice(CustomCurrencyID.DefenderMedals, 100).AddCondition(condition2);
			bartender.CreateEntry(3834).SetPrice(CustomCurrencyID.DefenderMedals, 100).AddCondition(condition2);
			bartender.CreateEntry(3831).SetPrice(CustomCurrencyID.DefenderMedals, 100).AddCondition(condition2);

			bartender.CreateEntry(3800).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3801).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3802).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3797).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3798).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3799).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3803).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3804).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3805).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3806).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3807).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);
			bartender.CreateEntry(3808).SetPrice(CustomCurrencyID.DefenderMedals, 25).AddCondition(condition1);

			bartender.CreateEntry(3871).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3872).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3873).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3874).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3875).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3876).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3877).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3878).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3879).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3880).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3881).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
			bartender.CreateEntry(3882).SetPrice(CustomCurrencyID.DefenderMedals, 75).AddCondition(condition2);
		}

		private static void SetupShop_SkeletonMerchant()
		{
			NPCShop skeletonMerchant = new NPCShop();
			shops.Add(NPCID.SkeletonMerchant, skeletonMerchant);

			skeletonMerchant.CreateEntry(3001).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseHalfAtRight);
			skeletonMerchant.CreateEntry(3001).AddCondition(NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);

			skeletonMerchant.CreateEntry(3002).AddCondition(NPCShop.Entry.Condition.TimeNight | NPCShop.Entry.Condition.PhaseFull);
			skeletonMerchant.CreateEntry(282).AddCondition(!(NPCShop.Entry.Condition.TimeNight | NPCShop.Entry.Condition.PhaseFull));

			var cond = new NPCShop.Entry.Condition(NetworkText.FromLiteral("Time"), _ => Main.time % 60.0 * 60.0 * 6.0 <= 10800.0);
			skeletonMerchant.CreateEntry(3004).AddCondition(cond);
			skeletonMerchant.CreateEntry(8).AddCondition(!cond);

			cond = NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight;
			skeletonMerchant.CreateEntry(3003).AddCondition(cond);
			skeletonMerchant.CreateEntry(40).AddCondition(!cond);

			skeletonMerchant.CreateEntry(3310).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseEmpty);
			skeletonMerchant.CreateEntry(3313).AddCondition(NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			skeletonMerchant.CreateEntry(3312).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseHalfAtRight);
			skeletonMerchant.CreateEntry(3311).AddCondition(NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);

			skeletonMerchant.CreateEntry(166);
			skeletonMerchant.CreateEntry(965);

			skeletonMerchant.CreateEntry(3316).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			skeletonMerchant.CreateEntry(3315).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty, NPCShop.Entry.Condition.PhaseQuarterAtRight, NPCShop.Entry.Condition.PhaseHalfAtRight, NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			skeletonMerchant.CreateEntry(3334).AddCondition(NPCShop.Entry.Condition.Hardmode);
			skeletonMerchant.CreateEntry(3258).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.BloodMoon);
			skeletonMerchant.CreateEntry(3043).AddCondition(NPCShop.Entry.Condition.PhaseFull, NPCShop.Entry.Condition.TimeNight);
		}

		private static void SetupShop_Stylist()
		{
			NPCShop stylist = new NPCShop();
			shops.Add(NPCID.Stylist, stylist);

			stylist.CreateEntry(1990);
			stylist.CreateEntry(1979);
			stylist.CreateEntry(1977).AddCondition(NetworkText.FromLiteral("HP400"), _ => Main.LocalPlayer.statLifeMax >= 400);
			stylist.CreateEntry(1978).AddCondition(NetworkText.FromLiteral("MANA200"), _ => Main.LocalPlayer.statManaMax >= 200);
			stylist.CreateEntry(1980).AddCondition(NetworkText.FromLiteral("Money1M"), _ => Main.LocalPlayer.inventory.CountCoins() >= 1000000);

			stylist.CreateEntry(1981).AddCondition(
				(NPCShop.Entry.Condition.TimeNight & (NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight)) |
				(NPCShop.Entry.Condition.TimeDay & (NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseHalfAtRight)));
			stylist.CreateEntry(1982).AddCondition(NetworkText.FromLiteral("Team"), _ => Main.LocalPlayer.team != 0);
			stylist.CreateEntry(1983).AddCondition(NPCShop.Entry.Condition.Hardmode);
			stylist.CreateEntry(1984).AddCondition(NPCShop.Entry.Condition.NPCExists(208));
			stylist.CreateEntry(1985).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedDestroyer, NPCShop.Entry.Condition.DownedTwins, NPCShop.Entry.Condition.DownedSkeletronPrime);
			stylist.CreateEntry(1986).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedAnyMechBoss);
			stylist.CreateEntry(2863).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMartians);
			stylist.CreateEntry(3259).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMartians);
		}

		private static void SetupShop_Pirate()
		{
			NPCShop pirate = new NPCShop();
			shops.Add(NPCID.Pirate, pirate);

			pirate.CreateEntry(928);
			pirate.CreateEntry(929);
			pirate.CreateEntry(876);
			pirate.CreateEntry(877);
			pirate.CreateEntry(878);
			pirate.CreateEntry(2434);
			pirate.CreateEntry(1180).AddCondition(NPCShop.Entry.Condition.InOcean);
			pirate.CreateEntry(1337).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedAnyMechBoss, NPCShop.Entry.Condition.NPCExists(208));
		}

		private static void SetupShop_WitchDoctor()
		{
			NPCShop witchDoctor = new NPCShop();
			shops.Add(NPCID.WitchDoctor, witchDoctor);

			witchDoctor.CreateEntry(1430);
			witchDoctor.CreateEntry(986);

			witchDoctor.CreateEntry(2999).AddCondition(NPCShop.Entry.Condition.NPCExists(108));
			witchDoctor.CreateEntry(1158).AddCondition(NPCShop.Entry.Condition.TimeNight);
			witchDoctor.CreateEntry(1159).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);
			witchDoctor.CreateEntry(1160).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);
			witchDoctor.CreateEntry(1161).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);
			witchDoctor.CreateEntry(1167).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera, NPCShop.Entry.Condition.InJungle);
			witchDoctor.CreateEntry(1339).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);

			witchDoctor.CreateEntry(1171).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.InJungle);
			witchDoctor.CreateEntry(1162).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.InJungle, NPCShop.Entry.Condition.TimeNight);

			witchDoctor.CreateEntry(909);
			witchDoctor.CreateEntry(910);
			witchDoctor.CreateEntry(940);
			witchDoctor.CreateEntry(941);
			witchDoctor.CreateEntry(942);
			witchDoctor.CreateEntry(943);
			witchDoctor.CreateEntry(944);
			witchDoctor.CreateEntry(945);
			witchDoctor.CreateEntry(4922);
			witchDoctor.CreateEntry(4917);
			witchDoctor.CreateEntry(1836).AddCondition(NPCShop.Entry.Condition.HasItem(1835));
			witchDoctor.CreateEntry(1261).AddCondition(NPCShop.Entry.Condition.HasItem(1258));
			witchDoctor.CreateEntry(1791).AddCondition(NPCShop.Entry.Condition.Halloween);
		}

		private static void SetupShop_Painer()
		{
			NPCShop painter = new NPCShop();
			shops.Add(NPCID.Painter, painter);

			painter.CreateEntry(1071);
			painter.CreateEntry(1072);
			painter.CreateEntry(1073);

			for (int i = 1073; i <= 1084; i++) painter.CreateEntry(i);

			painter.CreateEntry(1097);
			painter.CreateEntry(1099);
			painter.CreateEntry(1098);
			painter.CreateEntry(1966);
			painter.CreateEntry(4668).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.CreateEntry(1967).AddCondition(NPCShop.Entry.Condition.Hardmode);
			painter.CreateEntry(1968).AddCondition(NPCShop.Entry.Condition.Hardmode);
			painter.CreateEntry(1490).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.CreateEntry(1481).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.PhaseFull, NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			painter.CreateEntry(1482).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.PhaseHalfAtLeft, NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			painter.CreateEntry(1483).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.PhaseEmpty, NPCShop.Entry.Condition.PhaseQuarterAtRight);
			painter.CreateEntry(1484).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.PhaseHalfAtRight, NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);

			painter.CreateEntry(1492).AddCondition(NPCShop.Entry.Condition.InCrimson);
			painter.CreateEntry(1488).AddCondition(NPCShop.Entry.Condition.InCorrupt);
			painter.CreateEntry(1489).AddCondition(NPCShop.Entry.Condition.InHallow);
			painter.CreateEntry(1486).AddCondition(NPCShop.Entry.Condition.InJungle);
			painter.CreateEntry(1487).AddCondition(NPCShop.Entry.Condition.InSnow);
			painter.CreateEntry(1491).AddCondition(NPCShop.Entry.Condition.InDesert);
			painter.CreateEntry(1493).AddCondition(NPCShop.Entry.Condition.BloodMoon);

			painter.CreateEntry(1485).AddCondition(!NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.InSpace, NPCShop.Entry.Condition.BloodMoon);
			painter.CreateEntry(1494).AddCondition(!NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.InSpace, NPCShop.Entry.Condition.Hardmode);

			painter.CreateEntry(4723).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.CreateEntry(4724).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.CreateEntry(4725).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.CreateEntry(4726).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.CreateEntry(4727).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.CreateEntry(4728).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.CreateEntry(4729).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);

			for (int i = 1948; i <= 1957; i++) painter.CreateEntry(i).AddCondition(NPCShop.Entry.Condition.Christmas);
			for (int i = 2158; i <= 2160; i++) painter.CreateEntry(i);
			for (int i = 2008; i <= 2014; i++) painter.CreateEntry(i);
		}

		private static void SetupShop_Cyborg()
		{
			NPCShop cyborg = new NPCShop();
			shops.Add(NPCID.Cyborg, cyborg);

			cyborg.CreateEntry(771);
			cyborg.CreateEntry(772).AddCondition(NPCShop.Entry.Condition.BloodMoon);
			cyborg.CreateEntry(773).AddCondition(NPCShop.Entry.Condition.TimeNight | NPCShop.Entry.Condition.SolarEclipse);
			cyborg.CreateEntry(774).AddCondition(NPCShop.Entry.Condition.SolarEclipse);
			cyborg.CreateEntry(4445).AddCondition(NPCShop.Entry.Condition.DownedMartians);
			cyborg.CreateEntry(4446).AddCondition(NPCShop.Entry.Condition.DownedMartians, NPCShop.Entry.Condition.BloodMoon | NPCShop.Entry.Condition.SolarEclipse);
			cyborg.CreateEntry(4459).AddCondition(NPCShop.Entry.Condition.Hardmode);
			cyborg.CreateEntry(760).AddCondition(NPCShop.Entry.Condition.Hardmode);
			cyborg.CreateEntry(1346).AddCondition(NPCShop.Entry.Condition.Hardmode);
			cyborg.CreateEntry(4409).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			cyborg.CreateEntry(4392).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			cyborg.CreateEntry(1743).AddCondition(NPCShop.Entry.Condition.Halloween);
			cyborg.CreateEntry(1744).AddCondition(NPCShop.Entry.Condition.Halloween);
			cyborg.CreateEntry(1745).AddCondition(NPCShop.Entry.Condition.Halloween);
			cyborg.CreateEntry(2862).AddCondition(NPCShop.Entry.Condition.DownedMartians);
			cyborg.CreateEntry(3109).AddCondition(NPCShop.Entry.Condition.DownedMartians);
			cyborg.CreateEntry(3664).AddCondition(NPCShop.Entry.Condition.HasItem(33840) | NPCShop.Entry.Condition.HasItem(3664));
		}

		private static void SetupShop_PartyGirl()
		{
			NPCShop partyGirl = new NPCShop();
			shops.Add(NPCID.PartyGirl, partyGirl);

			partyGirl.CreateEntry(859);
			partyGirl.CreateEntry(4743).AddCondition(NetworkText.FromLiteral("GoodGolfer"), _ => Main.LocalPlayer.golferScoreAccumulated > 500);
			partyGirl.CreateEntry(1000);
			partyGirl.CreateEntry(1168);
			partyGirl.CreateEntry(1449).AddCondition(NPCShop.Entry.Condition.TimeDay);
			partyGirl.CreateEntry(4552).AddCondition(NPCShop.Entry.Condition.TimeNight);
			partyGirl.CreateEntry(1345);
			partyGirl.CreateEntry(1450);
			partyGirl.CreateEntry(3253);
			partyGirl.CreateEntry(4553);
			partyGirl.CreateEntry(2700);
			partyGirl.CreateEntry(2738);
			partyGirl.CreateEntry(4470);
			partyGirl.CreateEntry(4681);

			partyGirl.CreateEntry(4682).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			partyGirl.CreateEntry(4702).AddCondition(NPCShop.Entry.Condition.Lanterns);
			partyGirl.CreateEntry(3548).AddCondition(NPCShop.Entry.Condition.HasItem(3548));
			partyGirl.CreateEntry(3369).AddCondition(NPCShop.Entry.Condition.NPCExists(229));
			partyGirl.CreateEntry(3546).AddCondition(NPCShop.Entry.Condition.DownedGolem);

			partyGirl.CreateEntry(3214).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.CreateEntry(2868).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.CreateEntry(970).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.CreateEntry(971).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.CreateEntry(972).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.CreateEntry(973).AddCondition(NPCShop.Entry.Condition.Hardmode);

			partyGirl.CreateEntry(4791);
			partyGirl.CreateEntry(3747);
			partyGirl.CreateEntry(3732);
			partyGirl.CreateEntry(3742);

			partyGirl.CreateEntry(3749).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3746).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3739).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3740).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3741).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3737).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3738).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3736).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3745).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3744).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.CreateEntry(3743).AddCondition(NPCShop.Entry.Condition.PartyTime);
		}

		private static void SetupShop_DyeTrader()
		{
			NPCShop dyeTrader = new NPCShop();
			shops.Add(NPCID.DyeTrader, dyeTrader);

			dyeTrader.CreateEntry(1037);
			dyeTrader.CreateEntry(2874);
			dyeTrader.CreateEntry(1120);
			dyeTrader.CreateEntry(1969).AddCondition(NetworkText.FromLiteral("Multiplayer"), _ => Main.netMode == NetmodeID.MultiplayerClient);
			dyeTrader.CreateEntry(3248).AddCondition(NPCShop.Entry.Condition.Halloween);
			dyeTrader.CreateEntry(1741).AddCondition(NPCShop.Entry.Condition.Halloween);
			dyeTrader.CreateEntry(2871).AddCondition(NPCShop.Entry.Condition.PhaseFull);
			dyeTrader.CreateEntry(2872).AddCondition(NPCShop.Entry.Condition.PhaseFull);
			dyeTrader.CreateEntry(4663).AddCondition(NPCShop.Entry.Condition.TimeNight, NPCShop.Entry.Condition.BloodMoon);
			dyeTrader.CreateEntry(4662).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
		}

		private static void SetupShop_Steampunker()
		{
			NPCShop steampunker = new NPCShop();
			shops.Add(NPCID.Steampunker, steampunker);

			steampunker.CreateEntry(779);

			steampunker.CreateEntry(748).AddCondition(NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight | NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			steampunker.CreateEntry(839).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			steampunker.CreateEntry(840).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			steampunker.CreateEntry(841).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);

			steampunker.CreateEntry(948).AddCondition(NPCShop.Entry.Condition.DownedGolem);
			steampunker.CreateEntry(3623);
			steampunker.CreateEntry(3603);
			steampunker.CreateEntry(3604);
			steampunker.CreateEntry(3607);
			steampunker.CreateEntry(3605);
			steampunker.CreateEntry(3606);
			steampunker.CreateEntry(3608);
			steampunker.CreateEntry(3618);
			steampunker.CreateEntry(3602);
			steampunker.CreateEntry(3663);
			steampunker.CreateEntry(3609);
			steampunker.CreateEntry(3610);
			steampunker.CreateEntry(995);

			steampunker.CreateEntry(2203).AddCondition(NPCShop.Entry.Condition.DownedEoC, NPCShop.Entry.Condition.DownedEvilBoss, NPCShop.Entry.Condition.DownedSkeletron);

			steampunker.CreateEntry(2193).AddCondition(NPCShop.Entry.Condition.Crimson);
			steampunker.CreateEntry(4142).AddCondition(NPCShop.Entry.Condition.Corruption);
			steampunker.CreateEntry(2192).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			steampunker.CreateEntry(2204).AddCondition(NPCShop.Entry.Condition.InJungle);
			steampunker.CreateEntry(2198).AddCondition(NPCShop.Entry.Condition.InSnow);

			steampunker.CreateEntry(2197).AddCondition(NPCShop.Entry.Condition.InSpace);
			steampunker.CreateEntry(2196).AddCondition(NPCShop.Entry.Condition.HasItem(832));
			steampunker.CreateEntry(1263);
			steampunker.CreateEntry(784).AddCondition(NPCShop.Entry.Condition.AstrologicalEvent, NPCShop.Entry.Condition.Crimson);
			steampunker.CreateEntry(782).AddCondition(NPCShop.Entry.Condition.AstrologicalEvent, NPCShop.Entry.Condition.Corruption);

			steampunker.CreateEntry(781).AddCondition(!NPCShop.Entry.Condition.AstrologicalEvent, NPCShop.Entry.Condition.InHallow);
			steampunker.CreateEntry(780).AddCondition(!NPCShop.Entry.Condition.AstrologicalEvent, !NPCShop.Entry.Condition.InHallow);

			steampunker.CreateEntry(1344).AddCondition(NPCShop.Entry.Condition.Hardmode);
			steampunker.CreateEntry(4472).AddCondition(NPCShop.Entry.Condition.Hardmode);
			steampunker.CreateEntry(1742).AddCondition(NPCShop.Entry.Condition.Halloween);
		}

		private static void SetupShop_Truffle()
		{
			NPCShop truffle = new NPCShop();
			shops.Add(NPCID.Truffle, truffle);

			truffle.CreateEntry(756).AddCondition(NPCShop.Entry.Condition.DownedAnyMechBoss);
			truffle.CreateEntry(787).AddCondition(NPCShop.Entry.Condition.DownedAnyMechBoss);

			truffle.CreateEntry(868);
			truffle.CreateEntry(1551).AddCondition(NPCShop.Entry.Condition.DownedPlantera);
			truffle.CreateEntry(1181);
			truffle.CreateEntry(783);
		}

		private static void SetupShop_SantaClaus()
		{
			NPCShop santaClaus = new NPCShop();
			shops.Add(NPCID.SantaClaus, santaClaus);

			santaClaus.CreateEntry(588);
			santaClaus.CreateEntry(589);
			santaClaus.CreateEntry(590);
			santaClaus.CreateEntry(597);
			santaClaus.CreateEntry(598);
			santaClaus.CreateEntry(596);

			for (int i = 1873; i < 1906; i++) santaClaus.CreateEntry(i);
		}

		private static void SetupShop_Mechanic()
		{
			NPCShop mechanic = new NPCShop();
			shops.Add(NPCID.Mechanic, mechanic);

			mechanic.CreateEntry(509);
			mechanic.CreateEntry(850);
			mechanic.CreateEntry(851);
			mechanic.CreateEntry(3612);
			mechanic.CreateEntry(510);
			mechanic.CreateEntry(530);
			mechanic.CreateEntry(513);
			mechanic.CreateEntry(538);
			mechanic.CreateEntry(529);
			mechanic.CreateEntry(541);
			mechanic.CreateEntry(542);
			mechanic.CreateEntry(543);
			mechanic.CreateEntry(852);
			mechanic.CreateEntry(853);
			mechanic.CreateEntry(4261);
			mechanic.CreateEntry(3707);
			mechanic.CreateEntry(2739);
			mechanic.CreateEntry(849);
			mechanic.CreateEntry(3616);
			mechanic.CreateEntry(2799);
			mechanic.CreateEntry(3619);
			mechanic.CreateEntry(3627);
			mechanic.CreateEntry(3629);
			mechanic.CreateEntry(585);
			mechanic.CreateEntry(584);
			mechanic.CreateEntry(583);
			mechanic.CreateEntry(4484);
			mechanic.CreateEntry(4485);
			mechanic.CreateEntry(2295).AddCondition(new NPCShop.Entry.Condition(NetworkText.FromLiteral("Mechanic's Rod"), _ => NPC.AnyNPCs(369)
			                                                                                                                    && (Main.GetMoonPhase() == MoonPhase.QuarterAtLeft || Main.GetMoonPhase() == MoonPhase.QuarterAtRight || Main.GetMoonPhase() == MoonPhase.ThreeQuartersAtLeft || Main.GetMoonPhase() == MoonPhase.ThreeQuartersAtRight)));
		}

		private static void SetupShop_Wizard()
		{
			NPCShop wizard = new NPCShop();
			shops.Add(NPCID.Wizard, wizard);

			wizard.CreateEntry(487);
			wizard.CreateEntry(496);
			wizard.CreateEntry(500);
			wizard.CreateEntry(507);
			wizard.CreateEntry(508);
			wizard.CreateEntry(531);
			wizard.CreateEntry(149);
			wizard.CreateEntry(576);
			wizard.CreateEntry(3186);
			wizard.CreateEntry(1739).AddCondition(NPCShop.Entry.Condition.Halloween);
		}

		private static void SetupShop_GoblinTinkerer()
		{
			NPCShop goblinTinkerer = new NPCShop();
			shops.Add(NPCID.GoblinTinkerer, goblinTinkerer);

			goblinTinkerer.CreateEntry(128);
			goblinTinkerer.CreateEntry(486);
			goblinTinkerer.CreateEntry(398);
			goblinTinkerer.CreateEntry(84);
			goblinTinkerer.CreateEntry(407);
			goblinTinkerer.CreateEntry(161);
		}

		private static void SetupShop_Clothier()
		{
			NPCShop clothier = new NPCShop();
			shops.Add(NPCID.Clothier, clothier);

			clothier.CreateEntry(254);
			clothier.CreateEntry(981);
			clothier.CreateEntry(242).AddCondition(NPCShop.Entry.Condition.TimeDay);

			clothier.CreateEntry(245).AddCondition(NPCShop.Entry.Condition.PhaseFull);
			clothier.CreateEntry(246).AddCondition(NPCShop.Entry.Condition.PhaseFull);
			clothier.CreateEntry(1288).AddCondition(NPCShop.Entry.Condition.PhaseFull, NPCShop.Entry.Condition.TimeNight);
			clothier.CreateEntry(1829).AddCondition(NPCShop.Entry.Condition.PhaseFull, NPCShop.Entry.Condition.TimeNight);

			clothier.CreateEntry(325).AddCondition(NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			clothier.CreateEntry(326).AddCondition(NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);

			clothier.CreateEntry(269);
			clothier.CreateEntry(270);
			clothier.CreateEntry(271);

			clothier.CreateEntry(503).AddCondition(NPCShop.Entry.Condition.DownedClown);
			clothier.CreateEntry(504).AddCondition(NPCShop.Entry.Condition.DownedClown);
			clothier.CreateEntry(505).AddCondition(NPCShop.Entry.Condition.DownedClown);

			clothier.CreateEntry(322).AddCondition(NPCShop.Entry.Condition.BloodMoon);
			clothier.CreateEntry(3362).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.TimeNight);
			clothier.CreateEntry(3363).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.TimeNight);

			clothier.CreateEntry(2856).AddCondition(NPCShop.Entry.Condition.DownedLunaticCultist, NPCShop.Entry.Condition.TimeDay);
			clothier.CreateEntry(2858).AddCondition(NPCShop.Entry.Condition.DownedLunaticCultist, NPCShop.Entry.Condition.TimeDay);
			clothier.CreateEntry(2857).AddCondition(NPCShop.Entry.Condition.DownedLunaticCultist, NPCShop.Entry.Condition.TimeNight);
			clothier.CreateEntry(2859).AddCondition(NPCShop.Entry.Condition.DownedLunaticCultist, NPCShop.Entry.Condition.TimeNight);

			clothier.CreateEntry(3242).AddCondition(NetworkText.FromLiteral("441"), _ => NPC.AnyNPCs(441));
			clothier.CreateEntry(3243).AddCondition(NetworkText.FromLiteral("441"), _ => NPC.AnyNPCs(441));
			clothier.CreateEntry(3244).AddCondition(NetworkText.FromLiteral("441"), _ => NPC.AnyNPCs(441));

			clothier.CreateEntry(4685).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.CreateEntry(4686).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.CreateEntry(4704).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.CreateEntry(4705).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.CreateEntry(4706).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.CreateEntry(4707).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.CreateEntry(4708).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.CreateEntry(4709).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);

			clothier.CreateEntry(1429).AddCondition(NPCShop.Entry.Condition.InSnow);
			clothier.CreateEntry(1740).AddCondition(NPCShop.Entry.Condition.Halloween);

			clothier.CreateEntry(869).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtLeft);
			clothier.CreateEntry(4994).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			clothier.CreateEntry(4997).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			clothier.CreateEntry(864).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty);
			clothier.CreateEntry(865).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty);
			clothier.CreateEntry(4995).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseQuarterAtRight);
			clothier.CreateEntry(4998).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseQuarterAtRight);
			clothier.CreateEntry(873).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight);
			clothier.CreateEntry(874).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight);
			clothier.CreateEntry(875).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight);
			clothier.CreateEntry(4996).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			clothier.CreateEntry(4999).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			clothier.CreateEntry(1275).AddCondition(NPCShop.Entry.Condition.DownedFrostLegion);
			clothier.CreateEntry(1276).AddCondition(NPCShop.Entry.Condition.DownedFrostLegion);
			clothier.CreateEntry(3246).AddCondition(NPCShop.Entry.Condition.Halloween);
			clothier.CreateEntry(3247).AddCondition(NPCShop.Entry.Condition.Halloween);

			clothier.CreateEntry(3730).AddCondition(NPCShop.Entry.Condition.PartyTime);
			clothier.CreateEntry(3731).AddCondition(NPCShop.Entry.Condition.PartyTime);
			clothier.CreateEntry(3733).AddCondition(NPCShop.Entry.Condition.PartyTime);
			clothier.CreateEntry(3734).AddCondition(NPCShop.Entry.Condition.PartyTime);
			clothier.CreateEntry(3735).AddCondition(NPCShop.Entry.Condition.PartyTime);

			clothier.CreateEntry(4744).AddCondition(NetworkText.FromLiteral("GoodGolfer"), _ => Main.LocalPlayer.golferScoreAccumulated >= 2000);
		}

		private static void SetupShop_Demolitionist()
		{
			NPCShop demolitionist = new NPCShop();
			shops.Add(NPCID.Demolitionist, demolitionist);

			demolitionist.CreateEntry(168);
			demolitionist.CreateEntry(166);
			demolitionist.CreateEntry(167);

			demolitionist.CreateEntry(265).AddCondition(NPCShop.Entry.Condition.Hardmode);
			demolitionist.CreateEntry(937).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera, NPCShop.Entry.Condition.DownedPirates);
			demolitionist.CreateEntry(1347).AddCondition(NPCShop.Entry.Condition.Hardmode);

			demolitionist.CreateEntry(4827).AddCondition(NPCShop.Entry.Condition.HasItem(4827));
			demolitionist.CreateEntry(4824).AddCondition(NPCShop.Entry.Condition.HasItem(4824));
			demolitionist.CreateEntry(4825).AddCondition(NPCShop.Entry.Condition.HasItem(4825));
			demolitionist.CreateEntry(4826).AddCondition(NPCShop.Entry.Condition.HasItem(4826));
		}

		private static void SetupShop_Dryad()
		{
			NPCShop dryad = new NPCShop();
			shops.Add(NPCID.Dryad, dryad);
			dryad.CreateEntry(2886).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Crimson);
			dryad.CreateEntry(2171).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Crimson);
			dryad.CreateEntry(4508).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Crimson);

			dryad.CreateEntry(67).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Corruption);
			dryad.CreateEntry(59).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Corruption);
			dryad.CreateEntry(4504).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Corruption);

			dryad.CreateEntry(66).AddCondition(!NPCShop.Entry.Condition.BloodMoon);
			dryad.CreateEntry(62).AddCondition(!NPCShop.Entry.Condition.BloodMoon);
			dryad.CreateEntry(63).AddCondition(!NPCShop.Entry.Condition.BloodMoon);
			dryad.CreateEntry(745).AddCondition(!NPCShop.Entry.Condition.BloodMoon);

			dryad.CreateEntry(59).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.Crimson);
			dryad.CreateEntry(2171).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.Corruption);

			dryad.CreateEntry(27);
			dryad.CreateEntry(114);
			dryad.CreateEntry(1828);
			dryad.CreateEntry(747);

			dryad.CreateEntry(746).AddCondition(NPCShop.Entry.Condition.Hardmode);
			dryad.CreateEntry(369).AddCondition(NPCShop.Entry.Condition.Hardmode);
			dryad.CreateEntry(4505).AddCondition(NPCShop.Entry.Condition.Hardmode);

			dryad.CreateEntry(194).AddCondition(NPCShop.Entry.Condition.InGlowshroom);

			dryad.CreateEntry(1853).AddCondition(NPCShop.Entry.Condition.Halloween);
			dryad.CreateEntry(1854).AddCondition(NPCShop.Entry.Condition.Halloween);
			dryad.CreateEntry(3215).AddCondition(NPCShop.Entry.Condition.DownedKingSlime);
			dryad.CreateEntry(3216).AddCondition(NPCShop.Entry.Condition.DownedQueenBee);
			dryad.CreateEntry(3219).AddCondition(NPCShop.Entry.Condition.DownedEoC);
			dryad.CreateEntry(3217).AddCondition(NPCShop.Entry.Condition.DownedEoW);
			dryad.CreateEntry(3218).AddCondition(NPCShop.Entry.Condition.DownedBoC);
			dryad.CreateEntry(3220).AddCondition(NPCShop.Entry.Condition.DownedSkeletron);
			dryad.CreateEntry(3221).AddCondition(NPCShop.Entry.Condition.DownedSkeletron);

			dryad.CreateEntry(3222).AddCondition(NPCShop.Entry.Condition.Hardmode);

			dryad.CreateEntry(4047);
			dryad.CreateEntry(4045);
			dryad.CreateEntry(4044);
			dryad.CreateEntry(4043);
			dryad.CreateEntry(4042);
			dryad.CreateEntry(4046);
			dryad.CreateEntry(4041);
			dryad.CreateEntry(4241);
			dryad.CreateEntry(4048);

			dryad.CreateEntry(4430).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			dryad.CreateEntry(4431).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			dryad.CreateEntry(4432).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);

			dryad.CreateEntry(4433).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			dryad.CreateEntry(4434).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			dryad.CreateEntry(4435).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);

			dryad.CreateEntry(4436).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			dryad.CreateEntry(4437).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			dryad.CreateEntry(4438).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);

			dryad.CreateEntry(4439).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			dryad.CreateEntry(4440).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			dryad.CreateEntry(4441).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_ArmsDealer()
		{
			NPCShop armsDealer = new NPCShop();
			shops.Add(NPCID.ArmsDealer, armsDealer);
			armsDealer.CreateEntry(97);

			armsDealer.CreateEntry(4915).AddCondition(NetworkText.FromLiteral("23hard"), _ => (Main.bloodMoon || Main.hardMode) && WorldGen.SavedOreTiers.Silver == 168);
			armsDealer.CreateEntry(278).AddCondition(NetworkText.FromLiteral("23hard"), _ => (Main.bloodMoon || Main.hardMode) && WorldGen.SavedOreTiers.Silver != 168);
			armsDealer.CreateEntry(47).AddCondition(NetworkText.FromLiteral("23hard"), _ => NPC.downedBoss2 && !Main.dayTime || Main.hardMode);

			armsDealer.CreateEntry(95);
			armsDealer.CreateEntry(98);

			armsDealer.CreateEntry(4703).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.DownedSkeletron);
			armsDealer.CreateEntry(324).AddCondition(NPCShop.Entry.Condition.TimeNight);
			armsDealer.CreateEntry(534).AddCondition(NPCShop.Entry.Condition.Hardmode);
			armsDealer.CreateEntry(1432).AddCondition(NPCShop.Entry.Condition.Hardmode);

			armsDealer.CreateEntry(1261).AddCondition(NPCShop.Entry.Condition.HasItem(1258));
			armsDealer.CreateEntry(1836).AddCondition(NPCShop.Entry.Condition.HasItem(1835));
			armsDealer.CreateEntry(3108).AddCondition(NPCShop.Entry.Condition.HasItem(3107));
			armsDealer.CreateEntry(1783).AddCondition(NPCShop.Entry.Condition.HasItem(1782));
			armsDealer.CreateEntry(1785).AddCondition(NPCShop.Entry.Condition.HasItem(1784));

			armsDealer.CreateEntry(1736).AddCondition(NPCShop.Entry.Condition.Halloween);
			armsDealer.CreateEntry(1737).AddCondition(NPCShop.Entry.Condition.Halloween);
			armsDealer.CreateEntry(1738).AddCondition(NPCShop.Entry.Condition.Halloween);
		}

		private static void SetupShop_Merchant()
		{
			NPCShop merchant = new NPCShop();
			shops.Add(NPCID.Merchant, merchant);
			merchant.CreateEntry(88);
			merchant.CreateEntry(87);
			merchant.CreateEntry(35);
			merchant.CreateEntry(1991);
			merchant.CreateEntry(3509);
			merchant.CreateEntry(3506);
			merchant.CreateEntry(8);
			merchant.CreateEntry(28);
			merchant.CreateEntry(110);
			merchant.CreateEntry(40);
			merchant.CreateEntry(42);
			merchant.CreateEntry(965);

			merchant.CreateEntry(967).AddCondition(NPCShop.Entry.Condition.InSnow);
			merchant.CreateEntry(33).AddCondition(NPCShop.Entry.Condition.InJungle);
			merchant.CreateEntry(4074).AddCondition(NPCShop.Entry.Condition.TimeDay, new NPCShop.Entry.Condition(NetworkText.FromLiteral("HappyWind"), _ => Main.IsItAHappyWindyDay));
			merchant.CreateEntry(279).AddCondition(NPCShop.Entry.Condition.BloodMoon);
			merchant.CreateEntry(282).AddCondition(NPCShop.Entry.Condition.TimeNight);
			merchant.CreateEntry(346).AddCondition(NetworkText.FromLiteral("Boss3"), _ => NPC.downedBoss3);
			merchant.CreateEntry(488).AddCondition(NPCShop.Entry.Condition.Hardmode);

			merchant.CreateEntry(931).AddCondition(NPCShop.Entry.Condition.HasItem(930));
			merchant.CreateEntry(1614).AddCondition(NPCShop.Entry.Condition.HasItem(930));

			merchant.CreateEntry(1786);
			merchant.CreateEntry(1348).AddCondition(NPCShop.Entry.Condition.Hardmode);
			merchant.CreateEntry(3198).AddCondition(NPCShop.Entry.Condition.Hardmode);

			merchant.CreateEntry(3108).AddCondition(NPCShop.Entry.Condition.HasItem(3107));
			merchant.CreateEntry(4063).AddCondition(NetworkText.FromLiteral("23hard"), _ => NPC.downedBoss2 || NPC.downedBoss3 || Main.hardMode);
			merchant.CreateEntry(4673).AddCondition(NetworkText.FromLiteral("23hard"), _ => NPC.downedBoss2 || NPC.downedBoss3 || Main.hardMode);
		}

		public static void Unload()
		{
			shops.Clear();
		}
	}
}