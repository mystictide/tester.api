using tester.api.Infrastructure.Models.Main;

namespace tester.api.Infrastructure.Models.Tests
{
    public class Langger
    {
        public int Round { get; set; }
        public List<Languages>? Languages { get; set; }
        public Languages? Correct { get; set; }
    }
}
