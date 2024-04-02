using DatabaseContext;
using Microsoft.Extensions.Logging;
using Inventory.DataAccess.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Repository
{
    public class InvoiceDetailsRepository : GenericRepository<InvoiceDetailsRepository>, IInvoiceDetailsRepository
    {
        public InvoiceDetailsRepository(InventoryDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {

        }
    }
}
