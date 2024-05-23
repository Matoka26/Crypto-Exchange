using Microsoft.AspNetCore.Mvc;
using Binance.Spot;
using Microsoft.AspNetCore.Http.HttpResults;
using test_binance_api.Service.CoinService;
using test_binance_api.Models;
using System.ComponentModel;
using System.Reflection;

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

        [HttpGet("LivePrice/{pair}")]
        public async Task<IActionResult> GetLivePrice(string pair)
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

        [HttpGet("PreviousPrice/{pair}/{day}/{month}/{year}")]
        public async Task<IActionResult> GetHistoricalPrice(string pair, int day, int month, int year)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                var price = await _coinService.GetHistoricalPrice(pair, date);
                return Ok(price);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("PreviousPrices/{pair}/{day}/{month}/{year}/{offset}")]
        public async Task<IActionResult> GetPreviousPrices(string pair, int day, int month, int year, int offset)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                var prices = await _coinService.GetPreviousPrices(pair, date, offset);
                return Ok(prices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CalculateRSIs/{pair}/{offset}/{amount}")]
        public async Task<IActionResult> CalculateLastRSIs(string pair, int offset, int amount)
        {
            try
            {
                var values = await _coinService.CalculateLastRSIs(pair, offset, amount);
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

