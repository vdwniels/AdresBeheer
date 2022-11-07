using AdresbeheerBL.Model;
using AdresbeheerREST.Exceptions;
using AdresbeheerREST.Model.Input;

namespace AdresbeheerREST.Mappers
{
    public static class MapToDomain
    {
        public static Gemeente MapToGemeenteDomain(GemeenteRESTInputDTO dto)
        {
            try
            {
                Gemeente gemeente = new Gemeente(dto.NIScode, dto.Naam);
                return gemeente;
            }
            catch (Exception ex)
            {
                throw new MapException("MapToGemeenteDomain", ex);
            }
        }
    }
}
