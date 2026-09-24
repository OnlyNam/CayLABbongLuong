using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class Service {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int EstimatedDuration { get; set; } // minutes
    public bool IsActive { get; set; } = true;

    public ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();
}
