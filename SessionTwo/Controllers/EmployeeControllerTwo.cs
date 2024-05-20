using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer;
using Persistence_Layer.Entity.Models;
using Persistence_Layer.Entityt.ViewModel;
using SessionTwo.Repository.Interface;

namespace SessionTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllerTwo : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeControllerTwo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult> addEmployee(EmployeeDTO employee)
        {
            var emp = _mapper.Map<Employee>(employee);
             await _context.employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("GetAllEmployee")]
        public async Task<ActionResult> GetAllEmployee()
        {
            var employees = await _context.employees.ToListAsync();
            var list = _mapper.Map<List<EmployeeDTO>>(employees);
            return Ok(list);
        }

        [HttpPut("EditEmployee")]
        public async Task<ActionResult> EditEmployee(EmployeeDTO model)
        {
            var entity = _mapper.Map<Employee>(model);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpDelete("RemoveEmployee")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
           var delete = _context.employees.FirstOrDefault(x => x.EmployeeId == id);
            _context.employees.Remove(delete);
            await _context.SaveChangesAsync();
           
            return Ok();
        }

    }
}
