using GrapfQL.Core.Models;
using GrapfQL.Core.Services;

namespace GrapfQL.Core.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class PlayerQueryResolver
    {
        [GraphQLName("players")]
        [GraphQLDescription("Retorna todos los jugadores")]
        public async Task<IEnumerable<Player>> GetPlayersAsync([Service] IPlayerService playerService)
        {
            return await playerService.GetPlayersAsync();
        }

        [GraphQLName("getPlayer")]
        [GraphQLDescription("Obtiene un simple jugador por id")]
        public async Task<Player> GetPlayerAsync(int id, [Service] IPlayerService playerService)
        {
            return await playerService.GetPlayerAsync(id);
        }
    }
}
