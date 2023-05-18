﻿using ProgramKadrowy_WPF.Models.Domains;
using System.Data.Entity.ModelConfiguration;

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
