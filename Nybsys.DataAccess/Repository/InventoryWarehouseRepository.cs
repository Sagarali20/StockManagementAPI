using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nybsys.DataAccess.Contract;
using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Repository
{
	public class InventoryWarehouseRepository : GenericRepository<InventoryWarehouse>, IInventoryWarehouseRepository
	{
		public InventoryWarehouseRepository(NybsysDbContext dbContext, ILogger logger) : base(dbContext, logger)
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
