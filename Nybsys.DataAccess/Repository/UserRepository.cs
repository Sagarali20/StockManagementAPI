using DatabaseContext;
using Microsoft.Extensions.Logging;
using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Repository
{

	public class UserRepository : GenericRepository<User>, IUserRepository
    {
		public UserRepository(NybsysDbContext dbContext, ILogger logger) : base(dbContext, logger)
		{

		}
		public List<User> GetUserInfo()
		{
			throw new NotImplementedException();
		}
	}

}
