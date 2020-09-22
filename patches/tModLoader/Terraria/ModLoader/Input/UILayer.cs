using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;
using Terraria.ModLoader.Input.Keyboard;
using Terraria.ModLoader.Input.Mouse;
using Terraria.ModLoader.UI;
using Terraria.UI;

namespace Terraria.ModLoader.Input
{
	// todo: recalculate when scale changes
	public class UIPanel : BaseElement
	{
		public Color BackgroundColor = UICommon.DefaultUIBlue;
		public Color BorderColor = Color.Black;

		// public Texture2D customTexture;

		public UIPanel() {
			Padding = new Padding(8);
		}

		public static void DrawPanel(SpriteBatch spriteBatch, Rectangle dimensions, Texture2D texture, Color color) {
			Point point = new Point(dimensions.X, dimensions.Y);
			Point point2 = new Point((point.X + dimensions.Width) - 12, (point.Y + dimensions.Height) - 12);
			int width = point2.X - point.X - 12;
			int height = point2.Y - point.Y - 12;
			spriteBatch.Draw(texture, new Rectangle(point.X, point.Y, 12, 12), new Rectangle(0, 0, 12, 12), color);
			spriteBatch.Draw(texture, new Rectangle(point2.X, point.Y, 12, 12), new Rectangle(16, 0, 12, 12), color);
			spriteBatch.Draw(texture, new Rectangle(point.X, point2.Y, 12, 12), new Rectangle(0, 16, 12, 12), color);
			spriteBatch.Draw(texture, new Rectangle(point2.X, point2.Y, 12, 12), new Rectangle(16, 16, 12, 12), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + 12, point.Y, width, 12), new Rectangle(12, 0, 4, 12), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + 12, point2.Y, width, 12), new Rectangle(12, 16, 4, 12), color);
			spriteBatch.Draw(texture, new Rectangle(point.X, point.Y + 12, 12, height), new Rectangle(0, 12, 12, 4), color);
			spriteBatch.Draw(texture, new Rectangle(point2.X, point.Y + 12, 12, height), new Rectangle(16, 12, 12, 4), color);
			spriteBatch.Draw(texture, new Rectangle(point.X + 12, point.Y + 12, width, height), new Rectangle(12, 12, 4, 4), color);
		}

		public static readonly Color ColorPanel = new Color(73, 94, 171);
		public static readonly Color ColorPanel_Selected = new Color(51, 65, 119);
		public static readonly Color ColorPanel_Hovered = new Color(94, 120, 221);
		public static readonly Color ColorSlot = new Color(63, 65, 151);
		public static readonly Color ColorOutline = new Color(18, 18, 38);

		public static void DrawPanel(SpriteBatch spriteBatch, Rectangle rectangle, Color? bgColor = null, Color? borderColor = null) {
			DrawPanel(spriteBatch, rectangle, Main.Assets.Request<Texture2D>("Images/UI/PanelBackground").Value, bgColor ?? ColorPanel);
			DrawPanel(spriteBatch, rectangle, Main.Assets.Request<Texture2D>("Images/UI/PanelBorder").Value, borderColor ?? Color.Black);
		}

		protected override void Draw(SpriteBatch spriteBatch) {
			// if (customTexture != null) spriteBatch.Draw(customTexture, Dimensions);
			// else
			DrawPanel(spriteBatch, Dimensions, BackgroundColor, BorderColor);

			if (IsMouseHovering) {
				Main.LocalPlayer.cursorItemIconEnabled = false;
				Main.ItemIconCacheUpdate(0);
			}
		}
	}

	public class UIDraggablePanel : UIPanel
	{
		private Vector2 offset;
		private bool dragging;

		protected override void MouseDown(MouseButtonEventArgs args)
		{
			if (args.Button != MouseButton.Left) return;

			offset = args.Position - Position;

			dragging = true;

			args.Handled = true;
		}

		protected override void MouseUp(MouseButtonEventArgs args)
		{
			if (args.Button != MouseButton.Left) return;

			dragging = false;

			args.Handled = true;
		}

		protected override void Update(GameTime gameTime)
		{
			if (IsMouseHovering)
			{
				Main.LocalPlayer.mouseInterface = true;
				Main.LocalPlayer.cursorItemIconEnabled = false;
				Main.ItemIconCacheUpdate(0);
				Main.mouseText = false;
				Main.HoverItem = new Item();
			}

			if (dragging)
			{
				X.Percent = 0;
				Y.Percent = 0;

				Rectangle parent = Parent?.InnerDimensions ?? UserInterface.ActiveInstance.GetDimensions().ToRectangle();

				X.Pixels = Utils.Clamp((int)(Main.mouseX - offset.X - parent.X),0, parent.Width - OuterDimensions.Width);
				Y.Pixels = Utils.Clamp((int)(Main.mouseY - offset.Y - parent.Y),0, parent.Height - OuterDimensions.Height);

				Recalculate();
			}
		}
	}
	
	public class Doot : BaseState
	{
		public override bool Enabled => true;

		public Doot() {
			Width.Percent = 100;
			Height.Percent = 100;

			UIDraggablePanel panel = new UIDraggablePanel { Width = new StyleDimension(0, 20), Height = new StyleDimension(0, 20), X = new StyleDimension(0, 50), Y = new StyleDimension(0, 50) };
			Add(panel);
			
			UIPanel childPanel = new UIPanel { Width = new StyleDimension(0, 80), Height = new StyleDimension(60, 0), X = new StyleDimension(0, 30), Y = new StyleDimension(0, 100) };
			panel.Add(childPanel);
		}
	}

	public class UILayer : Layer
	{
		public override bool Enabled => !Main.gameMenu;

		private static float Scale => Main.gameMenu ? 1f : Main.UIScale;

		internal List<BaseState> Elements = new List<BaseState>();
		private BaseElement current;
		private BaseElement mouseDownElement;

		internal UILayer() {
			Add(new Doot());
			// Add(new PanelUI());
			// Add(new ChatUI());
		}

		public void Add(BaseState ui) {
			ui.Recalculate();
			Elements.Add(ui);
		}

		public override void OnDraw(SpriteBatch spriteBatch, GameTime gameTime) {
			foreach (BaseState element in Elements.Where(element => element.Display != Display.None).Reverse()) {
				element.InternalDraw(spriteBatch);
			}
		}

		public override void OnUpdate(GameTime gameTime) {
			foreach (BaseState element in Elements.Where(element => element.Display != Display.None)) {
				element.InternalUpdate(gameTime);
			}

			var modifiers = KeyboardUtil.GetModifiers(MouseInput.Keyboard);
			var mousePos = new Vector2(MouseInput.Mouse.X, MouseInput.Mouse.Y);
			foreach (MouseButton button in MouseInput.GetHeldButtons()) {
				MouseButtonEventArgs args = new MouseButtonEventArgs { Modifiers = modifiers, Position = mousePos * (1f / Scale), Button = button };

				foreach (BaseState element in Elements.Where(element => element.Display != Display.None && element.ContainsPoint(args.Position))) {
					element.InternalMouseHeld(args);
					if (args.Handled) break;
				}
			}
		}

		public override void OnMouseDown(MouseButtonEventArgs args) {
			args.Position *= 1f / Scale;

			var elements = Elements.Where(element => element.Display != Display.None && element.ContainsPoint(args.Position)).ToList();
			foreach (BaseState element in elements) {
				mouseDownElement = element.InternalMouseDown(args);
				if (args.Handled) break;
			}

			args.Position *= Scale;
		}

		public override void OnMouseUp(MouseButtonEventArgs args) {
			args.Position *= 1f / Scale;

			if (mouseDownElement != null) {
				mouseDownElement.InternalMouseUp(args);

				mouseDownElement = null;

				return;
			}

			var elements = Elements.Where(element => element.Display != Display.None && element.ContainsPoint(args.Position)).ToList();
			foreach (BaseState element in elements) {
				element.InternalMouseUp(args);
				if (args.Handled) break;
			}

			args.Position *= Scale;
		}

		public override void OnMouseMove(MouseMoveEventArgs args) {
			args.Position *= 1f / Scale;

			var elements = Elements.Where(element => element.Enabled && element.Display != Display.None && element.ContainsPoint(args.Position)).ToList();
			foreach (BaseState element in elements) {
				element.InternalMouseMove(args);
				if (args.Handled) break;
			}

			BaseElement at = Elements.Where(baseElement => baseElement.Enabled).Select(baseElement => baseElement.GetElementAt(args.Position)).FirstOrDefault(baseElement => baseElement != null);
			if (current != at) {
				current?.InternalMouseLeave(args);
				at?.InternalMouseEnter(args);
				current = at;

				foreach (string key in PlayerInput.MouseKeys) {
					foreach (var pair in PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus) {
						if (pair.Value.Contains(key)) {
							PlayerInput.Triggers.Current.KeyStatus[pair.Key] = false;
						}
					}
				}

				PlayerInput.MouseKeys.Clear();
			}

			args.Position *= Scale;
		}

		public override void OnMouseScroll(MouseScrollEventArgs args) {
			args.Position *= 1f / Scale;

			foreach (BaseState element in Elements.Where(element => element.Display != Display.None && element.ContainsPoint(args.Position))) {
				element.InternalMouseScroll(args);
				if (args.Handled) break;
			}

			args.Position *= Scale;
		}

		public override void OnClick(MouseButtonEventArgs args) {
			args.Position *= 1f / Scale;

			foreach (BaseState element in Elements.Where(element => element.Display != Display.None && element.ContainsPoint(args.Position))) {
				element.InternalMouseClick(args);
				if (args.Handled) break;
			}

			args.Position *= Scale;
		}

		public override void OnDoubleClick(MouseButtonEventArgs args) {
			foreach (BaseState element in Elements.Where(element => element.Display != Display.None && element.ContainsPoint(args.Position))) {
				element.InternalDoubleClick(args);
				if (args.Handled) break;
			}
		}

		public override void OnTripleClick(MouseButtonEventArgs args) {
			foreach (BaseState element in Elements.Where(element => element.Display != Display.None && element.ContainsPoint(args.Position))) {
				element.InternalTripleClick(args);
				if (args.Handled) break;
			}
		}

		public override void OnKeyPressed(KeyboardEventArgs args) {
			foreach (BaseState element in Elements.Where(element => element.Display != Display.None)) {
				element.InternalKeyPressed(args);
				if (args.Handled) break;
			}
		}

		public override void OnKeyReleased(KeyboardEventArgs args) {
			foreach (BaseState element in Elements.Where(element => element.Display != Display.None)) {
				element.InternalKeyReleased(args);
				if (args.Handled) break;
			}
		}

		public override void OnKeyTyped(KeyboardEventArgs args) {
			foreach (BaseState element in Elements.Where(element => element.Display != Display.None)) {
				element.InternalKeyTyped(args);
				if (args.Handled) break;
			}
		}

		public override void OnWindowResize(WindowResizedEventArgs args) {
			args.Size *= 1f / Scale;

			foreach (BaseState element in Elements.Where(element => element.Display != Display.None)) {
				element.Recalculate();
			}

			args.Size *= Scale;
		}
	}
}