using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityModels
{
	public class InventoryWarehouse
	{
		[Key]
		public int Id { get; set; }
		public Guid EquipmentId { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string Type { get; set; }
		public double Quantity { get; set; }
		public double Price { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string PurchaseOrderId { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string Description { get; set; }
		public DateTime LastUpdatedDate { get; set; }
		public Guid LastUpdatedBy { get; set; }
	}
}
