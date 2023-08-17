using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Contracts2
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAll();
		Task<IEnumerable<T>> GetAllByGuidId(Guid id);
		Task<T?> GetById(int id);
		Task<T?> GetByGuidId(Guid id);
		Task<bool> Add(T entity);
		//bool Update(T entity);
		Task<bool> Update(T entity);
		Task<bool> Delete(T entity);


	}
}
