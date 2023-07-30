using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
	public class InventoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public InventoryService(IUnitOfWork unitOfWork) 
		{
			_unitOfWork = unitOfWork;
		
		}
		public async Task<bool> InsertEquipment(Equipment Equipment)
		{
			return await _unitOfWork.Equipment.Add(Equipment);
		}
		public async Task<bool> UpdateEquipment(Equipment Equipment)
		{
			return await _unitOfWork.Equipment.Update(Equipment);
		}
		public async Task<bool> DeleteEquipment(Equipment Equipment)
		{
			return await _unitOfWork.Equipment.Delete(Equipment);
		}
		public async Task<List<Equipment>> GetAllEquipment()
		{
			var dr = await _unitOfWork.Equipment.GetAll();
			return dr.ToList();
		}
		public async Task<Equipment?> GetEquipmentById(int id)
		{
			return await _unitOfWork.Equipment.GetById(id);
		}

	}
}
