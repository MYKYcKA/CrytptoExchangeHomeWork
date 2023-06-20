using System.ComponentModel;
using Common.DTOs;
using ExchangeApp.Enums;

namespace Common.Services.PriceAdviser;

public class PriceAdviser : IPriceAdviser
{
    public OrderBookDto OrderBook { get; set; }

    public GetBestExecutionPlanResponse GetBestExecutionPlan(decimal amount, OperationTypeEnum operationType)
    {
        if (operationType == OperationTypeEnum.Unknown)
        {
            throw new InvalidEnumArgumentException();
        }

        var response = new GetBestExecutionPlanResponse();

        if (operationType == OperationTypeEnum.Buy)
        {
            var asks = OrderBook.Asks.OrderBy(x => x.Order.Price);
            response.TotalPrice = 0M;

            foreach (var ask in asks)
            {
                if (amount - ask.Order.Amount > 0)
                {
                    response.ExecutionPlan.Add(new Order
                    {
                        Price = ask.Order.Price,
                        Amount = ask.Order.Amount,
                    });
                    response.TotalPrice += ask.Order.Price * ask.Order.Amount;
                }
                else
                {
                    response.ExecutionPlan.Add(new Order
                    {
                        Price = ask.Order.Price,
                        Amount = ask.Order.Amount,
                    });
                    response.TotalPrice += ask.Order.Price * amount;
                    return response;
                }
            }
        }

        if (operationType == OperationTypeEnum.Sell)
        {
            var bids = OrderBook.Bids.OrderByDescending(x => x.Order.Price);
            response.TotalPrice = 0M;

            foreach (var ask in bids)
            {
                if (amount - ask.Order.Amount > 0)
                {
                    response.ExecutionPlan.Add(new Order
                    {
                        Price = ask.Order.Price,
                        Amount = ask.Order.Amount,
                    });
                    response.TotalPrice += ask.Order.Price * ask.Order.Amount;
                }
                else
                {
                    response.ExecutionPlan.Add(new Order
                    {
                        Price = ask.Order.Price,
                        Amount = ask.Order.Amount,
                    });
                    return response;
                }
            }
        }

        return response;
    }
}