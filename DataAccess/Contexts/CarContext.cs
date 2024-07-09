using Entities;
using Microsoft.EntityFrameworkCore;
using TeklifVer.Entities;

namespace DataAccess.Contexts
{

    public class CarContext : DbContext
    {
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public CarContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TeklifVer;Integrated Security=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                .HasMany(b => b.Advertisings)
                .WithOne(p => p.Model)
                .HasForeignKey(p => p.ModelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Brand>()
               .HasMany(b => b.Models)
               .WithOne(p => p.Brand)
               .HasForeignKey(p => p.BrandId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
              .HasMany(b => b.Members)
              .WithOne(p => p.Role)
              .HasForeignKey(p => p.RoleId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Member>()
                .HasMany(b => b.Advertisings)
                .WithOne(p => p.Member)
                .HasForeignKey(p => p.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Offer>()
             .HasOne(o => o.Member)
             .WithMany(m => m.Offers)
             .HasForeignKey(o => o.MemberId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Advertising)
                .WithMany(a => a.Offers)
                .HasForeignKey(o => o.AdvertisingId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
