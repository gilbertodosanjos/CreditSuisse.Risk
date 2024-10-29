using CreditSuisse.Domain.Interfaces;

namespace CreditSuisse.Domain.Services.Categories
{
    public class ExpiredCategoryHandler : ITradeCategoryHandler
    {
        public string CategoryName => "EXPIRED";

        public bool IsMatch(ITrade trade, DateTime referenceDate) =>
            (referenceDate - trade.NextPaymentDate).TotalDays > 30 && trade.IsPoliticallyExposed == false;
    }
}

