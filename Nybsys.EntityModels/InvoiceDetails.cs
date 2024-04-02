using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.EntityModels
{
    public class InvoiceDetails
    {
        [Key]

        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string InvoieId { get; set; }    
        public Guid EquipmentId { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string EquipmentName { get; set; }    
        public int Quantity { get; set; }    
        public double UnitPrice { get; set; }    
        public double TotalPrice { get; set; }    
        public DateTime CreatedDate { get; set; }    
        public Guid CreatedBy { get; set; }    

    }
}
