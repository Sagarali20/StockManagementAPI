using ApplicationService.Contract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Inventory.DataAccess.Contracts2;
using Inventory.EntityModels;
using System.Data;
using System.Xml;
using Microsoft.AspNetCore.Authorization;

namespace Inventory.Api.Controllers
{


    [Route("api/inventory")]

	[ApiController]
	public class InventoryController : ControllerBase
	{
		private readonly IInventoryService _inventoryService;
		public InventoryController(IInventoryService inventoryService) 
		{
			//_inventoryService = new InventoryService(unitOfWork);
			_inventoryService = inventoryService;
		}
		[HttpGet]
		[Route("getall-equipment")]
		public async Task<IActionResult> Get()
		{
		  var equipment  =await _inventoryService.GetAllEquipment();
			return Ok(new { equipment = equipment });
		}
		[Authorize]
		[HttpPost]
		[Route("get-equipment-by-id")]
		public async Task<IActionResult> Get(int id)
		 {
			var model = await _inventoryService.GetEquipmentById(id);
			if (model == null)
			{
				return NotFound();
			}
			var res = new
			{ 
				equipment = model
			};
			return Ok(res);
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
		[Route("getall-equipment")]
		public async Task<IActionResult>GetAllEquipment(StocFilter value)
		{
			var equipment = _inventoryService.GetAllEquipment(value);

			var res = new
			{
				equipmentlist = equipment.EquipmentList,
				Count = equipment.Count,
				result = true,
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
		[HttpGet()]
		[Route("getall-inventoryWarehouse")]
		public async Task<IActionResult> GetAllInventoryWarehouse()
		{
			var InventoryWarehouse = await _inventoryService.GetAllInventoryWarehouse();

			return Ok(new { data = InventoryWarehouse });
		}

		[HttpGet()]
		[Route("getall-inventoryWarehouse-by-guidid")]
		public async Task<IActionResult> GetAllInventoryWarehousebyId(string id)
		{
			var InventoryWarehouse = await _inventoryService.GetAllInventoryWarehouseByGuidId(Guid.Parse(id));

			return Ok(new { data = InventoryWarehouse });
		}

		[HttpPost]
		[Route("add-inventory-warehouse")]
		public async Task<IActionResult> AddEquipment([FromBody] InventoryWarehouse value)
		{

            bool result = false;
			if (value != null)
			{
				if(value.Type=="Damage")
				{
					value.Quantity = -value.Quantity;

				}
					value.LastUpdatedDate = DateTime.UtcNow;
					value.LastUpdatedBy = new Guid();
					result = await _inventoryService.InsertInventoryWarehouse(value);				
			}
			var res = new
			{
				result = result,
				model = value
			};
			return Ok(res);

		}

	}
}
