using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Repository
{
	public class DriverRepository : GenericRepository<Driver>, IDeriverRepository
	{
		public DriverRepository(NybsysDbContext dbContext, ILogger logger) : base(dbContext, logger)
		{

		}

		public List<Employee> GetAllEmployee()
		{
			throw new NotImplementedException();
		}

		public Task<Driver?> GetbyDriverNb(int driverNb)
		{
			throw new NotImplementedException();
		}
		//public override async Task<Driver?> GetById(int id)
		//{
		//	return await _dbContext.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		//}
		//public override async Task<IEnumerable<Driver>> GetAll()
		//{
		//	try {
		//		return await _dbContext.Drivers.ToListAsync(); 
		//	} 
		//	catch(Exception ex)
		//	{
		//		Console.WriteLine(ex);
		//		throw;
		//	}

		//}
		//public async  Task<Driver?> GetbyDriverNb(int driverNb)
		//{
		//	try {

		//		return await _dbContext.Drivers.FirstOrDefaultAsync(x =>x.DriverNumber== driverNb);

		//	}
		//	catch(Exception ex)
		//	{
		//		Console.WriteLine(ex);
		//		throw;
		//	}

		//}

		//Task<Driver?> IDeriverRepository.GetbyDriverNb(int driverNb)
		//{
		//	throw new NotImplementedException();
		//}

		//public List<Employee> GetAllEmployee()
		//{
		//	List<Employee> list = new List<Employee>();
		//	string sqlquery = @"select * from drivers   select * from drivers";
		//	sqlquery = string.Format(sqlquery);

		//	DataSet ds = GetDataSet(sqlquery);
		//	DataTable dt = ds.Tables[0];

		//	return list;
		//}
	}
}
