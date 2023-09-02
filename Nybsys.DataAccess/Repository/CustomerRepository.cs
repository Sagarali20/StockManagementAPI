using DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nybsys.DataAccess.Contract;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nybsys.DataAccess.Repository
{
	public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(NybsysDbContext dbContext, ILogger logger) : base(dbContext, logger)
		{

		}
		public override async Task<Customer?> GetById(int id)
		{
			return await _dbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}

        public DataSet GetAllCustomerFilter(StocFilter filter)
        {
            string sqlQuery = @"declare @pagestart int
                                declare @pageend int
                                set @pagestart=(@pageno-1)* @pagesize 
                                set @pageend = @pagesize
                                select ct.Id  into #CustomersFilter from Customers ct								
								where  ct.Id is not null {0}
								SELECT TOP (@pagesize)
                                *  Into #CustomersResultData
                                FROM  #CustomersFilter
                                where Id NOT IN(Select TOP (@pagestart) Id from #CustomersFilter #cd order by #cd.Id desc)
							    order by Id desc    
								select ct.*
                                from #CustomersResultData crd
								LEFT JOIN Customers ct on ct.Id = crd.Id
                                where crd.Id IS NOT NULL {0}             
								select count(*) [TotalCount]
                                from #CustomersResultData
								Drop table #CustomersFilter
								drop table #CustomersResultData";

            string sqlSubQuery = "";

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                filter.SearchText = HttpUtility.UrlDecode(filter.SearchText);
                sqlSubQuery += " AND CHARINDEX(@SearchText,ct.SearchText) > 0";
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
