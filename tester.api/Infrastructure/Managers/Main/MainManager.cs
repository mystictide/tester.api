using tester.api.Infrastructure.Models.Main;
using tester.api.Infrastructure.Models.Tests;
using tester.api.Infrastructure.Data.Repo.Main;
using tester.api.Infrastructure.Models.Helpers;
using tester.api.Infrastructure.Data.Interface.Main;

namespace tester.api.Infrastructure.Managers.Main
{
    public class MainManager : AppSettings, IMain
    {
        private readonly IMain _repo;
        public MainManager()
        {
            _repo = new MainRepository();
        }

        public async Task<Flagger> GetFlaggerRound(int? round, int? difficulty, string? prevFlag)
        {
            return await _repo.GetFlaggerRound(round, difficulty, prevFlag);
        }

        public async Task<Langger> GetLanggerRound(int? round, int? difficulty, string? prevLang)
        {
            return await _repo.GetLanggerRound(round, difficulty, prevLang);
        }
    }
}
