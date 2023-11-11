using AutoMapper;
using BusinessObject.DTOs;
using BusinessObject.Models;

namespace BusinessObject.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<JobSeeker, JobSeekerDTO>().ReverseMap();
            CreateMap<JobSeeker, JobSeekerRegisterDTO>().ReverseMap();
            CreateMap<Employer, EmployerDTO>().ReverseMap();
            CreateMap<Employer, EmployerRegisterDTO>().ReverseMap();
        }
    }
}