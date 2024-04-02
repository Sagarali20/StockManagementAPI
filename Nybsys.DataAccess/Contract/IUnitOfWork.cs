using Inventory.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Contracts2
{
	public interface IUnitOfWork
	{
		IUserRepository User { get; }
		IEquipmentRepository  EquipmentDataAccess { get; }
		ICategoryRepository Category { get; }	
		IInventoryWarehouseRepository InventoryWarehouseDataAccess { get; }
		ICustomerRepository CustomerDataAccess { get; }
		IInvoiceRepository InvoiceDataAccess { get; }
		IInvoiceDetailsRepository InvoiceDetailsDataAccess { get; }
        Task CompleteAsync();
	}
}
