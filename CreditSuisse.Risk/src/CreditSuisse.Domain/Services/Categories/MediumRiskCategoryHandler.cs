using CreditSuisse.Domain.Interfaces;

namespace CreditSuisse.Domain.Services.Categories
{
    public class MediumRiskCategoryHandler : ITradeCategoryHandler
    {
        public string CategoryName => "MEDIUMRISK";

        public bool IsMatch(ITrade trade, DateTime referenceDate) =>
            trade.Value > 1_000_000 && trade.ClientSector == "Public" && trade.IsPoliticallyExposed == false;
    }
}

