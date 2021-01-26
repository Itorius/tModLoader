using Microsoft.Xna.Framework;
using Terraria.ModLoader.Input;

namespace Terraria.GameInput
{
	public partial class PlayerInput
	{
		internal static bool reinitialize;

		internal static void Reinitialize()
		{
			Profiles.Clear();
			OriginalProfiles.Clear();
			Initialize_Inner(); //Mirsario: To not repeat code in patches, reuse the one that was previously in Initialize().
			Load(); // Loads the JSON into the Profiles above
			reinitialize = false;
		}

		public static void UpdateInput(GameTime gameTime)
		{
			if (reinitialize)
				Reinitialize();

			Triggers.Old = Triggers.Current.Clone();
			
			VerifyBuildingMode();

			Input.Update(gameTime);

			Main.mouseLeft = Triggers.Current.MouseLeft;
			Main.mouseRight = Triggers.Current.MouseRight;
			Main.mouseMiddle = Triggers.Current.MouseMiddle;
			Main.mouseXButton1 = Triggers.Current.MouseXButton1;
			Main.mouseXButton2 = Triggers.Current.MouseXButton2;

			Triggers.Update();
			WritingText = false;

			CacheZoomableValues();
		}
	}
}