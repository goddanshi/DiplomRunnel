using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class WoodStack
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string WoodType { get; set; } = string.Empty;
        public decimal CurrentVolume { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}