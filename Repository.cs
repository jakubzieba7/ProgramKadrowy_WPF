using ProgramKadrowy_WPF.Models.Converters;
using ProgramKadrowy_WPF.Models.Domains;
using ProgramKadrowy_WPF.Models.Wrappers;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ProgramKadrowy_WPF
{
    public class Repository
    {
        public List<Contract> GetContract()
        {
            using (var context = new ApplicationDBContext())
            {
                return context.Contracts.ToList();
            }
        }

        public List<EmployeeWrapper> GetEmployees(int contractId)
        {
            using (var context = new ApplicationDBContext())
            {
                var employees = context.Employees.Include(x => x.Contract).AsQueryable();

                if (contractId != 0)
                    employees = employees.Where(x => x.ContractId == contractId);

                return employees.ToList().Select(x => x.ToWrapper()).ToList();

            }
        }

        public void AddEmployee(EmployeeWrapper employeeWrapper)
        {
            var employee = employeeWrapper.ToDao();

            using (var context = new ApplicationDBContext())
            {
                var dbEmployee = context.Employees.Add(employee);

                context.SaveChanges();
            }
        }

        public void UpdateEmployee(EmployeeWrapper employeeWrapper)
        {
            var employee = employeeWrapper.ToDao();

            using (var context = new ApplicationDBContext())
            {
                UpdateEmployeeProperties(context, employee);

                context.SaveChanges();
            }
        }

        private void UpdateEmployeeProperties(ApplicationDBContext context, Employee employee)
        {
            var employeeToUpdate = context.Employees.Find(employee.Id);
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.ContractId = employee.ContractId;
            employeeToUpdate.Comments = employee.Comments;
            employeeToUpdate.Salary = employee.Salary;
            employeeToUpdate.EmploymentDate = employee.EmploymentDate;
            employeeToUpdate.UnemploymentDate = employee.UnemploymentDate;
            employeeToUpdate.IsCurrentlyHired = employee.IsCurrentlyHired;

        }
    }
}
