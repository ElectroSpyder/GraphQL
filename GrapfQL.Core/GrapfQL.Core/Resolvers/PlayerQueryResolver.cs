using GrapfQL.Core.Models;
using GrapfQL.Core.Services;

namespace GrapfQL.Core.Resolvers
{
    [ExtendObjectType("Query")]
    public class PlayerQueryResolver
    {
        public async Task<IEnumerable<Player>> GetPlayersAsync([Service] IPlayerService playerService)
        {
            return await playerService.GetPlayersAsync();
        }
    }
}
