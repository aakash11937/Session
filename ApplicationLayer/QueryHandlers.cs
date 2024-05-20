using ApplicationLayer.Query;
using MediatR;
using Persistence_Layer.Entityt.ViewModel;
using SessionTwo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    //public class QueryHandlers
    //{
    //    private readonly IEmployeeServies _employeeService;

    //    public QueryHandlers(IEmployeeServies employeeService)
    //    {
    //        _employeeService = _employeeService;
    //    }

    //}

    // Query Handlers
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {
        private readonly IEmployeeServies _employeeService;

        public GetEmployeeByIdQueryHandler(IEmployeeServies employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeService.GetById(request.EmployeeId);
        }
    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
    {
        private readonly IEmployeeServies _employeeService;

        public GetAllEmployeesQueryHandler(IEmployeeServies employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetAll();
            return employees;
        }
    }

}
