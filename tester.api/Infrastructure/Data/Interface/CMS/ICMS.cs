using tester.api.Infrastructure.Models.Main;

namespace tester.api.Infrastructure.Data.Interface.CMS
{
    public interface ICMS
    {
        Task<Flags> ManageFlag(Flags entity);
    }
}
