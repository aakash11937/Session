using MediatR;
using Persistence_Layer.Entityt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Command
{
    public class EmployeeCommand
    {

    }


    // Commands
    public class AddEmployeeCommand : IRequest<EmployeeDTO>
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int EmployeeId { get; set; }
    }


}
