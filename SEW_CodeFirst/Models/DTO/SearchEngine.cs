using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEW_CodeFirst.Models.DTO
{
    public class SearchEngine
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EngineId { get; set; }
        public string Name { get; set; }
        public string MainLink { get; set; }
        public string LinkAPI { get; set; }
        public string KeyAPI { get; set; }
        public string CX { get; set; }
        public string User { get; set; }
    }
}
