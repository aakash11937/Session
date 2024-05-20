using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence_Layer.Entityt.ViewModel;
using SessionTwo.Repository.Interface;

namespace SessionTwo.Controllers
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllerUpdated : ControllerBase
    {
        private readonly IEmployeeServies _services;

        public EmployeeControllerUpdated(IEmployeeServies services, IMapper mapper)
        {
            _services = services;
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult> addEmployee(EmployeeDTO employee)
        {
            var emp = await _services.AddAsync(employee);
            return Ok();
        }

        [HttpGet("GetAllEmployee")]
        public async Task<ActionResult> GetAllEmployee()
        {
            var employees = await _services.GetAll();

            return Ok(employees);
        }

        [HttpPut("EditEmployee")]
        public async Task<ActionResult> EditEmployee(EmployeeDTO model)
        {
            await _services.UpdateAsync(model);
            return Ok(model);
        }

        //[HttpDelete("RemoveEmployee")]
        //public async Task<ActionResult> DeleteEmployee(int id)
        //{
        //    await _services.DeleteAsync(id);
        //    return Ok();
        //}

    }
}

