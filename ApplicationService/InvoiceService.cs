using ApplicationService.Contract;
using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public DataTable DataTable(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertInvoice(Invoice invoice)
        {
            return await _unitOfWork.InvoiceDataAccess.Add(invoice);
        }
    }
}
