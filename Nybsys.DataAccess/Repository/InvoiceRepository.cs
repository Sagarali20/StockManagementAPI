using DatabaseContext;
using Microsoft.Extensions.Logging;
using Nybsys.DataAccess.Contract;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(NybsysDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
