using ApplicationService.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nybsys.EntityModels.Dto;
using SERP.Framework;

namespace Nybsys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceServiceController : ControllerBase
    {

        private readonly IInvoiceService _invoiceService;
        public InvoiceServiceController(IInvoiceService inventoryService)
        {
            //_inventoryService = new InventoryService(unitOfWork);
            _invoiceService = inventoryService;
        }


        [HttpPost]
        [Route("get-invoice-id")]
        public async Task<IActionResult> AddInvoice()
        {
            bool result = false; 
             CreateInvoice createInvoice = new CreateInvoice();

            createInvoice.Invoice = new EntityModels.Invoice
            {
                CreatedBy=new Guid(),
                CreatedDate=DateTime.UtcNow,
                LastUpdatedBy=new Guid(),   
            };
            result = await _invoiceService.InsertInvoice(createInvoice.Invoice);

            

            createInvoice.Invoice.InvoiceId = createInvoice.Invoice.Id.GenerateInvoiceNo();


            var model=0;

            var res = new
            {
                equipment = model
            };
            return Ok(res);
        }
        [HttpPost]
        [Route("get-equ")]
        public async Task<IActionResult> AddInvoice(CreateInvoice createInvoice)
        {


            var model=0;

            var res = new
            {
                equipment = model
            };
            return Ok(res);
        }

    }
}
