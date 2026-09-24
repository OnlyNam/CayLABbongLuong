using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class InvoiceDetail {
    [Key] public int Id { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;

    public int? ServiceId { get; set; }
    public Service? Service { get; set; }

    public int? PartId { get; set; }
    public Part? Part { get; set; }
}
