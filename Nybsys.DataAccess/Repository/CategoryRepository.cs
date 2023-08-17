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
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(NybsysDbContext dbContext, ILogger logger) : base(dbContext, logger)
		{
		}
		public override async Task<Category?> GetById(int id)
		{
			return await _dbContext.Categorys.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
