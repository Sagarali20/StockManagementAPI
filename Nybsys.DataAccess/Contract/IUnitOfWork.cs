﻿using Nybsys.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Contracts2
{
	public interface IUnitOfWork
	{
		IUserRepository User { get; }
		IEquipmentRepository  Equipment { get; }
		ICategoryRepository Category { get; }	
		IInventoryWarehouseRepository InventoryWarehouse { get; }
		Task CompleteAsync();
	}
}