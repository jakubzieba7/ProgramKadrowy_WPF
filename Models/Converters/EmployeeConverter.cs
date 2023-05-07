using ProgramKadrowy_WPF.Models.Domains;
using ProgramKadrowy_WPF.Models.Wrappers;

namespace ProgramKadrowy_WPF.Models.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeWrapper ToWrapper(this Employee model)
        {
            return new EmployeeWrapper
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Comments = model.Comments,
                Salary = model.Salary,
                EmploymentDate = model.EmploymentDate,
                UnemploymentDate = model.UnemploymentDate,
                IsCurrentlyHired = model.IsCurrentlyHired,
                Contract = new ContractWrapper { Id = model.Contract.Id, Name = model.Contract.Name }
            };
        }

        public static Employee ToDao(this EmployeeWrapper model)
        {
            return new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ContractId = model.Contract.Id,
                Comments = model.Comments,
                Salary = model.Salary,
                EmploymentDate = model.EmploymentDate,
                UnemploymentDate = model.UnemploymentDate,
                IsCurrentlyHired = model.IsCurrentlyHired
            };
        }
    }
}
