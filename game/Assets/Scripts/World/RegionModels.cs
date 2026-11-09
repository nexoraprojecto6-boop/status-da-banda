using System;

namespace SDB.World
{
    // Estrutura espelha infrastructure/database/regions.json (JsonUtility).
    [Serializable] public class SpawnPointData { public float x, y, z; }

    [Serializable]
    public class NeighborhoodData
    {
        public string id, name;
        public double birthWeight;
        public int capacity;
        public bool active;
        public SpawnPointData[] spawnPoints;
    }

    [Serializable] public class CityData { public string id, name; public NeighborhoodData[] neighborhoods; }
    [Serializable] public class ProvinceData { public string id, name; public CityData[] cities; }
    [Serializable] public class CountryData { public string code, name, currency; public ProvinceData[] provinces; }

    [Serializable]
    public class RegionCatalogData
    {
        public CountryData[] countries;

        public static RegionCatalogData Parse(string json) => UnityEngine.JsonUtility.FromJson<RegionCatalogData>(json);

        public CountryData Find(string code)
        {
            if (countries == null) return null;
            foreach (var c in countries) if (c.code == code) return c;
            return null;
        }
    }

    [Serializable]
    public class BirthOrigin
    {
        public string countryCode, provinceId, provinceName, cityId, cityName, neighborhoodId, neighborhoodName;
        public float spawnX, spawnY, spawnZ;
    }
}
