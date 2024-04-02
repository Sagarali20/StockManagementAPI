using Inventory.DataAccess.Contracts2;
using Inventory.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
	public class UserLoginService
	{
		private readonly IUnitOfWork _unitOfWork;
		public UserLoginService(IUnitOfWork unitOfWork) 
		{ 
			_unitOfWork = unitOfWork;
			//dsfgg
		}

		public async Task<bool> InsertUser(User User) 
		{
			return await _unitOfWork.User.Add(User);
		}
		public async Task<bool> UpdateUser(User User)
		{
			return await _unitOfWork.User.Update(User);
		}
		public async Task<bool> DeleteDrive(User User)
		{
			return await _unitOfWork.User.Delete(User);
		}
		public async Task<List<User>> GetAllUser()
		{
			var dr = await _unitOfWork.User.GetAll();
			return dr.ToList();
		}
		public async Task<User?> GetUserById(int id)
		{
			return await _unitOfWork.User.GetById(id);
		}
		//public List<User> GetEmployee()
		//{
		//	return _unitOfWork.Derivers.GetAllEmployee();
		//}

	}
}
