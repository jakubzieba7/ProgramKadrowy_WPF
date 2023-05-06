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
    }
}
