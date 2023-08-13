using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.EntityModels.Dto
{
	public class EquipmentWithCount
	{
		public List<Equipment> EquipmentList { get; set; }
		public Int32 Count { get; set; }	
	}
}
