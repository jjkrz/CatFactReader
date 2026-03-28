using CatFactReaderApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatFactReaderApi.Controllers
{
    [ApiController]
    [Route("cat-facts")]
    public class CatFactController : ControllerBase
    {
        private readonly ICatFactService _catFactService;
        private readonly IFileService _fileService;
        private readonly ILogger<CatFactController> _logger;

        public CatFactController(ICatFactService catFact, IFileService fileService, ILogger<CatFactController> logger)
        {
            _catFactService = catFact;
            _fileService = fileService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostCatFact()
        {
            try
            {
                var catFact = await _catFactService.GetCatFactAsync();
                await _fileService.AppendLineAsync(catFact);

                return Ok(catFact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the cat fact.");

                return StatusCode(500, ex.Message);
            }
        }
    }
}
