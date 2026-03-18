using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundaWeb.Controllers
{
    [ApiController]
    [Route("api/makelaars")]
    public class MakelaarsController: ControllerBase
    {
        private readonly IFundaService _fundaService;

        public MakelaarsController(IFundaService fundaService)
        {
            _fundaService = fundaService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTopMakelaars()
        {
            var result = await _fundaService.GetTopMakelaars();
            return Ok(result);
        }

        // Top makelaars with a tuin 
        [HttpGet("tuin")]
        public async Task<IActionResult> GetTopMakelaarsWithGarden()
        {
            var result = await _fundaService.GetTopMakelaarsWithGarden();
            return Ok(result);
        }
    }
}