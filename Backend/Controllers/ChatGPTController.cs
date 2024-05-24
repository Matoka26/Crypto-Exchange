using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;

namespace test_binance_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public ChatGPTController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> GetAIBasedResult(string searchText)
        {
            try
            {   
                // Connection key for OpenAI API
                var apiKey = Configuration["ApiKeys:OpenAIKey"];

                string answer = string.Empty;

                var openai = new OpenAIAPI(apiKey);
                CompletionRequest completion = new CompletionRequest();
                
                // Fill Fields for query
                completion.Prompt = searchText;                                      // text to search
                completion.Model = OpenAI_API.Models.Model.ChatGPTTurboInstruct;     // model to ask
                completion.MaxTokens = 2000;                                         // max tokens of a batch(depending on model)

                // Search for result
                var result = await openai.Completions.CreateCompletionsAsync(completion);
                foreach (var item in result.Completions)
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
