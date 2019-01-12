using System.Threading.Tasks;
using Allergo.Home.Models;

namespace Allergo.Home.Contracts
{
    public interface IStatisticsService
    {
        Task<AllergoStatisticsDto> GetStatisticsAsync();
    }
}
