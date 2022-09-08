using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts;
using Taxually.TechnicalTest.Domain.Entities;

namespace Taxually.TechnicalTest.DataAccess
{
    public class VatRegistrationRepository : IVatRegistrationRepository
    {
        private readonly IVatRegistrationFactory vatRegistrationFactory;

        public VatRegistrationRepository(IVatRegistrationFactory vatRegistrationFactory)
        {
            this.vatRegistrationFactory = vatRegistrationFactory;
        }

        public async Task RegisterCountryVat(VatRegistration vatRegistration)
        {
            var strategy = vatRegistrationFactory.GetStrategy(vatRegistration.Country);

            await strategy.RegisterCountryVat(vatRegistration);
        }
    }
}
