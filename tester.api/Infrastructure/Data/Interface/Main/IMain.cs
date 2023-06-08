using tester.api.Infrastructure.Models.Main;
using tester.api.Infrastructure.Models.Tests;

namespace tester.api.Infrastructure.Data.Interface.Main
{
    public interface IMain
    {
        Task<Flags> GetRandomFlag(int? difficulty);
        Task<Flagger> GetFlaggerRound(int? round, int? difficulty, string? prevFlag);
        Task<List<Flags>> GetCountries();
    }
}
