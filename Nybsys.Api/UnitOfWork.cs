using DatabaseContext;
using Nybsys.DataAccess.Contract;
using Nybsys.DataAccess.Contracts2;
using Nybsys.DataAccess.Repository;
using Nybsys.EntityModels;

namespace Nybsys.Api
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{

		private readonly NybsysDbContext _Context;

		public IUserRepository User { get; private set; }
		public IEquipmentRepository EquipmentDataAccess { get; private set; }
		public ICategoryRepository Category { get; private set; }

		public IInventoryWarehouseRepository InventoryWarehouse { get; private set; }

		public UnitOfWork(NybsysDbContext context, ILoggerFactory logger)
		{
			_Context = context;
			var _logger = logger.CreateLogger(categoryName: "logs");
			User = new UserRepository(_Context, _logger) ;
			EquipmentDataAccess = new EquipmentRepository(_Context, _logger) ;
			Category = new CategoryRepository(_Context, _logger) ;
			InventoryWarehouse = new InventoryWarehouseRepository(_Context, _logger) ;
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
