using ProgramKadrowy_WPF.Models.Configurations;
using ProgramKadrowy_WPF.Models.Domains;
using ProgramKadrowy_WPF.Properties;
using System.Data.Entity;

namespace ProgramKadrowy_WPF
{
    public class ApplicationDBContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProgramKadrowy_WPF.ApplicationDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationDBContext' 
        // connection string in the application configuration file.
        private static string _sqlConnectionString = string.Concat("Server=", Settings.Default.ServerName, @"\", Settings.Default.ServerInstance, "; Database=", Settings.Default.SQLDatabaseName, "; User Id=", Settings.Default.ServerUserName, ";Password=", Settings.Default.ServerUserPassword, ";");
        public ApplicationDBContext()
            //: base("name=ApplicationDBContext")
            : base(string.Concat("Server=", Settings.Default.ServerName, @"\", Settings.Default.ServerInstance, "; Database=", Settings.Default.SQLDatabaseName, "; User Id=", Settings.Default.ServerUserName, ";Password=", Settings.Default.ServerUserPassword, ";"))
            //: base($@"Server=.\SIGMANEST;Database=ProgramKadrowyDB;User Id=DOTNET;Password=DOTNET;")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ContractConfiguration());
        }
    }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}