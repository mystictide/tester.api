using tester.api.Infrasructure.Models.Helpers;

namespace tester.api.Infrastructure.Data.Interface.Helpers
{
    public interface ILogs
    {
        Task<int> Add(Logs entity);
    }
}
