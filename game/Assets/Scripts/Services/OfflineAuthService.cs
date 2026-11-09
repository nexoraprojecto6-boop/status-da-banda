using System;
using System.Threading.Tasks;
using SDB.Core;
using UnityEngine;

namespace SDB.Services
{
    /// <summary>Login local de desenvolvimento (sem rede). Substituído por PlayFab na fase de Auth.</summary>
    public sealed class OfflineAuthService : IAuthService
    {
        const string Key = "sdb.deviceId";

        public Task<Result<PlayerSession>> LoginAsync()
        {
            var id = PlayerPrefs.GetString(Key, "");
            if (string.IsNullOrEmpty(id)) { id = Guid.NewGuid().ToString("N"); PlayerPrefs.SetString(Key, id); PlayerPrefs.Save(); }
            return Task.FromResult(Result<PlayerSession>.Success(new PlayerSession { playerId = "p-" + id, username = "Jogador" }));
        }
    }
}
