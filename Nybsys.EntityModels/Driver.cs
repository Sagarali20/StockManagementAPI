using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.EntityModels
{
	public class Driver
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DriverNumber { get; set; }
		public string Team { get; set; }

		public Guid DriverId { get; set; }
		
	}
}
