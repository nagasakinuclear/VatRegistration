using Taxually.TechnicalTest.Domain.Entities;

namespace Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts
{
    public interface IVatRegistrationStrategy
    {
        public Task RegisterCountryVat(VatRegistration vatRegistration);
    }
}
