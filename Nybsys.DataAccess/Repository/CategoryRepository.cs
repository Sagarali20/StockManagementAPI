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
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(InventoryDbContext dbContext, ILogger logger) : base(dbContext, logger)
		{
		}
		public override async Task<Category?> GetById(int id)
		{
			return await _dbContext.Categorys.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
