using tester.api.Infrastructure.Models.Main;

namespace tester.api.Infrastructure.Data.Interface.Main
{
    public interface IMain
    {
        Task<Flags> GetRandomFlag(int? difficulty);
        Task<List<Flags>> GetCountries();
    }
}
