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
			return await _unitOfWork.EquipmentDataAccess.Add(Equipment);
		}
		public async Task<bool> InsertCategory(Category Category)
		{
			return await _unitOfWork.Category.Add(Category);
		}
		public async Task<bool> UpdateEquipment(Equipment Equipment)
		{
			return await _unitOfWork.EquipmentDataAccess.Update(Equipment);
		}
		public async Task<bool> DeleteEquipment(Equipment Equipment)
		{
			return await _unitOfWork.EquipmentDataAccess.Delete(Equipment);
		}
		public async Task<List<Equipment>> GetAllEquipment()
		{
			var dr = await _unitOfWork.EquipmentDataAccess.GetAll();
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
			return await _unitOfWork.EquipmentDataAccess.GetById(id);
		}
		public List<Equipment> GetAllEquipment(StocFilter filter)
		{
			  List<Equipment> list = new List<Equipment>();
			  DataSet ds=_unitOfWork.EquipmentDataAccess.GetAllEquipmentFilter(filter);
			if (ds != null)
			{
				list = (from DataRow dr in ds.Tables[0].Rows
						select new Equipment()
						{
							Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
							WholeSalePrice = dr["WholeSalePrice"] != DBNull.Value ? Convert.ToDouble(dr["WholeSalePrice"]) : 0,
							Name = dr["Name"].ToString(),
						    CategoryName = dr["CategoryName"].ToString(),
							Unit = dr["Unit"].ToString(),
							LocalCode = dr["LocalCode"].ToString(),
							Description = dr["Description"].ToString(),
							Barcode = dr["Barcode"].ToString(),
							Comments = dr["Comments"].ToString(),
							Note = dr["Note"].ToString(),
							RackNo = dr["RackNo"].ToString(),
							IsActive = Convert.ToBoolean(dr["IsActive"]),
							Retail = dr["Retail"] != DBNull.Value ? Convert.ToDouble(dr["Retail"]) : 0,
							RepCost = dr["RepCost"] != DBNull.Value ? Convert.ToDouble(dr["RepCost"]) : 0,
							EquipmentId = (Guid)dr["EquipmentId"],
							CategoryId = (Guid)dr["CategoryId"],

						}).ToList();

			}

			return list;
				
			
		}

		public DataTable datalldatatable(StocFilter filter)
		{
			DataSet ds = _unitOfWork.EquipmentDataAccess.GetAllEquipmentFilter(filter);

		  return ds.Tables[0];

		}

	}
}
