using CreditSuisse.Domain.Interfaces;

namespace CreditSuisse.Domain.Services
{
    public class TradeCategorizerService
    {
        private readonly IEnumerable<ITradeCategoryHandler> _categoryHandlers;

        public TradeCategorizerService(IEnumerable<ITradeCategoryHandler> categoryHandlers)
        {
            _categoryHandlers = categoryHandlers;
        }

        public string Categorize(ITrade trade, DateTime referenceDate)
        {
            foreach (var handler in _categoryHandlers)
            {
                if (handler.IsMatch(trade, referenceDate))
                {
                    return handler.CategoryName;
                }
            }

            return "UNCATEGORIZED"; 
        }
    }
}
