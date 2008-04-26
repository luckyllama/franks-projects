using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameObjects {

    public enum PlayerColor {
        Red,
        Blue,
        Orange,
        Green,
        Yellow,
        Purple,
        None
    }

    public class PlayerColorUtil {

        public static Color GetPlayerColor(PlayerColor player) {
            switch (player) {
                case PlayerColor.Red: return Color.FromArgb(255, 55, 55);
                case PlayerColor.Blue: return Color.FromArgb(110, 150, 255);
                case PlayerColor.Orange: return Color.FromArgb(255, 200, 90);
                case PlayerColor.Green: return Color.FromArgb(85, 255, 85);
                case PlayerColor.Yellow: return Color.FromArgb(255, 255, 100);
                case PlayerColor.Purple: return Color.FromArgb(255, 100, 255);
                default: return Color.FromKnownColor(KnownColor.Black);
            }
        }

    }

}
