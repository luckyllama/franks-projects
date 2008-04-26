using System;
using System.Collections.Generic;
using System.Text;

namespace GameObjects {

    public class CountryInfo {

        #region Constructor

        public CountryInfo(int[,] board) {
            this.gridWidth = board.GetLength(1);
            this.gridHeight = board.GetLength(0);
        }

        #endregion Constructor

        #region Methods (Set Info Methods) 

        internal void InitializeCountrySizeInfo(int[,] board) {
            countrySizeInfo = new Dictionary<int,int>();

            for (int yIndex = 0; yIndex < gridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < gridWidth; xIndex++) {
                    int countryId = board[yIndex, xIndex];
                    if (countrySizeInfo.ContainsKey(countryId)) {
                        countrySizeInfo[countryId] += countrySizeInfo[countryId];
                    } else {
                        countrySizeInfo.Add(countryId, 1);
                    }
                }
            }
        }

        internal void InitializeCountryBorderInfo(int[,] board) {
            countryBorderInfo = new Dictionary<int, List<int>>();

            for (int yIndex = 0; yIndex < gridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < gridWidth; xIndex++) {
                    int countryId = board[yIndex, xIndex];

                    // add the country if it doesn't currently exist
                    if (!countryBorderInfo.ContainsKey(countryId)) {
                        countryBorderInfo.Add(countryId, new List<int>());
                    }

                    // check the country id of the country to the right of the current one
                    if (xIndex != (gridWidth - 1)) {
                        int borderCountryId = board[yIndex, xIndex + 1];
                        // if we don't know about a bordering country... add it
                        if (borderCountryId != countryId
                            && borderCountryId != 0
                            && !countryBorderInfo[countryId].Contains(borderCountryId)) {

                            countryBorderInfo[countryId].Add(borderCountryId);

                            // also add the knowledge to the bordering country
                            if (!countryBorderInfo.ContainsKey(borderCountryId)) {
                                countryBorderInfo.Add(borderCountryId, new List<int>());
                            }

                            if (!countryBorderInfo[borderCountryId].Contains(countryId)) {
                                countryBorderInfo[borderCountryId].Add(countryId);
                            }
                        }
                    }

                    // check the country id of the country below the current one
                    if (yIndex != (gridHeight - 1)) {
                        int borderCountryId = board[yIndex + 1, xIndex];
                        // if we don't know about a bordering country... add it
                        if (borderCountryId != countryId
                            && borderCountryId != 0
                            && !countryBorderInfo[countryId].Contains(borderCountryId)) {

                            countryBorderInfo[countryId].Add(borderCountryId);

                            // also add the knowledge to the bordering country
                            if (!countryBorderInfo.ContainsKey(borderCountryId)) {
                                countryBorderInfo.Add(borderCountryId, new List<int>());
                            }

                            if (!countryBorderInfo[borderCountryId].Contains(countryId)) {
                                countryBorderInfo[borderCountryId].Add(countryId);
                            }
                        }
                    }
                }
            }
        }

        public void SetCountryOwner(int countryId, PlayerColor owner) {
            if (countryOwnerInfo.ContainsKey(countryId)) {
                countryOwnerInfo[countryId] = owner;
            } else {
                countryOwnerInfo.Add(countryId, owner);
            }
        }

        public void SetCountryArmyCount(int countryId, int armyCount) {
            if (countryArmyInfo.ContainsKey(countryId)) {
                countryArmyInfo[countryId] = armyCount;
            } else {
                countryArmyInfo.Add(countryId, armyCount);
            }
        }

        #endregion Methods (Set Info Methods)

        #region Methods (Get Info Methods)

        public int GetCountrySize(int countryId) {
            if (countrySizeInfo.ContainsKey(countryId)) {
                return countrySizeInfo[countryId];
            } else {
                return 0;
            }
        }

        public PlayerColor GetCountryOwner(int countryId) {
            if (countryOwnerInfo.ContainsKey(countryId)) {
                return countryOwnerInfo[countryId];
            } else {
                return PlayerColor.None;
            }
        }

        public int GetCountryArmyCount(int countryId) {
            if (countryArmyInfo.ContainsKey(countryId)) {
                return countryArmyInfo[countryId];
            } else {
                return 0;
            }
        }

        public int GetTotalCountryArmyCount(PlayerColor color) { 
            int total = 0;
            foreach (int countryId in countryOwnerInfo.Keys) {
                if (countryOwnerInfo[countryId].Equals(color)) {
                    total += GetCountryArmyCount(countryId);
                }
            }
            return total;
        }

        public bool CountriesShareBorder(int countryId1, int countryId2) {
            if (countryBorderInfo.ContainsKey(countryId1)) {
                return countryBorderInfo[countryId1].Contains(countryId2);
            } else {
                return false;
            }
        }

        public int GetCountryCenterX(int countryId, int[,] board) {
            int totalX = 0;
            int totalXCount = 0;

            for (int yIndex = 0; yIndex < gridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < gridWidth; xIndex++) {
                    if (board[yIndex, xIndex] == countryId) {
                        totalX += xIndex;
                        totalXCount++;
                    }
                }
            }

            return totalX / totalXCount;
        }

        public int GetCountryCenterY(int countryId, int[,] board) {
            int totalY = 0;
            int totalYCount = 0;

            for (int yIndex = 0; yIndex < gridHeight; yIndex++) {
                for (int xIndex = 0; xIndex < gridWidth; xIndex++) {
                    if (board[yIndex, xIndex] == countryId) {
                        totalY += yIndex;
                        totalYCount++;
                    }
                }
            }

            return totalY / totalYCount;
        }

        public int GetCountryCount() {
            return countryOwnerInfo.Count;
        }

        #endregion Methods (Get Info Methods)

        #region Properties & Fields

        private int gridWidth;

        private int gridHeight;

        private Dictionary<int, int> countrySizeInfo = new Dictionary<int,int>();

        private Dictionary<int, List<int>> countryBorderInfo = new Dictionary<int, List<int>>();

        private Dictionary<int, PlayerColor> countryOwnerInfo = new Dictionary<int, PlayerColor>();

        private Dictionary<int, int> countryArmyInfo = new Dictionary<int, int>();

        #endregion Properties & Fields

    }

}
