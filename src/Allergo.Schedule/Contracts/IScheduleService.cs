using System.Threading.Tasks;
using Allergo.Schedule.Dto;

namespace Allergo.Schedule.Contracts
{
    public interface IScheduleService
    {
        ScheduleDto GetSchedule(GetScheduleRequestDto request);
        Task CreateSchedule(CreateScheduleRequestDto request);
        Task RemoveSchedule(RemoveScheduleRequestDto request);
    }
}
