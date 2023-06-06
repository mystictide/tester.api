using Dapper.Contrib.Extensions;

namespace tester.api.Infrastructure.Models.Main
{
    [Table("flags")]
    public class Flags
    {
        [Key]
        public int? ID { get; set; }
        public string? Country { get; set; }
        public int Difficulty { get; set; }
        public string? URL { get; set; }
    }
}
