using AutoMapper;
using Taxually.TechnicalTest.Domain.Entities;
using Taxually.TechnicalTest.Dtos.In;

namespace Taxually.TechnicalTest.Web.Profiles
{
    public class VatRegistrationProfile : Profile
    {
        public VatRegistrationProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<VatRegistrationInDto, VatRegistration>();
        }
    }
}
