using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityModels
{
	public class Equipment
	{
		[Key]
		public int Id { get; set; }	
		public Guid EquipmentId { get; set; }
		public Guid? CategoryId { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string Name { get; set; }	
		public string Description { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string SKU { get; set; }
		public double Retail { get; set; }
		public double RepCost { get; set; }
		public double WholeSalePrice { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string Unit { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string LocalCode { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string Barcode { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string Comments { get; set; }
		public string Note { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string RackNo { get; set; }
		public bool IsActive { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime LastUpdatedDate { get; set; }
		public Guid LastUpdatedBy { get; set; }
		[NotMapped]
		public string CategoryName { get; set; }


	}
}
