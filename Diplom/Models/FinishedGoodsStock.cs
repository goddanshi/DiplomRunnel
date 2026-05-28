using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Models
{
    public class FinishedGoodsStock
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Тип древесины")]
        public string WoodType { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Длина листа (м)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal SheetLength { get; set; }

        [Required]
        [Display(Name = "Ширина листа (м)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal SheetWidth { get; set; }

        [Display(Name = "Объём (м³)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Volume { get; set; }

        [Display(Name = "Местоположение")]
        [MaxLength(100)]
        public string? Location { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}