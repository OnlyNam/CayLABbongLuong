using Microsoft.EntityFrameworkCore;
using VehicleCare.API.Models;

namespace VehicleCare.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentDetail> AppointmentDetails { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    public DbSet<Part> Parts { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }
    public DbSet<MaintenancePart> MaintenanceParts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships and constraints here if needed
        // For instance, restricting cascade deletes to avoid multiple cascade paths

        modelBuilder.Entity<AppointmentDetail>()
            .HasOne(ad => ad.Appointment)
            .WithMany(a => a.AppointmentDetails)
            .HasForeignKey(ad => ad.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<InvoiceDetail>()
            .HasOne(id => id.Invoice)
            .WithMany(i => i.InvoiceDetails)
            .HasForeignKey(id => id.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Invoice)
            .WithOne(i => i.Appointment)
            .HasForeignKey<Invoice>(i => i.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Appointment)
            .WithOne(a => a.Review)
            .HasForeignKey<Review>(r => r.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaintenanceRecord>()
            .HasOne(m => m.Vehicle)
            .WithMany(v => v.MaintenanceRecords)
            .HasForeignKey(m => m.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Vehicle)
            .WithMany(v => v.Appointments)
            .HasForeignKey(a => a.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.User)
            .WithMany(u => u.Appointments)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
        modelBuilder.Entity<User>()
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();
    }
}
