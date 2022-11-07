using AdresbeheerBL.Model;
using AdresbeheerBL.Services;
using AdresbeheerREST.Exceptions;
using AdresbeheerREST.Model.Output;

namespace AdresbeheerREST.Mappers
{
    public static class MapFromDomain
    {
        public static GemeenteRESToutputDTO MapFromGemeenteDomain(string url,Gemeente gemeente)
        {
            try
            {
                string gemeenteURL = $"{url}/gemeente/{gemeente.NIScode}";
                List<string> straten = straatService.GeefStratenGemeente(gemeente);
            }
            catch(Exception ex)
            {
                throw new MapException("MapFromGemeenteDomain", ex);
            }
        }
    }
}
