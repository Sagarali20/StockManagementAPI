using DatabaseContext;
using Microsoft.Extensions.Logging;
using Inventory.DataAccess.Contract;
using Inventory.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAccess.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(InventoryDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
