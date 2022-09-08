using Moq;
using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess;
using Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts;
using Xunit;

namespace Taxually.TechnicalTest.Tests.AppLogic.VatRegistrationProcess
{
    public class VatRegistrationFactoryTest
    {
        private readonly Mock<IVatRegistrationFactoryConfiguration> configuration = new Mock<IVatRegistrationFactoryConfiguration>();
        private readonly Mock<IServiceProvider> serviceProvider = new Mock<IServiceProvider>();

        private readonly string gbCountry = "GB";
        private readonly string frCountry = "FR";
        private readonly string deCountry = "DE";

        public VatRegistrationFactoryTest()
        {
            configuration.Setup(x => x.GetStrategyType(gbCountry))
                .Returns(typeof(IVatRegistrationJsonStrategy));
            configuration.Setup(x => x.GetStrategyType(frCountry))
                .Returns(typeof(IVatRegistrationCsvStrategy));
            configuration.Setup(x => x.GetStrategyType(deCountry))
                .Returns(typeof(IVatRegistrationXmlStrategy));

            serviceProvider.Setup(x => x.GetService(typeof(IVatRegistrationJsonStrategy)))
                .Returns(new Mock<IVatRegistrationJsonStrategy>().Object);
            serviceProvider.Setup(x => x.GetService(typeof(IVatRegistrationXmlStrategy)))
                .Returns(new Mock<IVatRegistrationXmlStrategy>().Object);
            serviceProvider.Setup(x => x.GetService(typeof(IVatRegistrationCsvStrategy)))
                .Returns(new Mock<IVatRegistrationCsvStrategy>().Object);
        }

        [Fact]
        public void Factory_ShouldRetrieveRegisteredStrategies_Ok()
        {
            var facory = new VatRegistrationFactory(configuration.Object, serviceProvider.Object);

            var deStrategy = facory.GetStrategy(deCountry);
            var frStrategy = facory.GetStrategy(frCountry);
            var gbStrategy = facory.GetStrategy(gbCountry);

            serviceProvider.Verify(x => x.GetService(typeof(IVatRegistrationJsonStrategy)));
            serviceProvider.Verify(x => x.GetService(typeof(IVatRegistrationXmlStrategy)));
            serviceProvider.Verify(x => x.GetService(typeof(IVatRegistrationCsvStrategy)));

            Assert.True(deStrategy is IVatRegistrationXmlStrategy);
            Assert.True(frStrategy is IVatRegistrationCsvStrategy);
            Assert.True(gbStrategy is IVatRegistrationJsonStrategy);
        }

        [Fact]
        public void Factory_ThrowsErrorForNotRegisteredCountry_Error()
        {
            var facory = new VatRegistrationFactory(configuration.Object, serviceProvider.Object);

            Assert.Throws<Exception>(() => facory.GetStrategy("NotRegisteredCountry"));
        }
    }
}
