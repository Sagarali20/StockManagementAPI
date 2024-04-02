using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityModels
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }	
		public Guid CustomerId { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string FirstName { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string LastName { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string Type { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string PhoneNumber { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string EmailAddress { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string Address { get; set; }
		public  DateTime JoinDate { get; set; }
		public  bool IsActive { get; set; }
		public  bool IsWholeSaler { get; set; }
		[Column(TypeName = "NVARCHAR(50)")]
		public string Occupation { get; set; }
		public  string ProfileImage { get; set; }
		[Column(TypeName = "NVARCHAR(250)")]
		public string SearchText { get; set; }
		public  Guid CreatedBy { get; set; }
		public  DateTime CreateDate { get; set; }
		public Guid LastCreatedBy { get; set; }
		public DateTime LastUpdateDate { get; set; }
	}
}
