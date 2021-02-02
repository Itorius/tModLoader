using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader.Container;
using Condition = Terraria.ModLoader.NPCShop.Entry.Condition;

namespace Terraria.ModLoader
{
	public static partial class NPCShopManager
	{
		private static void SetupShop_Zoologist()
		{
			NPCShop zoologist = RegisterShop(NPCID.BestiaryGirl);

			zoologist.CreateEntry(4776).AddCondition(NetworkText.FromKey("ShopConditions.FairyTorch"), () =>
			{
				static bool DidDiscoverBestiaryEntry(int npcId) => Main.BestiaryDB.FindEntryByNPCID(npcId).UIInfoProvider.GetEntryUICollectionInfo().UnlockState > BestiaryEntryUnlockState.NotKnownAtAll_0;

				return DidDiscoverBestiaryEntry(585) && DidDiscoverBestiaryEntry(584) && DidDiscoverBestiaryEntry(583);
			});

			zoologist.CreateEntry(4767);
			zoologist.CreateEntry(4759);

			zoologist.CreateEntry(4672).AddCondition(Condition.BestiaryCompletion(0.1f));
			zoologist.CreateEntry(4829).AddCondition(NetworkText.FromKey("ShopConditions.NotBoughtCat"), () => !NPC.boughtCat);
			zoologist.CreateEntry(4830).AddCondition(new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.NotBoughtDog"), () => !NPC.boughtDog), Condition.BestiaryCompletion(0.25f));
			zoologist.CreateEntry(4910).AddCondition(new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.NotBoughtBunny"), () => !NPC.boughtBunny), Condition.BestiaryCompletion(0.45f));

			zoologist.CreateEntry(4871).AddCondition(Condition.BestiaryCompletion(0.3f));
			zoologist.CreateEntry(4907).AddCondition(Condition.BestiaryCompletion(0.4f));

			zoologist.CreateEntry(4677).AddCondition(Condition.DownedSolarTower);

			zoologist.CreateEntry(4676).AddCondition(Condition.BestiaryCompletion(0.1f));
			zoologist.CreateEntry(4762).AddCondition(Condition.BestiaryCompletion(0.3f));
			zoologist.CreateEntry(4716).AddCondition(Condition.BestiaryCompletion(0.25f));
			zoologist.CreateEntry(4785).AddCondition(Condition.BestiaryCompletion(0.3f));
			zoologist.CreateEntry(4786).AddCondition(Condition.BestiaryCompletion(0.3f));
			zoologist.CreateEntry(4787).AddCondition(Condition.BestiaryCompletion(0.3f));
			zoologist.CreateEntry(4788).AddCondition(Condition.BestiaryCompletion(0.3f), Condition.Hardmode);
			zoologist.CreateEntry(4955).AddCondition(Condition.BestiaryCompletion(0.4f));

			zoologist.CreateEntry(4736).AddCondition(Condition.Hardmode, Condition.BloodMoon);
			zoologist.CreateEntry(4701).AddCondition(Condition.DownedPlantera);

			zoologist.CreateEntry(4765).AddCondition(Condition.BestiaryCompletion(0.5f));
			zoologist.CreateEntry(4766).AddCondition(Condition.BestiaryCompletion(0.5f));
			zoologist.CreateEntry(4777).AddCondition(Condition.BestiaryCompletion(0.5f));
			zoologist.CreateEntry(4763).AddCondition(Condition.BestiaryCompletion(0.6f));
			zoologist.CreateEntry(4735).AddCondition(Condition.BestiaryCompletion(0.7f));
			zoologist.CreateEntry(4751).AddCondition(Condition.BestiaryCompletion(1f));

			zoologist.CreateEntry(4768).AddCondition(Condition.PhaseFull | Condition.PhaseThreeQuartersAtLeft);
			zoologist.CreateEntry(4769).AddCondition(Condition.PhaseFull | Condition.PhaseThreeQuartersAtLeft);

			zoologist.CreateEntry(4770).AddCondition(Condition.PhaseHalfAtLeft | Condition.PhaseQuarterAtLeft);
			zoologist.CreateEntry(4771).AddCondition(Condition.PhaseHalfAtLeft | Condition.PhaseQuarterAtLeft);

			zoologist.CreateEntry(4772).AddCondition(Condition.PhaseEmpty | Condition.PhaseQuarterAtRight);
			zoologist.CreateEntry(4773).AddCondition(Condition.PhaseEmpty | Condition.PhaseQuarterAtRight);

			zoologist.CreateEntry(4560).AddCondition(Condition.PhaseHalfAtRight | Condition.PhaseThreeQuartersAtRight);
			zoologist.CreateEntry(4775).AddCondition(Condition.PhaseHalfAtRight | Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_Golfer()
		{
			NPCShop golfer = RegisterShop(NPCID.Golfer);

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

			golfer.CreateEntry(4039).AddCondition(Condition.GolfScore(500));
			golfer.CreateEntry(4094).AddCondition(Condition.GolfScore(500));
			golfer.CreateEntry(4093).AddCondition(Condition.GolfScore(500));
			golfer.CreateEntry(1092).AddCondition(Condition.GolfScore(500));

			golfer.CreateEntry(4089);
			golfer.CreateEntry(3979);
			golfer.CreateEntry(4095);
			golfer.CreateEntry(4040);
			golfer.CreateEntry(4319);
			golfer.CreateEntry(4320);

			golfer.CreateEntry(4591).AddCondition(Condition.GolfScore(1000));
			golfer.CreateEntry(4594).AddCondition(Condition.GolfScore(1000));
			golfer.CreateEntry(4593).AddCondition(Condition.GolfScore(1000));
			golfer.CreateEntry(4592).AddCondition(Condition.GolfScore(1000));

			golfer.CreateEntry(4135);
			golfer.CreateEntry(4138);
			golfer.CreateEntry(4136);
			golfer.CreateEntry(4137);
			golfer.CreateEntry(4049);

			golfer.CreateEntry(4265).AddCondition(Condition.GolfScore(500));

			golfer.CreateEntry(4595).AddCondition(Condition.GolfScore(2000));
			golfer.CreateEntry(4598).AddCondition(Condition.GolfScore(2000));
			golfer.CreateEntry(4597).AddCondition(Condition.GolfScore(2000));
			golfer.CreateEntry(4596).AddCondition(Condition.GolfScore(2000));
			golfer.CreateEntry(4264).AddCondition(Condition.GolfScore(2000), Condition.DownedSkeletron);

			golfer.CreateEntry(4599).AddCondition(Condition.GolfScore(500));
			golfer.CreateEntry(4600).AddCondition(Condition.GolfScore(999));
			golfer.CreateEntry(4601).AddCondition(Condition.GolfScore(1999));

			golfer.CreateEntry(4658).AddCondition(Condition.GolfScore(1999), Condition.PhaseFull | Condition.PhaseThreeQuartersAtLeft);
			golfer.CreateEntry(4659).AddCondition(Condition.GolfScore(1999), Condition.PhaseHalfAtLeft | Condition.PhaseQuarterAtLeft);
			golfer.CreateEntry(4660).AddCondition(Condition.GolfScore(1999), Condition.PhaseEmpty | Condition.PhaseQuarterAtRight);
			golfer.CreateEntry(4661).AddCondition(Condition.GolfScore(1999), Condition.PhaseHalfAtRight | Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_Princess()
		{
			NPCShop princess = RegisterShop(NPCID.Princess);

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
			princess.CreateEntry(5044).AddCondition(Condition.Hardmode, Condition.DownedMoonLord);
		}

		private static void SetupShop_Bartender()
		{
			NPCShop bartender = RegisterShop(NPCID.DD2Bartender);

			Condition condition1 = Condition.Hardmode & Condition.DownedAnyMechBoss;
			Condition condition2 = Condition.Hardmode & Condition.DownedGolem;

			bartender.CreateEntry(353);

			bartender.CreateEntry(3828).SetPrice(Item.buyPrice(gold: 4)).AddCondition(condition1, condition2);
			bartender.CreateEntry(3828).SetPrice(Item.buyPrice(gold: 1)).AddCondition(condition1, !condition2);
			bartender.CreateEntry(3828).SetPrice(Item.buyPrice(silver: 25)).AddCondition(!condition1, !condition2);

			bartender.CreateEntry(3816);

			bartender.CreateEntry(3813).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75);
			bartender.CreateEntry(3818).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(5);
			bartender.CreateEntry(3824).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(5);
			bartender.CreateEntry(3832).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(5);
			bartender.CreateEntry(3829).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(5);

			bartender.CreateEntry(3819).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3825).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3833).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3830).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);

			bartender.CreateEntry(3820).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(100).AddCondition(condition2);
			bartender.CreateEntry(3826).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(100).AddCondition(condition2);
			bartender.CreateEntry(3834).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(100).AddCondition(condition2);
			bartender.CreateEntry(3831).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(100).AddCondition(condition2);

			bartender.CreateEntry(3800).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3801).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3802).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3797).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3798).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3799).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3803).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3804).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3805).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3806).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3807).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);
			bartender.CreateEntry(3808).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(25).AddCondition(condition1);

			bartender.CreateEntry(3871).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3872).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3873).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3874).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3875).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3876).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3877).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3878).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3879).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3880).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3881).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
			bartender.CreateEntry(3882).SetCurrency(CustomCurrencyID.DefenderMedals).SetPrice(75).AddCondition(condition2);
		}

		private static void SetupShop_SkeletonMerchant()
		{
			NPCShop skeletonMerchant = RegisterShop(NPCID.SkeletonMerchant);

			skeletonMerchant.CreateEntry(3001).AddCondition(Condition.PhaseFull | Condition.PhaseHalfAtLeft | Condition.PhaseEmpty | Condition.PhaseHalfAtRight);
			skeletonMerchant.CreateEntry(3001).AddCondition(Condition.PhaseQuarterAtLeft | Condition.PhaseThreeQuartersAtLeft | Condition.PhaseQuarterAtRight | Condition.PhaseThreeQuartersAtRight);

			skeletonMerchant.CreateEntry(3002).AddCondition(Condition.TimeNight | Condition.PhaseFull);
			skeletonMerchant.CreateEntry(282).AddCondition(!(Condition.TimeNight | Condition.PhaseFull));

			Condition cond = new NPCShop.Entry.SimpleCondition(NetworkText.FromLiteral("ShopConditions.MinuteTime"), () => Main.time % 60.0 * 60.0 * 6.0 <= 10800.0);
			skeletonMerchant.CreateEntry(3004).AddCondition(cond);
			skeletonMerchant.CreateEntry(8).AddCondition(!cond);

			cond = Condition.PhaseFull | Condition.PhaseQuarterAtLeft | Condition.PhaseEmpty | Condition.PhaseQuarterAtRight;
			skeletonMerchant.CreateEntry(3003).AddCondition(cond);
			skeletonMerchant.CreateEntry(40).AddCondition(!cond);

			skeletonMerchant.CreateEntry(3310).AddCondition(Condition.PhaseFull | Condition.PhaseEmpty);
			skeletonMerchant.CreateEntry(3313).AddCondition(Condition.PhaseThreeQuartersAtLeft | Condition.PhaseQuarterAtRight);
			skeletonMerchant.CreateEntry(3312).AddCondition(Condition.PhaseHalfAtLeft | Condition.PhaseHalfAtRight);
			skeletonMerchant.CreateEntry(3311).AddCondition(Condition.PhaseQuarterAtLeft | Condition.PhaseThreeQuartersAtRight);

			skeletonMerchant.CreateEntry(166);
			skeletonMerchant.CreateEntry(965);

			skeletonMerchant.CreateEntry(3316).AddCondition(Condition.Hardmode, Condition.PhaseFull | Condition.PhaseQuarterAtLeft | Condition.PhaseHalfAtLeft | Condition.PhaseThreeQuartersAtLeft);
			skeletonMerchant.CreateEntry(3315).AddCondition(Condition.Hardmode, Condition.PhaseEmpty | Condition.PhaseQuarterAtRight | Condition.PhaseHalfAtRight | Condition.PhaseThreeQuartersAtRight);
			skeletonMerchant.CreateEntry(3334).AddCondition(Condition.Hardmode);
			skeletonMerchant.CreateEntry(3258).AddCondition(Condition.Hardmode, Condition.BloodMoon);
			skeletonMerchant.CreateEntry(3043).AddCondition(Condition.PhaseFull, Condition.TimeNight);
		}

		private static void SetupShop_Stylist()
		{
			NPCShop stylist = RegisterShop(NPCID.Stylist);

			stylist.CreateEntry(1990);
			stylist.CreateEntry(1979);
			stylist.CreateEntry(1977).AddCondition(NetworkText.FromKey("ShopConditions.Health400"), () => Main.LocalPlayer.statLifeMax >= 400);
			stylist.CreateEntry(1978).AddCondition(NetworkText.FromKey("ShopConditions.Mana200"), () => Main.LocalPlayer.statManaMax >= 200);
			stylist.CreateEntry(1980).AddCondition(NetworkText.FromKey("ShopConditions.HasPlatinum"), () => Main.LocalPlayer.inventory.CountCoins() >= 1000000);

			stylist.CreateEntry(1981).AddCondition(
				(Condition.TimeNight & (Condition.PhaseThreeQuartersAtLeft | Condition.PhaseQuarterAtLeft | Condition.PhaseQuarterAtRight | Condition.PhaseThreeQuartersAtRight)) |
				(Condition.TimeDay & (Condition.PhaseFull | Condition.PhaseHalfAtLeft | Condition.PhaseEmpty | Condition.PhaseHalfAtRight)));
			stylist.CreateEntry(1982).AddCondition(NetworkText.FromKey("ShopConditions.TeamPlayer"), () => Main.LocalPlayer.team != 0);
			stylist.CreateEntry(1983).AddCondition(Condition.Hardmode);
			stylist.CreateEntry(1984).AddCondition(Condition.NPCExists(208));
			stylist.CreateEntry(1985).AddCondition(Condition.Hardmode, Condition.DownedDestroyer, Condition.DownedTwins, Condition.DownedSkeletronPrime);
			stylist.CreateEntry(1986).AddCondition(Condition.Hardmode, Condition.DownedAnyMechBoss);
			stylist.CreateEntry(2863).AddCondition(Condition.Hardmode, Condition.DownedMartians);
			stylist.CreateEntry(3259).AddCondition(Condition.Hardmode, Condition.DownedMartians);
		}

		private static void SetupShop_Pirate()
		{
			NPCShop pirate = RegisterShop(NPCID.Pirate);

			pirate.CreateEntry(928);
			pirate.CreateEntry(929);
			pirate.CreateEntry(876);
			pirate.CreateEntry(877);
			pirate.CreateEntry(878);
			pirate.CreateEntry(2434);
			pirate.CreateEntry(1180).AddCondition(Condition.InOcean);
			pirate.CreateEntry(1337).AddCondition(Condition.Hardmode, Condition.DownedAnyMechBoss, Condition.NPCExists(208));
		}

		private static void SetupShop_WitchDoctor()
		{
			NPCShop witchDoctor = RegisterShop(NPCID.WitchDoctor);

			witchDoctor.CreateEntry(1430);
			witchDoctor.CreateEntry(986);

			witchDoctor.CreateEntry(2999).AddCondition(Condition.NPCExists(108));
			witchDoctor.CreateEntry(1158).AddCondition(Condition.TimeNight);
			witchDoctor.CreateEntry(1159).AddCondition(Condition.Hardmode, Condition.DownedPlantera);
			witchDoctor.CreateEntry(1160).AddCondition(Condition.Hardmode, Condition.DownedPlantera);
			witchDoctor.CreateEntry(1161).AddCondition(Condition.Hardmode, Condition.DownedPlantera);
			witchDoctor.CreateEntry(1167).AddCondition(Condition.Hardmode, Condition.DownedPlantera, Condition.InJungle);
			witchDoctor.CreateEntry(1339).AddCondition(Condition.Hardmode, Condition.DownedPlantera);

			witchDoctor.CreateEntry(1171).AddCondition(Condition.Hardmode, Condition.InJungle);
			witchDoctor.CreateEntry(1162).AddCondition(Condition.Hardmode, Condition.InJungle, Condition.TimeNight);

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
			witchDoctor.CreateEntry(1836).AddCondition(Condition.HasItem(1835));
			witchDoctor.CreateEntry(1261).AddCondition(Condition.HasItem(1258));
			witchDoctor.CreateEntry(1791).AddCondition(Condition.Halloween);
		}

		private static void SetupShop_Painer()
		{
			NPCShop painter = RegisterShop(NPCID.Painter);

			painter.CreateEntry(1071);
			painter.CreateEntry(1072);
			painter.CreateEntry(1073);

			for (int i = 1073; i <= 1084; i++) painter.CreateEntry(i);

			painter.CreateEntry(1097);
			painter.CreateEntry(1099);
			painter.CreateEntry(1098);
			painter.CreateEntry(1966);
			painter.CreateEntry(4668).AddCondition(Condition.InGraveyardBiome);
			painter.CreateEntry(1967).AddCondition(Condition.Hardmode);
			painter.CreateEntry(1968).AddCondition(Condition.Hardmode);
			painter.CreateEntry(1490).AddCondition(Condition.InGraveyardBiome);
			painter.CreateEntry(1481).AddCondition(Condition.InGraveyardBiome, Condition.PhaseFull, Condition.PhaseQuarterAtLeft);
			painter.CreateEntry(1482).AddCondition(Condition.InGraveyardBiome, Condition.PhaseHalfAtLeft, Condition.PhaseThreeQuartersAtLeft);
			painter.CreateEntry(1483).AddCondition(Condition.InGraveyardBiome, Condition.PhaseEmpty, Condition.PhaseQuarterAtRight);
			painter.CreateEntry(1484).AddCondition(Condition.InGraveyardBiome, Condition.PhaseHalfAtRight, Condition.PhaseThreeQuartersAtRight);

			painter.CreateEntry(1492).AddCondition(Condition.InCrimson);
			painter.CreateEntry(1488).AddCondition(Condition.InCorrupt);
			painter.CreateEntry(1489).AddCondition(Condition.InHallow);
			painter.CreateEntry(1486).AddCondition(Condition.InJungle);
			painter.CreateEntry(1487).AddCondition(Condition.InSnow);
			painter.CreateEntry(1491).AddCondition(Condition.InDesert);
			painter.CreateEntry(1493).AddCondition(Condition.BloodMoon);

			painter.CreateEntry(1485).AddCondition(!Condition.InGraveyardBiome, Condition.InSpace, Condition.BloodMoon);
			painter.CreateEntry(1494).AddCondition(!Condition.InGraveyardBiome, Condition.InSpace, Condition.Hardmode);

			painter.CreateEntry(4723).AddCondition(Condition.InGraveyardBiome);
			painter.CreateEntry(4724).AddCondition(Condition.InGraveyardBiome);
			painter.CreateEntry(4725).AddCondition(Condition.InGraveyardBiome);
			painter.CreateEntry(4726).AddCondition(Condition.InGraveyardBiome);
			painter.CreateEntry(4727).AddCondition(Condition.InGraveyardBiome);
			painter.CreateEntry(4728).AddCondition(Condition.InGraveyardBiome);
			painter.CreateEntry(4729).AddCondition(Condition.InGraveyardBiome);

			for (int i = 1948; i <= 1957; i++) painter.CreateEntry(i).AddCondition(Condition.Christmas);
			for (int i = 2158; i <= 2160; i++) painter.CreateEntry(i);
			for (int i = 2008; i <= 2014; i++) painter.CreateEntry(i);
		}

		private static void SetupShop_Cyborg()
		{
			NPCShop cyborg = RegisterShop(NPCID.Cyborg);

			cyborg.CreateEntry(771);
			cyborg.CreateEntry(772).AddCondition(Condition.BloodMoon);
			cyborg.CreateEntry(773).AddCondition(Condition.TimeNight | Condition.SolarEclipse);
			cyborg.CreateEntry(774).AddCondition(Condition.SolarEclipse);
			cyborg.CreateEntry(4445).AddCondition(Condition.DownedMartians);
			cyborg.CreateEntry(4446).AddCondition(Condition.DownedMartians, Condition.BloodMoon | Condition.SolarEclipse);
			cyborg.CreateEntry(4459).AddCondition(Condition.Hardmode);
			cyborg.CreateEntry(760).AddCondition(Condition.Hardmode);
			cyborg.CreateEntry(1346).AddCondition(Condition.Hardmode);
			cyborg.CreateEntry(4409).AddCondition(Condition.InGraveyardBiome);
			cyborg.CreateEntry(4392).AddCondition(Condition.InGraveyardBiome);
			cyborg.CreateEntry(1743).AddCondition(Condition.Halloween);
			cyborg.CreateEntry(1744).AddCondition(Condition.Halloween);
			cyborg.CreateEntry(1745).AddCondition(Condition.Halloween);
			cyborg.CreateEntry(2862).AddCondition(Condition.DownedMartians);
			cyborg.CreateEntry(3109).AddCondition(Condition.DownedMartians);
			cyborg.CreateEntry(3664).AddCondition(Condition.HasItem(33840) | Condition.HasItem(3664));
		}

		private static void SetupShop_PartyGirl()
		{
			NPCShop partyGirl = RegisterShop(NPCID.PartyGirl);

			partyGirl.CreateEntry(859);
			partyGirl.CreateEntry(4743).AddCondition(Condition.GolfScore(500));
			partyGirl.CreateEntry(1000);
			partyGirl.CreateEntry(1168);
			partyGirl.CreateEntry(1449).AddCondition(Condition.TimeDay);
			partyGirl.CreateEntry(4552).AddCondition(Condition.TimeNight);
			partyGirl.CreateEntry(1345);
			partyGirl.CreateEntry(1450);
			partyGirl.CreateEntry(3253);
			partyGirl.CreateEntry(4553);
			partyGirl.CreateEntry(2700);
			partyGirl.CreateEntry(2738);
			partyGirl.CreateEntry(4470);
			partyGirl.CreateEntry(4681);

			partyGirl.CreateEntry(4682).AddCondition(Condition.InGraveyardBiome);
			partyGirl.CreateEntry(4702).AddCondition(Condition.Lanterns);
			partyGirl.CreateEntry(3548).AddCondition(Condition.HasItem(3548));
			partyGirl.CreateEntry(3369).AddCondition(Condition.NPCExists(229));
			partyGirl.CreateEntry(3546).AddCondition(Condition.DownedGolem);

			partyGirl.CreateEntry(3214).AddCondition(Condition.Hardmode);
			partyGirl.CreateEntry(2868).AddCondition(Condition.Hardmode);
			partyGirl.CreateEntry(970).AddCondition(Condition.Hardmode);
			partyGirl.CreateEntry(971).AddCondition(Condition.Hardmode);
			partyGirl.CreateEntry(972).AddCondition(Condition.Hardmode);
			partyGirl.CreateEntry(973).AddCondition(Condition.Hardmode);

			partyGirl.CreateEntry(4791);
			partyGirl.CreateEntry(3747);
			partyGirl.CreateEntry(3732);
			partyGirl.CreateEntry(3742);

			partyGirl.CreateEntry(3749).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3746).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3739).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3740).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3741).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3737).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3738).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3736).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3745).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3744).AddCondition(Condition.PartyTime);
			partyGirl.CreateEntry(3743).AddCondition(Condition.PartyTime);
		}

		private static void SetupShop_DyeTrader()
		{
			NPCShop dyeTrader = RegisterShop(NPCID.DyeTrader);

			dyeTrader.CreateEntry(1037);
			dyeTrader.CreateEntry(2874);
			dyeTrader.CreateEntry(1120);
			dyeTrader.CreateEntry(1969).AddCondition(NetworkText.FromKey("ShopConditions.Multiplayer"), () => Main.netMode == NetmodeID.MultiplayerClient);
			dyeTrader.CreateEntry(3248).AddCondition(Condition.Halloween);
			dyeTrader.CreateEntry(1741).AddCondition(Condition.Halloween);
			dyeTrader.CreateEntry(2871).AddCondition(Condition.PhaseFull);
			dyeTrader.CreateEntry(2872).AddCondition(Condition.PhaseFull);
			dyeTrader.CreateEntry(4663).AddCondition(Condition.TimeNight, Condition.BloodMoon);
			dyeTrader.CreateEntry(4662).AddCondition(Condition.InGraveyardBiome);
		}

		private static void SetupShop_Steampunker()
		{
			NPCShop steampunker = RegisterShop(NPCID.Steampunker);

			steampunker.CreateEntry(779);

			steampunker.CreateEntry(748).AddCondition(Condition.PhaseEmpty | Condition.PhaseQuarterAtRight | Condition.PhaseHalfAtRight | Condition.PhaseThreeQuartersAtRight);
			steampunker.CreateEntry(839).AddCondition(Condition.PhaseFull | Condition.PhaseQuarterAtLeft | Condition.PhaseHalfAtLeft | Condition.PhaseThreeQuartersAtLeft);
			steampunker.CreateEntry(840).AddCondition(Condition.PhaseFull | Condition.PhaseQuarterAtLeft | Condition.PhaseHalfAtLeft | Condition.PhaseThreeQuartersAtLeft);
			steampunker.CreateEntry(841).AddCondition(Condition.PhaseFull | Condition.PhaseQuarterAtLeft | Condition.PhaseHalfAtLeft | Condition.PhaseThreeQuartersAtLeft);

			steampunker.CreateEntry(948).AddCondition(Condition.DownedGolem);
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

			steampunker.CreateEntry(2203).AddCondition(Condition.DownedEoC, Condition.DownedEvilBoss, Condition.DownedSkeletron);

			steampunker.CreateEntry(2193).AddCondition(Condition.Crimson);
			steampunker.CreateEntry(4142).AddCondition(Condition.Corruption);
			steampunker.CreateEntry(2192).AddCondition(Condition.InGraveyardBiome);
			steampunker.CreateEntry(2204).AddCondition(Condition.InJungle);
			steampunker.CreateEntry(2198).AddCondition(Condition.InSnow);

			steampunker.CreateEntry(2197).AddCondition(Condition.InSpace);
			steampunker.CreateEntry(2196).AddCondition(Condition.HasItem(832));
			steampunker.CreateEntry(1263);
			steampunker.CreateEntry(784).AddCondition(Condition.AstrologicalEvent, Condition.Crimson);
			steampunker.CreateEntry(782).AddCondition(Condition.AstrologicalEvent, Condition.Corruption);

			steampunker.CreateEntry(781).AddCondition(!Condition.AstrologicalEvent, Condition.InHallow);
			steampunker.CreateEntry(780).AddCondition(!Condition.AstrologicalEvent, !Condition.InHallow);

			steampunker.CreateEntry(1344).AddCondition(Condition.Hardmode);
			steampunker.CreateEntry(4472).AddCondition(Condition.Hardmode);
			steampunker.CreateEntry(1742).AddCondition(Condition.Halloween);
		}

		private static void SetupShop_Truffle()
		{
			NPCShop truffle = RegisterShop(NPCID.Truffle);

			truffle.CreateEntry(756).AddCondition(Condition.DownedAnyMechBoss);
			truffle.CreateEntry(787).AddCondition(Condition.DownedAnyMechBoss);

			truffle.CreateEntry(868);
			truffle.CreateEntry(1551).AddCondition(Condition.DownedPlantera);
			truffle.CreateEntry(1181);
			truffle.CreateEntry(783);
		}

		private static void SetupShop_SantaClaus()
		{
			NPCShop santaClaus = RegisterShop(NPCID.SantaClaus);

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
			NPCShop mechanic = RegisterShop(NPCID.Mechanic);

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
			mechanic.CreateEntry(2295).AddCondition(Condition.NPCExists(369), Condition.PhaseQuarterAtLeft | Condition.PhaseQuarterAtRight  | Condition.PhaseThreeQuartersAtLeft | Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_Wizard()
		{
			NPCShop wizard = RegisterShop(NPCID.Wizard);

			wizard.CreateEntry(487);
			wizard.CreateEntry(496);
			wizard.CreateEntry(500);
			wizard.CreateEntry(507);
			wizard.CreateEntry(508);
			wizard.CreateEntry(531);
			wizard.CreateEntry(149);
			wizard.CreateEntry(576);
			wizard.CreateEntry(3186);
			wizard.CreateEntry(1739).AddCondition(Condition.Halloween);
		}

		private static void SetupShop_GoblinTinkerer()
		{
			NPCShop goblinTinkerer = RegisterShop(NPCID.GoblinTinkerer);

			goblinTinkerer.CreateEntry(128);
			goblinTinkerer.CreateEntry(486);
			goblinTinkerer.CreateEntry(398);
			goblinTinkerer.CreateEntry(84);
			goblinTinkerer.CreateEntry(407);
			goblinTinkerer.CreateEntry(161);
		}

		private static void SetupShop_Clothier()
		{
			NPCShop clothier = RegisterShop(NPCID.Clothier);

			clothier.CreateEntry(254);
			clothier.CreateEntry(981);
			clothier.CreateEntry(242).AddCondition(Condition.TimeDay);

			clothier.CreateEntry(245).AddCondition(Condition.PhaseFull);
			clothier.CreateEntry(246).AddCondition(Condition.PhaseFull);
			clothier.CreateEntry(1288).AddCondition(Condition.PhaseFull, Condition.TimeNight);
			clothier.CreateEntry(1829).AddCondition(Condition.PhaseFull, Condition.TimeNight);

			clothier.CreateEntry(325).AddCondition(Condition.PhaseThreeQuartersAtLeft);
			clothier.CreateEntry(326).AddCondition(Condition.PhaseThreeQuartersAtLeft);

			clothier.CreateEntry(269);
			clothier.CreateEntry(270);
			clothier.CreateEntry(271);

			clothier.CreateEntry(503).AddCondition(Condition.DownedClown);
			clothier.CreateEntry(504).AddCondition(Condition.DownedClown);
			clothier.CreateEntry(505).AddCondition(Condition.DownedClown);

			clothier.CreateEntry(322).AddCondition(Condition.BloodMoon);
			clothier.CreateEntry(3362).AddCondition(Condition.BloodMoon, Condition.TimeNight);
			clothier.CreateEntry(3363).AddCondition(Condition.BloodMoon, Condition.TimeNight);

			clothier.CreateEntry(2856).AddCondition(Condition.DownedLunaticCultist, Condition.TimeDay);
			clothier.CreateEntry(2858).AddCondition(Condition.DownedLunaticCultist, Condition.TimeDay);
			clothier.CreateEntry(2857).AddCondition(Condition.DownedLunaticCultist, Condition.TimeNight);
			clothier.CreateEntry(2859).AddCondition(Condition.DownedLunaticCultist, Condition.TimeNight);

			clothier.CreateEntry(3242).AddCondition(Condition.NPCExists(441));
			clothier.CreateEntry(3243).AddCondition(Condition.NPCExists(441));
			clothier.CreateEntry(3244).AddCondition(Condition.NPCExists(441));

			clothier.CreateEntry(4685).AddCondition(Condition.InGraveyardBiome);
			clothier.CreateEntry(4686).AddCondition(Condition.InGraveyardBiome);
			clothier.CreateEntry(4704).AddCondition(Condition.InGraveyardBiome);
			clothier.CreateEntry(4705).AddCondition(Condition.InGraveyardBiome);
			clothier.CreateEntry(4706).AddCondition(Condition.InGraveyardBiome);
			clothier.CreateEntry(4707).AddCondition(Condition.InGraveyardBiome);
			clothier.CreateEntry(4708).AddCondition(Condition.InGraveyardBiome);
			clothier.CreateEntry(4709).AddCondition(Condition.InGraveyardBiome);

			clothier.CreateEntry(1429).AddCondition(Condition.InSnow);
			clothier.CreateEntry(1740).AddCondition(Condition.Halloween);

			clothier.CreateEntry(869).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtLeft);
			clothier.CreateEntry(4994).AddCondition(Condition.Hardmode, Condition.PhaseQuarterAtLeft);
			clothier.CreateEntry(4997).AddCondition(Condition.Hardmode, Condition.PhaseQuarterAtLeft);
			clothier.CreateEntry(864).AddCondition(Condition.Hardmode, Condition.PhaseEmpty);
			clothier.CreateEntry(865).AddCondition(Condition.Hardmode, Condition.PhaseEmpty);
			clothier.CreateEntry(4995).AddCondition(Condition.Hardmode, Condition.PhaseQuarterAtRight);
			clothier.CreateEntry(4998).AddCondition(Condition.Hardmode, Condition.PhaseQuarterAtRight);
			clothier.CreateEntry(873).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtRight);
			clothier.CreateEntry(874).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtRight);
			clothier.CreateEntry(875).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtRight);
			clothier.CreateEntry(4996).AddCondition(Condition.Hardmode, Condition.PhaseThreeQuartersAtRight);
			clothier.CreateEntry(4999).AddCondition(Condition.Hardmode, Condition.PhaseThreeQuartersAtRight);
			clothier.CreateEntry(1275).AddCondition(Condition.DownedFrostLegion);
			clothier.CreateEntry(1276).AddCondition(Condition.DownedFrostLegion);
			clothier.CreateEntry(3246).AddCondition(Condition.Halloween);
			clothier.CreateEntry(3247).AddCondition(Condition.Halloween);

			clothier.CreateEntry(3730).AddCondition(Condition.PartyTime);
			clothier.CreateEntry(3731).AddCondition(Condition.PartyTime);
			clothier.CreateEntry(3733).AddCondition(Condition.PartyTime);
			clothier.CreateEntry(3734).AddCondition(Condition.PartyTime);
			clothier.CreateEntry(3735).AddCondition(Condition.PartyTime);

			clothier.CreateEntry(4744).AddCondition(Condition.GolfScore(1999));
		}

		private static void SetupShop_Demolitionist()
		{
			NPCShop demolitionist = RegisterShop(NPCID.Demolitionist);

			demolitionist.CreateEntry(168);
			demolitionist.CreateEntry(166);
			demolitionist.CreateEntry(167);

			demolitionist.CreateEntry(265).AddCondition(Condition.Hardmode);
			demolitionist.CreateEntry(937).AddCondition(Condition.Hardmode, Condition.DownedPlantera, Condition.DownedPirates);
			demolitionist.CreateEntry(1347).AddCondition(Condition.Hardmode);

			demolitionist.CreateEntry(4827).AddCondition(Condition.HasItem(4827));
			demolitionist.CreateEntry(4824).AddCondition(Condition.HasItem(4824));
			demolitionist.CreateEntry(4825).AddCondition(Condition.HasItem(4825));
			demolitionist.CreateEntry(4826).AddCondition(Condition.HasItem(4826));
		}

		private static void SetupShop_Dryad()
		{
			NPCShop dryad = RegisterShop(NPCID.Dryad);

			dryad.CreateEntry(2886).AddCondition(Condition.BloodMoon, Condition.Crimson);
			dryad.CreateEntry(2171).AddCondition(Condition.BloodMoon, Condition.Crimson);
			dryad.CreateEntry(4508).AddCondition(Condition.BloodMoon, Condition.Crimson);

			dryad.CreateEntry(67).AddCondition(Condition.BloodMoon, Condition.Corruption);
			dryad.CreateEntry(59).AddCondition(Condition.BloodMoon, Condition.Corruption);
			dryad.CreateEntry(4504).AddCondition(Condition.BloodMoon, Condition.Corruption);

			dryad.CreateEntry(66).AddCondition(!Condition.BloodMoon);
			dryad.CreateEntry(62).AddCondition(!Condition.BloodMoon);
			dryad.CreateEntry(63).AddCondition(!Condition.BloodMoon);
			dryad.CreateEntry(745).AddCondition(!Condition.BloodMoon);

			dryad.CreateEntry(59).AddCondition(Condition.Hardmode, Condition.InGraveyardBiome, Condition.Crimson);
			dryad.CreateEntry(2171).AddCondition(Condition.Hardmode, Condition.InGraveyardBiome, Condition.Corruption);

			dryad.CreateEntry(27);
			dryad.CreateEntry(114);
			dryad.CreateEntry(1828);
			dryad.CreateEntry(747);

			dryad.CreateEntry(746).AddCondition(Condition.Hardmode);
			dryad.CreateEntry(369).AddCondition(Condition.Hardmode);
			dryad.CreateEntry(4505).AddCondition(Condition.Hardmode);

			dryad.CreateEntry(194).AddCondition(Condition.InGlowshroom);

			dryad.CreateEntry(1853).AddCondition(Condition.Halloween);
			dryad.CreateEntry(1854).AddCondition(Condition.Halloween);
			dryad.CreateEntry(3215).AddCondition(Condition.DownedKingSlime);
			dryad.CreateEntry(3216).AddCondition(Condition.DownedQueenBee);
			dryad.CreateEntry(3219).AddCondition(Condition.DownedEoC);
			dryad.CreateEntry(3217).AddCondition(Condition.DownedEoW);
			dryad.CreateEntry(3218).AddCondition(Condition.DownedBoC);
			dryad.CreateEntry(3220).AddCondition(Condition.DownedSkeletron);
			dryad.CreateEntry(3221).AddCondition(Condition.DownedSkeletron);

			dryad.CreateEntry(3222).AddCondition(Condition.Hardmode);

			dryad.CreateEntry(4047);
			dryad.CreateEntry(4045);
			dryad.CreateEntry(4044);
			dryad.CreateEntry(4043);
			dryad.CreateEntry(4042);
			dryad.CreateEntry(4046);
			dryad.CreateEntry(4041);
			dryad.CreateEntry(4241);
			dryad.CreateEntry(4048);

			dryad.CreateEntry(4430).AddCondition(Condition.Hardmode, Condition.PhaseFull | Condition.PhaseThreeQuartersAtLeft);
			dryad.CreateEntry(4431).AddCondition(Condition.Hardmode, Condition.PhaseFull | Condition.PhaseThreeQuartersAtLeft);
			dryad.CreateEntry(4432).AddCondition(Condition.Hardmode, Condition.PhaseFull | Condition.PhaseThreeQuartersAtLeft);

			dryad.CreateEntry(4433).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtLeft | Condition.PhaseQuarterAtLeft);
			dryad.CreateEntry(4434).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtLeft | Condition.PhaseQuarterAtLeft);
			dryad.CreateEntry(4435).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtLeft | Condition.PhaseQuarterAtLeft);

			dryad.CreateEntry(4436).AddCondition(Condition.Hardmode, Condition.PhaseEmpty | Condition.PhaseQuarterAtRight);
			dryad.CreateEntry(4437).AddCondition(Condition.Hardmode, Condition.PhaseEmpty | Condition.PhaseQuarterAtRight);
			dryad.CreateEntry(4438).AddCondition(Condition.Hardmode, Condition.PhaseEmpty | Condition.PhaseQuarterAtRight);

			dryad.CreateEntry(4439).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtRight | Condition.PhaseThreeQuartersAtRight);
			dryad.CreateEntry(4440).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtRight | Condition.PhaseThreeQuartersAtRight);
			dryad.CreateEntry(4441).AddCondition(Condition.Hardmode, Condition.PhaseHalfAtRight | Condition.PhaseThreeQuartersAtRight);
		}

		private static void SetupShop_ArmsDealer()
		{
			NPCShop armsDealer = RegisterShop(NPCID.ArmsDealer);

			armsDealer.CreateEntry(97);

			armsDealer.CreateEntry(4915).AddCondition(Condition.Hardmode | (Condition.BloodMoon & new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("WorldSilverOre"), ()=> WorldGen.SavedOreTiers.Silver == 168)));
			armsDealer.CreateEntry(278).AddCondition(Condition.Hardmode | (Condition.BloodMoon & new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("WorldTungstenOre"), ()=> WorldGen.SavedOreTiers.Silver != 168)));
			armsDealer.CreateEntry(47).AddCondition((Condition.DownedEvilBoss & Condition.TimeNight) | Condition.Hardmode);

			armsDealer.CreateEntry(95);
			armsDealer.CreateEntry(98);

			armsDealer.CreateEntry(4703).AddCondition(Condition.InGraveyardBiome, Condition.DownedSkeletron);
			armsDealer.CreateEntry(324).AddCondition(Condition.TimeNight);
			armsDealer.CreateEntry(534).AddCondition(Condition.Hardmode);
			armsDealer.CreateEntry(1432).AddCondition(Condition.Hardmode);

			armsDealer.CreateEntry(1261).AddCondition(Condition.HasItem(1258));
			armsDealer.CreateEntry(1836).AddCondition(Condition.HasItem(1835));
			armsDealer.CreateEntry(3108).AddCondition(Condition.HasItem(3107));
			armsDealer.CreateEntry(1783).AddCondition(Condition.HasItem(1782));
			armsDealer.CreateEntry(1785).AddCondition(Condition.HasItem(1784));

			armsDealer.CreateEntry(1736).AddCondition(Condition.Halloween);
			armsDealer.CreateEntry(1737).AddCondition(Condition.Halloween);
			armsDealer.CreateEntry(1738).AddCondition(Condition.Halloween);
		}

		private static void SetupShop_Merchant()
		{
			NPCShop merchant = RegisterShop(NPCID.Merchant);

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

			merchant.CreateEntry(967).AddCondition(Condition.InSnow);
			merchant.CreateEntry(33).AddCondition(Condition.InJungle);
			merchant.CreateEntry(4074).AddCondition(Condition.TimeDay, new NPCShop.Entry.SimpleCondition(NetworkText.FromLiteral("HappyWind"), () => Main.IsItAHappyWindyDay));
			merchant.CreateEntry(279).AddCondition(Condition.BloodMoon);
			merchant.CreateEntry(282).AddCondition(Condition.TimeNight);
			merchant.CreateEntry(346).AddCondition(Condition.DownedSkeletron);
			merchant.CreateEntry(488).AddCondition(Condition.Hardmode);

			merchant.CreateEntry(931).AddCondition(Condition.HasItem(930));
			merchant.CreateEntry(1614).AddCondition(Condition.HasItem(930));

			merchant.CreateEntry(1786);
			merchant.CreateEntry(1348).AddCondition(Condition.Hardmode);
			merchant.CreateEntry(3198).AddCondition(Condition.Hardmode);

			merchant.CreateEntry(3108).AddCondition(Condition.HasItem(3107));
			merchant.CreateEntry(4063).AddCondition(Condition.DownedEvilBoss | Condition.DownedSkeletron | Condition.Hardmode);
			merchant.CreateEntry(4673).AddCondition(Condition.DownedEvilBoss | Condition.DownedSkeletron | Condition.Hardmode);
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
						condition.SetCustomData(player);
						return condition.Evaluate();
					}));

					if (entry == null || evaluated.Contains(entry)) continue;
					evaluated.Add(entry);

					roll++;

					foreach (Item item in entry.GetItems(false)) yield return item;
				}
			}
		}

		private class LuckCondition : Condition
		{
			private int range;
			private Player player;

			public LuckCondition(int range) : base(NetworkText.FromKey("ShopConditions.PlayerLuck"))
			{
				this.range = range;
			}

			public override bool Evaluate() => player?.RollLuck(range) == 0;

			public override void SetCustomData(object obj)
			{
				if (obj is Player player) this.player = player;
			}
		}

		private static void SetupShop_TravellingMerchant()
		{
			NPCShop travellingMerchant = RegisterShop(NPCID.TravellingMerchant);
			travellingMerchant.EvaluateOnOpen = false;

			TravellingMerchantList list = new TravellingMerchantList();
			travellingMerchant.AddEntry(list);

			int[] array = { 100, 200, 300, 400, 500, 600 };

			list.CreateEntry(3309).AddCondition(new LuckCondition(array[4]));
			list.CreateEntry(3314).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(1987).AddCondition(new LuckCondition(array[5]));
			list.CreateEntry(2270).AddCondition(new LuckCondition(array[4]), Condition.Hardmode);
			list.CreateEntry(2278).AddCondition(new LuckCondition(array[4]));
			list.CreateEntry(2271).AddCondition(new LuckCondition(array[4]));

			list.CreateEntry(4347).AddCondition(new LuckCondition(array[4]), Condition.DownedEoC | Condition.DownedEvilBoss | Condition.DownedSkeletron | Condition.DownedQueenBee);
			list.CreateEntry(4348).AddCondition(new LuckCondition(array[4]), Condition.Hardmode);

			list.CreateEntry(2223).AddCondition(new LuckCondition(array[3]), Condition.Hardmode, Condition.DownedPlantera);
			list.CreateEntry(2272).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(2219).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(2276).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(2284).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(2285).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(2286).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(2287).AddCondition(new LuckCondition(array[3]));

			list.CreateEntry(4744).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(2296).AddCondition(new LuckCondition(array[3]), Condition.DownedSkeletron);
			list.CreateEntry(3628).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(4091).AddCondition(new LuckCondition(array[3]), Condition.Hardmode);
			list.CreateEntry(4603).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(4604).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(4605).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(4550).AddCondition(new LuckCondition(array[3]));
			list.CreateEntry(4550).AddCondition(new LuckCondition(array[3]));

			list.CreateEntry(2269).AddCondition(new LuckCondition(array[2]), Condition.OrbSmashed);
			list.CreateEntry(2177).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(1988).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(2275).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(2279).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(2277).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(4555).AddCondition(new LuckCondition(array[2]));

			list.AddEntry(new NPCShop.EntryList
			{
				new NPCShop.EntryItem(4555),
				new NPCShop.EntryItem(4556),
				new NPCShop.EntryItem(4557)
			}).AddCondition(new LuckCondition(array[2]));

			list.AddEntry(new NPCShop.EntryList
			{
				new NPCShop.EntryItem(4321),
				new NPCShop.EntryItem(4322),
			}).AddCondition(new LuckCondition(array[2]));

			list.CreateEntry(4323).AddCondition(new LuckCondition(array[2]));

			list.AddEntry(new NPCShop.EntryList
			{
				new NPCShop.EntryItem(4323),
				new NPCShop.EntryItem(4324),
				new NPCShop.EntryItem(4365),
			}).AddCondition(new LuckCondition(array[2]));

			list.CreateEntry(4549).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(4561).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(4774).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(4562).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(4558).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(4559).AddCondition(new LuckCondition(array[2]));
			list.CreateEntry(4563).AddCondition(new LuckCondition(array[2]));

			list.AddEntry(new NPCShop.EntryList
			{
				new NPCShop.EntryItem(4666),
				new NPCShop.EntryItem(4665),
				new NPCShop.EntryItem(4664),
			}).AddCondition(new LuckCondition(array[2]));

			list.CreateEntry(3262).AddCondition(new LuckCondition(array[2]), Condition.DownedEoC);
			list.CreateEntry(3284).AddCondition(new LuckCondition(array[2]), Condition.DownedAnyMechBoss);
			list.CreateEntry(3596).AddCondition(new LuckCondition(array[2]), Condition.Hardmode, Condition.DownedMoonLord);
			list.CreateEntry(2865).AddCondition(new LuckCondition(array[2]), Condition.Hardmode, Condition.DownedMartians);
			list.CreateEntry(2866).AddCondition(new LuckCondition(array[2]), Condition.Hardmode, Condition.DownedMartians);
			list.CreateEntry(2867).AddCondition(new LuckCondition(array[2]), Condition.Hardmode, Condition.DownedMartians);
			list.CreateEntry(3055).AddCondition(new LuckCondition(array[2]), Condition.Christmas);
			list.CreateEntry(3056).AddCondition(new LuckCondition(array[2]), Condition.Christmas);
			list.CreateEntry(3057).AddCondition(new LuckCondition(array[2]), Condition.Christmas);
			list.CreateEntry(3058).AddCondition(new LuckCondition(array[2]), Condition.Christmas);
			list.CreateEntry(3059).AddCondition(new LuckCondition(array[2]), Condition.Christmas);

			list.CreateEntry(2214).AddCondition(new LuckCondition(array[1]));
			list.CreateEntry(2215).AddCondition(new LuckCondition(array[1]));
			list.CreateEntry(2216).AddCondition(new LuckCondition(array[1]));
			list.CreateEntry(2217).AddCondition(new LuckCondition(array[1]));
			list.CreateEntry(3624).AddCondition(new LuckCondition(array[1]));
			list.CreateEntry(2273).AddCondition(new LuckCondition(array[1]));
			list.CreateEntry(2274).AddCondition(new LuckCondition(array[1]));

			list.CreateEntry(2266).AddCondition(new LuckCondition(array[0]));
			list.CreateEntry(2267).AddCondition(new LuckCondition(array[0]));
			list.CreateEntry(2268).AddCondition(new LuckCondition(array[0]));

			list.AddEntry(new NPCShop.EntryListRandom
			{
				new NPCShop.EntryItem(2281),
				new NPCShop.EntryItem(2282),
				new NPCShop.EntryItem(2283),
			}).AddCondition(new LuckCondition(array[0]));

			list.CreateEntry(2274).AddCondition(new LuckCondition(array[0]));

			list.CreateEntry(2258).AddCondition(new LuckCondition(array[0]));
			list.CreateEntry(2242).AddCondition(new LuckCondition(array[0]));

			list.AddEntry(new NPCShop.EntryList
			{
				new NPCShop.EntryItem(2260),
				new NPCShop.EntryItem(2261),
				new NPCShop.EntryItem(2262)
			}).AddCondition(new LuckCondition(array[0]));

			NPCShop.EntryListRandom teamBlocks = new NPCShop.EntryListRandom
			{
				new NPCShop.EntryList
				{
					new NPCShop.EntryItem(3637),
					new NPCShop.EntryItem(3642),
				},
				new NPCShop.EntryList
				{
					new NPCShop.EntryItem(3621),
					new NPCShop.EntryItem(3622),
				},
				new NPCShop.EntryList
				{
					new NPCShop.EntryItem(3634),
					new NPCShop.EntryItem(3639),
				},
				new NPCShop.EntryList
				{
					new NPCShop.EntryItem(3633),
					new NPCShop.EntryItem(3638),
				},
				new NPCShop.EntryList
				{
					new NPCShop.EntryItem(3635),
					new NPCShop.EntryItem(3640),
				},
				new NPCShop.EntryList
				{
					new NPCShop.EntryItem(3636),
					new NPCShop.EntryItem(3641),
				},
			};
			list.AddEntry(teamBlocks).AddCondition(new LuckCondition(array[0]));

			list.CreateEntry(4420).AddCondition(new LuckCondition(array[0]));
			list.CreateEntry(3119).AddCondition(new LuckCondition(array[0]));
			list.CreateEntry(3118).AddCondition(new LuckCondition(array[0]));
			list.CreateEntry(3099).AddCondition(new LuckCondition(array[0]));
		}

		private static void SetupShop_Pylons()
		{
			// note: allow modded NPC to sell pylons?
			foreach (KeyValuePair<int, NPCShop> pair in shops)
			{
				if (pair.Key == NPCID.TravellingMerchant || pair.Key == NPCID.SkeletonMerchant || Main.LocalPlayer.currentShoppingSettings.PriceAdjustment > 0.8500000238418579) continue;
				if (Main.LocalPlayer.ZoneCrimson || Main.LocalPlayer.ZoneCorrupt) continue;

				pair.Value.CreateEntry(4876).AddCondition(
					!Condition.InSnow, !Condition.InDesert, !Condition.InBeach, !Condition.InJungle, !Condition.Halloween, !Condition.InGlowshroom,
					new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.PlayerPosY"), ()=>  Main.LocalPlayer.position.Y < Main.worldSurface * 16.0));;

				pair.Value.CreateEntry(4920).AddCondition(Condition.InSnow);

				pair.Value.CreateEntry(4919).AddCondition(Condition.InDesert);

				pair.Value.CreateEntry(4917)
					.AddCondition(
						!Condition.InSnow, !Condition.InDesert, !Condition.InBeach, !Condition.InJungle, !Condition.Halloween, !Condition.InGlowshroom,
						new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.PlayerPosY"), ()=>  Main.LocalPlayer.position.Y >= Main.worldSurface * 16.0));

				pair.Value.CreateEntry(4918).AddCondition(Condition.InBeach, new NPCShop.Entry.SimpleCondition(NetworkText.FromKey("ShopConditions.PlayerPosY"), ()=>  Main.LocalPlayer.position.Y < Main.worldSurface * 16.0));

				pair.Value.CreateEntry(4875).AddCondition(Condition.InJungle);

				pair.Value.CreateEntry(4916).AddCondition(Condition.InHallow);

				pair.Value.CreateEntry(4921).AddCondition(Condition.InGlowshroom);
			}
		}
	}
}