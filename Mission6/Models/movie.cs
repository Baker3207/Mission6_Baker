using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    public class movie
    {
        [Key]
        public int MovieId { get; set; }

        public string category { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public bool edited { get; set; }
        public string? lentTo { get; set; }
        public string? notes { get; set; }
    }
}
