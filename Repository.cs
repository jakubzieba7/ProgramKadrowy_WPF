using ProgramKadrowy_WPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
