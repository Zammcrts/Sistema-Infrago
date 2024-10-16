using Microsoft.EntityFrameworkCore;
using Sistema_Infrago.Shared.Entities;

namespace Sistema_Infrago.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Machinery> Machineries { get; set; }
        public DbSet<MachineryAssignment> MachineryAssignments { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<MaintenanceDetails> MaintenanceDetails { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDetails> ProjectDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Stockist> Stockists { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ToolAssignment> ToolAssignments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MachineryAssignment>().HasIndex(x => x.MachineProject).IsUnique();
            //modelBuilder.Entity<Assignment>().HasIndex(x => x.Quantity).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(x => x.Project).IsUnique();
            modelBuilder.Entity<Machinery>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Maintenance>().HasIndex(x => x.MaintenanceID).IsUnique();
            modelBuilder.Entity<Material>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Service>().HasIndex(x => x.ServiceName).IsUnique();
            modelBuilder.Entity<Stockist>().HasIndex(x => x.ProviderName).IsUnique();
            modelBuilder.Entity<Tool>().HasIndex(x => x.ToolID).IsUnique();
            modelBuilder.Entity<ToolAssignment>().HasIndex(x => x.ToolAssignmentID).IsUnique();
        }
    }
}
