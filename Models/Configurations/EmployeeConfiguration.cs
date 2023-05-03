using ProgramKadrowy_WPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramKadrowy_WPF.Models.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("dbo.Employees");
            HasKey(x => x.Id);
            Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            Property(x => x.LastName).HasMaxLength(100).IsRequired();
        }
    }
}
