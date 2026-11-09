namespace StatusDaBanda.Rules;

public sealed record BirthPick(Province Province, City City, Neighborhood Neighborhood);

/// <summary>Seleção ponderada. Regra espelhada em game/Assets/Scripts/World/BirthSelector.cs (apenas para modo offline).</summary>
public static class BirthSelector
{
    public static BirthPick? Pick(Country country, Func<string, int> occupancy, Func<double> rng)
    {
        var cands = new List<(BirthPick Pick, double Weight)>();
        double total = 0;
        foreach (var p in country.Provinces)
        foreach (var c in p.Cities)
        foreach (var n in c.Neighborhoods)
        {
            if (!n.Active || n.BirthWeight <= 0 || n.Capacity <= 0) continue;
            var occ = occupancy(n.Id);
            if (occ >= n.Capacity) continue;
            var w = n.BirthWeight * Math.Max(0.1, 1.0 - (double)occ / n.Capacity);
            cands.Add((new BirthPick(p, c, n), w));
            total += w;
        }
        if (cands.Count == 0) return null;
        var roll = rng() * total;
        foreach (var (pick, w) in cands)
        {
            roll -= w;
            if (roll < 0) return pick;
        }
        return cands[^1].Pick;
    }
}
