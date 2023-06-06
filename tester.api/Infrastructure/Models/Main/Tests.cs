using Dapper.Contrib.Extensions;

namespace tester.api.Infrastructure.Models.Main
{
    [Table("tests")]
    public class Tests
    {
        [Key]
        public int? ID { get; set; }
        public int? Author { get; set; }
        public string? Name { get; set; }
        public string? BannerURL { get; set; }
    }
}
