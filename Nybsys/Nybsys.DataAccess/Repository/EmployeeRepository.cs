using DatabaseContext;
using Nybsys.DataAccess.Contracts;
using Nybsys.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

       // NybsysDbContext _db = new NybsysDbContext();
        private readonly NybsysDbContext _db;
        public EmployeeRepository(NybsysDbContext nybsysDbContext)
        {
            _db = nybsysDbContext;
        }
        EmployeeRepository()
        {

        }
        public bool Create(Employee employee)
        {
            _db.Employees.Add(employee);
            return Save();
        }
        public bool Update(Employee employee)
        {
            _db.Employees.Update(employee);
            return Save();
        }
        public bool Delete(Employee employee)
        {
            _db.Employees.Remove(employee);
            return Save();
        }
        public Employee GetById(int id)
        {
            var employee = _db.Employees.Find(id);
            return employee;
        }
        public bool Save()
        {         
            return _db.SaveChanges() > 0;
        }
        public ICollection<Employee> GetAll()
        {
            return _db.Employees.ToList();
        }
    }
}
