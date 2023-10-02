using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Contract
{
    public interface IInvoiceService
    {
        DataTable DataTable(DateTime dateTime);
        Task<bool> InsertInvoice(Invoice invoice);

    }
}
