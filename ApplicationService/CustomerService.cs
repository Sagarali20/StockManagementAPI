using Nybsys.DataAccess.Contracts2;
using Nybsys.EntityModels;
using Nybsys.EntityModels.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
	public class CustomerService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CustomerService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;	
		}

		public async Task<bool> InsertCustomer(Customer Customer)
		{
			return await _unitOfWork.CustomerDataAccess.Add(Customer);
		}

		public async Task<bool> UpdateCustomer(Customer Customer)
		{
			return await _unitOfWork.CustomerDataAccess.Update(Customer);
		}
		public async Task<bool> DeleteCustomer(Customer Customer)
		{
			return await _unitOfWork.CustomerDataAccess.Delete(Customer);
		}
        public async Task<Customer?> GetCustomerById(int  id)
        {
            return await _unitOfWork.CustomerDataAccess.GetById(id);
        }

        public  CustomerWithCount  GetAllCustomer(StocFilter stocFilter)
		{ 
			CustomerWithCount customerWithCount = new CustomerWithCount();

			List<Customer> list = new List<Customer>();
			DataSet ds = _unitOfWork.CustomerDataAccess.GetAllCustomerFilter(stocFilter);
            if (ds is not null)
            {
                customerWithCount.Customerlist = (from DataRow dr in ds.Tables[0].Rows
                                                    select new Customer()
                                                    {
                                                        Id = dr["Id"] != DBNull.Value ? Convert.ToInt32(dr["Id"]) : 0,
                                                        FirstName = dr["FirstName"].ToString(),
                                                        LastName = dr["LastName"].ToString(),
                                                        Type = dr["Type"].ToString(),
                                                        PhoneNumber = dr["PhoneNumber"].ToString(),
                                                        Address = dr["Address"].ToString(),
                                                        EmailAddress = dr["EmailAddress"].ToString(),
                                                        JoinDate = Convert.ToDateTime(dr["JoinDate"]),
                                                        IsActive = Convert.ToBoolean(dr["IsActive"]),
                                                        IsWholeSaler = Convert.ToBoolean(dr["IsWholeSaler"]),
                                                        CustomerId = (Guid)dr["CustomerId"]
                                                    }).ToList();
                //equipmentWithCount.Count = ds.Tables[1].Rows[0]["TotalCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[1].Rows[0]["TotalCount"]) : 0;

                customerWithCount.Count = ds.Tables[1].Rows.Count > 0 ?
                                   (int)ds.Tables[1].Rows[0]["TotalCount"] : 0;

            }


            return customerWithCount;

        }


	}
}
