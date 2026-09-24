using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class Invoice {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(50)] public string InvoiceCode { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal FinalAmount { get; set; }
    [MaxLength(50)] public string PaymentMethod { get; set; } = "Cash"; // Cash, Transfer, VNPay
    [MaxLength(20)] public string PaymentStatus { get; set; } = "Unpaid"; // Unpaid, Paid
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
