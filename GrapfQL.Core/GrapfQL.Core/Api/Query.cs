using GrapfQL.Core.Models;
using GrapfQL.Core.Services;

namespace GrapfQL.Core.Api
{
    public class Query
    {
        /// <summary>
        /// HotChocolate support injection and recive interface like parameter
        /// not need contructor for inject
        /// </summary>
        /// <param name="playerService"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Player>> GetPlayersAsync([Service] IPlayerService playerService)
        {
            return await playerService.GetPlayersAsync();
        }
    }
}
