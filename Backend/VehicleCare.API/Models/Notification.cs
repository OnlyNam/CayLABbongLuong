using System.ComponentModel.DataAnnotations;
namespace VehicleCare.API.Models;
public class Notification {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(200)] public string Title { get; set; } = string.Empty;
    [Required] public string Content { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
