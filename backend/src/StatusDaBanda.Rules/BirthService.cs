using System.Security.Cryptography;

namespace StatusDaBanda.Rules;

public interface IOriginStore
{
    BirthOrigin? Get(string playerId);
    /// <summary>Atómico: se já existir origem devolve-a; senão grava a devolvida pela fábrica.</summary>
    BirthOrigin GetOrAdd(string playerId, Func<BirthOrigin> factory);
    int Occupancy(string neighborhoodId);
}

public sealed class InMemoryOriginStore : IOriginStore
{
    readonly object _gate = new();
    readonly Dictionary<string, BirthOrigin> _byPlayer = new();

    public BirthOrigin? Get(string playerId) { lock (_gate) return _byPlayer.GetValueOrDefault(playerId); }

    public BirthOrigin GetOrAdd(string playerId, Func<BirthOrigin> factory)
    {
        lock (_gate)
        {
            if (_byPlayer.TryGetValue(playerId, out var existing)) return existing;
            var created = factory();
            _byPlayer[playerId] = created;
            return created;
        }
    }

    public int Occupancy(string neighborhoodId) { lock (_gate) return _byPlayer.Values.Count(o => o.NeighborhoodId == neighborhoodId); }
}

/// <summary>Nascimento aleatório autoritativo (ADR-0004): só recebe o país; idempotente por jogador.</summary>
public sealed class BirthService
{
    readonly RegionCatalog _catalog;
    readonly IOriginStore _store;
    readonly Func<double> _rng;

    public BirthService(RegionCatalog catalog, IOriginStore store, Func<double>? rng = null)
    {
        _catalog = catalog; _store = store; _rng = rng ?? SecureRng;
    }

    public static double SecureRng() => (RandomNumberGenerator.GetInt32(int.MaxValue) + 0.0) / int.MaxValue * 0.999999999;

    public BirthResult Assign(string playerId, string countryCode)
    {
        if (string.IsNullOrWhiteSpace(playerId)) return new(false, null, "playerId inválido");
        var existing = _store.Get(playerId);
        if (existing is not null) return new(true, existing, null);

        var country = _catalog.Countries.FirstOrDefault(c => c.Code == countryCode);
        if (country is null) return new(false, null, "País inválido");

        try
        {
            var origin = _store.GetOrAdd(playerId, () =>
            {
                var pick = BirthSelector.Pick(country, _store.Occupancy, _rng)
                           ?? throw new InvalidOperationException("Sem bairros disponíveis");
                var sp = pick.Neighborhood.SpawnPoints;
                var s = sp.Count > 0 ? sp[Math.Min(sp.Count - 1, (int)(_rng() * sp.Count))] : new SpawnPoint(0, 1, 0);
                return new BirthOrigin(playerId, country.Code, pick.Province.Id, pick.City.Id, pick.Neighborhood.Id, s.X, s.Y, s.Z);
            });
            return new(true, origin, null);
        }
        catch (InvalidOperationException e)
        {
            return new(false, null, e.Message);
        }
    }
}
