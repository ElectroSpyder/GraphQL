using GrapfQL.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GrapfQL.Core.Services
{
    public class PositionService : IPositionService
    {
        private readonly FootballDBContext _dbContext;
        public PositionService(FootballDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _dbContext.Positions.ToListAsync();
        }
    }
}
