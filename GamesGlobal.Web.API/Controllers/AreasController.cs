using GamesGlobal.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesGlobal.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreaCalculationService _areaCalculationService;

        public AreasController(IAreaCalculationService areaCalculationService)
        {
            _areaCalculationService = areaCalculationService;
        }

        [HttpPost(Name = "CalculateSurfaceAreaOfWater")]
        public IActionResult Calculate([FromBody] string[][] jaggedArray)
        {
            try
            {
                var result = _areaCalculationService.CalculateArea(jaggedArray);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
