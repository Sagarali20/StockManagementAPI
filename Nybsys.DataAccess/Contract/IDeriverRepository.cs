using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Contracts2
{
	public interface IDeriverRepository:IGenericRepository<Driver>
	{
		Task<Driver?> GetbyDriverNb(int driverNb);
		List<Employee> GetAllEmployee();	
	}
}
