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
    public class GemeenteService
    {
        private IGemeenteRepository repo;

        public GemeenteService(IGemeenteRepository repo)
        {
            this.repo = repo;
        }

        public Gemeente GeefGemeente(int gemeenteId)
        {
            try
            {
                return repo.GeefGemeente(gemeenteId);
            }
            catch (Exception ex)
            {
                throw new GemeenteServiceException("GeefGemeente", ex);
            }
        }
        public Gemeente VoegGemeenteToe(Gemeente gemeente)
        {
            try
            {
                if (gemeente == null) throw new GemeenteServiceException("VoegGemeenteToe - gemeente is null");
                if (repo.HeeftGemeente(gemeente.NIScode)) throw new GemeenteServiceException("VoegGemeenteToe - gemeente bestaat al");
                repo.VoegGemeenteToe(gemeente);
                return gemeente;
            }
            catch(Exception ex)
            {
                throw new GemeenteServiceException("VoegGemeenteToe", ex);
            }
        }
    }
}
