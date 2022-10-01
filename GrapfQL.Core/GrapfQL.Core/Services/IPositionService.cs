using GrapfQL.Core.Models;
using System.Linq.Expressions;

namespace GrapfQL.Core.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task<Position> CreatePositionAsync(Position position);
        Task<int> UpdatePositionAsync(Position position);
        Task<int> DeletePositionAsync(Position position);
        Task<Position> GetPositionAsync(int id);
        Task<IEnumerable<Position>> Find(Expression<Func<Position, bool>> expression);
    }
}
