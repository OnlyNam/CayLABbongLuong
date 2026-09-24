using BCrypt.Net;
using VehicleCare.API.Models;

namespace VehicleCare.API.Data;

public static class DataSeeder
{
    public static void SeedData(AppDbContext context)
    {
        if (!context.Roles.Any())
        {
            var adminRole = new Role { Name = "Admin" };
            var staffRole = new Role { Name = "Staff" };
            var customerRole = new Role { Name = "Customer" };

            context.Roles.AddRange(adminRole, staffRole, customerRole);
            context.SaveChanges();

            // Seed Users
            var passwordHash = BCrypt.Net.BCrypt.HashPassword("123456");

            var admin = new User { FullName = "Admin User", PhoneNumber = "0901234567", Email = "admin@vehiclecare.com", PasswordHash = passwordHash, RoleId = adminRole.Id };
            var staff1 = new User { FullName = "Staff One", PhoneNumber = "0911234567", Email = "staff1@vehiclecare.com", PasswordHash = passwordHash, RoleId = staffRole.Id };
            var staff2 = new User { FullName = "Staff Two", PhoneNumber = "0921234567", Email = "staff2@vehiclecare.com", PasswordHash = passwordHash, RoleId = staffRole.Id };
            
            var customers = new List<User>
            {
                new User { FullName = "Nguyễn Văn A", PhoneNumber = "0931234567", Email = "khachhang1@gmail.com", PasswordHash = passwordHash, RoleId = customerRole.Id },
                new User { FullName = "Trần Thị B", PhoneNumber = "0941234567", Email = "khachhang2@gmail.com", PasswordHash = passwordHash, RoleId = customerRole.Id },
                new User { FullName = "Lê Văn C", PhoneNumber = "0951234567", Email = "khachhang3@gmail.com", PasswordHash = passwordHash, RoleId = customerRole.Id },
                new User { FullName = "Phạm Thị D", PhoneNumber = "0961234567", Email = "khachhang4@gmail.com", PasswordHash = passwordHash, RoleId = customerRole.Id },
                new User { FullName = "Hoàng Văn E", PhoneNumber = "0971234567", Email = "khachhang5@gmail.com", PasswordHash = passwordHash, RoleId = customerRole.Id }
            };

            context.Users.Add(admin);
            context.Users.Add(staff1);
            context.Users.Add(staff2);
            context.Users.AddRange(customers);
            context.SaveChanges();

            // Seed Services
            var services = new List<Service>
            {
                new Service { Name = "Thay nhớt", Description = "Thay nhớt động cơ chính hãng", Price = 150000, EstimatedDuration = 15 },
                new Service { Name = "Kiểm tra phanh", Description = "Bảo dưỡng, vệ sinh hệ thống phanh", Price = 50000, EstimatedDuration = 20 },
                new Service { Name = "Kiểm tra lốp", Description = "Kiểm tra áp suất và tình trạng lốp", Price = 30000, EstimatedDuration = 10 },
                new Service { Name = "Kiểm tra bình ắc quy", Description = "Đo điện áp bình ắc quy", Price = 40000, EstimatedDuration = 15 },
                new Service { Name = "Kiểm tra hệ thống điện", Description = "Đo đạc kiểm tra đèn còi xi nhan", Price = 100000, EstimatedDuration = 30 },
                new Service { Name = "Bảo dưỡng định kỳ", Description = "Kiểm tra tổng quát toàn bộ xe", Price = 250000, EstimatedDuration = 60 },
                new Service { Name = "Sửa phanh", Description = "Thay bố phanh, canh chỉnh", Price = 120000, EstimatedDuration = 45 },
                new Service { Name = "Sửa điện", Description = "Khắc phục các sự cố về điện", Price = 200000, EstimatedDuration = 60 },
                new Service { Name = "Thay bugi", Description = "Thay mới bugi xe", Price = 80000, EstimatedDuration = 15 },
                new Service { Name = "Rửa xe", Description = "Rửa xe bọt tuyết siêu sạch", Price = 50000, EstimatedDuration = 20 }
            };
            context.Services.AddRange(services);
            context.SaveChanges();

            // Seed Vehicles
            var vehicles = new List<Vehicle>
            {
                new Vehicle { LicensePlate = "59A1-123.45", Brand = "Yamaha", Model = "Exciter 155", Year = 2022, Color = "Xanh", VehicleType = "Xe côn tay", Odometer = 15200, UserId = customers[0].Id },
                new Vehicle { LicensePlate = "59B1-234.56", Brand = "Honda", Model = "Winner X", Year = 2021, Color = "Đỏ đen", VehicleType = "Xe côn tay", Odometer = 22000, UserId = customers[1].Id },
                new Vehicle { LicensePlate = "59C1-345.67", Brand = "Honda", Model = "SH 150i", Year = 2023, Color = "Trắng", VehicleType = "Xe tay ga", Odometer = 8500, UserId = customers[2].Id },
                new Vehicle { LicensePlate = "59D1-456.78", Brand = "Yamaha", Model = "NVX", Year = 2020, Color = "Đen", VehicleType = "Xe tay ga", Odometer = 35000, UserId = customers[3].Id },
                new Vehicle { LicensePlate = "59E1-567.89", Brand = "Honda", Model = "Air Blade", Year = 2022, Color = "Bạc", VehicleType = "Xe tay ga", Odometer = 18000, UserId = customers[4].Id }
            };
            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
            
            // Further seeding (appointments, invoices) can be done similarly
        }
    }
}
