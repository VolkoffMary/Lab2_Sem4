using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Models
{
    public class CatalogueAPIContext : DbContext
    {
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<TShirt> TShorts { get; set; }
        public virtual DbSet<Dress> Dresses { get; set; }
        public virtual DbSet<Trousers> Trousers { get; set; }
        public virtual DbSet<Skirt> Skirts { get; set; }
        public virtual DbSet<SizeTShirt> SizeTShorts { get; set; }
        public virtual DbSet<SizeDress> SizeDresses { get; set; }
        public virtual DbSet<SizeTrousers> SizeTrousers { get; set; }
        public virtual DbSet<SizeSkirt> SizeSkirts { get; set; }
        public virtual DbSet<PhotoTShirt> PhotoTShorts { get; set; }
        public virtual DbSet<PhotoDress> PhotoDresses { get; set; }
        public virtual DbSet<PhotoTrousers> PhotoTrousers { get; set; }
        public virtual DbSet<PhotoSkirt> PhotoSkirts { get; set; }
        public virtual DbSet<ColorTShirt> ColorTShorts { get; set; }
        public virtual DbSet<ColorDress> ColorDresses { get; set; }
        public virtual DbSet<ColorTrousers> ColorTrousers { get; set; }
        public virtual DbSet<ColorSkirt> ColorSkirts { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public CatalogueAPIContext(DbContextOptions<CatalogueAPIContext> options) 
            :base(options) => Database.EnsureCreated();
        public CatalogueAPIContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-5NBPC5J; Database=CatalogueAPI; Trusted_Connection=True; MultipleActiveResultSets=true");
            }
        }
    }
}
