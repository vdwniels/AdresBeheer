using AdresbeheerBL.Exceptions;
using AdresbeheerBL.Interfaces;
using AdresbeheerBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Services
{
    public class straatService
    {
        private IStraatRepository repo;

        public straatService(IStraatRepository repo)
        {
            this.repo = repo;
        }

        public List<Straat> GeefStratenGemeente(int gemeenteId)
        {
            try
            {
                return repo.GeefStratenGemeente(gemeenteId);
            }
            catch(Exception ex)
            {
                throw new straatServiceException("GeefStratenGemeente", ex);
            }
        }
    }
}
