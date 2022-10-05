using GrapfQL.Core.Models;
using GrapfQL.Core.Models.ViewModels;
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

        [GraphQLName("updatePositionr")]
        [GraphQLDescription("Actualizacion de position")]
        public async Task<int> UpdatePositionAsync(int id, PositionInputs positionInputs, [Service] IPositionService positionService)
        {            
            var positionExist = await positionService
                .Find(x => x.Id == id); 

            if(positionExist == null) 
                throw new GraphQLException(new Error("Posicion no encontrado.", "POSICION_NO_ENCONTRADO")); ;
           
            var newPosition = positionExist.First();
            newPosition.Name = positionInputs.Name;
            newPosition.DisplayOrder = positionInputs.DisplayOrder;
            
            return await positionService.UpdatePositionAsync(newPosition);
        }

    }
}
