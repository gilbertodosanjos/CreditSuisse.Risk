using CreditSuisse.Domain.Interfaces;

namespace CreditSuisse.Domain.Services.Categories
{
    public class PepCategoryHandler : ITradeCategoryHandler
    {
        public string CategoryName => "PEP";

        public bool IsMatch(ITrade trade, DateTime referenceDate) => trade.IsPoliticallyExposed == true;
    }

}


