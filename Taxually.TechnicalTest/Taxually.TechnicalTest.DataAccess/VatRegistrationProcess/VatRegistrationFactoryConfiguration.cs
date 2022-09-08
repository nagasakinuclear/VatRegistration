using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts;

namespace Taxually.TechnicalTest.DataAccess.VatRegistrationProcess
{
    public class VatRegistrationFactoryConfiguration : IVatRegistrationFactoryConfiguration
    {
        private readonly Dictionary<string, Type> vatStrategyConfigurations = new Dictionary<string, Type>();

        public VatRegistrationFactoryConfiguration(Dictionary<string, Type> vatStrategyConfigurations)
        {
            this.vatStrategyConfigurations = vatStrategyConfigurations;
        }

        public Type GetStrategyType(string? country)
        {
            if (country == null)
            {
                throw new Exception("Country was not provided");
            }

            if (!vatStrategyConfigurations.ContainsKey(country))
            {
                throw new Exception("Country is not supported");
            }

            return vatStrategyConfigurations[country];
        }
    }
}
