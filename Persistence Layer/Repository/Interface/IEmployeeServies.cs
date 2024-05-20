
using Persistence_Layer.Entityt.ViewModel;

namespace SessionTwo.Repository.Interface
{
    public interface IEmployeeServies
    {
        Task<EmployeeDTO> GetById(int id);

        Task<EmployeeDTO> AddAsync(EmployeeDTO Entity);

        Task UpdateAsync(EmployeeDTO Entity);

        Task DeleteAsync(int id);

        Task<List<EmployeeDTO>> GetAll();

    }
}

