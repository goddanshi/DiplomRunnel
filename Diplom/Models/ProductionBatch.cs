using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom.Models
{
    public class ProductionBatch
    {
        [Key]
        public int Id { get; set; }

        public int WoodStackId { get; set; }
        [ForeignKey("WoodStackId")]
        public virtual WoodStack? WoodStack { get; set; }

        // --- ПАРАМЕТРЫ СПИСАНИЯ СЫРЬЯ ---
        [Display(Name = "Длина (м)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal LogLength { get; set; }

        [Display(Name = "Ширина (м)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal LogWidth { get; set; }

        [Display(Name = "Высота (м)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal LogHeight { get; set; }

        [Display(Name = "Коэффициент полнодревесности")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal WoodDensityCoeff { get; set; } = 0.65m;

        [Display(Name = "Объём сырья (м³)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal RawVolume { get; set; }

        // --- ПАРАМЕТРЫ ВЫХОДА ШПОНА ---
        [Display(Name = "Длина листа (м)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal SheetLength { get; set; }

        [Display(Name = "Ширина листа (м)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal SheetWidth { get; set; }

        [Display(Name = "Высота пачки (м)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal SheetStackHeight { get; set; }

        [Display(Name = "Коэффициент плотности")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal DensityCoefficient { get; set; } = 0.85m;

        [Display(Name = "Объём шпона (м³)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal VeneerVolume { get; set; }

        // --- РАССЧИТАННЫЕ ПОКАЗАТЕЛИ ---
        [Display(Name = "Отходы (м³)")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal WasteVolume { get; set; }

        [Display(Name = "Коэффициент выхода")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Efficiency { get; set; }

        [Display(Name = "Оценка эффективности")]
        [MaxLength(20)]
        public string? EfficiencyGrade { get; set; }

        // --- СЛУЖЕБНАЯ ИНФОРМАЦИЯ ---
        public DateTime ProductionDate { get; set; } = DateTime.Now;
        public string? Comment { get; set; }
        public string? CreatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public virtual AppUser? CreatedByUser { get; set; }
    }
}