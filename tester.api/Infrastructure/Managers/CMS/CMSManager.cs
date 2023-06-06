using tester.api.Infrastructure.Models.Main;
using tester.api.Infrastructure.Data.Repo.Main;
using tester.api.Infrastructure.Models.Helpers;
using tester.api.Infrastructure.Data.Interface.CMS;

namespace tester.api.Infrastructure.Managers.CMS
{
    public class CMSManager : AppSettings, ICMS
    {
        private readonly ICMS _repo;
        public CMSManager()
        {
            _repo = new CMSRepository();
        }

        public async Task<Flags> ManageFlag(Flags entity)
        {
            return await _repo.ManageFlag(entity);
        }
    }
}
