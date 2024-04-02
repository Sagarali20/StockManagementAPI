using DatabaseContext;
using Inventory.DataAccess.Contract;
using Inventory.DataAccess.Contracts2;
using Inventory.DataAccess.Repository;
using Inventory.EntityModels;

namespace Inventory.Api
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{

		private readonly InventoryDbContext _Context;

		public IUserRepository User { get; private set; }
		public IEquipmentRepository EquipmentDataAccess { get; private set; }
		public ICategoryRepository Category { get; private set; }

		public IInventoryWarehouseRepository InventoryWarehouseDataAccess { get; private set; }
		public ICustomerRepository CustomerDataAccess { get; private set; }

        public IInvoiceRepository InvoiceDataAccess { get; private set; }

        public IInvoiceDetailsRepository InvoiceDetailsDataAccess { get; private set; }

        public UnitOfWork(InventoryDbContext context, ILoggerFactory logger)
		{
			_Context = context;
			var _logger = logger.CreateLogger(categoryName: "logs");
			User = new UserRepository(_Context, _logger);
			EquipmentDataAccess = new EquipmentRepository(_Context, _logger) ;
			Category = new CategoryRepository(_Context, _logger) ;
			InventoryWarehouseDataAccess = new InventoryWarehouseRepository(_Context, _logger);
			CustomerDataAccess = new CustomerRepository(_Context, _logger) ;
            InvoiceDataAccess = new InvoiceRepository(_Context, _logger) ;
			CustomerDataAccess = new CustomerRepository(_Context, _logger) ;
		}
        public void Dispose()
		{
			_Context.Dispose();
		}
		public async Task CompleteAsync()
		{
			await _Context.SaveChangesAsync();
		}

    }
}
