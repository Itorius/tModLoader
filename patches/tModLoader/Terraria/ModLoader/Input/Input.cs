using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader.Input.Keyboard;
using Terraria.ModLoader.Input.Mouse;

namespace Terraria.ModLoader.Input
{
	public static class Input
	{
		private static int _lastScreenWidth;
		private static int _lastScreenHeight;

		private static KeyConfiguration KeyConfiguration {
			get {
				if (Main.gameMenu && !PlayerInput.WritingText) return PlayerInput.CurrentProfile.InputModes[InputMode.KeyboardUI];
				return PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard];
			}
		}

		// todo: implement layer system
		internal static void Load() {
			MouseInput.Load();
			KeyboardInput.Load();

			MouseInput.MouseMoved += args => {
				PlayerInput.MouseX = (int)(args.X * PlayerInput.RawMouseScale.X);
				PlayerInput.MouseY = (int)(args.Y * PlayerInput.RawMouseScale.Y);

				Main.lastMouseX = Main.mouseX;
				Main.lastMouseY = Main.mouseY;
				Main.mouseX = PlayerInput.MouseX;
				Main.mouseY = PlayerInput.MouseY;

				PlayerInput.CurrentInputMode = InputMode.Mouse;
				PlayerInput.Triggers.Current.UsedMovementKey = false;
			};

			MouseInput.ButtonPressed += args => {
				PlayerInput.CurrentInputMode = InputMode.Mouse;
				PlayerInput.Triggers.Current.UsedMovementKey = false;

				foreach (var item in KeyConfiguration.KeyStatus) {
					if (item.Value.Contains("Mouse" + args.Button))
						PlayerInput.Triggers.Current.KeyStatus[item.Key] = true;
				}
			};

			MouseInput.ButtonReleased += args => {
				foreach (var pair in KeyConfiguration.KeyStatus) {
					if (pair.Value.Contains("Mouse" + args.Button)) {
						PlayerInput.Triggers.Current.KeyStatus[pair.Key] = false;
					}
				}
			};

			MouseInput.MouseScroll += args => {
				PlayerInput.ScrollWheelValue = (int)args.Y;
				PlayerInput.ScrollWheelDelta = (int)args.OffsetY;
				PlayerInput.ScrollWheelDeltaForUI = PlayerInput.ScrollWheelDelta;

				PlayerInput.CurrentInputMode = InputMode.Mouse;
				PlayerInput.Triggers.Current.UsedMovementKey = false;
			};

			KeyboardInput.KeyPressed += args => {
				if (args.Key == Keys.F10 && !Main.drawingPlayerChat && !Main.editSign && !Main.editChest) {
					SoundEngine.PlaySound(SoundID.MenuTick);
					Main.showFrameRate = !Main.showFrameRate;
					return;
				}

				if (args.Key == Keys.Enter && !KeyboardUtil.AltDown(args.Modifiers) && Main.hasFocus) {
					if (!Main.drawingPlayerChat && !Main.editSign && !Main.editChest && !Main.gameMenu && !KeyboardInput.IsKeyDown(Keys.Escape)) {
						SoundEngine.PlaySound(SoundID.MenuOpen);
						Main.OpenPlayerChat();
						Main.chatText = "";
					}

					return;
				}

				KeyConfiguration.Processkey(PlayerInput.Triggers.Current, args.Key.ToString());
			};

			KeyboardInput.KeyReleased += args => {
				foreach (var pair in KeyConfiguration.KeyStatus) {
					if (pair.Value.Contains(args.Key.ToString())) {
						PlayerInput.Triggers.Current.KeyStatus[pair.Key] = false;
					}
				}
			};
		}

		internal static void Update(GameTime time) {
			PlayerInput.ScrollWheelDelta = 0;
			PlayerInput.ScrollWheelDeltaForUI = 0;

			if (_lastScreenWidth != Main.screenWidth || _lastScreenHeight != Main.screenHeight) {
				WindowResizedEventArgs args = new WindowResizedEventArgs { Size = new Vector2(Main.screenWidth, Main.screenHeight) };

				// foreach (Layer layer in Layers) layer.OnWindowResize(args);

				_lastScreenWidth = Main.screenWidth;
				_lastScreenHeight = Main.screenHeight;
			}

			MouseInput.Update(time);
			KeyboardInput.Update(time);
		}
	}
}