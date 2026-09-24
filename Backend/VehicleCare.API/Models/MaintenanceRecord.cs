using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class MaintenanceRecord {
    [Key] public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int Odometer { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalCost { get; set; }
    public string? Notes { get; set; }
    public int StaffId { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public ICollection<MaintenancePart> MaintenanceParts { get; set; } = new List<MaintenancePart>();
}
