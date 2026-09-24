using System.ComponentModel.DataAnnotations;
namespace VehicleCare.API.Models;
public class User {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string FullName { get; set; } = string.Empty;
    [Required] [MaxLength(20)] public string PhoneNumber { get; set; } = string.Empty;
    [Required] [MaxLength(100)] public string Email { get; set; } = string.Empty;
    [Required] public string PasswordHash { get; set; } = string.Empty;
    [MaxLength(200)] public string? Address { get; set; }
    public string? AvatarUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
