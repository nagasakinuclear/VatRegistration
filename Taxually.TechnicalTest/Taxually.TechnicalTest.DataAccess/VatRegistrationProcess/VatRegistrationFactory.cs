using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts;

namespace Taxually.TechnicalTest.DataAccess.VatRegistrationProcess
{
    public class VatRegistrationFactory : IVatRegistrationFactory
    {
        private readonly IVatRegistrationFactoryConfiguration vatRegistrationFactoryConfiguration;
        private readonly IServiceProvider serviceProvider;

        public VatRegistrationFactory(IVatRegistrationFactoryConfiguration vatRegistrationFactoryConfiguration, IServiceProvider serviceProvider)
        {
            this.vatRegistrationFactoryConfiguration = vatRegistrationFactoryConfiguration;
            this.serviceProvider = serviceProvider;
        }

        public IVatRegistrationStrategy GetStrategy(string? country)
        {
            var strategyType = vatRegistrationFactoryConfiguration.GetStrategyType(country);
            var strategy = serviceProvider.GetService(strategyType) as IVatRegistrationStrategy;

            if (strategy == null)
            {
                throw new Exception($"Strategy was not registered for country {country}");
            }

            return strategy;
        }
    }
}
