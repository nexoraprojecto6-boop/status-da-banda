using System;
using NUnit.Framework;
using SDB.Core;
using SDB.World;

namespace SDB.Tests
{
    public class BirthSelectorTests
    {
        static CountryData Country(params NeighborhoodData[] n) => new CountryData
        {
            code = "XX",
            provinces = new[] { new ProvinceData { id = "P", cities = new[] { new CityData { id = "C", neighborhoods = n } } } }
        };

        static NeighborhoodData N(string id, double w, int cap, bool active = true) =>
            new NeighborhoodData { id = id, birthWeight = w, capacity = cap, active = active, spawnPoints = new SpawnPointData[0] };

        [Test]
        public void IgnoraInativosECheios()
        {
            var c = Country(N("a", 1, 1), N("b", 1, 10, false));
            Assert.IsTrue(BirthSelector.TryPick(c, _ => 0, CryptoRng.NextDouble, out var p));
            Assert.AreEqual("a", p.Neighborhood.id);
            Assert.IsFalse(BirthSelector.TryPick(c, id => 1, CryptoRng.NextDouble, out _));
        }

        [Test]
        public void DistribuicaoRespeitaPesos()
        {
            var c = Country(N("a", 3, 1000000), N("b", 1, 1000000));
            var rng = new Random(42);
            int a = 0, total = 20000;
            for (int i = 0; i < total; i++)
            {
                BirthSelector.TryPick(c, _ => 0, rng.NextDouble, out var p);
                if (p.Neighborhood.id == "a") a++;
            }
            Assert.That(a / (double)total, Is.EqualTo(0.75).Within(0.02));
        }

        [Test]
        public void ServiceLocator_RegistaEObtem()
        {
            ServiceLocator.Clear();
            ServiceLocator.Register<string>("x");
            Assert.AreEqual("x", ServiceLocator.Get<string>());
            Assert.IsFalse(ServiceLocator.TryGet<object>(out _));
        }
    }
}
