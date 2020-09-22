using Microsoft.Xna.Framework;
using Terraria.GameInput;
using Terraria.ModLoader.Input.Keyboard;
using Terraria.ModLoader.Input.Mouse;

namespace Terraria.ModLoader.Input
{
	public static class Input
	{
		private static int _lastScreenWidth;
		private static int _lastScreenHeight;

		private static LayerStack Layers;

		internal static void Load() {
			Layers = new LayerStack();
			Layers.PushLayer(new TerrariaLayer());

			MouseInput.Load();
			KeyboardInput.Load();

			MouseInput.MouseMoved += args => {
				foreach (Layer layer in Layers) {
					layer.OnMouseMove(args);
				}
			};

			MouseInput.ButtonPressed += args => {
				foreach (Layer layer in Layers) {
					layer.OnMouseDown(args);
					if (args.Handled) break;
				}
			};

			MouseInput.ButtonReleased += args => {
				foreach (Layer layer in Layers) {
					layer.OnMouseUp(args);
					if (args.Handled) break;
				}
			};

			MouseInput.MouseScroll += args => {
				foreach (Layer layer in Layers) {
					layer.OnMouseScroll(args);
					if (args.Handled) break;
				}
			};

			KeyboardInput.KeyPressed += args => {
				foreach (Layer layer in Layers) {
					layer.OnKeyPressed(args);
					if (args.Handled) break;
				}
			};

			KeyboardInput.KeyReleased += args => {
				foreach (Layer layer in Layers) {
					layer.OnKeyReleased(args);
					if (args.Handled) break;
				}
			};
		}

		internal static void Update(GameTime time) {
			PlayerInput.ScrollWheelDelta = 0;
			PlayerInput.ScrollWheelDeltaForUI = 0;

			if (_lastScreenWidth != Main.screenWidth || _lastScreenHeight != Main.screenHeight) {
				WindowResizedEventArgs args = new WindowResizedEventArgs { Size = new Vector2(Main.screenWidth, Main.screenHeight) };

				foreach (Layer layer in Layers) layer.OnWindowResize(args);

				_lastScreenWidth = Main.screenWidth;
				_lastScreenHeight = Main.screenHeight;
			}

			MouseInput.Update(time);
			KeyboardInput.Update(time);
		}
	}
}