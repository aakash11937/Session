using ApplicationLayer;
using ApplicationLayer.Command;
using ApplicationLayer.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence_Layer.Entity.Models;
using Serilog;

namespace SessionTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpolyeeMediatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmpolyeeMediatorController> _logger;

        public EmpolyeeMediatorController(IMediator mediator, ILogger<EmpolyeeMediatorController> logger)
        {
            _mediator = mediator;
            _logger = logger;

        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateEmployee(AddEmployeeCommand command)
        {
            var employee = await _mediator.Send(command);
            //  _logger.LogInformation("Employee Added by Mediator Successfully !!",employee);
            _logger.LogInformation("Employee Added by Mediator Successfully !! Result: {@employee}", employee);

            return Ok(employee);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var query = new GetEmployeeByIdQuery { EmployeeId = id };
            var empolyee = await _mediator.Send(query);
            _logger.LogInformation("Employee Get by Mediator(id) !!", empolyee);

            if (empolyee == null)
            {
                return NotFound();
            }
            return Ok(empolyee);
        }

        [HttpGet("GetAllEmployee")]
        public async Task<ActionResult> GetAllEmployee()
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery());
            _logger.LogInformation(" GetAll Employee by Mediator(id) !!", employees);
            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var query = new DeleteEmployeeCommand { EmployeeId = id };
            var empolyee = await _mediator.Send(query);
            _logger.LogInformation("Deleted Employee by Mediator(id) !!", query);

            if (empolyee == null)
            {
                return NotFound();
            }
            return Ok(empolyee);
        }







    }
}
