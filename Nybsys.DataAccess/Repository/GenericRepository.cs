using DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Inventory.DataAccess.Contracts2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Inventory.DataAccess.Repository
{
	public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
	{

		protected InventoryDbContext _dbContext;
		internal DbSet<T> _dbSet;
		protected readonly ILogger _logger;
		private readonly string connnection;
		private SqlConnection _DBConnection = new SqlConnection(); 

		public GenericRepository(InventoryDbContext dbContext, ILogger logger)
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
		public virtual async Task<IEnumerable<T>> GetAllByGuidId(Guid id)
		{
			return await _dbSet.AsNoTracking().ToListAsync();

		}
		public virtual async Task<T?> GetById(int id)
		{
			return await _dbSet.FindAsync(id);
		}
		public virtual async Task<T?> GetByGuidId(Guid id)
		{
			return await _dbSet.FindAsync(id);
		}
		public virtual async Task<bool> Add(T entity)
		{
			
		    await _dbSet.AddAsync(entity);
			return await _dbContext.SaveChangesAsync() > 0;
		}
		public virtual  async  Task<bool> Update(T entity)
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
		protected SqlCommand GetSQLCommand(string QueryString)
		{
			if(DBConnection !=null)
			{
			    SqlCommand command;
				command = new SqlCommand(QueryString, DBConnection);
		     	command.CommandType = CommandType.Text;
				return command;
			}

			return null;
		}


		protected DataSet GetDataSet(SqlCommand command)
		{
			return GetDataSet(command, "Default");
		}

		public DataSet GetDataSet(SqlCommand command, string tablename)
		{
			DataSet dataset = new DataSet();
			dataset.Tables.Add(new DataTable(tablename));
			SqlDataAdapter dataadapter = new SqlDataAdapter(command);
			dataadapter.Fill(dataset, tablename);
			return dataset;
		}

		public void AddParameter(SqlCommand command, SqlParameter param)
		{
			if (param != null)
				command.Parameters.Add(param);
		}
		protected SqlParameter pDateTime(string paramName, DateTime? value) 
		{
			return pDateTime(paramName, value, ParameterDirection.Input);
		}
		protected SqlParameter pDateTime(string paramName, DateTime? value, ParameterDirection direction)
		{
			SqlParameter param = new SqlParameter("@" + paramName, SqlDbType.DateTime);
			if (!value.HasValue)
				param.Value = DBNull.Value;
			else if (value.Value == DateTime.MinValue && direction == ParameterDirection.Input)
				param.Value = DBNull.Value;
			else
				param.Value = value;
			param.Direction = direction;
			return param;
		}
		protected SqlParameter pInt32(string paramName, int value)
		{
			return pInt32(paramName, value, ParameterDirection.Input);
		}
		protected SqlParameter pInt32(string paramName, int? value)
		{
			return pInt32(paramName, value, ParameterDirection.Input);
		}
		protected SqlParameter pInt32(string paramName, int? value, ParameterDirection direction)
		{
			SqlParameter param = new SqlParameter("@" + paramName, SqlDbType.Int);
			if (!value.HasValue)
				param.Value = DBNull.Value;
			else
				param.Value = value;
			param.Direction = direction;
			return param;
		}
		public SqlParameter pNVarChar(string paramName, string value)
		{
			return pNVarChar(paramName, -1, value, ParameterDirection.Input);
		}
		protected SqlParameter pNVarChar(string paramName, int size, string value, ParameterDirection direction)
		{
			SqlParameter param = new SqlParameter("@" + paramName, SqlDbType.NVarChar);
			param.Size = size;
			if (value == null)
				param.Value = "";
			else
				param.Value = value;
			param.Direction = direction;
			return param;
		}

		protected SqlParameter pGuid(string paramName, Guid value)
		{
			return pGuid(paramName, value, ParameterDirection.Input);
		}

		protected SqlParameter pGuid(string paramName, Guid value, ParameterDirection direction)
		{
			SqlParameter param = new SqlParameter("@" + paramName, SqlDbType.UniqueIdentifier);
			param.Value = value;
			param.Direction = direction;
			return param;
		}

	}
}
