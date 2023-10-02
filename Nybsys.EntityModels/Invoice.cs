using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.EntityModels
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string InvoiceId { get; set; }
        public Guid CustomerId { get; set; }   
        public double Amount { get; set; }   
        public double Tax { get; set; }   
        public double TotalAmount { get; set; }    
        public double BlanceDue { get; set; }    
        public double Deposit { get; set; }    
        public double Blance { get; set; }    
        public double TodayAdvance { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string Status { get; set; }    
        public DateTime InvoiceDate { get; set; }    
        public DateTime CreatedDate { get; set; }    
        public Guid CreatedBy { get; set; }    
        public DateTime LastUpdatedDate { get; set; }    
        public Guid LastUpdatedBy { get; set; }
        [NotMapped]
        public string PaymentType { get; set; } 

    }
}
