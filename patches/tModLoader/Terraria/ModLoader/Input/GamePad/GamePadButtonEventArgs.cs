using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Terraria.ModLoader.Input.GamePad
{
	public class GamePadButtonEventArgs : GamePadEventArgs
	{
		public GamePadButtons Button { get; set; }

		public GamePadButtonEventArgs(TimeSpan gameTime, PlayerIndex logicalIndex, GamePadButtons button, GamePadState current) : base(gameTime, logicalIndex, current)
		{
			Button = button;
		}
	}
}