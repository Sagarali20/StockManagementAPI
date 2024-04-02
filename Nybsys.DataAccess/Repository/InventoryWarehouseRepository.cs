using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Inventory.DataAccess.Contract;
using Inventory.DataAccess.Contracts2;
using Inventory.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Repository
{
	public class InventoryWarehouseRepository : GenericRepository<InventoryWarehouse>, IInventoryWarehouseRepository
	{
		public InventoryWarehouseRepository(InventoryDbContext dbContext, ILogger logger) : base(dbContext, logger)
		{

		}
		public override async Task<InventoryWarehouse?> GetById(int id)
		{
			return await _dbContext.InventoryWarehouses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}
		public override async Task<IEnumerable<InventoryWarehouse>> GetAllByGuidId(Guid id)
		{
			return await _dbContext.InventoryWarehouses.Where(x => x.EquipmentId==id).OrderByDescending(x=>x.Id).ToListAsync();
		}

	}
}
