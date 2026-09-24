using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class Appointment {
    [Key] public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal ExpectedTotal { get; set; }
    [Required] [MaxLength(20)] public string Status { get; set; } = "PENDING"; // PENDING, CONFIRMED, REJECTED, CHECKING, MAINTENANCE, COMPLETED, CANCELLED, PAID
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();
    public Invoice? Invoice { get; set; }
    public Review? Review { get; set; }
}
