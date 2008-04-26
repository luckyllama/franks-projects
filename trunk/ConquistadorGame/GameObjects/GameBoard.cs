using System;
using System.Collections.Generic;
using System.Text;
using GameObjects.MapGenerator;

namespace GameObjects {

    public class GameBoard {

        #region Constructor

        public GameBoard(IMapGenerator generator, int numberOfPlayers) {
            if (generator == null) {
                throw new ArgumentNullException("The argument 'generator' must be non null.");
            }
            if (numberOfPlayers <= 1) {
                throw new ArgumentOutOfRangeException("The number of players must be greater than one.");
            }
            if (numberOfPlayers > Enum.GetValues(typeof(PlayerColor)).Length) {
                throw new ArgumentOutOfRangeException("The number of players must be less than "
                    + Enum.GetValues(typeof(PlayerColor)).Length + ".");
            }
            initializePlayers(numberOfPlayers);
            this.board = generator.GenerateBoard();
            this.countryInfo = generator.GetCountryInfo(this.board);
            Console.WriteLine("Generated Board (size: " + board.Length + ")");
        }

        private void initializePlayers(int numberOfPlayers) {
            players = new Player[numberOfPlayers];
            for (int playerIndex = 0; playerIndex < numberOfPlayers; playerIndex++) {
                PlayerColor color = (PlayerColor)Enum.GetValues(typeof(PlayerColor)).GetValue(playerIndex);
                if (playerIndex == 0) {
                    players[playerIndex] = new Player(color, true);
                } else {
                    players[playerIndex] = new Player(color, false);
                }
            }
            currentPlayerIndex = 0;
        }

        #endregion Constructor

        #region Methods

        public void NextPlayer() { 
            currentPlayerIndex++;
            if (currentPlayerIndex == players.Length) {
                currentPlayerIndex = 0;
            }
        }

        public bool Contains(int y, int x) {
            if (x < 0 || x >= GridWidth) {
                return false;
            } else if (y < 0 || y >= GridHeight) {
                return false;
            } else {
                return true;
            }
        }

        #endregion Methods

        #region Properties & Fields

        private int[,] board;

        public int[,] Board {
            get { return board; }
        }

        public int GridWidth {
            get {
                if (board != null) {
                    return board.GetLength(1);
                } else {
                    return 0;
                }
            }
        }

        public int GridHeight {
            get {
                if (board != null) {
                    return board.GetLength(0);
                } else {
                    return 0;
                }
            }
        }

        private CountryInfo countryInfo;

        public CountryInfo CountryInfo {
            get { return countryInfo; }
        }

        private Player[] players;

        public Player[] Players {
            get { return players; }
        }

        private int currentPlayerIndex;

        public Player CurrentPlayer {
            get { return players[currentPlayerIndex]; }
        }

        #endregion Properties & Fields

    }

}
