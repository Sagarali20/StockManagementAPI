using Inventory.EntityModels;
using Inventory.EntityModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Contracts2
{
	public interface IUserRepository:IGenericRepository<User>
	{
		List<User> GetUserInfo();
		bool InsertData(Webhook model);


    }
}
