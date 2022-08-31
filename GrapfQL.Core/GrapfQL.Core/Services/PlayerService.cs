using GrapfQL.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GrapfQL.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly FootballDBContext _dbContext;
        public PlayerService(FootballDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            _dbContext.Players.Add(player);
            await _dbContext.SaveChangesAsync();
            return player;
        }

        public async Task<int> DeletePlayerAsync(Player player)
        {
            _dbContext.Players.Remove(player);
            return await _dbContext.SaveChangesAsync(); 
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            return await _dbContext.Players
                .Include(x => x.Position)
                .Where(x => x.Id == id).SingleAsync();
        }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            
            return await _dbContext.Players
                .Include(x => x.Position).ToListAsync();
        }

        public async Task<int> UpdatePlayerAsync(Player player)
        {
            _dbContext.Players.Update(player);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
