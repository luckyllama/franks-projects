using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameObjects {

    public class Player {

        #region Constructor

        public Player(PlayerColor color) {
            this.color = color;
        }

        public Player(PlayerColor color, bool isHuman) {
            this.color = color;
            this.isHuman = isHuman;
        }

        #endregion Constructor

        #region Methods

        public Color GetDrawingColor() {
            return PlayerColorUtil.GetPlayerColor(color);
        }

        #endregion Methods

        #region Properties & Fields

        private PlayerColor color;

        public PlayerColor Color { 
            get { return color; }
        }

        private bool isHuman = false;

        public bool IsHuman {
            get { return isHuman; }
        }

        #endregion Properties & Fields

    }

}
