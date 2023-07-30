using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nybsys.Api.Utils;
using Nybsys.DataAccess.Contracts;
using Nybsys.DataAccess.Repository;
using Nybsys.EntityModels;

namespace Nybsys.Api.Controllers
{
    //[Route("api/[controller]/Action")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private IEmployeeRepository _EmployeeRepository;
        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }
        [HttpPost]
        [Route(LabelHelper.NybsysApiHelper.SaveEmployee)]
        public JsonResult AddEmployee([FromBody] Employee employee)
        {
            bool result = false;
            string Message = "";
            employee.CreatedDate = DateTime.Now;
            try
            {
                result = _EmployeeRepository.Create(employee);
                return new JsonResult(new { result = result,Message="Save successfully" });
            }
            catch(Exception ex)
            {
              return new JsonResult(new {result=false,ex.Message});
            }
               
        }

        [HttpPost]
        [Route(LabelHelper.NybsysApiHelper.UpdateEmployee)]
        public JsonResult UpdateEmployee([FromBody] Employee employee)
        {
            bool result = false;
            string Message = "";
            try
            {
                result = _EmployeeRepository.Update(employee);
                return new JsonResult(new { result = result,model=employee,Message="Update successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }
        }
        [HttpGet]
        [Route(LabelHelper.NybsysApiHelper.GetByEmployeeId)]
        public JsonResult GetByEmployeeId(int id)
        {
            Employee Model = new Employee();
            bool result = false;
            string Message = "";
            try
            {
                Model = _EmployeeRepository.GetById(id);          
                return new JsonResult(new { result = true,model=Model });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }

        }
        [HttpGet]
        [Route(LabelHelper.NybsysApiHelper.GetAllEmployee)]
        public JsonResult GetAllEmployee()
        {
           List<Employee> employees = new List<Employee>();
            bool result = false;
            string Message = "";
            try
            {
                employees = _EmployeeRepository.GetAll().ToList();
                return new JsonResult(new { result = true, list = employees });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { result = false, ex.Message });
            }

        }
        [HttpPost]
        [Route(LabelHelper.NybsysApiHelper.DeleteEmployee)]
        public JsonResult DeleteEmployee(int id)
        {
            Employee employee = new Employee();
            bool result = false;
            string Message = "";
                try
                {
                        employee.Id= id;
                        result = _EmployeeRepository.Delete(employee);
                        return new JsonResult(new { result = result, Message = "Delete successfully" });
              
                }
                catch (Exception ex)
                {
                    return new JsonResult(new { result = false, ex.Message });
                }
            
        }
    }
}
