using GrapfQL.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GrapfQL.Core.Services
{
    public class PositionService : IPositionService
    {
        private readonly FootballDBContext _dbContext;
        public PositionService(FootballDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Position> CreatePositionAsync(Position position)
        {
            _dbContext.Positions.Add(position);
            await _dbContext.SaveChangesAsync();
            return position;
        }

        public async Task<int> DeletePositionAsync(Position position)
        {
            _dbContext.Positions.Remove(position);
            return await _dbContext.SaveChangesAsync();            
        }

        public async Task<IEnumerable<Position>> Find(Expression<Func<Position, bool>> expression)
        {
            return await _dbContext.Positions.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _dbContext.Positions.ToListAsync();
        }

        public async Task<Position> GetPositionAsync(int id)
        {
            return await _dbContext.Positions.Where(x => x.Id == id).SingleAsync();
        }

        public async Task<int> UpdatePositionAsync(Position position)
        {
            if (position != null)
            {
                _dbContext.Positions.Update(position);
                return await _dbContext.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
             
        }
    }
}
