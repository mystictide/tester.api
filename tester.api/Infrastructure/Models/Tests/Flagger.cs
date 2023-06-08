using tester.api.Infrastructure.Models.Main;

namespace tester.api.Infrastructure.Models.Tests
{
    public class Flagger
    {
        public int Round { get; set; }
        public List<Flags>? Flags { get; set; }
        public Flags? Correct { get; set; }
    }
}
