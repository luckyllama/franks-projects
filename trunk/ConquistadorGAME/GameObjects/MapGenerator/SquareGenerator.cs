using System;
using System.Collections.Generic;
using System.Text;

namespace GameObjects.MapGenerator {

    public class SquareGenerator : IMapGenerator {

        public SquareGenerator(int numberOfPlayers) {
            this.numberOfPlayers = numberOfPlayers;
            this.numberOfCountries = countriesInX * countriesInY;
        }

        #region IMapGenerator Members

        #region Generate Board

        public int[,] GenerateBoard() {
            int[,] result = new int[countriesInY * countrySize, countriesInX * countrySize];

            int currentCountry = 1;

            for (int yIndex = 0; yIndex < countriesInY; yIndex++) {
                for (int xIndex = 0; xIndex < countriesInX; xIndex++) {
                    int firstY = yIndex * countrySize;
                    int firstX = xIndex * countrySize;
                    result[firstY, firstX] = currentCountry;
                    result[firstY + 1, firstX] = currentCountry;
                    result[firstY + 2, firstX] = currentCountry;
                    result[firstY + 3, firstX] = currentCountry;

                    result[firstY, firstX + 1] = currentCountry;
                    result[firstY + 1, firstX + 1] = currentCountry;
                    result[firstY + 2, firstX + 1] = currentCountry;
                    result[firstY + 3, firstX + 1] = currentCountry;

                    result[firstY, firstX + 2] = currentCountry;
                    result[firstY + 1, firstX + 2] = currentCountry;
                    result[firstY + 2, firstX + 2] = currentCountry;
                    result[firstY + 3, firstX + 2] = currentCountry;

                    result[firstY, firstX + 3] = currentCountry;
                    result[firstY + 1, firstX + 3] = currentCountry;
                    result[firstY + 2, firstX + 3] = currentCountry;
                    result[firstY + 3, firstX + 3] = currentCountry;

                    currentCountry++;
                }
            }

            return result;
        }

        #endregion Generate Board

        #region Country Info

        public CountryInfo GetCountryInfo(int[,] board) {
            CountryInfo newInfo = new CountryInfo(board);

            newInfo.InitializeCountrySizeInfo(board);
            newInfo.InitializeCountryBorderInfo(board);
            
            Random random = new Random();

            for (int countryIndex = 1; countryIndex <= numberOfCountries; countryIndex++) {
                newInfo.SetCountryOwner(countryIndex, (PlayerColor)random.Next(numberOfPlayers));
                newInfo.SetCountryArmyCount(countryIndex, random.Next(5) + 1);
            }

            return newInfo;
        }

        #endregion Country Info

        #endregion IMapGenerator Members

        #region Properties & Fields

        private int numberOfPlayers;

        private const int countriesInX = 8;

        private const int countriesInY = 5;

        private const int countrySize = 4;

        private int numberOfCountries;


        #endregion Properties & Fields

    }

}
