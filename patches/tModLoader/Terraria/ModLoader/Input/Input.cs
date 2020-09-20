using Microsoft.Xna.Framework;
using Terraria.GameInput;
using Terraria.ModLoader.Input.Keyboard;
using Terraria.ModLoader.Input.Mouse;

namespace Terraria.ModLoader.Input
{
	public static class Input
	{
		private static int lastScreenWidth;
		private static int lastScreenHeight;

		// todo: implement layer system
		internal static void Load() {
			MouseInput.Load();
			KeyboardEvents.Load();
			KeyboardEvents.RepeatDelay = 31;

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
				if (args.Button == MouseButton.Left) {
					PlayerInput.MouseKeys.Add("Mouse1");
					Main.mouseLeft = true;
				}

				if (args.Button == MouseButton.Right) {
					PlayerInput.MouseKeys.Add("Mouse2");
					Main.mouseRight = true;
				}

				if (args.Button == MouseButton.Middle) {
					PlayerInput.MouseKeys.Add("Mouse3");
					Main.mouseMiddle = true;
				}

				if (args.Button == MouseButton.XButton1) {
					PlayerInput.MouseKeys.Add("Mouse4");
					Main.mouseXButton1 = true;
				}

				if (args.Button == MouseButton.XButton2) {
					PlayerInput.MouseKeys.Add("Mouse5");
					Main.mouseXButton2 = true;
				}

				PlayerInput.CurrentInputMode = InputMode.Mouse;
				PlayerInput.Triggers.Current.UsedMovementKey = false;
			};

			MouseInput.ButtonReleased += args => {
				if (args.Button == MouseButton.Left) {
					PlayerInput.MouseKeys.Remove("Mouse1");
					Main.mouseLeft = false;
				}

				if (args.Button == MouseButton.Right) {
					PlayerInput.MouseKeys.Remove("Mouse2");
					Main.mouseRight = false;
				}

				if (args.Button == MouseButton.Middle) {
					PlayerInput.MouseKeys.Remove("Mouse3");
					Main.mouseMiddle = false;
				}

				if (args.Button == MouseButton.XButton1) {
					PlayerInput.MouseKeys.Remove("Mouse4");
					Main.mouseXButton1 = false;
				}

				if (args.Button == MouseButton.XButton2) {
					PlayerInput.MouseKeys.Remove("Mouse5");
					Main.mouseXButton2 = false;
				}
			};

			MouseInput.MouseScroll += args => {
				PlayerInput.ScrollWheelValue = (int)args.Y;
				PlayerInput.ScrollWheelDelta = (int)args.OffsetY;
				PlayerInput.ScrollWheelDeltaForUI = PlayerInput.ScrollWheelDelta;

				PlayerInput.CurrentInputMode = InputMode.Mouse;
				PlayerInput.Triggers.Current.UsedMovementKey = false;
			};

			// MouseInput.ButtonDoubleClicked += args =>
			// {
			// 	foreach (Layer layer in Layers)
			// 	{
			// 		layer.OnDoubleClick(args);
			// 		if (args.Handled) break;
			// 	}
			// };
			//
			// MouseInput.ButtonTripleClicked += args =>
			// {
			// 	foreach (Layer layer in Layers)
			// 	{
			// 		layer.OnTripleClick(args);
			// 		if (args.Handled) break;
			// 	}
			// };
			//
			// MouseInput.ButtonPressed += args =>
			// {
			// 	foreach (Layer layer in Layers)
			// 	{
			// 		layer.OnMouseDown(args);
			// 		if (args.Handled) break;
			// 	}
			// };
			//
			// MouseInput.ButtonReleased += args =>
			// {
			// 	foreach (Layer layer in Layers)
			// 	{
			// 		layer.OnMouseUp(args);
			// 		if (args.Handled) break;
			// 	}
			// };
			//
			// KeyboardEvents.KeyPressed += args =>
			// {
			// 	foreach (Layer layer in Layers)
			// 	{
			// 		layer.OnKeyPressed(args);
			// 		if (args.Handled) break;
			// 	}
			// };
			//
			// KeyboardEvents.KeyReleased += args =>
			// {
			// 	foreach (Layer layer in Layers)
			// 	{
			// 		layer.OnKeyReleased(args);
			// 		if (args.Handled) break;
			// 	}
			// };
			//
			// KeyboardEvents.KeyTyped += args =>
			// {
			// 	foreach (Layer layer in Layers)
			// 	{
			// 		layer.OnKeyTyped(args);
			// 		if (args.Handled) break;
			// 	}
			// };
		}

		internal static void Update(GameTime time) {
			PlayerInput.ScrollWheelDelta = 0;
			PlayerInput.ScrollWheelDeltaForUI = 0;

			if (lastScreenWidth != Main.screenWidth || lastScreenHeight != Main.screenHeight) {
				WindowResizedEventArgs args = new WindowResizedEventArgs { Size = new Vector2(Main.screenWidth, Main.screenHeight) };

				// foreach (Layer layer in Layers) layer.OnWindowResize(args);

				lastScreenWidth = Main.screenWidth;
				lastScreenHeight = Main.screenHeight;
			}

			MouseInput.Update(time);
			KeyboardEvents.Update(time);
		}
	}
}