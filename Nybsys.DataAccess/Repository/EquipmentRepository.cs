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
	public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
	{
		public EquipmentRepository(NybsysDbContext dbContext, ILogger logger) : base(dbContext, logger)
		{

		}

		public override async Task<Equipment?> GetById(int id)
		{
			return await _dbContext.Equipments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}


		public List<Equipment> GetAllEquipment()
		{
			throw new NotImplementedException();
		}
	}
}
