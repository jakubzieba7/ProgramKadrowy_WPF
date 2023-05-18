using ProgramKadrowy_WPF.Models.Configurations;
using ProgramKadrowy_WPF.Models.Domains;
using ProgramKadrowy_WPF.Properties;
using System.Data.Entity;

namespace ProgramKadrowy_WPF
{
    public class ApplicationDBContext : DbContext
    {
        //using below variable is not working 
        private static string _sqlConnectionString = string.Concat("Server=", Settings.Default.ServerName, @"\", Settings.Default.ServerInstance, "; Database=", Settings.Default.SQLDatabaseName, "; User Id=", Settings.Default.ServerUserName, ";Password=", Settings.Default.ServerUserPassword, ";");
        public ApplicationDBContext()
            //: base("name=ApplicationDBContext")
            : base(string.Concat("Server=", Settings.Default.ServerName, @"\", Settings.Default.ServerInstance, "; Database=", Settings.Default.SQLDatabaseName, "; User Id=", Settings.Default.ServerUserName, ";Password=", Settings.Default.ServerUserPassword, ";"))
            //: base($@"Server=.\SIGMANEST;Database=ProgramKadrowyDB;User Id=DOTNET;Password=DOTNET;")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ContractConfiguration());
        }
    }
}