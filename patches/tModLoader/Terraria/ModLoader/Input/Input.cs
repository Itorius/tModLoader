﻿using Microsoft.Xna.Framework;
using Terraria.GameInput;
using Terraria.ModLoader.Input.Keyboard;
using Terraria.ModLoader.Input.Mouse;

namespace Terraria.ModLoader.Input
{
	public static class Input
	{
		private static int _lastScreenWidth;
		private static int _lastScreenHeight;

		public static LayerStack Layers;

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

			MouseInput.ButtonClicked += args =>
			{
				foreach (Layer layer in Layers)
				{
					layer.OnClick(args);
					if (args.Handled) break;
				}
			};

			MouseInput.ButtonDoubleClicked += args =>
			{
				foreach (Layer layer in Layers)
				{
					layer.OnDoubleClick(args);
					if (args.Handled) break;
				}
			};

			MouseInput.ButtonTripleClicked += args =>
			{
				foreach (Layer layer in Layers)
				{
					layer.OnTripleClick(args);
					if (args.Handled) break;
				}
			};

			MouseInput.MouseScroll += args =>
			{
				foreach (Layer layer in Layers)
				{
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
			
			KeyboardInput.KeyTyped += args => {
				foreach (Layer layer in Layers) {
					layer.OnKeyTyped(args);
					if (args.Handled) break;
				}
			};

			Main.OnRenderTargetsInitialized += (width, height) =>
			{
				WindowResizedEventArgs args = new WindowResizedEventArgs(new Vector2(width, height));

				foreach (Layer layer in Layers) layer.OnWindowResize(args);
			};
		}

		internal static void Update(GameTime time) {
			PlayerInput.ScrollWheelDelta = 0;
			PlayerInput.ScrollWheelDeltaForUI = 0;

			// if (_lastScreenWidth != Main.screenWidth || _lastScreenHeight != Main.screenHeight) {
			// 	WindowResizedEventArgs args = new WindowResizedEventArgs { Size = new Vector2(Main.screenWidth, Main.screenHeight) };
			//
			// 	foreach (Layer layer in Layers) layer.OnWindowResize(args);
			//
			// 	_lastScreenWidth = Main.screenWidth;
			// 	_lastScreenHeight = Main.screenHeight;
			// }

			MouseInput.Update(time);
			KeyboardInput.Update(time);
		}
	}
}