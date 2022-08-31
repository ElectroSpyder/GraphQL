using GrapfQL.Core.Models;

namespace GrapfQL.Core.Services
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
    }
}
