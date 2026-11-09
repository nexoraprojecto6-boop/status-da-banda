using System;
using System.Threading.Tasks;
using SDB.Core;
using SDB.World;

namespace SDB.Services
{
    [Serializable] public class PlayerSession { public string playerId, username; }

    public interface IAuthService
    {
        Task<Result<PlayerSession>> LoginAsync();
    }

    public interface IBirthService
    {
        /// <summary>Origem existente (ou null). A origem é permanente.</summary>
        Task<BirthOrigin> GetOriginAsync(string playerId);
        /// <summary>Idempotente: se já existir origem, devolve-a. O cliente só envia o país.</summary>
        Task<Result<BirthOrigin>> AssignAsync(string playerId, string countryCode);
    }
}
