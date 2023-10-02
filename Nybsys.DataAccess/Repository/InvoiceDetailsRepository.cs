using DatabaseContext;
using Microsoft.Extensions.Logging;
using Nybsys.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Repository
{
    public class InvoiceDetailsRepository : GenericRepository<InvoiceDetailsRepository>, IInvoiceDetailsRepository
    {
        public InvoiceDetailsRepository(NybsysDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {

        }
    }
}
