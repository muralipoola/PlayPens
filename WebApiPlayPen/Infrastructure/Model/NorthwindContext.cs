using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;

namespace WebApiPlayPen.Model
{
    public class NorthwindContext : DbContext
    {
        static NorthwindContext()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<NorthwindContext>(null);
        }

        public NorthwindContext()
            : base("name=NorthwindContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public NorthwindContext(DbConnection existingConnection)
            : base(existingConnection, false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Category>()
                .Map(e => e.ToTable("Categories"))
                .HasKey(e => e.CategoryId);

            modelBuilder
                .Entity<CustomerDemographic>()
                .Map(e => e.ToTable("CustomerDemographics"))
                .HasKey(e => e.CustomerTypeId)
                .Property(e => e.CustomerTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder
                .Entity<Customer>()
                .Map(e => e.ToTable("Customers"))
                .HasKey(e => e.CustomerId)
                .Property(e => e.CustomerId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder
                .Entity<Employee>()
                .Map(e => e.ToTable("Employees"))
                .HasKey(e => e.EmployeeId);

            modelBuilder
                .Entity<OrderDetail>()
                .Map(e => e.ToTable("[Order Details]"))
                .HasKey(e => new { e.OrderId, e.ProductId });

            modelBuilder
                .Entity<Order>()
                .Map(e => e.ToTable("Orders"))
                .HasKey(e => e.OrderId);

            modelBuilder
                .Entity<Product>()
                .Map(e => e.ToTable("Products"))
                .HasKey(e => e.ProductId);

            modelBuilder
                .Entity<Region>()
                .Map(e => e.ToTable("Region"))
                .HasKey(e => e.RegionId)
                .Property(e => e.RegionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder
                .Entity<Shipper>()
                .Map(e => e.ToTable("Shippers"))
                .HasKey(e => e.ShipperId);

            modelBuilder
                .Entity<StudentDetail>()
                .Map(e => e.ToTable("StudentDetails"))
                .HasKey(e => e.StudentId)
                .Property(e => e.StudentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder
                .Entity<Supplier>()
                .Map(e => e.ToTable("Suppliers"))
                .HasKey(e => e.SupplierId);

            modelBuilder
                .Entity<Territory>()
                .Map(e => e.ToTable("Territories"))
                .HasKey(e => e.TerritoryId)
                .Property(e => e.TerritoryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
    }
}
