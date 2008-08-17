using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GameObjects;
using GameObjects.MapGenerator;
using ConquistadorGame.Controller;

namespace ConquistadorGame.UserControls {

    public partial class GameBoardUserControl : UserControl {

        #region Constructor 

        public GameBoardUserControl() {
            InitializeComponent();
        }

        #endregion Constructor

        #region Event Handlers

        #region Paint Event

        private void GameBoardUserControl_Paint(object sender, PaintEventArgs e) {
            if (gameIsActive) {
                Graphics graphics = e.Graphics;

                int gridSizeWidth = gameBoardWidth / board.GridWidth;
                int gridSizeHeight = gameBoardHeight / board.GridHeight;
                Rectangle gridRectangle = new Rectangle(0, 0, gridSizeWidth, gridSizeHeight);

                Console.WriteLine("GridWidth: " + board.GridWidth);
                Console.WriteLine("GridHeight: " + board.GridHeight);
                Console.WriteLine("GridSize: " + gridSizeWidth + " x " + gridSizeHeight);

                //drawGrid(graphics, gridSizeWidth, gridSizeHeight, gridRectangle);
                drawCountries(graphics, gridSizeWidth, gridSizeHeight, gridRectangle);
                drawBorders(graphics, gridSizeWidth, gridSizeHeight);
                drawArmyCount(graphics, gridSizeWidth, gridSizeHeight);
            }

            conditionallyShowEndTurnButton();
            conditionallyShowPlayerScore();
        }

        private void drawGrid(Graphics graphics, int gridSizeWidth, int gridSizeHeight, Rectangle gridRectangle) {
            Pen dashedDarkGrayPen = new Pen(Brushes.DarkGray);
            dashedDarkGrayPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            for (int yIndex = 0; yIndex < board.GridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < board.GridWidth; xIndex++) {
                    gridRectangle.X = gridSizeWidth * xIndex;
                    gridRectangle.Y = gridSizeHeight * yIndex;

                    graphics.DrawRectangle(dashedDarkGrayPen, gridRectangle);
                }
            }
        }

        private void drawCountries(Graphics graphics, int gridSizeWidth, int gridSizeHeight, Rectangle gridRectangle) {
            for (int yIndex = 0; yIndex < board.GridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < board.GridWidth; xIndex++) {
                    gridRectangle.X = gridSizeWidth * xIndex;
                    gridRectangle.Y = gridSizeHeight * yIndex;

                    int currentCountryId = board.Board[yIndex, xIndex];
                    if (currentCountryId > 0) {
                        if (selectedCountryId != currentCountryId) {
                            PlayerColor playerColor = board.CountryInfo.GetCountryOwner(currentCountryId);
                            graphics.FillRectangle(new SolidBrush(PlayerColorUtil.GetPlayerColor(playerColor)), gridRectangle);
                        } else {
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), gridRectangle);
                        }
                    }
                }
            }
        }

        private void drawBorders(Graphics graphics, int gridSizeWidth, int gridSizeHeight) {
            Pen borderPen = new Pen(Color.Black);
            Point point1 = new Point();
            Point point2 = new Point();
            for (int yIndex = 0; yIndex < board.GridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < board.GridWidth; xIndex++) {

                    if (xIndex > 0) {
                        if (board.CountryInfo.CountriesShareBorder(board.Board[yIndex, xIndex], board.Board[yIndex, xIndex - 1])) {
                            point1 = new Point(gridSizeWidth * xIndex, gridSizeHeight * yIndex);
                            point2 = new Point(gridSizeWidth * xIndex, gridSizeHeight * (yIndex + 1));
                            graphics.DrawLine(borderPen, point1, point2);
                        }
                    }

                    if (xIndex != (board.GridWidth - 1)) {
                        if (board.CountryInfo.CountriesShareBorder(board.Board[yIndex, xIndex], board.Board[yIndex, xIndex + 1])) {
                            point1 = new Point(gridSizeWidth * (xIndex + 1), gridSizeHeight * yIndex);
                            point2 = new Point(gridSizeWidth * (xIndex + 1), gridSizeHeight * (yIndex + 1));
                            graphics.DrawLine(borderPen, point1, point2);
                        }
                    }

                    if (yIndex > 0) {
                        if (board.CountryInfo.CountriesShareBorder(board.Board[yIndex, xIndex], board.Board[yIndex - 1, xIndex])) {
                            point1 = new Point(gridSizeWidth * (xIndex), gridSizeHeight * yIndex);
                            point2 = new Point(gridSizeWidth * (xIndex + 1), gridSizeHeight * yIndex);
                            graphics.DrawLine(borderPen, point1, point2);
                        }
                    }

                    if (yIndex != (board.GridHeight - 1)) {
                        if (board.CountryInfo.CountriesShareBorder(board.Board[yIndex, xIndex], board.Board[yIndex + 1, xIndex])) {
                            point1 = new Point(gridSizeWidth * (xIndex), gridSizeHeight * (yIndex + 1));
                            point2 = new Point(gridSizeWidth * (xIndex + 1), gridSizeHeight * (yIndex + 1));
                            graphics.DrawLine(borderPen, point1, point2);
                        }
                    }
                }
            }
        }

        private void drawArmyCount(Graphics graphics, int gridSizeWidth, int gridSizeHeight) {
            Font font = new Font(FontFamily.GenericSansSerif, 12);
            Brush brush = new SolidBrush(Color.Black);
            Brush selectedBrush = new SolidBrush(Color.White);

            for (int countryIndex = 1; countryIndex < board.CountryInfo.GetCountryCount(); countryIndex++) {
                int newX = gridSizeWidth * board.CountryInfo.GetCountryCenterX(countryIndex, board.Board);
                int newY = gridSizeHeight * board.CountryInfo.GetCountryCenterY(countryIndex, board.Board);
                if (countryIndex != selectedCountryId) {
                    graphics.DrawString(board.CountryInfo.GetCountryArmyCount(countryIndex).ToString(), font, brush, newX, newY);
                } else {
                    graphics.DrawString(board.CountryInfo.GetCountryArmyCount(countryIndex).ToString(), font, selectedBrush, newX, newY);
                }
            }
        }

        private void conditionallyShowEndTurnButton() {
            if (gameIsActive) {
                EndTurnButton.Visible = true;
                if (board.CurrentPlayer.IsHuman) {
                    EndTurnButton.Enabled = true;
                } else {
                    EndTurnButton.Enabled = false;
                }
            } else {
                EndTurnButton.Visible = false;
            }
        }

        private void conditionallyShowPlayerScore() {
            if (gameIsActive) {
                PlayerScore.Visible = true;
            } else {
                PlayerScore.Visible = false;
            }
        }

        #endregion Paint Event

        #region Mouse Click Event

        internal void GameBoardUserCountrol_MouseClick(object sender, MouseEventArgs e) {
            if (gameIsActive && board.CurrentPlayer.IsHuman) {
                int gridSizeWidth = gameBoardWidth / board.GridWidth;
                int gridSizeHeight = gameBoardHeight / board.GridHeight;
                int boardX = e.X / gridSizeWidth;
                int boardY = e.Y / gridSizeHeight;

                if (board.Contains(boardY, boardX)) {
                    int clickedCountryId = board.Board[boardY, boardX];
                    if (selectedCountryId == 0) {
                        handleFirstMouseClick(clickedCountryId);
                    } else {
                        handleSecondMouseClick(clickedCountryId);
                    }
                }

                UpdateGameBoard();
            }
        }

        private void handleFirstMouseClick(int clickedCountryId) {
            if (userClickedOnOwnCountry(clickedCountryId)) {
                selectedCountryId = clickedCountryId;
                SoundController.PlayCountrySelectSound();
            } else {
                SoundController.PlayCountrySelectErrorSound();
            }
        }

        private bool userClickedOnOwnCountry(int clickedCountryId) {
            return board.CountryInfo.GetCountryOwner(clickedCountryId).Equals(board.CurrentPlayer.Color);
        }

        private void handleSecondMouseClick(int clickedCountryId) {
            // if the user clicks the same square, de-select it
            if (selectedCountryId == clickedCountryId) {
                selectedCountryId = 0;
                SoundController.PlayCountrySelectSound();
            } // else if the user clicks on another country they own, make that the selected one
            else if (userClickedOnOwnCountry(clickedCountryId)) {
                selectedCountryId = clickedCountryId;
                SoundController.PlayCountrySelectSound();
            } // else check to see if the countries can battle and perform the battle
            else {
                if (countriesCanBattle(clickedCountryId, selectedCountryId)) {
                    if (board.CountryInfo.GetCountryArmyCount(selectedCountryId) > 1) {
                        if (rollDice(selectedCountryId, clickedCountryId)) {
                            int newArmyCount = board.CountryInfo.GetCountryArmyCount(selectedCountryId) - 1;
                            board.CountryInfo.SetCountryArmyCount(clickedCountryId, newArmyCount);
                            board.CountryInfo.SetCountryOwner(clickedCountryId, board.CurrentPlayer.Color);
                        }
                        board.CountryInfo.SetCountryArmyCount(selectedCountryId, 1);
                        selectedCountryId = 0;
                    } else {
                        SoundController.PlayCountrySelectErrorSound();
                    }
                } else {
                    SoundController.PlayCountrySelectErrorSound();
                }
            }
        }

        private bool countriesCanBattle(int countryId1, int countryId2) {
            return board.CountryInfo.CountriesShareBorder(countryId1, countryId2);
        }

        private bool rollDice(int attackerId, int defenderId) {
            DiceRollUserControl diceControl = new DiceRollUserControl();
            diceControl.Left = 160;
            diceControl.Top = 90;

            PlayerColor attacker = board.CountryInfo.GetCountryOwner(attackerId);
            int attackerArmy = board.CountryInfo.GetCountryArmyCount(attackerId);
            PlayerColor defender = board.CountryInfo.GetCountryOwner(defenderId);
            int defenderArmy = board.CountryInfo.GetCountryArmyCount(defenderId);

            Controls.Add(diceControl);

            bool result = diceControl.RollDice(attacker, attackerArmy, defender, defenderArmy);

            Controls.Remove(diceControl);

            return result;
        }

        #endregion Mouse Click Event

        private void EndTurnButton_Click(object sender, EventArgs e) {

        }

        #endregion Event Handlers

        #region Methods

        public void NewGame(int numberOfPlayers) {
            IMapGenerator generator = new SquareGenerator(numberOfPlayers);
            this.board = new GameBoard(generator, numberOfPlayers);
            gameIsActive = true;
            selectedCountryId = 0;

            UpdateGameBoard();
        }

        public void UpdateGameBoard() {
            PlayerScore.UpdateScore(board.Players, board.CurrentPlayer, board.CountryInfo);
            this.Invalidate();
            this.Update();
        }

        #endregion Methods

        #region Properties & Fields

        private int selectedCountryId = 0;

        private GameBoard board;

        private bool gameIsActive = false;

        public bool GameIsActive {
            get { return gameIsActive; }
        }

        private int gameBoardWidth = 875;
        private int gameBoardHeight = 500;

        #endregion Properties & Fields

    }
}
