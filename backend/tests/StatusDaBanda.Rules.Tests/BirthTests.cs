using StatusDaBanda.Rules;
using Xunit;

namespace StatusDaBanda.Rules.Tests;

public class BirthTests
{
    static Neighborhood N(string id, double w, int cap, bool active = true) =>
        new(id, id, w, cap, active, new[] { new SpawnPoint(0, 1, 0) });

    static RegionCatalog Catalog(params Neighborhood[] ns) =>
        new(new[] { new Country("XX", "X", "X", new[] { new Province("P", "P", new[] { new City("C", "C", ns) }) }) });

    [Fact]
    public void Assign_EIdempotente()
    {
        var s = new BirthService(Catalog(N("a", 1, 100), N("b", 1, 100)), new InMemoryOriginStore(), new Random(1).NextDouble);
        var r1 = s.Assign("p1", "XX");
        var r2 = s.Assign("p1", "XX");
        Assert.True(r1.Ok);
        Assert.Equal(r1.Origin, r2.Origin);
    }

    [Fact]
    public void PaisInvalido_Falha()
    {
        var s = new BirthService(Catalog(N("a", 1, 10)), new InMemoryOriginStore());
        Assert.False(s.Assign("p1", "ZZ").Ok);
    }

    [Fact]
    public void IgnoraInativosECheios()
    {
        var s = new BirthService(Catalog(N("a", 1, 1), N("b", 1, 10, active: false)), new InMemoryOriginStore());
        var r1 = s.Assign("p1", "XX");
        Assert.True(r1.Ok);
        Assert.Equal("a", r1.Origin!.NeighborhoodId);
        Assert.False(s.Assign("p2", "XX").Ok); // a cheio, b inativo
    }

    [Fact]
    public void DistribuicaoRespeitaPesos()
    {
        var country = Catalog(N("a", 3, int.MaxValue), N("b", 1, int.MaxValue)).Countries[0];
        var rng = new Random(42);
        int a = 0, total = 20000;
        for (int i = 0; i < total; i++)
            if (BirthSelector.Pick(country, _ => 0, rng.NextDouble)!.Neighborhood.Id == "a") a++;
        Assert.InRange(a / (double)total, 0.73, 0.77);
    }

    [Fact]
    public void ConcorrenciaNaoCriaDuasOrigens()
    {
        var s = new BirthService(Catalog(N("a", 1, 1000), N("b", 1, 1000)), new InMemoryOriginStore());
        var results = Enumerable.Range(0, 50).AsParallel().Select(_ => s.Assign("p1", "XX").Origin!).ToList();
        Assert.Single(results.Distinct());
    }

    [Fact]
    public void SeedRegionsJson_EValido()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && !File.Exists(Path.Combine(dir.FullName, "infrastructure", "database", "regions.json"))) dir = dir.Parent;
        Assert.NotNull(dir);
        var cat = RegionCatalog.FromJson(File.ReadAllText(Path.Combine(dir!.FullName, "infrastructure", "database", "regions.json")));
        var ids = new HashSet<string>();
        foreach (var n in cat.Countries.SelectMany(c => c.Provinces).SelectMany(p => p.Cities).SelectMany(c => c.Neighborhoods))
        {
            Assert.True(ids.Add(n.Id), $"id duplicado {n.Id}");
            Assert.NotEmpty(n.SpawnPoints);
        }
        Assert.Contains(cat.Countries, c => c.Code == "AO");
        Assert.Contains(cat.Countries, c => c.Code == "MZ");
    }
}
