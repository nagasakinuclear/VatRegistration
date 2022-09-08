using Taxually.TechnicalTest.Domain.Entities;

namespace Taxually.TechnicalTest.AppLogic
{
    public interface IVatRegistrationService
    {
        Task RegisterCountryVat(VatRegistration vatRegistration);
    }
}