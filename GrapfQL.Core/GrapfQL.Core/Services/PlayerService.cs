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

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            
            return await _dbContext.Players
                .Include(x => x.Position).ToListAsync();
        }
    }
}
