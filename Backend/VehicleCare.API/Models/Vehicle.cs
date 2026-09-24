using System.ComponentModel.DataAnnotations;
namespace VehicleCare.API.Models;
public class Vehicle {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(20)] public string LicensePlate { get; set; } = string.Empty;
    [Required] [MaxLength(50)] public string Brand { get; set; } = string.Empty;
    [Required] [MaxLength(50)] public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    [MaxLength(30)] public string? Color { get; set; }
    [MaxLength(50)] public string? VehicleType { get; set; }
    public int Odometer { get; set; }
    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
}
