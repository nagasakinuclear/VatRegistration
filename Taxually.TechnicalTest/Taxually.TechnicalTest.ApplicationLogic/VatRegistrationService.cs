using Taxually.TechnicalTest.DataAccess;
using Taxually.TechnicalTest.Domain.Entities;

namespace Taxually.TechnicalTest.AppLogic
{
    public class VatRegistrationService : IVatRegistrationService
    {
        private readonly IVatRegistrationRepository vatRegistrationRepository;

        public VatRegistrationService(IVatRegistrationRepository vatRegistrationRepository)
        {
            this.vatRegistrationRepository = vatRegistrationRepository;
        }

        public async Task RegisterCountryVat(VatRegistration vatRegistration)
        {
            await vatRegistrationRepository.RegisterCountryVat(vatRegistration);
        }
    }
}
