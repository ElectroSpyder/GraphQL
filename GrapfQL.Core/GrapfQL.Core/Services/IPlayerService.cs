using GrapfQL.Core.Models;

namespace GrapfQL.Core.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetPlayersAsync();
    }
}
