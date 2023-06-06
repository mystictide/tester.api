using tester.api.Infrastructure.Models.Main;
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

        public async Task<List<Flags>> GetCountries()
        {
            return await _repo.GetCountries();
        }

        public async Task<Flags> GetRandomFlag(int? difficulty)
        {
            return await _repo.GetRandomFlag(difficulty);
        }
    }
}
