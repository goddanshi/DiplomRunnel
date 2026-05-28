using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Models
{
    public class ShipmentOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Номер накладной")]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Покупатель")]
        [MaxLength(200)]
        public string Customer { get; set; } = string.Empty;

        [Display(Name = "Дата отгрузки")]
        public DateTime ShipmentDate { get; set; } = DateTime.Now;

        [Display(Name = "Комментарий")]
        [MaxLength(500)]
        public string? Comment { get; set; }

        public string? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual AppUser? CreatedByUser { get; set; }

        // Связь с позициями
        public virtual ICollection<ShipmentItem> Items { get; set; } = new List<ShipmentItem>();
    }
}