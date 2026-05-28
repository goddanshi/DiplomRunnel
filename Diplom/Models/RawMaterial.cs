namespace Diplom.Models
{
    public class RawMaterial
    {
        public int Id { get; set; }
        public string BatchNumber { get; set; } = string.Empty;
        public DateTime ArrivalDate { get; set; }
        public string WoodType { get; set; } = string.Empty;
        public decimal Volume { get; set; }
        public int Grade { get; set; }
        public string? Supplier { get; set; }
        public string? Comment { get; set; }
        public string Status { get; set; } = "На складе";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedByUserId { get; set; }
        public virtual AppUser? CreatedByUser { get; set; }
    }
}