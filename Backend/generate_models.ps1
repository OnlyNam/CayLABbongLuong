$basePath = "d:\Tieuluanmonhoc_149\H-th-ng-d-ch-v-b-o-d-ng-xe\Backend\VehicleCare.API\Models"

$files = @{
    "Role.cs" = @"
using System.ComponentModel.DataAnnotations;
namespace VehicleCare.API.Models;
public class Role {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(50)] public string Name { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
}
"@;
    "User.cs" = @"
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
"@;
    "Vehicle.cs" = @"
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
"@;
    "Service.cs" = @"
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class Service {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal Price { get; set; }
    public int EstimatedDuration { get; set; } // minutes
    public bool IsActive { get; set; } = true;

    public ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();
}
"@;
    "Appointment.cs" = @"
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class Appointment {
    [Key] public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal ExpectedTotal { get; set; }
    [Required] [MaxLength(20)] public string Status { get; set; } = ""PENDING""; // PENDING, CONFIRMED, REJECTED, CHECKING, MAINTENANCE, COMPLETED, CANCELLED, PAID
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public ICollection<AppointmentDetail> AppointmentDetails { get; set; } = new List<AppointmentDetail>();
    public Invoice? Invoice { get; set; }
    public Review? Review { get; set; }
}
"@;
    "AppointmentDetail.cs" = @"
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class AppointmentDetail {
    [Key] public int Id { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal Price { get; set; }

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;
}
"@;
    "Invoice.cs" = @"
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class Invoice {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(50)] public string InvoiceCode { get; set; } = string.Empty;
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal TotalAmount { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal Discount { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal FinalAmount { get; set; }
    [MaxLength(50)] public string PaymentMethod { get; set; } = ""Cash""; // Cash, Transfer, VNPay
    [MaxLength(20)] public string PaymentStatus { get; set; } = ""Unpaid""; // Unpaid, Paid
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    public ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
"@;
    "Part.cs" = @"
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class Part {
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
"@;
    "InvoiceDetail.cs" = @"
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class InvoiceDetail {
    [Key] public int Id { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal UnitPrice { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal Amount { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;

    public int? ServiceId { get; set; }
    public Service? Service { get; set; }

    public int? PartId { get; set; }
    public Part? Part { get; set; }
}
"@;
    "Review.cs" = @"
using System.ComponentModel.DataAnnotations;
namespace VehicleCare.API.Models;
public class Review {
    [Key] public int Id { get; set; }
    public int Rating { get; set; } // 1-5
    public string? Comment { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
"@;
    "Notification.cs" = @"
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
"@;
    "MaintenanceRecord.cs" = @"
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class MaintenanceRecord {
    [Key] public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public int Odometer { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal TotalCost { get; set; }
    public string? Notes { get; set; }
    public int StaffId { get; set; }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public ICollection<MaintenancePart> MaintenanceParts { get; set; } = new List<MaintenancePart>();
}
"@;
    "MaintenancePart.cs" = @"
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleCare.API.Models;
public class MaintenancePart {
    [Key] public int Id { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = ""decimal(18,2)"")]
    public decimal UnitPrice { get; set; }

    public int MaintenanceRecordId { get; set; }
    public MaintenanceRecord MaintenanceRecord { get; set; } = null!;

    public int PartId { get; set; }
    public Part Part { get; set; } = null!;
}
"@;
}

foreach ($item in $files.GetEnumerator()) {
    $filePath = Join-Path $basePath $item.Key
    Set-Content -Path $filePath -Value $item.Value -Encoding UTF8
}
