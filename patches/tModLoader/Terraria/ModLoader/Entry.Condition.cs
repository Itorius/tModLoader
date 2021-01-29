using System;
using System.Linq.Expressions;
using Terraria.Enums;
using Terraria.GameContent.Events;
using Terraria.Localization;

namespace Terraria.ModLoader
{
	public partial class NPCShop
	{
		public partial class Entry
		{
			public abstract class Condition
			{
				private class ReplaceExpressionVisitor : ExpressionVisitor
				{
					private readonly Expression oldValue;
					private readonly Expression newValue;

					public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
					{
						this.oldValue = oldValue;
						this.newValue = newValue;
					}

					public override Expression Visit(Expression node) => node == oldValue ? newValue : base.Visit(node);
				}

				public static Condition operator !(Condition condition)
				{
					Expression<Func<bool>> exp = () => condition.Evaluate();
					var neg = Expression.Lambda<Func<bool>>(Expression.Not(exp.Body));

					// todo: localization
					return new SimpleCondition(NetworkText.FromLiteral("Not " + condition.DescriptionText), neg.Compile());
				}

				public static Condition operator |(Condition condition1, Condition condition2)
				{
					Expression<Func<bool>> exp1 = () => condition1.Evaluate();
					Expression<Func<bool>> exp2 = () => condition2.Evaluate();
					// var parameter = Expression.Parameter(typeof(Entry));

					// var leftVisitor = new ReplaceExpressionVisitor(exp1.Parameters[0], parameter);
					// var left = leftVisitor.Visit(exp1.Body);
					//
					// var rightVisitor = new ReplaceExpressionVisitor(exp2.Parameters[0], parameter);
					// var right = rightVisitor.Visit(exp2.Body);

					var neg = Expression.Lambda<Func<bool>>(Expression.Or(exp1.Body, exp2.Body));

					// todo: localization
					return new SimpleCondition(NetworkText.FromLiteral(condition1.DescriptionText + " or " + condition2.DescriptionText), neg.Compile());
				}

				public static Condition operator &(Condition condition1, Condition condition2)
				{
					Expression<Func<bool>> exp1 = () => condition1.Evaluate();
					Expression<Func<bool>> exp2 = () => condition2.Evaluate();

					var neg = Expression.Lambda<Func<bool>>(Expression.And(exp1.Body, exp2.Body));

					// todo: localization
					return new SimpleCondition(NetworkText.FromLiteral(condition1.DescriptionText + " and " + condition2.DescriptionText), neg.Compile());
				}

				#region Conditions
				// Time
				public static readonly Condition TimeDay = new SimpleCondition(NetworkText.FromKey("ShopConditions.TimeDay"), () => Main.dayTime);
				public static readonly Condition TimeNight = new SimpleCondition(NetworkText.FromKey("ShopConditions.TimeNight"), () => !Main.dayTime);
				public static readonly Condition Crimson = new SimpleCondition(NetworkText.FromKey("ShopConditions.Crimson"), () => WorldGen.crimson);
				public static readonly Condition Corruption = new SimpleCondition(NetworkText.FromKey("ShopConditions.Corruption"), () => !WorldGen.crimson);

				// Event
				public static readonly Condition BloodMoon = new SimpleCondition(NetworkText.FromKey("ShopConditions.Bloodmoon"), () => Main.bloodMoon);
				public static readonly Condition SolarEclipse = new SimpleCondition(NetworkText.FromKey("ShopConditions.SolarEclipse"), () => Main.eclipse);
				public static readonly Condition AstrologicalEvent = new SimpleCondition(NetworkText.FromKey("ShopConditions.AstrologicalEvent"), () => Main.eclipse || Main.bloodMoon);

				public static readonly Condition Halloween = new SimpleCondition(NetworkText.FromKey("ShopConditions.Halloween"), () => Main.halloween);
				public static readonly Condition DownedPirates = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedPirates"), () => NPC.downedPirates);
				public static readonly Condition DownedMartians = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedMartians"), () => NPC.downedMartians);
				public static readonly Condition DownedGoblinArmy = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedGoblinArmy"), () => NPC.downedGoblins);
				public static readonly Condition DownedClown = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedClown"), () => NPC.downedClown);
				public static readonly Condition DownedFrostLegion = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedFrostLegion"), () => NPC.downedFrost);
				public static readonly Condition PartyTime = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedFrostLegion"), () => BirthdayParty.PartyIsUp);
				public static readonly Condition Lanterns = new SimpleCondition(NetworkText.FromKey("ShopConditions.Lanterns"), () => LanternNight.LanternsUp);
				public static readonly Condition Christmas = new SimpleCondition(NetworkText.FromKey("ShopConditions.Christmas"), () => Main.xMas);

				// Moon Phase
				public static readonly Condition PhaseFull = new SimpleCondition(NetworkText.FromKey("ShopConditions.PhaseFullMoon"), () => Main.GetMoonPhase() == MoonPhase.Full);
				public static readonly Condition PhaseThreeQuartersAtLeft = new SimpleCondition(NetworkText.FromKey("ShopConditions.PhaseWaningGibbous"), () => Main.GetMoonPhase() == MoonPhase.ThreeQuartersAtLeft);
				public static readonly Condition PhaseHalfAtLeft = new SimpleCondition(NetworkText.FromKey("ShopConditions.PhaseThirdQuarter"), () => Main.GetMoonPhase() == MoonPhase.HalfAtLeft);
				public static readonly Condition PhaseQuarterAtLeft = new SimpleCondition(NetworkText.FromKey("ShopConditions.PhaseWaningCrescent"), () => Main.GetMoonPhase() == MoonPhase.QuarterAtLeft);
				public static readonly Condition PhaseEmpty = new SimpleCondition(NetworkText.FromKey("ShopConditions.PhaseNewMoon"), () => Main.GetMoonPhase() == MoonPhase.Empty);
				public static readonly Condition PhaseQuarterAtRight = new SimpleCondition(NetworkText.FromKey("ShopConditions.PhaseWaxingCrescent"), () => Main.GetMoonPhase() == MoonPhase.QuarterAtRight);
				public static readonly Condition PhaseHalfAtRight = new SimpleCondition(NetworkText.FromKey("ShopConditions.PhaseFirstQuarter"), () => Main.GetMoonPhase() == MoonPhase.HalfAtRight);
				public static readonly Condition PhaseThreeQuartersAtRight = new SimpleCondition(NetworkText.FromKey("ShopConditions.PhaseWaxingGibbous"), () => Main.GetMoonPhase() == MoonPhase.ThreeQuartersAtRight);

				// Boss				
				public static readonly Condition DownedKingSlime = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedKingSlime"), () => NPC.downedSlimeKing);
				public static readonly Condition DownedEoC = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedEoC"), () => NPC.downedBoss1);
				public static readonly Condition DownedEoW = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedEoW"), () => NPC.downedBoss2 && !WorldGen.crimson);
				public static readonly Condition DownedBoC = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedBoC"), () => NPC.downedBoss2 && WorldGen.crimson);
				public static readonly Condition DownedQueenBee = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedQueenBee"), () => NPC.downedQueenBee);
				public static readonly Condition DownedSkeletron = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedSkeletron"), () => NPC.downedBoss3);
				public static readonly Condition DownedWoF = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedWoF"), () => Main.hardMode);
				public static readonly Condition DownedQueenSlime = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedQueenSlime"), () => NPC.downedQueenSlime);
				public static readonly Condition DownedDestroyer = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedDestroyer"), () => NPC.downedMechBoss1);
				public static readonly Condition DownedTwins = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedTwins"), () => NPC.downedMechBoss2);
				public static readonly Condition DownedSkeletronPrime = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedSkeletronPrime"), () => NPC.downedMechBoss3);
				public static readonly Condition DownedPlantera = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedPlantera"), () => NPC.downedPlantBoss);
				public static readonly Condition DownedGolem = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedGolem"), () => NPC.downedGolemBoss);
				public static readonly Condition DownedEmpress = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedEmpress"), () => NPC.downedEmpressOfLight);
				public static readonly Condition DownedDukeFishron = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedDukeFishron"), () => NPC.downedFishron);
				public static readonly Condition DownedLunaticCultist = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedLunaticCultist"), () => NPC.downedAncientCultist);
				public static readonly Condition DownedMoonLord = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedMoonLord"), () => NPC.downedMoonlord);
				public static readonly Condition DownedAnyMechBoss = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedAnyMechBoss"), () => NPC.downedMechBossAny);
				public static readonly Condition DownedEvilBoss = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedEvilBoss"), () => NPC.downedBoss2);

				public static readonly Condition DownedSolarTower = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedSolarTower"), () => NPC.downedTowerSolar);
				public static readonly Condition DownedNebulaTower = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedNebulaTower"), () => NPC.downedTowerNebula);
				public static readonly Condition DownedStardustTower = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedStardustTower"), () => NPC.downedTowerStardust);
				public static readonly Condition DownedVortexTower = new SimpleCondition(NetworkText.FromKey("ShopConditions.DownedVortexTower"), () => NPC.downedTowerVortex);

				// Biome
				public static readonly Condition InDungeon = new SimpleCondition(NetworkText.FromKey("ShopConditions.InDungeon"), () => Main.LocalPlayer.ZoneDungeon);
				public static readonly Condition InCorrupt = new SimpleCondition(NetworkText.FromKey("ShopConditions.InCorrupt"), () => Main.LocalPlayer.ZoneCorrupt);
				public static readonly Condition InHallow = new SimpleCondition(NetworkText.FromKey("ShopConditions.InHallow"), () => Main.LocalPlayer.ZoneHallow);
				public static readonly Condition InMeteor = new SimpleCondition(NetworkText.FromKey("ShopConditions.InMeteor"), () => Main.LocalPlayer.ZoneMeteor);
				public static readonly Condition InJungle = new SimpleCondition(NetworkText.FromKey("ShopConditions.InJungle"), () => Main.LocalPlayer.ZoneJungle);
				public static readonly Condition InSnow = new SimpleCondition(NetworkText.FromKey("ShopConditions.InSnow"), () => Main.LocalPlayer.ZoneSnow);
				public static readonly Condition InCrimson = new SimpleCondition(NetworkText.FromKey("ShopConditions.InCrimson"), () => Main.LocalPlayer.ZoneCrimson);
				public static readonly Condition InWaterCandle = new SimpleCondition(NetworkText.FromKey("ShopConditions.InWaterCandle"), () => Main.LocalPlayer.ZoneWaterCandle);
				public static readonly Condition InPeaceCandle = new SimpleCondition(NetworkText.FromKey("ShopConditions.InPeaceCandle"), () => Main.LocalPlayer.ZonePeaceCandle);
				public static readonly Condition InTowerSolar = new SimpleCondition(NetworkText.FromKey("ShopConditions.InTowerSolar"), () => Main.LocalPlayer.ZoneTowerSolar);
				public static readonly Condition InTowerVortex = new SimpleCondition(NetworkText.FromKey("ShopConditions.InTowerVortex"), () => Main.LocalPlayer.ZoneTowerVortex);
				public static readonly Condition InTowerNebula = new SimpleCondition(NetworkText.FromKey("ShopConditions.InTowerNebula"), () => Main.LocalPlayer.ZoneTowerNebula);
				public static readonly Condition InTowerStardust = new SimpleCondition(NetworkText.FromKey("ShopConditions.InTowerStardust"), () => Main.LocalPlayer.ZoneTowerStardust);
				public static readonly Condition InDesert = new SimpleCondition(NetworkText.FromKey("ShopConditions.InDesert"), () => Main.LocalPlayer.ZoneDesert);
				public static readonly Condition InGlowshroom = new SimpleCondition(NetworkText.FromKey("ShopConditions.InGlowshroom"), () => Main.LocalPlayer.ZoneGlowshroom);
				public static readonly Condition InUndergroundDesert = new SimpleCondition(NetworkText.FromKey("ShopConditions.InUndergroundDesert"), () => Main.LocalPlayer.ZoneUndergroundDesert);
				public static readonly Condition InSkyHeight = new SimpleCondition(NetworkText.FromKey("ShopConditions.InSkyHeight"), () => Main.LocalPlayer.ZoneSkyHeight);
				public static readonly Condition InOverworldHeight = new SimpleCondition(NetworkText.FromKey("ShopConditions.InOverworldHeight"), () => Main.LocalPlayer.ZoneOverworldHeight);
				public static readonly Condition InDirtLayerHeight = new SimpleCondition(NetworkText.FromKey("ShopConditions.InDirtLayerHeight"), () => Main.LocalPlayer.ZoneDirtLayerHeight);
				public static readonly Condition InRockLayerHeight = new SimpleCondition(NetworkText.FromKey("ShopConditions.InRockLayerHeight"), () => Main.LocalPlayer.ZoneRockLayerHeight);
				public static readonly Condition InUnderworldHeight = new SimpleCondition(NetworkText.FromKey("ShopConditions.InUnderworldHeight"), () => Main.LocalPlayer.ZoneUnderworldHeight);
				public static readonly Condition InBeach = new SimpleCondition(NetworkText.FromKey("ShopConditions.InBeach"), () => Main.LocalPlayer.ZoneBeach);
				public static readonly Condition InRain = new SimpleCondition(NetworkText.FromKey("ShopConditions.InRain"), () => Main.LocalPlayer.ZoneRain);
				public static readonly Condition InSandstorm = new SimpleCondition(NetworkText.FromKey("ShopConditions.InSandstorm"), () => Main.LocalPlayer.ZoneSandstorm);
				public static readonly Condition InOldOneArmy = new SimpleCondition(NetworkText.FromKey("ShopConditions.InOldOneArmy"), () => Main.LocalPlayer.ZoneOldOneArmy);
				public static readonly Condition InGranite = new SimpleCondition(NetworkText.FromKey("ShopConditions.InGranite"), () => Main.LocalPlayer.ZoneGranite);
				public static readonly Condition InMarble = new SimpleCondition(NetworkText.FromKey("ShopConditions.InMarble"), () => Main.LocalPlayer.ZoneMarble);
				public static readonly Condition InHive = new SimpleCondition(NetworkText.FromKey("ShopConditions.InHive"), () => Main.LocalPlayer.ZoneHive);
				public static readonly Condition InGemCave = new SimpleCondition(NetworkText.FromKey("ShopConditions.InGemCave"), () => Main.LocalPlayer.ZoneGemCave);
				public static readonly Condition InLihzhardTemple = new SimpleCondition(NetworkText.FromKey("ShopConditions.InLihzardTemple"), () => Main.LocalPlayer.ZoneLihzhardTemple);
				public static readonly Condition InGraveyardBiome = new SimpleCondition(NetworkText.FromKey("ShopConditions.InGraveyardBiome"), () => Main.LocalPlayer.ZoneGraveyard);
				public static readonly Condition InSpace = new SimpleCondition(NetworkText.FromKey("ShopConditions.InSpace"), () => Main.LocalPlayer.position.Y / 16f < Main.worldSurface * 0.3499999940395355);

				public static readonly Condition InOcean = new SimpleCondition(NetworkText.FromKey("ShopConditions.InOcean"), () =>
				{
					int x = (int)((Main.screenPosition.X + Main.screenWidth * 0.5f) / 16f);
					return Main.screenPosition.Y / 16f < Main.worldSurface + 10.0 && (x < 380 || x > Main.maxTilesX - 380);
				});

				// Other
				public static readonly Condition Hardmode = new SimpleCondition(NetworkText.FromKey("ShopConditions.Hardmode"), () => Main.hardMode);
				public static readonly Condition HappyNPCs = new SimpleCondition(NetworkText.FromKey("ShopConditions.HappyNPCs"), () => Main.LocalPlayer.currentShoppingSettings.PriceAdjustment <= 0.8500000238418579);
				public static readonly Condition OrbSmashed = new SimpleCondition(NetworkText.FromKey("ShopConditions.OrbSmashed"), () => WorldGen.shadowOrbSmashed);
				public static Condition HasItem(int type) => new SimpleCondition(NetworkText.FromKey("ShopConditions.HasItem"), () => Main.LocalPlayer.HasItem(type));
				public static Condition NPCExists(int type) => new SimpleCondition(NetworkText.FromKey("ShopConditions.NPCExists"), () => NPC.AnyNPCs(type));
				#endregion

				private readonly NetworkText DescriptionText;

				public string Description => DescriptionText.ToString();

				public Condition(NetworkText description)
				{
					DescriptionText = description ?? throw new ArgumentNullException(nameof(description));
				}

				public abstract bool Evaluate();
			}

			public class SimpleCondition : Condition
			{
				private readonly Func<bool> Predicate;

				public SimpleCondition(NetworkText description, Func<bool> predicate) : base(description)
				{
					Predicate = predicate ?? throw new ArgumentNullException(nameof(description));
				}

				public override bool Evaluate() => Predicate();
			}
		}
	}
}