using Inventory.EntityModels;
using Inventory.EntityModels.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Contract
{
    public interface IInventoryService
    {
        Task<List<Equipment>> GetAllEquipment();
        Task<bool> InsertEquipment(Equipment Equipment);
        Task<bool> InsertCategory(Category Category);
        Task<bool> UpdateEquipment(Equipment Equipment);
        Task<bool> DeleteEquipment(Equipment Equipment);
        Task<List<Category>> GetAllCategory();
        Task<bool> DeleteCategory(Category Category);
        Task<Category?> GetCategoryById(int id);
        Task<Equipment?> GetEquipmentById(int id);
        EquipmentWithCount GetAllEquipment(StocFilter filter);
        DataTable datalldatatable(StocFilter filter);
        Task<bool> InsertInventoryWarehouse(InventoryWarehouse InventoryWarehouse);
        Task<List<InventoryWarehouse>> GetAllInventoryWarehouse();
        Task<List<InventoryWarehouse>> GetAllInventoryWarehouseByGuidId(Guid id);
    }
}
