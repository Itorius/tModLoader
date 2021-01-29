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
			public interface ICondition
			{
				string Description { get; }

				bool ItemAvailable(Entry recipe);
			}

			public sealed class Condition : ICondition
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
					Expression<Predicate<Entry>> exp = e => condition.Predicate(e);
					var neg = Expression.Lambda<Predicate<Entry>>(Expression.Not(exp.Body), exp.Parameters);

					// todo: localization
					return new Condition(NetworkText.FromLiteral("Not "+condition.DescriptionText), neg.Compile());
				}

				public static Condition operator |(Condition condition1, Condition condition2)
				{
					Expression<Predicate<Entry>> exp1 = e => condition1.Predicate(e);
					Expression<Predicate<Entry>> exp2 = e => condition2.Predicate(e);
					var parameter = Expression.Parameter(typeof(Entry));

					var leftVisitor = new ReplaceExpressionVisitor(exp1.Parameters[0], parameter);
					var left = leftVisitor.Visit(exp1.Body);

					var rightVisitor = new ReplaceExpressionVisitor(exp2.Parameters[0], parameter);
					var right = rightVisitor.Visit(exp2.Body);

					var neg = Expression.Lambda<Predicate<Entry>>(Expression.Or(left, right), parameter);

					// todo: localization
					return new Condition(NetworkText.FromLiteral(condition1.DescriptionText + " or " + condition2.DescriptionText), neg.Compile());
				}

				public static Condition operator &(Condition condition1, Condition condition2)
				{
					Expression<Predicate<Entry>> exp1 = e => condition1.Predicate(e);
					Expression<Predicate<Entry>> exp2 = e => condition2.Predicate(e);
					var parameter = Expression.Parameter(typeof(Entry));

					var leftVisitor = new ReplaceExpressionVisitor(exp1.Parameters[0], parameter);
					var left = leftVisitor.Visit(exp1.Body);

					var rightVisitor = new ReplaceExpressionVisitor(exp2.Parameters[0], parameter);
					var right = rightVisitor.Visit(exp2.Body);

					var neg = Expression.Lambda<Predicate<Entry>>(Expression.And(left, right), parameter);

					// todo: localization
					return new Condition(NetworkText.FromLiteral(condition1.DescriptionText + " and " + condition2.DescriptionText), neg.Compile());
				}

				#region Conditions
				// Time
				public static readonly Condition TimeDay = new Condition(NetworkText.FromKey("ShopConditions.TimeDay"), _ => Main.dayTime);
				public static readonly Condition TimeNight = new Condition(NetworkText.FromKey("ShopConditions.TimeNight"), _ => !Main.dayTime);
				public static readonly Condition Crimson = new Condition(NetworkText.FromKey("ShopConditions.Crimson"), _ => WorldGen.crimson);
				public static readonly Condition Corruption = new Condition(NetworkText.FromKey("ShopConditions.Corruption"), _ => !WorldGen.crimson);

				// Event
				public static readonly Condition BloodMoon = new Condition(NetworkText.FromKey("ShopConditions.Bloodmoon"), _ => Main.bloodMoon);
				public static readonly Condition SolarEclipse = new Condition(NetworkText.FromKey("ShopConditions.SolarEclipse"), _ => Main.eclipse);
				public static readonly Condition AstrologicalEvent = new Condition(NetworkText.FromKey("ShopConditions.AstrologicalEvent"), _ => Main.eclipse || Main.bloodMoon);

				public static readonly Condition Halloween = new Condition(NetworkText.FromKey("ShopConditions.Halloween"), _ => Main.halloween);
				public static readonly Condition DownedPirates = new Condition(NetworkText.FromKey("ShopConditions.DownedPirates"), _ => NPC.downedPirates);
				public static readonly Condition DownedMartians = new Condition(NetworkText.FromKey("ShopConditions.DownedMartians"), _ => NPC.downedMartians);
				public static readonly Condition DownedGoblinArmy = new Condition(NetworkText.FromKey("ShopConditions.DownedGoblinArmy"), _ => NPC.downedGoblins);
				public static readonly Condition DownedClown = new Condition(NetworkText.FromKey("ShopConditions.DownedClown"), _ => NPC.downedClown);
				public static readonly Condition DownedFrostLegion = new Condition(NetworkText.FromKey("ShopConditions.DownedFrostLegion"), _ => NPC.downedFrost);
				public static readonly Condition PartyTime = new Condition(NetworkText.FromKey("ShopConditions.DownedFrostLegion"), _ => BirthdayParty.PartyIsUp);
				public static readonly Condition Lanterns = new Condition(NetworkText.FromKey("ShopConditions.Lanterns"), _ => LanternNight.LanternsUp);
				public static readonly Condition Christmas = new Condition(NetworkText.FromKey("ShopConditions.Christmas"), _ => Main.xMas);

				// Moon Phase
				public static readonly Condition PhaseFull = new Condition(NetworkText.FromKey("ShopConditions.PhaseFullMoon"), _ => Main.GetMoonPhase() == MoonPhase.Full);
				public static readonly Condition PhaseThreeQuartersAtLeft = new Condition(NetworkText.FromKey("ShopConditions.PhaseWaningGibbous"), _ => Main.GetMoonPhase() == MoonPhase.ThreeQuartersAtLeft);
				public static readonly Condition PhaseHalfAtLeft = new Condition(NetworkText.FromKey("ShopConditions.PhaseThirdQuarter"), _ => Main.GetMoonPhase() == MoonPhase.HalfAtLeft);
				public static readonly Condition PhaseQuarterAtLeft = new Condition(NetworkText.FromKey("ShopConditions.PhaseWaningCrescent"), _ => Main.GetMoonPhase() == MoonPhase.QuarterAtLeft);
				public static readonly Condition PhaseEmpty = new Condition(NetworkText.FromKey("ShopConditions.PhaseNewMoon"), _ => Main.GetMoonPhase() == MoonPhase.Empty);
				public static readonly Condition PhaseQuarterAtRight = new Condition(NetworkText.FromKey("ShopConditions.PhaseWaxingCrescent"), _ => Main.GetMoonPhase() == MoonPhase.QuarterAtRight);
				public static readonly Condition PhaseHalfAtRight = new Condition(NetworkText.FromKey("ShopConditions.PhaseFirstQuarter"), _ => Main.GetMoonPhase() == MoonPhase.HalfAtRight);
				public static readonly Condition PhaseThreeQuartersAtRight = new Condition(NetworkText.FromKey("ShopConditions.PhaseWaxingGibbous"), _ => Main.GetMoonPhase() == MoonPhase.ThreeQuartersAtRight);

				// Boss				
				public static readonly Condition DownedKingSlime = new Condition(NetworkText.FromKey("ShopConditions.DownedKingSlime"), _ => NPC.downedSlimeKing);
				public static readonly Condition DownedEoC = new Condition(NetworkText.FromKey("ShopConditions.DownedEoC"), _ => NPC.downedBoss1);
				public static readonly Condition DownedEoW = new Condition(NetworkText.FromKey("ShopConditions.DownedEoW"), _ => NPC.downedBoss2 && !WorldGen.crimson);
				public static readonly Condition DownedBoC = new Condition(NetworkText.FromKey("ShopConditions.DownedBoC"), _ => NPC.downedBoss2 && WorldGen.crimson);
				public static readonly Condition DownedQueenBee = new Condition(NetworkText.FromKey("ShopConditions.DownedQueenBee"), _ => NPC.downedQueenBee);
				public static readonly Condition DownedSkeletron = new Condition(NetworkText.FromKey("ShopConditions.DownedSkeletron"), _ => NPC.downedBoss3);
				public static readonly Condition DownedWoF = new Condition(NetworkText.FromKey("ShopConditions.DownedWoF"), _ => Main.hardMode);
				public static readonly Condition DownedQueenSlime = new Condition(NetworkText.FromKey("ShopConditions.DownedQueenSlime"), _ => NPC.downedQueenSlime);
				public static readonly Condition DownedDestroyer = new Condition(NetworkText.FromKey("ShopConditions.DownedDestroyer"), _ => NPC.downedMechBoss1);
				public static readonly Condition DownedTwins = new Condition(NetworkText.FromKey("ShopConditions.DownedTwins"), _ => NPC.downedMechBoss2);
				public static readonly Condition DownedSkeletronPrime = new Condition(NetworkText.FromKey("ShopConditions.DownedSkeletronPrime"), _ => NPC.downedMechBoss3);
				public static readonly Condition DownedPlantera = new Condition(NetworkText.FromKey("ShopConditions.DownedPlantera"), _ => NPC.downedPlantBoss);
				public static readonly Condition DownedGolem = new Condition(NetworkText.FromKey("ShopConditions.DownedGolem"), _ => NPC.downedGolemBoss);
				public static readonly Condition DownedEmpress = new Condition(NetworkText.FromKey("ShopConditions.DownedEmpress"), _ => NPC.downedEmpressOfLight);
				public static readonly Condition DownedDukeFishron = new Condition(NetworkText.FromKey("ShopConditions.DownedDukeFishron"), _ => NPC.downedFishron);
				public static readonly Condition DownedLunaticCultist = new Condition(NetworkText.FromKey("ShopConditions.DownedLunaticCultist"), _ => NPC.downedAncientCultist);
				public static readonly Condition DownedMoonLord = new Condition(NetworkText.FromKey("ShopConditions.DownedMoonLord"), _ => NPC.downedMoonlord);
				public static readonly Condition DownedAnyMechBoss = new Condition(NetworkText.FromKey("ShopConditions.DownedAnyMechBoss"), _ => NPC.downedMechBossAny);
				public static readonly Condition DownedEvilBoss = new Condition(NetworkText.FromKey("ShopConditions.DownedEvilBoss"), _ => NPC.downedBoss2);

				public static readonly Condition DownedSolarTower = new Condition(NetworkText.FromKey("ShopConditions.DownedSolarTower"), _ => NPC.downedTowerSolar);
				public static readonly Condition DownedNebulaTower = new Condition(NetworkText.FromKey("ShopConditions.DownedNebulaTower"), _ => NPC.downedTowerNebula);
				public static readonly Condition DownedStardustTower = new Condition(NetworkText.FromKey("ShopConditions.DownedStardustTower"), _ => NPC.downedTowerStardust);
				public static readonly Condition DownedVortexTower = new Condition(NetworkText.FromKey("ShopConditions.DownedVortexTower"), _ => NPC.downedTowerVortex);


				// Biome
				public static readonly Condition InDungeon = new Condition(NetworkText.FromKey("ShopConditions.InDungeon"), _ => Main.LocalPlayer.ZoneDungeon);
				public static readonly Condition InCorrupt = new Condition(NetworkText.FromKey("ShopConditions.InCorrupt"), _ => Main.LocalPlayer.ZoneCorrupt);
				public static readonly Condition InHallow = new Condition(NetworkText.FromKey("ShopConditions.InHallow"), _ => Main.LocalPlayer.ZoneHallow);
				public static readonly Condition InMeteor = new Condition(NetworkText.FromKey("ShopConditions.InMeteor"), _ => Main.LocalPlayer.ZoneMeteor);
				public static readonly Condition InJungle = new Condition(NetworkText.FromKey("ShopConditions.InJungle"), _ => Main.LocalPlayer.ZoneJungle);
				public static readonly Condition InSnow = new Condition(NetworkText.FromKey("ShopConditions.InSnow"), _ => Main.LocalPlayer.ZoneSnow);
				public static readonly Condition InCrimson = new Condition(NetworkText.FromKey("ShopConditions.InCrimson"), _ => Main.LocalPlayer.ZoneCrimson);
				public static readonly Condition InWaterCandle = new Condition(NetworkText.FromKey("ShopConditions.InWaterCandle"), _ => Main.LocalPlayer.ZoneWaterCandle);
				public static readonly Condition InPeaceCandle = new Condition(NetworkText.FromKey("ShopConditions.InPeaceCandle"), _ => Main.LocalPlayer.ZonePeaceCandle);
				public static readonly Condition InTowerSolar = new Condition(NetworkText.FromKey("ShopConditions.InTowerSolar"), _ => Main.LocalPlayer.ZoneTowerSolar);
				public static readonly Condition InTowerVortex = new Condition(NetworkText.FromKey("ShopConditions.InTowerVortex"), _ => Main.LocalPlayer.ZoneTowerVortex);
				public static readonly Condition InTowerNebula = new Condition(NetworkText.FromKey("ShopConditions.InTowerNebula"), _ => Main.LocalPlayer.ZoneTowerNebula);
				public static readonly Condition InTowerStardust = new Condition(NetworkText.FromKey("ShopConditions.InTowerStardust"), _ => Main.LocalPlayer.ZoneTowerStardust);
				public static readonly Condition InDesert = new Condition(NetworkText.FromKey("ShopConditions.InDesert"), _ => Main.LocalPlayer.ZoneDesert);
				public static readonly Condition InGlowshroom = new Condition(NetworkText.FromKey("ShopConditions.InGlowshroom"), _ => Main.LocalPlayer.ZoneGlowshroom);
				public static readonly Condition InUndergroundDesert = new Condition(NetworkText.FromKey("ShopConditions.InUndergroundDesert"), _ => Main.LocalPlayer.ZoneUndergroundDesert);
				public static readonly Condition InSkyHeight = new Condition(NetworkText.FromKey("ShopConditions.InSkyHeight"), _ => Main.LocalPlayer.ZoneSkyHeight);
				public static readonly Condition InOverworldHeight = new Condition(NetworkText.FromKey("ShopConditions.InOverworldHeight"), _ => Main.LocalPlayer.ZoneOverworldHeight);
				public static readonly Condition InDirtLayerHeight = new Condition(NetworkText.FromKey("ShopConditions.InDirtLayerHeight"), _ => Main.LocalPlayer.ZoneDirtLayerHeight);
				public static readonly Condition InRockLayerHeight = new Condition(NetworkText.FromKey("ShopConditions.InRockLayerHeight"), _ => Main.LocalPlayer.ZoneRockLayerHeight);
				public static readonly Condition InUnderworldHeight = new Condition(NetworkText.FromKey("ShopConditions.InUnderworldHeight"), _ => Main.LocalPlayer.ZoneUnderworldHeight);
				public static readonly Condition InBeach = new Condition(NetworkText.FromKey("ShopConditions.InBeach"), _ => Main.LocalPlayer.ZoneBeach);
				public static readonly Condition InRain = new Condition(NetworkText.FromKey("ShopConditions.InRain"), _ => Main.LocalPlayer.ZoneRain);
				public static readonly Condition InSandstorm = new Condition(NetworkText.FromKey("ShopConditions.InSandstorm"), _ => Main.LocalPlayer.ZoneSandstorm);
				public static readonly Condition InOldOneArmy = new Condition(NetworkText.FromKey("ShopConditions.InOldOneArmy"), _ => Main.LocalPlayer.ZoneOldOneArmy);
				public static readonly Condition InGranite = new Condition(NetworkText.FromKey("ShopConditions.InGranite"), _ => Main.LocalPlayer.ZoneGranite);
				public static readonly Condition InMarble = new Condition(NetworkText.FromKey("ShopConditions.InMarble"), _ => Main.LocalPlayer.ZoneMarble);
				public static readonly Condition InHive = new Condition(NetworkText.FromKey("ShopConditions.InHive"), _ => Main.LocalPlayer.ZoneHive);
				public static readonly Condition InGemCave = new Condition(NetworkText.FromKey("ShopConditions.InGemCave"), _ => Main.LocalPlayer.ZoneGemCave);
				public static readonly Condition InLihzhardTemple = new Condition(NetworkText.FromKey("ShopConditions.InLihzardTemple"), _ => Main.LocalPlayer.ZoneLihzhardTemple);
				public static readonly Condition InGraveyardBiome = new Condition(NetworkText.FromKey("ShopConditions.InGraveyardBiome"), _ => Main.LocalPlayer.ZoneGraveyard);
				public static readonly Condition InSpace = new Condition(NetworkText.FromKey("ShopConditions.InSpace"), _ => Main.LocalPlayer.position.Y / 16f < Main.worldSurface * 0.3499999940395355);

				public static readonly Condition InOcean = new Condition(NetworkText.FromKey("ShopConditions.InOcean"), _ =>
				{
					int x = (int)((Main.screenPosition.X + Main.screenWidth * 0.5f) / 16f);
					return Main.screenPosition.Y / 16f < Main.worldSurface + 10.0 && (x < 380 || x > Main.maxTilesX - 380);
				});

				// Other
				public static readonly Condition Hardmode = new Condition(NetworkText.FromKey("ShopConditions.Hardmode"), _ => Main.hardMode);
				public static readonly Condition HappyNPCs = new Condition(NetworkText.FromKey("ShopConditions.HappyNPCs"), _ => Main.LocalPlayer.currentShoppingSettings.PriceAdjustment <= 0.8500000238418579);
				public static Condition HasItem(int type) => new Condition(NetworkText.FromKey("ShopConditions.HasItem"), _ => Main.LocalPlayer.HasItem(type));
				public static Condition NPCExists(int type) => new Condition(NetworkText.FromKey("ShopConditions.NPCExists"), _ => NPC.AnyNPCs(type));
				#endregion

				private readonly NetworkText DescriptionText;
				private readonly Predicate<Entry> Predicate;

				public string Description => DescriptionText.ToString();

				public Condition(NetworkText description, Predicate<Entry> predicate)
				{
					DescriptionText = description ?? throw new ArgumentNullException(nameof(description));
					Predicate = predicate ?? throw new ArgumentNullException(nameof(description));
				}

				public bool ItemAvailable(Entry recipe) => Predicate(recipe);
			}
		}
	}
}