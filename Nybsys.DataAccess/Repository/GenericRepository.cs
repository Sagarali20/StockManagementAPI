using DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nybsys.DataAccess.Contracts2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Nybsys.DataAccess.Repository
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
	{

		protected NybsysDbContext _dbContext;
		internal DbSet<T> _dbSet;
		protected readonly ILogger _logger;
		private readonly string connnection;
		private SqlConnection _DBConnection = new SqlConnection(); 

		public GenericRepository(NybsysDbContext dbContext, ILogger logger)
		{
			_dbContext = dbContext;
			_logger= logger;
			this._dbSet= _dbContext.Set<T>();
			connnection = _dbContext.Database.GetConnectionString().ToString();
		}

		public virtual async Task<IEnumerable<T>> GetAll()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
		}

		public virtual async Task<T?> GetById(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		public virtual async Task<bool> Add(T entity)
		{
		    await _dbSet.AddAsync(entity);
			return await _dbContext.SaveChangesAsync() > 0;
		}


		public virtual  async  Task<bool>  Update(T entity)
		{	
			_dbSet.Update(entity);
			return await _dbContext.SaveChangesAsync() > 0;
		}

		public virtual async Task<bool> Delete(T entity)
		{
			      _dbSet.Remove(entity);
			return await _dbContext.SaveChangesAsync() > 0;
			
		}
		public  bool Save()
		{
			return _dbContext.SaveChanges() > 0;
		}


		public DataSet GetDataSet(string query)
		{
			using (SqlConnection con = new SqlConnection(connnection))
			{
				con.Open();
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataSet ds = new DataSet();
					da.Fill(ds);
	                con.Close();
					return ds;
				}
			
			}
		}
		protected SqlConnection DBConnection
		{
			get
			{
				_DBConnection = new SqlConnection(connnection);
				return _DBConnection;
			}
		}
		protected SqlCommand GetTableCommand(string TableName)
		{
			SqlCommand command;
			command = new SqlCommand(TableName, _DBConnection);
			command.CommandType = CommandType.Text;
			return command;
		}


	}
}
