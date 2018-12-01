using System.Threading.Tasks;
using Allergo.Schedule.Dto;

namespace Allergo.Schedule.Contracts
{
    public interface IScheduleService
    {
        Task<ScheduleDto> GetScheduleAsync(GetScheduleRequestDto request);
        Task CreateScheduleAsync(CreateScheduleRequestDto request);
        Task RemoveScheduleAsync(RemoveScheduleRequestDto request);
    }
}
