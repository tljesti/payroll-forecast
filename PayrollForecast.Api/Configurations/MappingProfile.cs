using AutoMapper;
using PayrollForecast.Api.BusinessModels;
using PayrollForecast.Api.Dtos;
using PayrollForecast.Api.Entities;

namespace PayrollForecast.Api.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Dependent, DependentDto>().ReverseMap();

            // Entity to Business Model
            CreateMap<Employee, EmployeeBusinessModel>();
            CreateMap<Employee, EmployeeWithYearlyPaymentBusinessModel>();
            CreateMap<Employee, EmployeeWithYearlyPaymentAndSummaryBusinessModel>();

            // Business Model to DTO
            CreateMap<DeductionBusinessModel, DeductionDto>()
                .ForMember(d => d.Label, o => o.MapFrom(s => s.Type))
                .ForMember(d => d.IsDiscounted, o => o.MapFrom(s => s.Discount > 0M))
                .ForMember(d => d.Value, o => o.MapFrom(s => s.TotalCost));
            CreateMap<EmployeeWithYearlyPaymentBusinessModel, EmployeeWithYearlyPaymentDto>();
            CreateMap<EmployeeWithYearlyPaymentAndSummaryBusinessModel, EmployeeWithYearlyPaymentAndSummaryDto>();
        }
    }
}
