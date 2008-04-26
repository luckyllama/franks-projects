using System;
using System.Collections.Generic;
using System.Text;

namespace GameObjects.MapGenerator {
    public class AdditiveGrowGenerator : IMapGenerator {

        #region Constructor

        public AdditiveGrowGenerator(BoardSize size, int numberOfPlayers) {
            this.size = size;
            this.numberOfPlayers = numberOfPlayers;
            this.numberOfCountries = (int)size * numberOfPlayers;
            Console.WriteLine("AdditiveGrowGenerator: numberOfCountries = " + numberOfCountries);
        }

        #endregion Constructor

        #region IMapGenerator Implemented Methods

        #region Generate Board

        public int[,] GenerateBoard() {
            this.gridWidth = numberOfCountries * 2;
            this.gridHeight = numberOfCountries;
            generatedBoard = new int[gridHeight, gridWidth];

            for (int yIndex = 0; yIndex < gridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < gridWidth; xIndex++) {
                    generatedBoard[yIndex, xIndex] = 0;
                }
            }

            generateFirstCountry();
            growCountry(1);
            for (int countryIndex = 2; countryIndex < (numberOfCountries + 1); countryIndex++) {

            }

            return generatedBoard;
        }

        private void generateFirstCountry() {
            generatedBoard[gridHeight / 2, gridWidth / 2] = 1;
        }

        private void growCountry(int countryId) {
            int countrySize = (gridWidth * gridHeight) / (numberOfCountries * 16);
            //int countrySize = 4;
            for (int sizeIndex = 0; sizeIndex < countrySize; sizeIndex++) {
                growCountryOnce(countryId);
            }
        }

        private void growCountryOnce(int countryId) {
            int[,] newBoard = (int[,])generatedBoard.Clone();
            for (int yIndex = 0; yIndex < gridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < gridWidth; xIndex++) {
                    if (generatedBoard[yIndex, xIndex] == countryId) {
                        if (yIndex != gridHeight - 1) {
                            if (generatedBoard[yIndex + 1, xIndex] == 0) {
                                newBoard[yIndex + 1, xIndex] = countryId;
                            }
                        }
                        if (yIndex != 0) {
                            if (generatedBoard[yIndex - 1, xIndex] == 0) {
                                newBoard[yIndex - 1, xIndex] = countryId;
                            }
                        }
                        if (xIndex != gridWidth - 1) {
                            if (generatedBoard[yIndex, xIndex + 1] == 0) {
                                newBoard[yIndex, xIndex + 1] = countryId;
                            }
                        }
                        if (xIndex != 0) {
                            if (generatedBoard[yIndex, xIndex - 1] == 0) {
                                newBoard[yIndex, xIndex - 1] = countryId;
                            }
                        }
                    }
                }
            }
            generatedBoard = newBoard;
        }

        #endregion Generate Board

        #region Get Country Info

        public CountryInfo GetCountryInfo(int[,] board) {
            CountryInfo newInfo = new CountryInfo(board);

            newInfo.InitializeCountrySizeInfo(board);
            newInfo.InitializeCountryBorderInfo(board);

            return newInfo;
        }

        #endregion Get Country Info

        #endregion IMapGenerator Implemented Methods

        #region Properties & Fields & Enums

        private BoardSize size;

        private int[,] generatedBoard;

        private int numberOfPlayers;

        private int numberOfCountries;

        private int gridWidth;

        private int gridHeight;

        public enum BoardSize {
            Tiny = 3,
            Small = 4,
            Medium = 6,
            Large = 8
        }

        #endregion Properties & Fields & Enums

    }
}
