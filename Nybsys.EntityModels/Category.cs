using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityModels
{
	public class Category
	{
		[Key]
		public int Id { get; set; }	
		public Guid CategoryId { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string Name { get; set; }
	}
}
