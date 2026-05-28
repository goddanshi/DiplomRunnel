using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Models
{
    public class ShipmentItem
    {
        [Key]
        public int Id { get; set; }

        public int ShipmentOrderId { get; set; }
        [ForeignKey("ShipmentOrderId")]
        public virtual ShipmentOrder? ShipmentOrder { get; set; }

        public int FinishedGoodsStockId { get; set; }
        [ForeignKey("FinishedGoodsStockId")]
        public virtual FinishedGoodsStock? FinishedGoodsStock { get; set; }

        [Required]
        [Display(Name = "Объём (м³)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Volume { get; set; }
    }
}