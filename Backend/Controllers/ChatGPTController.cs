using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;

namespace test_binance_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetAIBasedResult(string searchText)
        {
            try
            {   
                // Connection key for OpenAI API
                string APIkey = "sk-proj-7BKYGDME92LvGdCmqo2fT3BlbkFJ1G5wLUQSiOyjww1ECxt7";
                string answer = string.Empty;

                var openai = new OpenAIAPI(APIkey);
                CompletionRequest completion = new CompletionRequest();
                
                // Fill Fields for query
                completion.Prompt = searchText;                         // text to search
                completion.Model = OpenAI_API.Models.Model.DavinciText; // model to ask
                completion.MaxTokens = 200;                             // max size to complete to

                // Search for result
                var result = openai.Completions.CreateCompletionsAsync(completion);
                foreach (var item in result.Result.Completions)
                {
                    answer += item.Text;
                }

                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
