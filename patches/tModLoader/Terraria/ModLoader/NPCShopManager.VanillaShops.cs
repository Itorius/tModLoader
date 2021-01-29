using System.Collections.Generic;
using System.Linq;
using Terraria.Enums;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Container;

namespace Terraria.ModLoader
{
	public static partial class NPCShopManager
	{
		private static void SetupShop_Zoologist()
		{
			NPCShop zoologist = RegisterShop(NPCID.BestiaryGirl);

			zoologist.AddEntry(4776).AddCondition(NetworkText.FromLiteral("FairyTorch"), () =>
			{
				static bool DidDiscoverBestiaryEntry(int npcId) => Main.BestiaryDB.FindEntryByNPCID(npcId).UIInfoProvider.GetEntryUICollectionInfo().UnlockState > BestiaryEntryUnlockState.NotKnownAtAll_0;

				return DidDiscoverBestiaryEntry(585) && DidDiscoverBestiaryEntry(584) && DidDiscoverBestiaryEntry(583);
			});

			zoologist.AddEntry(4767);
			zoologist.AddEntry(4759);

			static NPCShop.Entry.Condition Completion(float value) => new NPCShop.Entry.SimpleCondition(NetworkText.FromLiteral("BestiaryCompletion"), () => Main.GetBestiaryProgressReport().CompletionPercent >= value);

			zoologist.AddEntry(4672).AddCondition(Completion(0.1f));
			zoologist.AddEntry(4829).AddCondition(NetworkText.FromLiteral("Cat"), () => !NPC.boughtCat);
			zoologist.AddEntry(4830).AddCondition(new NPCShop.Entry.SimpleCondition(NetworkText.FromLiteral("Dog"), () => !NPC.boughtDog), Completion(0.25f));
			zoologist.AddEntry(4910).AddCondition(new NPCShop.Entry.SimpleCondition(NetworkText.FromLiteral("Bunny"), () => !NPC.boughtBunny), Completion(0.45f));

			zoologist.AddEntry(4871).AddCondition(Completion(0.3f));
			zoologist.AddEntry(4907).AddCondition(Completion(0.4f));

			zoologist.AddEntry(4677).AddCondition(NPCShop.Entry.Condition.DownedSolarTower);

			zoologist.AddEntry(4676).AddCondition(Completion(0.1f));
			zoologist.AddEntry(4762).AddCondition(Completion(0.3f));
			zoologist.AddEntry(4716).AddCondition(Completion(0.25f));
			zoologist.AddEntry(4785).AddCondition(Completion(0.3f));
			zoologist.AddEntry(4786).AddCondition(Completion(0.3f));
			zoologist.AddEntry(4787).AddCondition(Completion(0.3f));
			zoologist.AddEntry(4788).AddCondition(Completion(0.3f), NPCShop.Entry.Condition.Hardmode);
			zoologist.AddEntry(4955).AddCondition(Completion(0.4f));

			zoologist.AddEntry(4736).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.BloodMoon);
			zoologist.AddEntry(4701).AddCondition(NPCShop.Entry.Condition.DownedPlantera);

			zoologist.AddEntry(4765).AddCondition(Completion(0.5f));
			zoologist.AddEntry(4766).AddCondition(Completion(0.5f));
			zoologist.AddEntry(4777).AddCondition(Completion(0.5f));
			zoologist.AddEntry(4763).AddCondition(Completion(0.6f));
			zoologist.AddEntry(4735).AddCondition(Completion(0.7f));
			zoologist.AddEntry(4751).AddCondition(Completion(1f));

			zoologist.AddEntry(4768).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			zoologist.AddEntry(4769).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);

			zoologist.AddEntry(4770).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			zoologist.AddEntry(4771).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);

			zoologist.AddEntry(4772).AddCondition(NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			zoologist.AddEntry(4773).AddCondition(NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);

			zoologist.AddEntry(4560).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			zoologist.AddEntry(4775).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_Golfer()
		{
			NPCShop golfer = RegisterShop(NPCID.Golfer);

			golfer.AddEntry(4587);
			golfer.AddEntry(4590);
			golfer.AddEntry(4589);
			golfer.AddEntry(4588);
			golfer.AddEntry(4083);
			golfer.AddEntry(4084);
			golfer.AddEntry(4085);
			golfer.AddEntry(4086);
			golfer.AddEntry(4087);
			golfer.AddEntry(4088);

			static NPCShop.Entry.Condition GolfScore(int count) => new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.GolfScore"), () => Main.LocalPlayer.golferScoreAccumulated > count);

			golfer.AddEntry(4039).AddCondition(GolfScore(500));
			golfer.AddEntry(4094).AddCondition(GolfScore(500));
			golfer.AddEntry(4093).AddCondition(GolfScore(500));
			golfer.AddEntry(1092).AddCondition(GolfScore(500));

			golfer.AddEntry(4089);
			golfer.AddEntry(3979);
			golfer.AddEntry(4095);
			golfer.AddEntry(4040);
			golfer.AddEntry(4319);
			golfer.AddEntry(4320);

			golfer.AddEntry(4591).AddCondition(GolfScore(1000));
			golfer.AddEntry(4594).AddCondition(GolfScore(1000));
			golfer.AddEntry(4593).AddCondition(GolfScore(1000));
			golfer.AddEntry(4592).AddCondition(GolfScore(1000));

			golfer.AddEntry(4135);
			golfer.AddEntry(4138);
			golfer.AddEntry(4136);
			golfer.AddEntry(4137);
			golfer.AddEntry(4049);

			golfer.AddEntry(4265).AddCondition(GolfScore(500));

			golfer.AddEntry(4595).AddCondition(GolfScore(2000));
			golfer.AddEntry(4598).AddCondition(GolfScore(2000));
			golfer.AddEntry(4597).AddCondition(GolfScore(2000));
			golfer.AddEntry(4596).AddCondition(GolfScore(2000));
			golfer.AddEntry(4264).AddCondition(GolfScore(2000), NPCShop.Entry.Condition.DownedSkeletron);

			golfer.AddEntry(4599).AddCondition(GolfScore(500));
			golfer.AddEntry(4600).AddCondition(GolfScore(999));
			golfer.AddEntry(4601).AddCondition(GolfScore(1999));

			golfer.AddEntry(4658).AddCondition(GolfScore(1999), NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			golfer.AddEntry(4659).AddCondition(GolfScore(1999), NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			golfer.AddEntry(4660).AddCondition(GolfScore(1999), NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			golfer.AddEntry(4661).AddCondition(GolfScore(1999), NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_Princess()
		{
			NPCShop princess = RegisterShop(NPCID.Princess);

			princess.AddEntry(5071);
			princess.AddEntry(5072);
			princess.AddEntry(5073);
			princess.AddEntry(5076);
			princess.AddEntry(5077);
			princess.AddEntry(5078);
			princess.AddEntry(5079);
			princess.AddEntry(5080);
			princess.AddEntry(5081);
			princess.AddEntry(5082);
			princess.AddEntry(5083);
			princess.AddEntry(5084);
			princess.AddEntry(5085);
			princess.AddEntry(5086);
			princess.AddEntry(5087);
			princess.AddEntry(5044).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMoonLord);
		}

		private static void SetupShop_Bartender()
		{
			NPCShop bartender = RegisterShop(NPCID.DD2Bartender);

			NPCShop.Entry.Condition condition1 = NPCShop.Entry.Condition.Hardmode & NPCShop.Entry.Condition.DownedAnyMechBoss;
			NPCShop.Entry.Condition condition2 = NPCShop.Entry.Condition.Hardmode & NPCShop.Entry.Condition.DownedGolem;

			bartender.AddEntry(353);

			bartender.AddEntry(3828).SetPrice(Item.buyPrice(gold: 4)).AddCondition(condition1, condition2);
			bartender.AddEntry(3828).SetPrice(Item.buyPrice(gold: 1)).AddCondition(condition1, !condition2);
			bartender.AddEntry(3828).SetPrice(Item.buyPrice(silver: 25)).AddCondition(!condition1, !condition2);

			bartender.AddEntry(3816);

			bartender.AddEntry(3813).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75);
			bartender.AddEntry(3818).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(5);
			bartender.AddEntry(3824).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(5);
			bartender.AddEntry(3832).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(5);
			bartender.AddEntry(3829).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(5);

			bartender.AddEntry(3819).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3825).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3833).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3830).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);

			bartender.AddEntry(3820).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(100).AddCondition(condition2);
			bartender.AddEntry(3826).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(100).AddCondition(condition2);
			bartender.AddEntry(3834).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(100).AddCondition(condition2);
			bartender.AddEntry(3831).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(100).AddCondition(condition2);

			bartender.AddEntry(3800).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3801).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3802).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3797).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3798).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3799).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3803).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3804).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3805).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3806).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3807).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.AddEntry(3808).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);

			bartender.AddEntry(3871).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3872).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3873).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3874).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3875).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3876).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3877).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3878).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3879).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3880).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3881).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.AddEntry(3882).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
		}

		private static void SetupShop_SkeletonMerchant()
		{
			NPCShop skeletonMerchant = RegisterShop(NPCID.SkeletonMerchant);

			skeletonMerchant.AddEntry(3001).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseHalfAtRight);
			skeletonMerchant.AddEntry(3001).AddCondition(NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);

			skeletonMerchant.AddEntry(3002).AddCondition(NPCShop.Entry.Condition.TimeNight | NPCShop.Entry.Condition.PhaseFull);
			skeletonMerchant.AddEntry(282).AddCondition(!(NPCShop.Entry.Condition.TimeNight | NPCShop.Entry.Condition.PhaseFull));

			NPCShop.Entry.Condition cond = new NPCShop.Entry.SimpleCondition(NetworkText.FromLiteral("Time"), () => Main.time % 60.0 * 60.0 * 6.0 <= 10800.0);
			skeletonMerchant.AddEntry(3004).AddCondition(cond);
			skeletonMerchant.AddEntry(8).AddCondition(!cond);

			cond = NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight;
			skeletonMerchant.AddEntry(3003).AddCondition(cond);
			skeletonMerchant.AddEntry(40).AddCondition(!cond);

			skeletonMerchant.AddEntry(3310).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseEmpty);
			skeletonMerchant.AddEntry(3313).AddCondition(NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			skeletonMerchant.AddEntry(3312).AddCondition(NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseHalfAtRight);
			skeletonMerchant.AddEntry(3311).AddCondition(NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);

			skeletonMerchant.AddEntry(166);
			skeletonMerchant.AddEntry(965);

			skeletonMerchant.AddEntry(3316).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			skeletonMerchant.AddEntry(3315).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight | NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			skeletonMerchant.AddEntry(3334).AddCondition(NPCShop.Entry.Condition.Hardmode);
			skeletonMerchant.AddEntry(3258).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.BloodMoon);
			skeletonMerchant.AddEntry(3043).AddCondition(NPCShop.Entry.Condition.PhaseFull, NPCShop.Entry.Condition.TimeNight);
		}

		private static void SetupShop_Stylist()
		{
			NPCShop stylist = RegisterShop(NPCID.Stylist);

			stylist.AddEntry(1990);
			stylist.AddEntry(1979);
			stylist.AddEntry(1977).AddCondition(NetworkText.FromLiteral("HP400"), () => Main.LocalPlayer.statLifeMax >= 400);
			stylist.AddEntry(1978).AddCondition(NetworkText.FromLiteral("MANA200"), () => Main.LocalPlayer.statManaMax >= 200);
			stylist.AddEntry(1980).AddCondition(NetworkText.FromLiteral("Money1M"), () => Main.LocalPlayer.inventory.CountCoins() >= 1000000);

			stylist.AddEntry(1981).AddCondition(
				(NPCShop.Entry.Condition.TimeNight & (NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight)) |
				(NPCShop.Entry.Condition.TimeDay & (NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseHalfAtRight)));
			stylist.AddEntry(1982).AddCondition(NetworkText.FromLiteral("Team"), () => Main.LocalPlayer.team != 0);
			stylist.AddEntry(1983).AddCondition(NPCShop.Entry.Condition.Hardmode);
			stylist.AddEntry(1984).AddCondition(NPCShop.Entry.Condition.NPCExists(208));
			stylist.AddEntry(1985).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedDestroyer, NPCShop.Entry.Condition.DownedTwins, NPCShop.Entry.Condition.DownedSkeletronPrime);
			stylist.AddEntry(1986).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedAnyMechBoss);
			stylist.AddEntry(2863).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMartians);
			stylist.AddEntry(3259).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMartians);
		}

		private static void SetupShop_Pirate()
		{
			NPCShop pirate = RegisterShop(NPCID.Pirate);

			pirate.AddEntry(928);
			pirate.AddEntry(929);
			pirate.AddEntry(876);
			pirate.AddEntry(877);
			pirate.AddEntry(878);
			pirate.AddEntry(2434);
			pirate.AddEntry(1180).AddCondition(NPCShop.Entry.Condition.InOcean);
			pirate.AddEntry(1337).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedAnyMechBoss, NPCShop.Entry.Condition.NPCExists(208));
		}

		private static void SetupShop_WitchDoctor()
		{
			NPCShop witchDoctor = RegisterShop(NPCID.WitchDoctor);

			witchDoctor.AddEntry(1430);
			witchDoctor.AddEntry(986);

			witchDoctor.AddEntry(2999).AddCondition(NPCShop.Entry.Condition.NPCExists(108));
			witchDoctor.AddEntry(1158).AddCondition(NPCShop.Entry.Condition.TimeNight);
			witchDoctor.AddEntry(1159).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);
			witchDoctor.AddEntry(1160).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);
			witchDoctor.AddEntry(1161).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);
			witchDoctor.AddEntry(1167).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera, NPCShop.Entry.Condition.InJungle);
			witchDoctor.AddEntry(1339).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);

			witchDoctor.AddEntry(1171).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.InJungle);
			witchDoctor.AddEntry(1162).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.InJungle, NPCShop.Entry.Condition.TimeNight);

			witchDoctor.AddEntry(909);
			witchDoctor.AddEntry(910);
			witchDoctor.AddEntry(940);
			witchDoctor.AddEntry(941);
			witchDoctor.AddEntry(942);
			witchDoctor.AddEntry(943);
			witchDoctor.AddEntry(944);
			witchDoctor.AddEntry(945);
			witchDoctor.AddEntry(4922);
			witchDoctor.AddEntry(4917);
			witchDoctor.AddEntry(1836).AddCondition(NPCShop.Entry.Condition.HasItem(1835));
			witchDoctor.AddEntry(1261).AddCondition(NPCShop.Entry.Condition.HasItem(1258));
			witchDoctor.AddEntry(1791).AddCondition(NPCShop.Entry.Condition.Halloween);
		}

		private static void SetupShop_Painer()
		{
			NPCShop painter = RegisterShop(NPCID.Painter);

			painter.AddEntry(1071);
			painter.AddEntry(1072);
			painter.AddEntry(1073);

			for (int i = 1073; i <= 1084; i++) painter.AddEntry(i);

			painter.AddEntry(1097);
			painter.AddEntry(1099);
			painter.AddEntry(1098);
			painter.AddEntry(1966);
			painter.AddEntry(4668).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.AddEntry(1967).AddCondition(NPCShop.Entry.Condition.Hardmode);
			painter.AddEntry(1968).AddCondition(NPCShop.Entry.Condition.Hardmode);
			painter.AddEntry(1490).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.AddEntry(1481).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.PhaseFull, NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			painter.AddEntry(1482).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.PhaseHalfAtLeft, NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			painter.AddEntry(1483).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.PhaseEmpty, NPCShop.Entry.Condition.PhaseQuarterAtRight);
			painter.AddEntry(1484).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.PhaseHalfAtRight, NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);

			painter.AddEntry(1492).AddCondition(NPCShop.Entry.Condition.InCrimson);
			painter.AddEntry(1488).AddCondition(NPCShop.Entry.Condition.InCorrupt);
			painter.AddEntry(1489).AddCondition(NPCShop.Entry.Condition.InHallow);
			painter.AddEntry(1486).AddCondition(NPCShop.Entry.Condition.InJungle);
			painter.AddEntry(1487).AddCondition(NPCShop.Entry.Condition.InSnow);
			painter.AddEntry(1491).AddCondition(NPCShop.Entry.Condition.InDesert);
			painter.AddEntry(1493).AddCondition(NPCShop.Entry.Condition.BloodMoon);

			painter.AddEntry(1485).AddCondition(!NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.InSpace, NPCShop.Entry.Condition.BloodMoon);
			painter.AddEntry(1494).AddCondition(!NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.InSpace, NPCShop.Entry.Condition.Hardmode);

			painter.AddEntry(4723).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.AddEntry(4724).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.AddEntry(4725).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.AddEntry(4726).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.AddEntry(4727).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.AddEntry(4728).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			painter.AddEntry(4729).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);

			for (int i = 1948; i <= 1957; i++) painter.AddEntry(i).AddCondition(NPCShop.Entry.Condition.Christmas);
			for (int i = 2158; i <= 2160; i++) painter.AddEntry(i);
			for (int i = 2008; i <= 2014; i++) painter.AddEntry(i);
		}

		private static void SetupShop_Cyborg()
		{
			NPCShop cyborg = RegisterShop(NPCID.Cyborg);

			cyborg.AddEntry(771);
			cyborg.AddEntry(772).AddCondition(NPCShop.Entry.Condition.BloodMoon);
			cyborg.AddEntry(773).AddCondition(NPCShop.Entry.Condition.TimeNight | NPCShop.Entry.Condition.SolarEclipse);
			cyborg.AddEntry(774).AddCondition(NPCShop.Entry.Condition.SolarEclipse);
			cyborg.AddEntry(4445).AddCondition(NPCShop.Entry.Condition.DownedMartians);
			cyborg.AddEntry(4446).AddCondition(NPCShop.Entry.Condition.DownedMartians, NPCShop.Entry.Condition.BloodMoon | NPCShop.Entry.Condition.SolarEclipse);
			cyborg.AddEntry(4459).AddCondition(NPCShop.Entry.Condition.Hardmode);
			cyborg.AddEntry(760).AddCondition(NPCShop.Entry.Condition.Hardmode);
			cyborg.AddEntry(1346).AddCondition(NPCShop.Entry.Condition.Hardmode);
			cyborg.AddEntry(4409).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			cyborg.AddEntry(4392).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			cyborg.AddEntry(1743).AddCondition(NPCShop.Entry.Condition.Halloween);
			cyborg.AddEntry(1744).AddCondition(NPCShop.Entry.Condition.Halloween);
			cyborg.AddEntry(1745).AddCondition(NPCShop.Entry.Condition.Halloween);
			cyborg.AddEntry(2862).AddCondition(NPCShop.Entry.Condition.DownedMartians);
			cyborg.AddEntry(3109).AddCondition(NPCShop.Entry.Condition.DownedMartians);
			cyborg.AddEntry(3664).AddCondition(NPCShop.Entry.Condition.HasItem(33840) | NPCShop.Entry.Condition.HasItem(3664));
		}

		private static void SetupShop_PartyGirl()
		{
			NPCShop partyGirl = RegisterShop(NPCID.PartyGirl);

			partyGirl.AddEntry(859);
			partyGirl.AddEntry(4743).AddCondition(NetworkText.FromLiteral("GoodGolfer"), () => Main.LocalPlayer.golferScoreAccumulated > 500);
			partyGirl.AddEntry(1000);
			partyGirl.AddEntry(1168);
			partyGirl.AddEntry(1449).AddCondition(NPCShop.Entry.Condition.TimeDay);
			partyGirl.AddEntry(4552).AddCondition(NPCShop.Entry.Condition.TimeNight);
			partyGirl.AddEntry(1345);
			partyGirl.AddEntry(1450);
			partyGirl.AddEntry(3253);
			partyGirl.AddEntry(4553);
			partyGirl.AddEntry(2700);
			partyGirl.AddEntry(2738);
			partyGirl.AddEntry(4470);
			partyGirl.AddEntry(4681);

			partyGirl.AddEntry(4682).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			partyGirl.AddEntry(4702).AddCondition(NPCShop.Entry.Condition.Lanterns);
			partyGirl.AddEntry(3548).AddCondition(NPCShop.Entry.Condition.HasItem(3548));
			partyGirl.AddEntry(3369).AddCondition(NPCShop.Entry.Condition.NPCExists(229));
			partyGirl.AddEntry(3546).AddCondition(NPCShop.Entry.Condition.DownedGolem);

			partyGirl.AddEntry(3214).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.AddEntry(2868).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.AddEntry(970).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.AddEntry(971).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.AddEntry(972).AddCondition(NPCShop.Entry.Condition.Hardmode);
			partyGirl.AddEntry(973).AddCondition(NPCShop.Entry.Condition.Hardmode);

			partyGirl.AddEntry(4791);
			partyGirl.AddEntry(3747);
			partyGirl.AddEntry(3732);
			partyGirl.AddEntry(3742);

			partyGirl.AddEntry(3749).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3746).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3739).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3740).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3741).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3737).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3738).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3736).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3745).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3744).AddCondition(NPCShop.Entry.Condition.PartyTime);
			partyGirl.AddEntry(3743).AddCondition(NPCShop.Entry.Condition.PartyTime);
		}

		private static void SetupShop_DyeTrader()
		{
			NPCShop dyeTrader = RegisterShop(NPCID.DyeTrader);

			dyeTrader.AddEntry(1037);
			dyeTrader.AddEntry(2874);
			dyeTrader.AddEntry(1120);
			dyeTrader.AddEntry(1969).AddCondition(NetworkText.FromLiteral("Multiplayer"), () => Main.netMode == NetmodeID.MultiplayerClient);
			dyeTrader.AddEntry(3248).AddCondition(NPCShop.Entry.Condition.Halloween);
			dyeTrader.AddEntry(1741).AddCondition(NPCShop.Entry.Condition.Halloween);
			dyeTrader.AddEntry(2871).AddCondition(NPCShop.Entry.Condition.PhaseFull);
			dyeTrader.AddEntry(2872).AddCondition(NPCShop.Entry.Condition.PhaseFull);
			dyeTrader.AddEntry(4663).AddCondition(NPCShop.Entry.Condition.TimeNight, NPCShop.Entry.Condition.BloodMoon);
			dyeTrader.AddEntry(4662).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
		}

		private static void SetupShop_Steampunker()
		{
			NPCShop steampunker = RegisterShop(NPCID.Steampunker);

			steampunker.AddEntry(779);

			steampunker.AddEntry(748).AddCondition(NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight | NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			steampunker.AddEntry(839).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			steampunker.AddEntry(840).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			steampunker.AddEntry(841).AddCondition(NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseQuarterAtLeft | NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);

			steampunker.AddEntry(948).AddCondition(NPCShop.Entry.Condition.DownedGolem);
			steampunker.AddEntry(3623);
			steampunker.AddEntry(3603);
			steampunker.AddEntry(3604);
			steampunker.AddEntry(3607);
			steampunker.AddEntry(3605);
			steampunker.AddEntry(3606);
			steampunker.AddEntry(3608);
			steampunker.AddEntry(3618);
			steampunker.AddEntry(3602);
			steampunker.AddEntry(3663);
			steampunker.AddEntry(3609);
			steampunker.AddEntry(3610);
			steampunker.AddEntry(995);

			steampunker.AddEntry(2203).AddCondition(NPCShop.Entry.Condition.DownedEoC, NPCShop.Entry.Condition.DownedEvilBoss, NPCShop.Entry.Condition.DownedSkeletron);

			steampunker.AddEntry(2193).AddCondition(NPCShop.Entry.Condition.Crimson);
			steampunker.AddEntry(4142).AddCondition(NPCShop.Entry.Condition.Corruption);
			steampunker.AddEntry(2192).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			steampunker.AddEntry(2204).AddCondition(NPCShop.Entry.Condition.InJungle);
			steampunker.AddEntry(2198).AddCondition(NPCShop.Entry.Condition.InSnow);

			steampunker.AddEntry(2197).AddCondition(NPCShop.Entry.Condition.InSpace);
			steampunker.AddEntry(2196).AddCondition(NPCShop.Entry.Condition.HasItem(832));
			steampunker.AddEntry(1263);
			steampunker.AddEntry(784).AddCondition(NPCShop.Entry.Condition.AstrologicalEvent, NPCShop.Entry.Condition.Crimson);
			steampunker.AddEntry(782).AddCondition(NPCShop.Entry.Condition.AstrologicalEvent, NPCShop.Entry.Condition.Corruption);

			steampunker.AddEntry(781).AddCondition(!NPCShop.Entry.Condition.AstrologicalEvent, NPCShop.Entry.Condition.InHallow);
			steampunker.AddEntry(780).AddCondition(!NPCShop.Entry.Condition.AstrologicalEvent, !NPCShop.Entry.Condition.InHallow);

			steampunker.AddEntry(1344).AddCondition(NPCShop.Entry.Condition.Hardmode);
			steampunker.AddEntry(4472).AddCondition(NPCShop.Entry.Condition.Hardmode);
			steampunker.AddEntry(1742).AddCondition(NPCShop.Entry.Condition.Halloween);
		}

		private static void SetupShop_Truffle()
		{
			NPCShop truffle = RegisterShop(NPCID.Truffle);

			truffle.AddEntry(756).AddCondition(NPCShop.Entry.Condition.DownedAnyMechBoss);
			truffle.AddEntry(787).AddCondition(NPCShop.Entry.Condition.DownedAnyMechBoss);

			truffle.AddEntry(868);
			truffle.AddEntry(1551).AddCondition(NPCShop.Entry.Condition.DownedPlantera);
			truffle.AddEntry(1181);
			truffle.AddEntry(783);
		}

		private static void SetupShop_SantaClaus()
		{
			NPCShop santaClaus = RegisterShop(NPCID.SantaClaus);

			santaClaus.AddEntry(588);
			santaClaus.AddEntry(589);
			santaClaus.AddEntry(590);
			santaClaus.AddEntry(597);
			santaClaus.AddEntry(598);
			santaClaus.AddEntry(596);

			for (int i = 1873; i < 1906; i++) santaClaus.AddEntry(i);
		}

		private static void SetupShop_Mechanic()
		{
			NPCShop mechanic = RegisterShop(NPCID.Mechanic);

			mechanic.AddEntry(509);
			mechanic.AddEntry(850);
			mechanic.AddEntry(851);
			mechanic.AddEntry(3612);
			mechanic.AddEntry(510);
			mechanic.AddEntry(530);
			mechanic.AddEntry(513);
			mechanic.AddEntry(538);
			mechanic.AddEntry(529);
			mechanic.AddEntry(541);
			mechanic.AddEntry(542);
			mechanic.AddEntry(543);
			mechanic.AddEntry(852);
			mechanic.AddEntry(853);
			mechanic.AddEntry(4261);
			mechanic.AddEntry(3707);
			mechanic.AddEntry(2739);
			mechanic.AddEntry(849);
			mechanic.AddEntry(3616);
			mechanic.AddEntry(2799);
			mechanic.AddEntry(3619);
			mechanic.AddEntry(3627);
			mechanic.AddEntry(3629);
			mechanic.AddEntry(585);
			mechanic.AddEntry(584);
			mechanic.AddEntry(583);
			mechanic.AddEntry(4484);
			mechanic.AddEntry(4485);
			mechanic.AddEntry(2295).AddCondition(new NPCShop.Entry.SimpleCondition(NetworkText.FromLiteral("Mechanic's Rod"), () => NPC.AnyNPCs(369)
			                                                                                                                        && (Main.GetMoonPhase() == MoonPhase.QuarterAtLeft || Main.GetMoonPhase() == MoonPhase.QuarterAtRight || Main.GetMoonPhase() == MoonPhase.ThreeQuartersAtLeft || Main.GetMoonPhase() == MoonPhase.ThreeQuartersAtRight)));
		}

		private static void SetupShop_Wizard()
		{
			NPCShop wizard = RegisterShop(NPCID.Wizard);

			wizard.AddEntry(487);
			wizard.AddEntry(496);
			wizard.AddEntry(500);
			wizard.AddEntry(507);
			wizard.AddEntry(508);
			wizard.AddEntry(531);
			wizard.AddEntry(149);
			wizard.AddEntry(576);
			wizard.AddEntry(3186);
			wizard.AddEntry(1739).AddCondition(NPCShop.Entry.Condition.Halloween);
		}

		private static void SetupShop_GoblinTinkerer()
		{
			NPCShop goblinTinkerer = RegisterShop(NPCID.GoblinTinkerer);

			goblinTinkerer.AddEntry(128);
			goblinTinkerer.AddEntry(486);
			goblinTinkerer.AddEntry(398);
			goblinTinkerer.AddEntry(84);
			goblinTinkerer.AddEntry(407);
			goblinTinkerer.AddEntry(161);
		}

		private static void SetupShop_Clothier()
		{
			NPCShop clothier = RegisterShop(NPCID.Clothier);

			clothier.AddEntry(254);
			clothier.AddEntry(981);
			clothier.AddEntry(242).AddCondition(NPCShop.Entry.Condition.TimeDay);

			clothier.AddEntry(245).AddCondition(NPCShop.Entry.Condition.PhaseFull);
			clothier.AddEntry(246).AddCondition(NPCShop.Entry.Condition.PhaseFull);
			clothier.AddEntry(1288).AddCondition(NPCShop.Entry.Condition.PhaseFull, NPCShop.Entry.Condition.TimeNight);
			clothier.AddEntry(1829).AddCondition(NPCShop.Entry.Condition.PhaseFull, NPCShop.Entry.Condition.TimeNight);

			clothier.AddEntry(325).AddCondition(NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			clothier.AddEntry(326).AddCondition(NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);

			clothier.AddEntry(269);
			clothier.AddEntry(270);
			clothier.AddEntry(271);

			clothier.AddEntry(503).AddCondition(NPCShop.Entry.Condition.DownedClown);
			clothier.AddEntry(504).AddCondition(NPCShop.Entry.Condition.DownedClown);
			clothier.AddEntry(505).AddCondition(NPCShop.Entry.Condition.DownedClown);

			clothier.AddEntry(322).AddCondition(NPCShop.Entry.Condition.BloodMoon);
			clothier.AddEntry(3362).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.TimeNight);
			clothier.AddEntry(3363).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.TimeNight);

			clothier.AddEntry(2856).AddCondition(NPCShop.Entry.Condition.DownedLunaticCultist, NPCShop.Entry.Condition.TimeDay);
			clothier.AddEntry(2858).AddCondition(NPCShop.Entry.Condition.DownedLunaticCultist, NPCShop.Entry.Condition.TimeDay);
			clothier.AddEntry(2857).AddCondition(NPCShop.Entry.Condition.DownedLunaticCultist, NPCShop.Entry.Condition.TimeNight);
			clothier.AddEntry(2859).AddCondition(NPCShop.Entry.Condition.DownedLunaticCultist, NPCShop.Entry.Condition.TimeNight);

			clothier.AddEntry(3242).AddCondition(NetworkText.FromLiteral("441"), () => NPC.AnyNPCs(441));
			clothier.AddEntry(3243).AddCondition(NetworkText.FromLiteral("441"), () => NPC.AnyNPCs(441));
			clothier.AddEntry(3244).AddCondition(NetworkText.FromLiteral("441"), () => NPC.AnyNPCs(441));

			clothier.AddEntry(4685).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.AddEntry(4686).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.AddEntry(4704).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.AddEntry(4705).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.AddEntry(4706).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.AddEntry(4707).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.AddEntry(4708).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);
			clothier.AddEntry(4709).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome);

			clothier.AddEntry(1429).AddCondition(NPCShop.Entry.Condition.InSnow);
			clothier.AddEntry(1740).AddCondition(NPCShop.Entry.Condition.Halloween);

			clothier.AddEntry(869).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtLeft);
			clothier.AddEntry(4994).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			clothier.AddEntry(4997).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			clothier.AddEntry(864).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty);
			clothier.AddEntry(865).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty);
			clothier.AddEntry(4995).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseQuarterAtRight);
			clothier.AddEntry(4998).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseQuarterAtRight);
			clothier.AddEntry(873).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight);
			clothier.AddEntry(874).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight);
			clothier.AddEntry(875).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight);
			clothier.AddEntry(4996).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			clothier.AddEntry(4999).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			clothier.AddEntry(1275).AddCondition(NPCShop.Entry.Condition.DownedFrostLegion);
			clothier.AddEntry(1276).AddCondition(NPCShop.Entry.Condition.DownedFrostLegion);
			clothier.AddEntry(3246).AddCondition(NPCShop.Entry.Condition.Halloween);
			clothier.AddEntry(3247).AddCondition(NPCShop.Entry.Condition.Halloween);

			clothier.AddEntry(3730).AddCondition(NPCShop.Entry.Condition.PartyTime);
			clothier.AddEntry(3731).AddCondition(NPCShop.Entry.Condition.PartyTime);
			clothier.AddEntry(3733).AddCondition(NPCShop.Entry.Condition.PartyTime);
			clothier.AddEntry(3734).AddCondition(NPCShop.Entry.Condition.PartyTime);
			clothier.AddEntry(3735).AddCondition(NPCShop.Entry.Condition.PartyTime);

			clothier.AddEntry(4744).AddCondition(NetworkText.FromLiteral("GoodGolfer"), () => Main.LocalPlayer.golferScoreAccumulated >= 2000);
		}

		private static void SetupShop_Demolitionist()
		{
			NPCShop demolitionist = RegisterShop(NPCID.Demolitionist);

			demolitionist.AddEntry(168);
			demolitionist.AddEntry(166);
			demolitionist.AddEntry(167);

			demolitionist.AddEntry(265).AddCondition(NPCShop.Entry.Condition.Hardmode);
			demolitionist.AddEntry(937).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera, NPCShop.Entry.Condition.DownedPirates);
			demolitionist.AddEntry(1347).AddCondition(NPCShop.Entry.Condition.Hardmode);

			demolitionist.AddEntry(4827).AddCondition(NPCShop.Entry.Condition.HasItem(4827));
			demolitionist.AddEntry(4824).AddCondition(NPCShop.Entry.Condition.HasItem(4824));
			demolitionist.AddEntry(4825).AddCondition(NPCShop.Entry.Condition.HasItem(4825));
			demolitionist.AddEntry(4826).AddCondition(NPCShop.Entry.Condition.HasItem(4826));
		}

		private static void SetupShop_Dryad()
		{
			NPCShop dryad = RegisterShop(NPCID.Dryad);

			dryad.AddEntry(2886).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Crimson);
			dryad.AddEntry(2171).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Crimson);
			dryad.AddEntry(4508).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Crimson);

			dryad.AddEntry(67).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Corruption);
			dryad.AddEntry(59).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Corruption);
			dryad.AddEntry(4504).AddCondition(NPCShop.Entry.Condition.BloodMoon, NPCShop.Entry.Condition.Corruption);

			dryad.AddEntry(66).AddCondition(!NPCShop.Entry.Condition.BloodMoon);
			dryad.AddEntry(62).AddCondition(!NPCShop.Entry.Condition.BloodMoon);
			dryad.AddEntry(63).AddCondition(!NPCShop.Entry.Condition.BloodMoon);
			dryad.AddEntry(745).AddCondition(!NPCShop.Entry.Condition.BloodMoon);

			dryad.AddEntry(59).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.Crimson);
			dryad.AddEntry(2171).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.Corruption);

			dryad.AddEntry(27);
			dryad.AddEntry(114);
			dryad.AddEntry(1828);
			dryad.AddEntry(747);

			dryad.AddEntry(746).AddCondition(NPCShop.Entry.Condition.Hardmode);
			dryad.AddEntry(369).AddCondition(NPCShop.Entry.Condition.Hardmode);
			dryad.AddEntry(4505).AddCondition(NPCShop.Entry.Condition.Hardmode);

			dryad.AddEntry(194).AddCondition(NPCShop.Entry.Condition.InGlowshroom);

			dryad.AddEntry(1853).AddCondition(NPCShop.Entry.Condition.Halloween);
			dryad.AddEntry(1854).AddCondition(NPCShop.Entry.Condition.Halloween);
			dryad.AddEntry(3215).AddCondition(NPCShop.Entry.Condition.DownedKingSlime);
			dryad.AddEntry(3216).AddCondition(NPCShop.Entry.Condition.DownedQueenBee);
			dryad.AddEntry(3219).AddCondition(NPCShop.Entry.Condition.DownedEoC);
			dryad.AddEntry(3217).AddCondition(NPCShop.Entry.Condition.DownedEoW);
			dryad.AddEntry(3218).AddCondition(NPCShop.Entry.Condition.DownedBoC);
			dryad.AddEntry(3220).AddCondition(NPCShop.Entry.Condition.DownedSkeletron);
			dryad.AddEntry(3221).AddCondition(NPCShop.Entry.Condition.DownedSkeletron);

			dryad.AddEntry(3222).AddCondition(NPCShop.Entry.Condition.Hardmode);

			dryad.AddEntry(4047);
			dryad.AddEntry(4045);
			dryad.AddEntry(4044);
			dryad.AddEntry(4043);
			dryad.AddEntry(4042);
			dryad.AddEntry(4046);
			dryad.AddEntry(4041);
			dryad.AddEntry(4241);
			dryad.AddEntry(4048);

			dryad.AddEntry(4430).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			dryad.AddEntry(4431).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);
			dryad.AddEntry(4432).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseFull | NPCShop.Entry.Condition.PhaseThreeQuartersAtLeft);

			dryad.AddEntry(4433).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			dryad.AddEntry(4434).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);
			dryad.AddEntry(4435).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtLeft | NPCShop.Entry.Condition.PhaseQuarterAtLeft);

			dryad.AddEntry(4436).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			dryad.AddEntry(4437).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);
			dryad.AddEntry(4438).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseEmpty | NPCShop.Entry.Condition.PhaseQuarterAtRight);

			dryad.AddEntry(4439).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			dryad.AddEntry(4440).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
			dryad.AddEntry(4441).AddCondition(NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.PhaseHalfAtRight | NPCShop.Entry.Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_ArmsDealer()
		{
			NPCShop armsDealer = RegisterShop(NPCID.ArmsDealer);

			armsDealer.AddEntry(97);

			armsDealer.AddEntry(4915).AddCondition(NetworkText.FromLiteral("23hard"), () => (Main.bloodMoon || Main.hardMode) && WorldGen.SavedOreTiers.Silver == 168);
			armsDealer.AddEntry(278).AddCondition(NetworkText.FromLiteral("23hard"), () => (Main.bloodMoon || Main.hardMode) && WorldGen.SavedOreTiers.Silver != 168);
			armsDealer.AddEntry(47).AddCondition(NetworkText.FromLiteral("23hard"), () => NPC.downedBoss2 && !Main.dayTime || Main.hardMode);

			armsDealer.AddEntry(95);
			armsDealer.AddEntry(98);

			armsDealer.AddEntry(4703).AddCondition(NPCShop.Entry.Condition.InGraveyardBiome, NPCShop.Entry.Condition.DownedSkeletron);
			armsDealer.AddEntry(324).AddCondition(NPCShop.Entry.Condition.TimeNight);
			armsDealer.AddEntry(534).AddCondition(NPCShop.Entry.Condition.Hardmode);
			armsDealer.AddEntry(1432).AddCondition(NPCShop.Entry.Condition.Hardmode);

			armsDealer.AddEntry(1261).AddCondition(NPCShop.Entry.Condition.HasItem(1258));
			armsDealer.AddEntry(1836).AddCondition(NPCShop.Entry.Condition.HasItem(1835));
			armsDealer.AddEntry(3108).AddCondition(NPCShop.Entry.Condition.HasItem(3107));
			armsDealer.AddEntry(1783).AddCondition(NPCShop.Entry.Condition.HasItem(1782));
			armsDealer.AddEntry(1785).AddCondition(NPCShop.Entry.Condition.HasItem(1784));

			armsDealer.AddEntry(1736).AddCondition(NPCShop.Entry.Condition.Halloween);
			armsDealer.AddEntry(1737).AddCondition(NPCShop.Entry.Condition.Halloween);
			armsDealer.AddEntry(1738).AddCondition(NPCShop.Entry.Condition.Halloween);
		}

		private static void SetupShop_Merchant()
		{
			NPCShop merchant = RegisterShop(NPCID.Merchant);

			merchant.AddEntry(88);
			merchant.AddEntry(87);
			merchant.AddEntry(35);
			merchant.AddEntry(1991);
			merchant.AddEntry(3509);
			merchant.AddEntry(3506);
			merchant.AddEntry(8);
			merchant.AddEntry(28);
			merchant.AddEntry(110);
			merchant.AddEntry(40);
			merchant.AddEntry(42);
			merchant.AddEntry(965);

			merchant.AddEntry(967).AddCondition(NPCShop.Entry.Condition.InSnow);
			merchant.AddEntry(33).AddCondition(NPCShop.Entry.Condition.InJungle);
			merchant.AddEntry(4074).AddCondition(NPCShop.Entry.Condition.TimeDay, new NPCShop.Entry.SimpleCondition(NetworkText.FromLiteral("HappyWind"), () => Main.IsItAHappyWindyDay));
			merchant.AddEntry(279).AddCondition(NPCShop.Entry.Condition.BloodMoon);
			merchant.AddEntry(282).AddCondition(NPCShop.Entry.Condition.TimeNight);
			merchant.AddEntry(346).AddCondition(NetworkText.FromLiteral("Boss3"), () => NPC.downedBoss3);
			merchant.AddEntry(488).AddCondition(NPCShop.Entry.Condition.Hardmode);

			merchant.AddEntry(931).AddCondition(NPCShop.Entry.Condition.HasItem(930));
			merchant.AddEntry(1614).AddCondition(NPCShop.Entry.Condition.HasItem(930));

			merchant.AddEntry(1786);
			merchant.AddEntry(1348).AddCondition(NPCShop.Entry.Condition.Hardmode);
			merchant.AddEntry(3198).AddCondition(NPCShop.Entry.Condition.Hardmode);

			merchant.AddEntry(3108).AddCondition(NPCShop.Entry.Condition.HasItem(3107));
			merchant.AddEntry(4063).AddCondition(NetworkText.FromLiteral("23hard"), () => NPC.downedBoss2 || NPC.downedBoss3 || Main.hardMode);
			merchant.AddEntry(4673).AddCondition(NetworkText.FromLiteral("23hard"), () => NPC.downedBoss2 || NPC.downedBoss3 || Main.hardMode);
		}

		private static void SetupShop_Pylons()
		{
			// note: allow modded NPC to sell pylons?
			foreach (KeyValuePair<int, NPCShop> pair in shops)
			{
				if (pair.Key == NPCID.TravellingMerchant || pair.Key == NPCID.SkeletonMerchant || Main.LocalPlayer.currentShoppingSettings.PriceAdjustment > 0.8500000238418579) continue;
				if (Main.LocalPlayer.ZoneCrimson || Main.LocalPlayer.ZoneCorrupt) continue;

				if (!Main.LocalPlayer.ZoneSnow && !Main.LocalPlayer.ZoneDesert && !Main.LocalPlayer.ZoneBeach && !Main.LocalPlayer.ZoneJungle && !Main.LocalPlayer.ZoneHallow && !Main.LocalPlayer.ZoneGlowshroom && Main.LocalPlayer.Center.Y / 16f < Main.worldSurface)
					pair.Value.AddEntry(4876);

				if (Main.LocalPlayer.ZoneSnow)
					pair.Value.AddEntry(4920);

				if (Main.LocalPlayer.ZoneDesert)
					pair.Value.AddEntry(4919);

				if (!Main.LocalPlayer.ZoneSnow && !Main.LocalPlayer.ZoneDesert && !Main.LocalPlayer.ZoneBeach && !Main.LocalPlayer.ZoneJungle && !Main.LocalPlayer.ZoneHallow && !Main.LocalPlayer.ZoneGlowshroom && Main.LocalPlayer.Center.Y / 16f >= Main.worldSurface)
					pair.Value.AddEntry(4917);

				if (Main.LocalPlayer.ZoneBeach && Main.LocalPlayer.position.Y < Main.worldSurface * 16.0)
					pair.Value.AddEntry(4918);

				if (Main.LocalPlayer.ZoneJungle)
					pair.Value.AddEntry(4875);

				if (Main.LocalPlayer.ZoneHallow)
					pair.Value.AddEntry(4916);

				if (Main.LocalPlayer.ZoneGlowshroom)
					pair.Value.AddEntry(4921);
			}
		}

		private class TravellingMerchantList : NPCShop.EntryList
		{
			public override IEnumerable<Item> GetItems(bool checkRequirements = true)
			{
				Player player = null;
				for (int i = 0; i < 255; i++)
				{
					Player player2 = Main.player[i];
					if (player2.active && (player == null || player.luck < player2.luck)) player = player2;
				}

				player ??= new Player();

				int toPick = Main.rand.Next(4, 7);
				if (player.RollLuck(4) == 0) toPick++;
				if (player.RollLuck(8) == 0) toPick++;
				if (player.RollLuck(16) == 0) toPick++;
				if (player.RollLuck(32) == 0) toPick++;
				if (Main.expertMode && player.RollLuck(2) == 0) toPick++;

				List<NPCShop.Entry> evaluated = new List<NPCShop.Entry>();

				int roll = 0;
				while (roll < toPick)
				{
					NPCShop.Entry entry = entries.LastOrDefault(entry => entry.Conditions.All(condition =>
					{
						// todo: generalize this
						if (condition is LuckCondition luckCondition) luckCondition.player = player;
						return condition.Evaluate();
					}));

					if (entry == null || evaluated.Contains(entry)) continue;
					evaluated.Add(entry);

					roll++;

					foreach (Item item in entry.GetItems(false)) yield return item;
				}
			}
		}

		public class LuckCondition : NPCShop.Entry.Condition
		{
			private int range;
			public Player player;

			public LuckCondition(int range) : base(NetworkText.FromLiteral("Luck"))
			{
				this.range = range;
			}

			public override bool Evaluate() => player.RollLuck(range) == 0;
		}

		private static void SetupShop_TravellingMerchant()
		{
			NPCShop travellingMerchant = RegisterShop(NPCID.TravellingMerchant);
			travellingMerchant.EvaluateOnOpen = false;

			TravellingMerchantList list = new TravellingMerchantList();
			travellingMerchant.AddEntry(list);

			static NPCShop.Entry.Condition LuckCondition(int range) => new LuckCondition(range);

			int[] array = { 100, 200, 300, 400, 500, 600 };

			list.AddEntry(3309).AddCondition(LuckCondition(array[4]));
			list.AddEntry(3314).AddCondition(LuckCondition(array[3]));
			list.AddEntry(1987).AddCondition(LuckCondition(array[5]));
			list.AddEntry(2270).AddCondition(LuckCondition(array[4]), NPCShop.Entry.Condition.Hardmode);
			list.AddEntry(2278).AddCondition(LuckCondition(array[4]));
			list.AddEntry(2271).AddCondition(LuckCondition(array[4]));

			list.AddEntry(4347).AddCondition(LuckCondition(array[4]), NPCShop.Entry.Condition.DownedEoC | NPCShop.Entry.Condition.DownedEvilBoss | NPCShop.Entry.Condition.DownedSkeletron | NPCShop.Entry.Condition.DownedQueenBee);
			list.AddEntry(4348).AddCondition(LuckCondition(array[4]), NPCShop.Entry.Condition.Hardmode);

			list.AddEntry(2223).AddCondition(LuckCondition(array[3]), NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedPlantera);
			list.AddEntry(2272).AddCondition(LuckCondition(array[3]));
			list.AddEntry(2219).AddCondition(LuckCondition(array[3]));
			list.AddEntry(2276).AddCondition(LuckCondition(array[3]));
			list.AddEntry(2284).AddCondition(LuckCondition(array[3]));
			list.AddEntry(2285).AddCondition(LuckCondition(array[3]));
			list.AddEntry(2286).AddCondition(LuckCondition(array[3]));
			list.AddEntry(2287).AddCondition(LuckCondition(array[3]));

			list.AddEntry(4744).AddCondition(LuckCondition(array[3]));
			list.AddEntry(2296).AddCondition(LuckCondition(array[3]), NPCShop.Entry.Condition.DownedSkeletron);
			list.AddEntry(3628).AddCondition(LuckCondition(array[3]));
			list.AddEntry(4091).AddCondition(LuckCondition(array[3]), NPCShop.Entry.Condition.Hardmode);
			list.AddEntry(4603).AddCondition(LuckCondition(array[3]));
			list.AddEntry(4604).AddCondition(LuckCondition(array[3]));
			list.AddEntry(4605).AddCondition(LuckCondition(array[3]));
			list.AddEntry(4550).AddCondition(LuckCondition(array[3]));
			list.AddEntry(4550).AddCondition(LuckCondition(array[3]));

			list.AddEntry(2269).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.OrbSmashed);
			list.AddEntry(2177).AddCondition(LuckCondition(array[2]));
			list.AddEntry(1988).AddCondition(LuckCondition(array[2]));
			list.AddEntry(2275).AddCondition(LuckCondition(array[2]));
			list.AddEntry(2279).AddCondition(LuckCondition(array[2]));
			list.AddEntry(2277).AddCondition(LuckCondition(array[2]));
			list.AddEntry(4555).AddCondition(LuckCondition(array[2]));

			NPCShop.EntryList chefOutfit = new NPCShop.EntryList();
			chefOutfit.AddEntry(4555);
			chefOutfit.AddEntry(4556);
			chefOutfit.AddEntry(4557);
			list.AddEntry(chefOutfit).AddCondition(LuckCondition(array[2]));

			NPCShop.EntryList gameMasterOutfit = new NPCShop.EntryList();
			gameMasterOutfit.AddEntry(4321);
			gameMasterOutfit.AddEntry(4322);
			list.AddEntry(gameMasterOutfit).AddCondition(LuckCondition(array[2]));

			list.AddEntry(4323).AddCondition(LuckCondition(array[2]));

			NPCShop.EntryList princessOutfit = new NPCShop.EntryList();
			princessOutfit.AddEntry(4323);
			princessOutfit.AddEntry(4324);
			princessOutfit.AddEntry(4365);
			list.AddEntry(princessOutfit).AddCondition(LuckCondition(array[2]));

			list.AddEntry(4549).AddCondition(LuckCondition(array[2]));
			list.AddEntry(4561).AddCondition(LuckCondition(array[2]));
			list.AddEntry(4774).AddCondition(LuckCondition(array[2]));
			list.AddEntry(4562).AddCondition(LuckCondition(array[2]));
			list.AddEntry(4558).AddCondition(LuckCondition(array[2]));
			list.AddEntry(4559).AddCondition(LuckCondition(array[2]));
			list.AddEntry(4563).AddCondition(LuckCondition(array[2]));

			NPCShop.EntryList prettyPink = new NPCShop.EntryList();
			prettyPink.AddEntry(4666);
			prettyPink.AddEntry(4665);
			prettyPink.AddEntry(4664);
			list.AddEntry(prettyPink).AddCondition(LuckCondition(array[2]));

			list.AddEntry(3262).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.DownedEoC);
			list.AddEntry(3284).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.DownedAnyMechBoss);
			list.AddEntry(3596).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMoonLord);
			list.AddEntry(2865).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMartians);
			list.AddEntry(2866).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMartians);
			list.AddEntry(2867).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Hardmode, NPCShop.Entry.Condition.DownedMartians);
			list.AddEntry(3055).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Christmas);
			list.AddEntry(3056).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Christmas);
			list.AddEntry(3057).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Christmas);
			list.AddEntry(3058).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Christmas);
			list.AddEntry(3059).AddCondition(LuckCondition(array[2]), NPCShop.Entry.Condition.Christmas);

			list.AddEntry(2214).AddCondition(LuckCondition(array[1]));
			list.AddEntry(2215).AddCondition(LuckCondition(array[1]));
			list.AddEntry(2216).AddCondition(LuckCondition(array[1]));
			list.AddEntry(2217).AddCondition(LuckCondition(array[1]));
			list.AddEntry(3624).AddCondition(LuckCondition(array[1]));
			list.AddEntry(2273).AddCondition(LuckCondition(array[1]));
			list.AddEntry(2274).AddCondition(LuckCondition(array[1]));

			list.AddEntry(2266).AddCondition(LuckCondition(array[0]));
			list.AddEntry(2267).AddCondition(LuckCondition(array[0]));
			list.AddEntry(2268).AddCondition(LuckCondition(array[0]));

			NPCShop.EntryListRandom skins = new NPCShop.EntryListRandom();
			skins.AddEntry(2281);
			skins.AddEntry(2282);
			skins.AddEntry(2283);
			list.AddEntry(skins).AddCondition(LuckCondition(array[0]));

			list.AddEntry(2274).AddCondition(LuckCondition(array[0]));

			list.AddEntry(2258).AddCondition(LuckCondition(array[0]));
			list.AddEntry(2242).AddCondition(LuckCondition(array[0]));

			NPCShop.EntryList dynastyWood = new NPCShop.EntryList();
			dynastyWood.AddEntry(2260);
			dynastyWood.AddEntry(2261);
			dynastyWood.AddEntry(2262);
			list.AddEntry(dynastyWood).AddCondition(LuckCondition(array[0]));

			NPCShop.EntryListRandom teamBlocks = new NPCShop.EntryListRandom();
			{
				NPCShop.EntryList team = new NPCShop.EntryList();
				team.AddEntry(3637);
				team.AddEntry(3642);
				teamBlocks.AddEntry(team);

				team = new NPCShop.EntryList();
				team.AddEntry(3621);
				team.AddEntry(3622);
				teamBlocks.AddEntry(team);

				team = new NPCShop.EntryList();
				team.AddEntry(3634);
				team.AddEntry(3639);
				teamBlocks.AddEntry(team);

				team = new NPCShop.EntryList();
				team.AddEntry(3633);
				team.AddEntry(3638);
				teamBlocks.AddEntry(team);

				team = new NPCShop.EntryList();
				team.AddEntry(3635);
				team.AddEntry(3640);
				teamBlocks.AddEntry(team);

				team = new NPCShop.EntryList();
				team.AddEntry(3636);
				team.AddEntry(3641);
				teamBlocks.AddEntry(team);
			}
			list.AddEntry(teamBlocks).AddCondition(LuckCondition(array[0]));

			list.AddEntry(4420).AddCondition(LuckCondition(array[0]));
			list.AddEntry(3119).AddCondition(LuckCondition(array[0]));
			list.AddEntry(3118).AddCondition(LuckCondition(array[0]));
			list.AddEntry(3099).AddCondition(LuckCondition(array[0]));
		}
	}
}