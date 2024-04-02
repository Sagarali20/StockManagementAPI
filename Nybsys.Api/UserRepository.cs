using DatabaseContext;
using Microsoft.Extensions.Logging;
using Inventory.DataAccess.Contracts2;
using Inventory.EntityModels;
using Inventory.EntityModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Repository
{

	public class UserRepository : GenericRepository<User>, IUserRepository
    {
		public UserRepository(InventoryDbContext dbContext, ILogger logger) : base(dbContext, logger)
		{

		}
		public List<User> GetUserInfo()
		{
			throw new NotImplementedException();
		}

        public bool InsertData(Webhook model)
        {
			string query = "";
			return true;
        }

  
    }

}
