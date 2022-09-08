using Taxually.TechnicalTest.Domain.Entities;

namespace Taxually.TechnicalTest.DataAccess
{
    public interface IVatRegistrationRepository
    {
        Task RegisterCountryVat(VatRegistration vatRegistration);
    }
}