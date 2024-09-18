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
    }
}
