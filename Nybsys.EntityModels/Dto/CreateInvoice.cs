using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.EntityModels.Dto
{
    public class CreateInvoice
    {
        public Invoice Invoice { get; set; }  
        public List<InvoiceDetails> InvoiceDetails  { get; set; }  

    }
}
