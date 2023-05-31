using tester.api.Infrastructure.Data.Repo.Main;
using tester.api.Infrastructure.Models.Helpers;
using tester.api.Infrastructure.Data.Interface.Culture;

namespace tester.api.Infrastructure.Managers.Main
{
    public class MainManager : AppSettings, IMain
    {
        private readonly IMain _repo;
        public MainManager()
        {
            _repo = new MainRepository();
        }

    }
}
