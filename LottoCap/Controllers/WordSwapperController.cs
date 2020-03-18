using LottoCap.Models;
using Microsoft.AspNetCore.Mvc;

namespace LottoCap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordSwapperController : ControllerBase
    {
        private readonly IWordSwapper WordSwapper;

        public WordSwapperController(IWordSwapper wordSwapper)
        {
            WordSwapper = wordSwapper;
        }

        [HttpPost]
        public ActionResult<WordSwapperModelResponse> Post(WordSwapperModelRequest requestModel)
        {
            var responseModel = WordSwapper.TransformWords(requestModel);
            return Ok(responseModel);
        }
    }
}
