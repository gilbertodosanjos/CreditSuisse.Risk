using CreditSuisse.Domain.Interfaces;

namespace CreditSuisse.Domain.Services.Categories
{
    public class HighRiskCategoryHandler : ITradeCategoryHandler
    {
        public string CategoryName => "HIGHRISK";

        public bool IsMatch(ITrade trade, DateTime referenceDate) =>
            trade.Value > 1_000_000 && trade.ClientSector == "Private" && trade.IsPoliticallyExposed == false;
    }
}

