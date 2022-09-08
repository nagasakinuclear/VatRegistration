using Taxually.TechnicalTest.DataAccess.Clients.Contracts;
using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts;
using Taxually.TechnicalTest.Domain.Entities;

namespace Taxually.TechnicalTest.DataAccess.VatRegistrationProcess
{
    public class VatRegistrationJsonStrategy : IVatRegistrationJsonStrategy
    {
        private readonly ITaxuallyHttpClient taxuallyHttpClient;

        public VatRegistrationJsonStrategy(ITaxuallyHttpClient taxuallyHttpClient)
        {
            this.taxuallyHttpClient = taxuallyHttpClient;
        }

        public async Task RegisterCountryVat(VatRegistration vatRegistration)
        {
            await taxuallyHttpClient.PostAsync("https://api.uktax.gov.uk", vatRegistration);
        }
    }
}
