using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Номер инвентаризации")]
        [MaxLength(50)]
        public string InventoryNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Тип")]
        [MaxLength(50)]
        public string InventoryType { get; set; } = string.Empty;

        [Display(Name = "Дата начала")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "Дата завершения")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Статус")]
        [MaxLength(50)]
        public string Status { get; set; } = "В процессе";

        [Display(Name = "Комментарий")]
        [MaxLength(500)]
        public string? Comment { get; set; }

        public string? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual AppUser? CreatedByUser { get; set; }

        // НАВИГАЦИОННОЕ СВОЙСТВО ДЛЯ ПОЗИЦИЙ
        public virtual ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
    }
}