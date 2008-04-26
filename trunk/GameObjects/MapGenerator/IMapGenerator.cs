using System;

namespace GameObjects.MapGenerator {

    public interface IMapGenerator {

        int[,] GenerateBoard();

        CountryInfo GetCountryInfo(int[,] board);

    }

}
