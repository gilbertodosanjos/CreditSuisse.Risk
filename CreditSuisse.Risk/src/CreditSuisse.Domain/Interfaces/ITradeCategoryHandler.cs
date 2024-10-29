namespace CreditSuisse.Domain.Interfaces
{
    public interface ITradeCategoryHandler
    {
        string CategoryName { get; }
        bool IsMatch(ITrade trade, DateTime referenceDate);
    }
}