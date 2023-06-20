using Common.DTOs;
using ExchangeApp.Enums;

namespace Common.Services.PriceAdviser;

public interface IPriceAdviser
{
    public OrderBookDto? OrderBook { get; set; }

    public GetBestExecutionPlanResponse GetBestExecutionPlan(decimal amount, OperationTypeEnum operationType);
}