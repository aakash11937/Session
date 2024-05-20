using AutoMapper;
using Persistence_Layer.Entity.Models;
using Persistence_Layer.Entityt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_Layer.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile() 
        { 
            CreateMap<Employee,EmployeeDTO>().ReverseMap();
        }

    }
}
