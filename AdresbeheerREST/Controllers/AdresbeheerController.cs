using AdresbeheerBL.Model;
using AdresbeheerBL.Services;
using AdresbeheerREST.Mappers;
using AdresbeheerREST.Model.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdresbeheerREST.Controllers
{
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresbeheerController : ControllerBase
    {
        private GemeenteService gemeenteService;

        [HttpGet("{gemeenteId}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int gemeenteId)
        {
            try
            {
                Gemeente gemeente = gemeenteService.GeefGemeente(gemeenteId);
                return Ok(MapFromDomain.MapFromGemeenteDomain(gemeente));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
