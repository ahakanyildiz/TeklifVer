using Entities;
using Microsoft.EntityFrameworkCore;
using TeklifVer.Common.Enums;
using TeklifVer.Entities;

namespace DataAccess.Contexts
{

    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }

        public CarContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TeklifVer;Integrated Security=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>()
                .HasMany(b => b.Cars)
                .WithOne(p => p.Model)
                .HasForeignKey(p => p.ModelId);

            modelBuilder.Entity<CarBrand>()
               .HasMany(b => b.CarModels)
               .WithOne(p => p.Brand)
               .HasForeignKey(p => p.BrandId);

            modelBuilder.Entity<Role>()
              .HasMany(b => b.Members)
              .WithOne(p => p.Role)
              .HasForeignKey(p => p.RoleId);

            modelBuilder.Entity<Member>().HasData(new Member() //initial metod
            {
                Id = 1,
                Email = "teknomanihah@gmail.com",
                Name = "Hakan",
                Surname = "Yıldız",
                Password = "123",
                PhoneNumber = "5060407176",
                RoleId = (int)RoleType.Admin
            });




            modelBuilder.Entity<Role>().HasData(
            new Role() //initial metod
            {
                Id = 1,
                Definition = "Member"
            },
            new Role() //initial metod
            {
                Id = 2,
                Definition = "Admin"
            }
            );
        }

    }
}
