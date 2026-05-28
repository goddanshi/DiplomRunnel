using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }

        public int InventoryId { get; set; }
        [ForeignKey("InventoryId")]
        public virtual Inventory? Inventory { get; set; }

        // Тип и ID объекта
        [Required]
        [MaxLength(50)]
        public string ItemType { get; set; } = string.Empty; // "WoodStack" или "FinishedGoods"

        public int ItemId { get; set; }

        [Display(Name = "Наименование")]
        [MaxLength(200)]
        public string ItemName { get; set; } = string.Empty;

        [Display(Name = "Учётный остаток (м³)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal AccountingVolume { get; set; }

        [Display(Name = "Фактический остаток (м³)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ActualVolume { get; set; }

        [Display(Name = "Расхождение (м³)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Difference { get; set; }

        [Display(Name = "Тип расхождения")]
        [MaxLength(20)]
        public string? DifferenceType { get; set; } // "Излишек", "Недостача", "Нет"

        [Display(Name = "Комментарий")]
        [MaxLength(500)]
        public string? Comment { get; set; }
    }
}