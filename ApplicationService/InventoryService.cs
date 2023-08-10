using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
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
		public async Task<bool> InsertCategory(Category Category)
		{
			return await _unitOfWork.Category.Add(Category);
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
		public async Task<List<Category>> GetAllCategory()
		{
			var model = await _unitOfWork.Category.GetAll();
			return model.ToList();
		}

		public async Task<bool> DeleteCategory(Category Category)
		{
			return await _unitOfWork.Category.Delete(Category);
		}

		public async Task<Category?> GetCategoryById(int id)
		{
			return await _unitOfWork.Category.GetById(id);
		}
		public async Task<Equipment?> GetEquipmentById(int id)
		{
			return await _unitOfWork.Equipment.GetById(id);
		}
		public DataSet GetAllEquipment(StocFilter filter)
		{
			return _unitOfWork.Equipment.GetAllEquipmentDataset(filter);
		}

	}
}
