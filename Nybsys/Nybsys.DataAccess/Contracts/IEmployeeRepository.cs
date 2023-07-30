using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Contracts
{
    public interface IEmployeeRepository
    {
        bool Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);  
        Employee GetById(int id);
        ICollection<Employee> GetAll();
    }
}
