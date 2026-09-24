using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class Part {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
