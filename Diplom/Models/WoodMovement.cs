using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Models
{

    public class WoodMovement
    {
        [Key]
        public int Id { get; set; }
        public int WoodStackId { get; set; }
        [ForeignKey("WoodStackId")]
        public virtual WoodStack? WoodStack { get; set; }
        
        public decimal Volume { get; set; }
        public string MovementType { get; set; } = "Income";
        public DateTime MovementDate { get; set; }
        public string? Comment { get; set; }
        public string? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual AppUser? CreatedByUser { get; set; }

        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Coefficient { get; set; }

        [Display(Name = "Поставщик")]
        [MaxLength(200)]
        public string? Supplier { get; set; }
    }
}