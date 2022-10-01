using GrapfQL.Core.Models;
using GrapfQL.Core.Services;

namespace GrapfQL.Core.Resolvers.Mutations
{
    public class PositionMutationResolver
    {

        [GraphQLName("createPosition")]
        [GraphQLDescription("Creat a position")]
        public async Task<Position> CreatePositionAsync(PositionInputs positionInputs, [Service] IPositionService   positionService)
        {
            var position = new Position
            {
                Name = positionInputs.Name,
                DisplayOrder = positionInputs.DisplayOrder
            };

            return await positionService.CreatePositionAsync(position);
        }
    }
}
