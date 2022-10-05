using GrapfQL.Core.Models;
using GrapfQL.Core.Services;

namespace GrapfQL.Core.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class PositionQueryResolver
    {
        [GraphQLName("positions")]
        [GraphQLDescription("Retorna todos los tipos de jugadores")]
        public async Task<IEnumerable<Position>> GetPositionsAsync([Service] IPositionService positionService)
        {
            return await positionService.GetAllPositionsAsync();
        }
    }
}
