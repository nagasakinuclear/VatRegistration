using System.Text;
using Taxually.TechnicalTest.DataAccess.Clients.Contracts;
using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts;
using Taxually.TechnicalTest.Domain.Entities;

namespace Taxually.TechnicalTest.DataAccess.VatRegistrationProcess
{
    public class VatRegistrationCsvStrategy : IVatRegistrationCsvStrategy
    {
        private readonly ITaxuallyQueueClient taxuallyQueueClient;

        public VatRegistrationCsvStrategy(ITaxuallyQueueClient taxuallyQueueClient)
        {
            this.taxuallyQueueClient = taxuallyQueueClient;
        }

        public async Task RegisterCountryVat(VatRegistration vatRegistration)
        {
            var csvBuilder = new StringBuilder();

            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{vatRegistration.CompanyName}{vatRegistration.CompanyId}");

            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());

            // I don't like this hardcoded string, but for now I'll leave it here
            await taxuallyQueueClient.EnqueueAsync("vat-registration-csv", csv);
        }
    }
}
