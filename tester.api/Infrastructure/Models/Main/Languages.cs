using Dapper.Contrib.Extensions;

namespace tester.api.Infrastructure.Models.Main
{
    [Table("languages")]
    public class Languages
    {
        [Key]
        public int? ID { get; set; }
        public string? Language { get; set; }
        public int Difficulty { get; set; }
        public string? URL { get; set; }
    }
}
