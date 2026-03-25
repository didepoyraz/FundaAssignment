using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FundaWeb.Services;
// Constructor Injection: Added the service as a constructor parameter and the runtime
//  will resolve the service from the service container
namespace FundaWeb.Controllers
{
    // The [ApiController] attribute makes model validation
    //  errors automatically trigger an HTTP 400 response. 
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
            try
            {
                var result = await _fundaService.GetTopMakelaars();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet("tuin")]
        public async Task<IActionResult> GetTopMakelaarsWithTuin()
        {
            try
            {
                var result = await _fundaService.GetTopMakelaarsWithTuin();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
    }
}