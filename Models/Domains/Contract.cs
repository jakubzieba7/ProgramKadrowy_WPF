using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProgramKadrowy_WPF.Models.Domains
{
    public class Contract
    {
        public Contract()
        {
            Employees = new Collection<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
