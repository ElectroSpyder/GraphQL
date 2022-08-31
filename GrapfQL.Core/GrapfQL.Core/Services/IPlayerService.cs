using GrapfQL.Core.Models;

namespace GrapfQL.Core.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetPlayersAsync();
        Task<Player> CreatePlayerAsync(Player player);
        Task<int> UpdatePlayerAsync(Player player);
        Task<int> DeletePlayerAsync(Player player);
        Task<Player> GetPlayerAsync(int id);
    }
}
