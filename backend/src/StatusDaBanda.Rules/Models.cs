using System.Text.Json;

namespace StatusDaBanda.Rules;

public record SpawnPoint(float X, float Y, float Z);
public record Neighborhood(string Id, string Name, double BirthWeight, int Capacity, bool Active, IReadOnlyList<SpawnPoint> SpawnPoints);
public record City(string Id, string Name, IReadOnlyList<Neighborhood> Neighborhoods);
public record Province(string Id, string Name, IReadOnlyList<City> Cities);
public record Country(string Code, string Name, string Currency, IReadOnlyList<Province> Provinces);

public record RegionCatalog(IReadOnlyList<Country> Countries)
{
    static readonly JsonSerializerOptions Options = new() { PropertyNameCaseInsensitive = true };

    public static RegionCatalog FromJson(string json) =>
        JsonSerializer.Deserialize<RegionCatalog>(json, Options) ?? throw new InvalidDataException("regions.json inválido");
}

public record BirthOrigin(string PlayerId, string CountryCode, string ProvinceId, string CityId, string NeighborhoodId, float SpawnX, float SpawnY, float SpawnZ);
public record BirthResult(bool Ok, BirthOrigin? Origin, string? Error);
