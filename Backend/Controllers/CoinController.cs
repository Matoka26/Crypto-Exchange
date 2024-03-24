using Microsoft.AspNetCore.Mvc;
using Binance.Spot;
using Microsoft.AspNetCore.Http.HttpResults;
using test_binance_api.Service.CoinService;
using test_binance_api.Models;

namespace test_binance_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]


    public class CoinController : ControllerBase
    {

        private readonly ICoinService _coinService;

        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;
        }



        [HttpGet("{pair}")]
        public async Task<IActionResult> GetBitcoinPrice(string pair)
        {
            try
            {
                var price = await _coinService.GetLivePrice(pair);
                return Ok(price);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

