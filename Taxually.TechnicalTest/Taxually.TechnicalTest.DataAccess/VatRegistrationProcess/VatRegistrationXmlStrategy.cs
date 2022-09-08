using System.Xml.Serialization;
using Taxually.TechnicalTest.DataAccess.Clients.Contracts;
using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts;
using Taxually.TechnicalTest.Domain.Entities;

namespace Taxually.TechnicalTest.DataAccess.VatRegistrationProcess
{
    public class VatRegistrationXmlStrategy : IVatRegistrationXmlStrategy
    {
        private readonly ITaxuallyQueueClient taxuallyQueueClient;

        public VatRegistrationXmlStrategy(ITaxuallyQueueClient taxuallyQueueClient)
        {
            this.taxuallyQueueClient = taxuallyQueueClient;
        }

        public async Task RegisterCountryVat(VatRegistration vatRegistration)
        {
            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistration));

                serializer.Serialize(stringwriter, vatRegistration);

                var xml = stringwriter.ToString();

                // I don't like this hardcoded string, but for now I'll leave it here
                await taxuallyQueueClient.EnqueueAsync("vat-registration-xml", xml);
            }
        }
    }
}
