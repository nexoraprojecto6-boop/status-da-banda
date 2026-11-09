using System.Threading.Tasks;
using SDB.Core;
using SDB.World;
using UnityEngine;

namespace SDB.Services
{
    /// <summary>Implementação offline (só desenvolvimento). Em produção quem sorteia é o servidor (ADR-0004).</summary>
    public sealed class OfflineBirthService : IBirthService
    {
        readonly RegionCatalogData _catalog;
        public OfflineBirthService(RegionCatalogData catalog) { _catalog = catalog; }

        public static string Key(string playerId) => "sdb.origin." + playerId;

        public Task<BirthOrigin> GetOriginAsync(string playerId)
        {
            var json = PlayerPrefs.GetString(Key(playerId), "");
            return Task.FromResult(string.IsNullOrEmpty(json) ? null : JsonUtility.FromJson<BirthOrigin>(json));
        }

        public async Task<Result<BirthOrigin>> AssignAsync(string playerId, string countryCode)
        {
            var existing = await GetOriginAsync(playerId);
            if (existing != null) return Result<BirthOrigin>.Success(existing);

            var country = _catalog?.Find(countryCode);
            if (country == null) return Result<BirthOrigin>.Fail("País inválido");
            if (!BirthSelector.TryPick(country, _ => 0, CryptoRng.NextDouble, out var pick))
                return Result<BirthOrigin>.Fail("Sem bairros disponíveis");

            var sp = pick.Neighborhood.spawnPoints;
            var s = (sp != null && sp.Length > 0)
                ? sp[Mathf.Min(sp.Length - 1, (int)(CryptoRng.NextDouble() * sp.Length))]
                : new SpawnPointData();

            var origin = new BirthOrigin
            {
                countryCode = country.code,
                provinceId = pick.Province.id, provinceName = pick.Province.name,
                cityId = pick.City.id, cityName = pick.City.name,
                neighborhoodId = pick.Neighborhood.id, neighborhoodName = pick.Neighborhood.name,
                spawnX = s.x, spawnY = s.y, spawnZ = s.z
            };
            PlayerPrefs.SetString(Key(playerId), JsonUtility.ToJson(origin));
            PlayerPrefs.Save();
            return Result<BirthOrigin>.Success(origin);
        }
    }
}
