using Microsoft.EntityFrameworkCore;
namespace CrudApiJw.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=JWTCRUDPRODUCT;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public  DbSet<Product>? Products { get; set; }
        public  DbSet<UserInfo>? UserInfos { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });



            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ManufacturePhone).HasMaxLength(50).IsUnicode(true);
                entity.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.ManufactureEmail).HasMaxLength(50).IsUnicode(true);
                entity.Property(e => e.IsAvailable).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.ProduceDate).IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
