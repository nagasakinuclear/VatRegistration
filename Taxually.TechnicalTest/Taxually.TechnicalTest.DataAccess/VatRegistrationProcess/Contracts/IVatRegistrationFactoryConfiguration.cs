namespace Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts
{
    public interface IVatRegistrationFactoryConfiguration
    {
        Type GetStrategyType(string? country);
    }
}