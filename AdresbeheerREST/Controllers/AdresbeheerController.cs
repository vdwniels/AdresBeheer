using AdresbeheerBL.Model;
using AdresbeheerBL.Services;
using AdresbeheerREST.Mappers;
using AdresbeheerREST.Model.Input;
using AdresbeheerREST.Model.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdresbeheerREST.Controllers
{
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresbeheerController : ControllerBase
    {
        private string hostURL= @"http://localhost:5013/api/adresbeheer";
        private GemeenteService gemeenteService;
        private straatService straatservice;

        public AdresbeheerController(GemeenteService gemeenteService, straatService straatservice)
        {
            this.gemeenteService = gemeenteService;
            this.straatservice = straatservice;
        }

        [HttpGet("{gemeenteId}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int gemeenteId)
        {
            try
            {
                Gemeente gemeente = gemeenteService.GeefGemeente(gemeenteId);
                return Ok(MapFromDomain.MapFromGemeenteDomain(hostURL,gemeente,straatservice));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<GemeenteRESTInputDTO> PostGemeente([FromBody] GemeenteRESTInputDTO restDTO)
        {
            try
            {
                Gemeente gemeente = gemeenteService.VoegGemeenteToe(MapToDomain.MapToGemeenteDomain(restDTO));
                return CreatedAtAction(nameof(GetGemeente), new { gemeenteId = gemeente.NIScode }, MapFromDomain.MapFromGemeenteDomain(hostURL, gemeente, straatservice));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
