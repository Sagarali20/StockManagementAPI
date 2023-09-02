using DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Nybsys.DataAccess.Contract;
using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nybsys.DataAccess.Repository
{
	public class EquipmentRepository : GenericRepository<Equipment>, IEquipmentRepository
	{
		public EquipmentRepository(NybsysDbContext dbContext, ILogger logger ) : base(dbContext,logger)
		{

		}

		public override async Task<Equipment?> GetById(int id)
		{
			return await _dbContext.Equipments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}
		//public override async Task<Equipment?> GetAll()
		//{
		//	var equipmentWithCategories = await _dbContext.Equipments
		//				.Include(e => e.Category) // Include the related Category
		//				.ToListAsync();
		//	return equipmentWithCategories;
		//}
     

		public List<Equipment> GetAllEquipment(StocFilter filter)
		{



		//	DataSet ds = GetDataSet("")


			throw new NotImplementedException();
		}

		public DataSet GetAllEquipmentFilter(StocFilter filter)
	{
			string sqlQuery = @"declare @pagestart int
                                declare @pageend int
                                set @pagestart=(@pageno-1)* @pagesize 
                                set @pageend = @pagesize

                                select eq.Id  into #EquipmentsFilter from Equipments eq								
                                LEFT JOIN  Categorys ct on ct.CategoryId = eq.CategoryId 
								where  eq.Id is not null {0}
								SELECT TOP (@pagesize)
                                  *  Into #EquipmentsResultData
                                FROM  #EquipmentsFilter
                                where Id NOT IN(Select TOP (@pagestart) Id from #EquipmentsFilter #cd order by #cd.Id desc)
							    order by Id desc    
								select eq.*,ct.[Name] as CategoryName,
								eq.EquipmentId,
                                eq.CategoryId,
								eq.[Name], 
								eq.SKU,
								eq.Retail,
								eq.RepCost,
								eq.WholeSalePrice,
								eq.Unit,
								eq.LocalCode,
								eq.Barcode,
								eq.Comments,
								eq.RackNo,
								eq.IsActive,
								eq.Note
                                from #EquipmentsResultData eqd
								LEFT JOIN Equipments eq on eq.Id = eqd.Id
								left join Categorys  ct on ct.CategoryId=eq.CategoryId
                                where eq.Id IS NOT NULL {0}            
								select count(*) [TotalCount]
                                from #EquipmentsFilter
								Drop table #EquipmentsFilter
								drop table #EquipmentsResultData";

			string sqlSubQuery = "";

			if (!string.IsNullOrWhiteSpace(filter.SearchText))
			{
				filter.SearchText = HttpUtility.UrlDecode(filter.SearchText).TrimEnd();
				sqlSubQuery += " AND CHARINDEX(@SearchText,eq.[Name]) > 0 or CHARINDEX(@SearchText,eq.SKU) > 0 or CHARINDEX(@SearchText,eq.LocalCode) > 0";

			}
			try
			{

				//sqlQuery = string.Format(sqlQuery, CompanyId, filter.StartDate);
				sqlQuery = string.Format(sqlQuery, sqlSubQuery);
				using (SqlCommand cmd = GetSQLCommand(sqlQuery))
				{
					//AddParameter(cmd, pDateTime("StartDate", filter.StartDate));
					//AddParameter(cmd, pDateTime("EndDate", filter.EndDate));
					//AddParameter(cmd, pGuid("CompanyId", filter.CompanyId));
					AddParameter(cmd, pInt32("pagesize", filter.PageSize));
					AddParameter(cmd, pInt32("pageno", filter.PageNo));
					if (!string.IsNullOrWhiteSpace(filter.SearchText))
						AddParameter(cmd, pNVarChar("SearchText", Uri.UnescapeDataString(filter.SearchText)));

					DataSet dsResult = GetDataSet(cmd);
					return dsResult;
				}
			}
			catch (Exception ex)
			{
				return null;
			}

			
		}
	}
}
