using ApplicationLayer.Command;
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
    public class CommandHandlers
    {
    }

    // Command Handlers
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeDTO>
    {
        private readonly IEmployeeServies _employeeService;

        public AddEmployeeCommandHandler(IEmployeeServies employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<EmployeeDTO> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = new EmployeeDTO { Name = request.Name, Salary = request.Salary };
            return await _employeeService.AddAsync(model);
        }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeServies _employeeService;

        public UpdateEmployeeCommandHandler(IEmployeeServies employeeService)
        {
            _employeeService = employeeService;
        }



        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var model = new EmployeeDTO { EmployeeId = request.EmployeeId, Name = request.Name, Salary = request.Salary };
            await _employeeService.UpdateAsync(model);
            return model.EmployeeId;
        }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeServies _employeeService;

        public DeleteEmployeeCommandHandler(IEmployeeServies employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeService.DeleteAsync(request.EmployeeId);
            return request.EmployeeId;
        }

    }


}
