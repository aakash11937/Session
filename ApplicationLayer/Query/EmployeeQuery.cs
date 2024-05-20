using MediatR;
using Persistence_Layer.Entityt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Query
{
    public class EmployeeQuery
    {

    }

    public class GetEmployeeByIdQuery : IRequest<EmployeeDTO>
    {
        public int EmployeeId { get; set; }
    }

    public class GetAllEmployeesQuery : IRequest<List<EmployeeDTO>>
    {

    }
    
}
