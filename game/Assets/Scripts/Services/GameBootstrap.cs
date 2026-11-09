using SDB.Core;
using SDB.World;
using UnityEngine;

namespace SDB.Services
{
    /// <summary>Composition root: regista os serviços antes de qualquer cena. Trocar por PlayFab/Functions aqui.</summary>
    public static class GameBootstrap
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Init()
        {
            ServiceLocator.Register<IMoveInput>(new TouchInput());
            ServiceLocator.Register<IAuthService>(new OfflineAuthService());

            var asset = Resources.Load<TextAsset>("Data/regions");
            if (asset == null) Debug.LogError("[SDB] Resources/Data/regions.json em falta (corre tools/sync-regions.sh).");
            var catalog = asset != null ? RegionCatalogData.Parse(asset.text) : null;
            ServiceLocator.Register<IBirthService>(new OfflineBirthService(catalog));
        }
    }
}
