using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer;
using Persistence_Layer.Entity.Models;
using Persistence_Layer.Entityt.ViewModel;
using SessionTwo.Repository.Interface;

namespace SessionTwo.Repository.Implimentaion
{
    public class EmployeeServies : IEmployeeServies
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeServies(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> GetById(int id)
        {
            var entity = await _context.employees.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();
            return _mapper.Map<EmployeeDTO>(entity);
        }

        public async Task<EmployeeDTO> AddAsync(EmployeeDTO model)
        {
            var entity = _mapper.Map<Employee>(model);
            await _context.employees.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(entity);

        }

        public async Task UpdateAsync(EmployeeDTO model)
        {
            var entity = _mapper.Map<Employee>(model);
            //_context.employees.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var delete = _context.employees.FirstOrDefault(x => x.EmployeeId == id);
            _context.employees.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeDTO>> GetAll()
        {
            var entity = await _context.employees.ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(entity);
        }
    }
}

