using Common;
using Common.DTOs;
using Common.Services.FileDataParser;
using Common.Services.PriceAdviser;
using ExchangeApp.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoExchangeController : ControllerBase
    {
        public CryptoExchangeController(
            ILogger<CryptoExchangeController> logger,
            IPriceAdviser priceAdviser,
            IFileDataParser fileDataParser,
            IConfiguration configuration)
        {
            Logger = logger;
            PriceAdviser = priceAdviser;
            FileDataParser = fileDataParser;
            Configuration = configuration;
        }

        public ILogger<CryptoExchangeController> Logger { get; set; }

        public IPriceAdviser PriceAdviser { get; set; }

        public IFileDataParser FileDataParser { get; set; }

        public IConfiguration Configuration { get; set; }

        [HttpGet(Name = "GetBestExecutionPlan")]
        public GetBestExecutionPlanResponse Get(decimal amount, OperationTypeEnum operationType)
        {
            try
            {
                var fileName = Configuration[ExchangeAppConstants.ConfigurationKeys.DataFileNameKey];
                var orders = this.FileDataParser.GetDataFromFile(fileName);
                this.PriceAdviser.OrderBook = orders.FirstOrDefault();
            }
            catch
            {
                return new GetBestExecutionPlanResponse()
                {
                    ErrorMsg = "An error occurred while reading data from file"
                };
            }

            return this.PriceAdviser.GetBestExecutionPlan(amount, operationType);
        }
    }
}