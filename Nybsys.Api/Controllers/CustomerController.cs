using ApplicationService;
using ApplicationService.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Inventory.DataAccess.Contracts2;
using Inventory.EntityModels;

namespace Inventory.Api.Controllers
{
	[Route("api/customer")]
	[ApiController]
	public class CustomerController : ControllerBase
	{

		private readonly CustomerService _customerService;
		public CustomerController(IUnitOfWork unitOfWork)
		{
			_customerService = new CustomerService(unitOfWork);
		}

		[HttpPost]
		[Route("add-customer")]

		public async Task<IActionResult> AddCustomer([FromBody] Customer value)
		{
			bool result = false;

			if (value != null)
			{
				if (value.Id > 0)
				{
					value.LastUpdateDate = DateTime.UtcNow;
					value.LastCreatedBy = new Guid();
					result = await _customerService.UpdateCustomer(value);
				}
				else
				{
					value.SearchText = value.FirstName + " " + value.LastName + " " + value.Type + " " + value.PhoneNumber + " " + value.Address;
					value.CustomerId = Guid.NewGuid();
					value.CreateDate = DateTime.UtcNow;
					value.JoinDate = DateTime.UtcNow;
					value.CreatedBy = new Guid();
					result = await _customerService.InsertCustomer(value);
				}
			}
			var res = new
			{
				result = result,
				model = value
			};
			return Ok(res);

		}

        [HttpPost]
        [Route("getall-customer")]
        public async Task<IActionResult> GetAllCustomer(StocFilter value)
        {
            var customer = _customerService.GetAllCustomer(value);

			var res = new
			{
                customers = customer.Customerlist,
                Count = customer.Count,
                result = true,
            };
            return Ok(res);

        }

        [HttpPost]
        [Route("get-customer-by-id")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _customerService.GetCustomerById(id);
            if (model == null)
            {
                return NotFound();
            }
            var res = new
            {
                customer = model
            };
            return Ok(res);
        }
        [HttpPost]
        [Route("get-customer-by-search-name")]
        public async Task<IActionResult> GetByname(string searchText)
        {
            StocFilter filter = new StocFilter();
            filter.SearchText= searchText;
            filter.PageNo= 1;
            filter.PageSize = 10;
            filter.SearchText= searchText;
            var customer = _customerService.GetAllCustomer(filter);
            var res = new
            {
                customers = customer.Customerlist,
                Count = customer.Count,
                result = true,
            };
            return Ok(res);
        }

    }
}
