using System.ComponentModel.DataAnnotations;

namespace SEW_CodeFirst.Models.DTO
{
    public class SearchResult
    {
        [Key]
        public int ResultId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Query { get; set; }
        [Required]
        public int EngineId { get; set; }
    }
}
