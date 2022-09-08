namespace Taxually.TechnicalTest.DataAccess.VatRegistrationProcess.Contracts
{
    public interface IVatRegistrationFactory
    {
        IVatRegistrationStrategy GetStrategy(string? country);
    }
}