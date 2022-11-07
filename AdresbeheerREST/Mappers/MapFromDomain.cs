using AdresbeheerBL.Model;
using AdresbeheerBL.Services;
using AdresbeheerREST.Exceptions;
using AdresbeheerREST.Model.Output;

namespace AdresbeheerREST.Mappers
{
    public static class MapFromDomain
    {
        public static GemeenteRESToutputDTO MapFromGemeenteDomain(string url,Gemeente gemeente, straatService straatService)
        {
            try
            {
                string gemeenteURL = $"{url}/gemeente/{gemeente.NIScode}";
                List<string> straten = straatService.GeefStratenGemeente(gemeente.NIScode).Select(x => gemeenteURL + $"/straat/{x.Id}").ToList();
                GemeenteRESToutputDTO dto = new GemeenteRESToutputDTO(gemeenteURL,gemeente.NIScode,gemeente.Gemeentenaam,straten.Count(),straten);
                return dto;
            }
            catch(Exception ex)
            {
                throw new MapException("MapFromGemeenteDomain", ex);
            }
        }
    }
}
