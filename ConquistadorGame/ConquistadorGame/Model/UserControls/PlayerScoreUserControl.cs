using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using GameObjects;

namespace ConquistadorGame.Model.UserControls {

    public partial class PlayerScoreUserControl : UserControl {

        public PlayerScoreUserControl() {
            InitializeComponent();
        }

        #region Methods

        public void UpdateScore(Player[] players, Player currentPlayer, CountryInfo info) {
            this.players = players;
            this.currentPlayer = currentPlayer;
            this.info = info;
        }

        #endregion Methods

        #region Paint Method

        private void PlayerScoreUserControl_Paint(object sender, PaintEventArgs e) {
            Graphics graphics = e.Graphics;
            // draw backgroud
            drawBackground(graphics);
            drawPlayerBackgrounds(graphics);
            drawPlayerText(graphics);
        }

        private void drawBackground(Graphics graphics) {
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            Color firstColor = Color.FromArgb(64, 64, 64);
            Color secondColor = Color.FromArgb(100, 100, 100);
            LinearGradientBrush brush = new LinearGradientBrush(rect, firstColor, secondColor, 90);
            RoundRectangleCreater.DrawFilledRoundRectangle(graphics, brush, 0, 0, this.Width, this.Height, RADIUS);
        }

        private void drawPlayerBackgrounds(Graphics graphics) {
            if (players != null) {
                for (int playerIndex = 0; playerIndex < players.Length; playerIndex++) {
                    Brush brush = new SolidBrush(players[playerIndex].GetDrawingColor());
                    RoundRectangleCreater.DrawFilledRoundRectangle(graphics, brush, 10 + (110 * playerIndex), 7, 100, 26, RADIUS);
                    if (currentPlayer.Equals(players[playerIndex])) {
                        Pen pen = new Pen(Color.White);
                        RoundRectangleCreater.DrawOutlinedRoundRectangle(graphics, pen, 10 + (110 * playerIndex), 7, 100, 26, RADIUS);
                    }
                }
            }
        }

        private void drawPlayerText(Graphics graphics) {
            if (players != null) {
                Font font = new Font(FontFamily.GenericSansSerif, 12);
                Font currentPlayerFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.Black);

                for (int playerIndex = 0; playerIndex < players.Length; playerIndex++) {
                    PlayerColor color = players[playerIndex].Color;
                    string text = color.ToString() + " - " + info.GetTotalCountryArmyCount(color);
                    if (!currentPlayer.Equals(players[playerIndex])) {
                        graphics.DrawString(text, font, brush, 15 + (110 * playerIndex), 10);
                    } else {
                        graphics.DrawString(text, currentPlayerFont, brush, 15 + (110 * playerIndex), 10);
                    }
                }
            }
        }

        #endregion Paint Method

        #region Properties & Fields

        private CountryInfo info;
        private Player[] players;
        private Player currentPlayer;

        private const int RADIUS = 5;

        #endregion Properties & Fields

    }
}
