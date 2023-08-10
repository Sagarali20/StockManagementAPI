using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Contract
{
	public interface IEquipmentRepository: IGenericRepository<Equipment>
	{
		List<Equipment> GetAllEquipment(StocFilter filter);
		DataSet GetAllEquipmentDataset(StocFilter filter);
	}
}
