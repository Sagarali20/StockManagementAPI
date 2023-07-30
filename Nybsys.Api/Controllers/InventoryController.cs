using ApplicationService;
using Microsoft.AspNetCore.Mvc;
using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;

namespace Nybsys.Api.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class InventoryController : ControllerBase
	{
		private readonly InventoryService _inventoryService;
		public InventoryController(IUnitOfWork unitOfWork) 
		{
			_inventoryService = new InventoryService(unitOfWork);

		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _inventoryService.GetAllEquipment());
		}

		[HttpGet("{id}")]
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
		public async Task<IActionResult> Addderiver([FromBody] Equipment value)
		{
			value.EquipmentId = Guid.NewGuid();
			value.CreatedDate= DateTime.UtcNow ;
			value.LastUpdatedDate= DateTime.UtcNow ;
			value.CreatedBy= new Guid();
			value.LastUpdatedBy= new Guid();


			bool re = await _inventoryService.InsertEquipment(value);
			return Ok();

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
	}
}
