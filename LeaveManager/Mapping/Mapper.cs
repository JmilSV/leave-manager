using AutoMapper;
using LeaveManager.Data.Entities;
using LeaveManager.Models;

namespace LeaveManager.Mapping
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
