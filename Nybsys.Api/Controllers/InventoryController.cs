using ApplicationService;
using Microsoft.AspNetCore.Mvc;
using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;

namespace Nybsys.Api.Controllers
{


	[Route("api/inventory")]

	[ApiController]
	public class InventoryController : ControllerBase
	{
		private readonly InventoryService _inventoryService;
		public InventoryController(IUnitOfWork unitOfWork) 
		{
			_inventoryService = new InventoryService(unitOfWork);

		}
		[HttpGet]
		[Route("getall-equipment")]
		public async Task<IActionResult> Get()
		{
		  var equipment  =await _inventoryService.GetAllEquipment();
			return Ok(new { equipment = equipment });
		}

		[HttpPost]
		[Route("get-equipment-by-id")]
		public async Task<IActionResult> Get(int id)
		{
			var model = await _inventoryService.GetEquipmentById(id);
			if (model == null)
			{
				return NotFound();
			}
			return Ok(model);
		}

		[HttpPost]
		[Route("add-equipment")]

		public async Task<IActionResult> AddEquipment([FromBody] Equipment value)
		{
			bool result = false;

			if(value !=null)
			{
				if (value.Id > 0)
				{
					value.LastUpdatedDate = DateTime.UtcNow;
					value.LastUpdatedBy = new Guid();

					result = await _inventoryService.UpdateEquipment(value);

				}
				else
				{
					value.EquipmentId = Guid.NewGuid();
					value.CreatedDate = DateTime.UtcNow;
					value.LastUpdatedDate = DateTime.UtcNow;
					value.CreatedBy = new Guid();
					value.LastUpdatedBy = new Guid();
					result = await _inventoryService.InsertEquipment(value);

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
		[Route("delete-equipment")]
		public async Task<IActionResult> DeleteEquipment(int id)
		{
			bool result = false;
			var model = await _inventoryService.GetEquipmentById(id);
			if (model == null)
			{
				return NotFound();
			}
			result= await _inventoryService.DeleteEquipment(model);
			var res = new
			{
				result = result
			};
			return Ok(res);
		}


		[HttpPatch()]
		public async Task<IActionResult> UpdateDeriver(Equipment Equipment)
		{
			var model = await _inventoryService.GetEquipmentById(Equipment.Id);

			if (model == null) return NotFound();
			//{
			try
			{
				var res = await _inventoryService.UpdateEquipment(Equipment);
			}
			catch (Exception ex)
			{

			}
			//}


			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDriver(int id)
		{
			var model = await _inventoryService.GetEquipmentById(id);
			if (model == null)
			{
				return NotFound();
			}
			await _inventoryService.DeleteEquipment(model);
			return Ok();
		}


		[HttpPost("category")]
		public async Task<IActionResult> Category([FromBody] Category value)
		{
			bool result = false;
			value.CategoryId = Guid.NewGuid();
			result = await _inventoryService.InsertCategory(value);

			var model = new
			{
				result = result
			};

			return Ok(model);
		}
		[HttpGet("getallcategory")]
		public async Task<IActionResult> GetAllCategory()
		{
			var allCategory = await _inventoryService.GetAllCategory();

			return Ok(new { category = allCategory });
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{

			bool result = false;

			var Category = await _inventoryService.GetCategoryById(id);
			if (Category == null)
			{
				return NotFound();

			}
			result = await _inventoryService.DeleteCategory(Category);

			var model = new { 		
				result = result 
			};
			return Ok(model);
		}

		[HttpGet()]
		[Route("GetAllCategory-2")]
		public async Task<IActionResult> GetAllCategory2()
		{
			var allCategory = await _inventoryService.GetAllCategory();

			return Ok(new { category = allCategory });
		}


	}
}
