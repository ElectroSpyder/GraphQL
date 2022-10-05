using GrapfQL.Core.Models;
using GrapfQL.Core.Models.ViewModels;
using GrapfQL.Core.Services;

namespace GrapfQL.Core.Resolvers.Mutations
{
    [ExtendObjectType("Mutation")]
    public class PlayerMutationResolver
    {
        [GraphQLName("createPlayer")]
        [GraphQLDescription("Crear un nuevo jugador")]
        public async Task<Player> CreatePlayerAsync(PlayerInputs playerInputs, [Service] IPlayerService playerService)
        {
            var player = new Player()
            {
                ShirtNo = playerInputs.ShirtNo,
                Appearances = playerInputs.Appearances,
                Goals = playerInputs.Goals,
                Name = playerInputs.Name,
                PositionId = playerInputs.PositionId
            };

            return await playerService.CreatePlayerAsync(player);
        }

        [GraphQLName("updatePlayer")]
        [GraphQLDescription("Actualizacion de jugador")]
        public async Task<Player> UpdatePlayerAsync(int id, PlayerInputs playerInputs, [Service] IPlayerService playerService)
        {
            var player = await playerService.GetPlayerAsync(id);
            if (player != null)
                throw new GraphQLException(new Error("Jugador no encontrado.", "JUGADOR_NO_ENCONTRADO"));

            player.ShirtNo = playerInputs.ShirtNo;
            player.Appearances = playerInputs.Appearances;
            player.Name = playerInputs.Name;
            player.PositionId = playerInputs.PositionId;
            player.Goals = playerInputs.Goals;

            await playerService.UpdatePlayerAsync(player);

            return player;
        }

        [GraphQLName("deletePlayer")]
        [GraphQLDescription("Borrar jugador")]
        public async Task<int> DeletePlayerAsync(int id, [Service] IPlayerService playerService)
        {
            var player = await playerService.GetPlayerAsync(id);

            if(player == null)
                throw new GraphQLException(new Error("Jugador no encontrado.", "JUGADOR_NO_ENCONTRADO"));
            return await playerService.DeletePlayerAsync(player);
        }
    }
}
