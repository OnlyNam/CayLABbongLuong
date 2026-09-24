using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class MaintenancePart {
    [Key] public int Id { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    public int MaintenanceRecordId { get; set; }
    public MaintenanceRecord MaintenanceRecord { get; set; } = null!;

    public int PartId { get; set; }
    public Part Part { get; set; } = null!;
}
