using System;
using System.Collections.Generic;

namespace SDB.World
{
    public sealed class BirthPick
    {
        public ProvinceData Province; public CityData City; public NeighborhoodData Neighborhood;
    }

    /// <summary>Seleção ponderada: peso base x fator de equilíbrio (favorece bairros menos ocupados). Mesma regra do backend.</summary>
    public static class BirthSelector
    {
        public static bool TryPick(CountryData country, Func<string, int> occupancy, Func<double> rng, out BirthPick pick)
        {
            pick = null;
            if (country?.provinces == null) return false;
            var cands = new List<(BirthPick p, double w)>();
            double total = 0;
            foreach (var pr in country.provinces)
            foreach (var c in pr.cities)
            foreach (var n in c.neighborhoods)
            {
                if (!n.active || n.birthWeight <= 0 || n.capacity <= 0) continue;
                int occ = occupancy(n.id);
                if (occ >= n.capacity) continue;
                double w = n.birthWeight * Math.Max(0.1, 1.0 - (double)occ / n.capacity);
                cands.Add((new BirthPick { Province = pr, City = c, Neighborhood = n }, w));
                total += w;
            }
            if (cands.Count == 0) return false;
            double roll = rng() * total;
            foreach (var (p, w) in cands)
            {
                roll -= w;
                if (roll < 0) { pick = p; return true; }
            }
            pick = cands[cands.Count - 1].p;
            return true;
        }
    }
}
