using Inventory.DataAccess.Contracts2;
using Inventory.EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Contract
{
	public interface ICustomerRepository: IGenericRepository<Customer>
	{
        DataSet GetAllCustomerFilter(StocFilter filter);

    }
}
