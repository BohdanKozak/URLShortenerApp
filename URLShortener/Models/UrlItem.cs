using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class UrlItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Url { get; set; }
        public string? ShortedUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
