using AdresbeheerBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Model
{
    public class Straat
    {
        public Straat(int id, string straatNaam, Gemeente gemeente)
        {
            ZetID(id);
            ZetStraatNaam(straatNaam);
            ZetGemeente(gemeente);  
        }

        public int Id { get; private set; }
        public string StraatNaam { get; private  set; }
        public Gemeente Gemeente { get; private  set; }

        public void ZetStraatNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                StraatException ex = new StraatException("ZetStraatNaam - naam niet correct");
                ex.Data.Add("straatnaam", naam);
                throw ex;
            }
            StraatNaam = naam;
        }
        public void ZetID(int id)
        {
            if(id <= 0)
            {
                StraatException ex = new StraatException("ZetId - id niet correct");
                ex.Data.Add("id", id);
                throw ex;
            }
            Id = id;
        }
        public void ZetGemeente(Gemeente nieuwegemeente)
        {
            if (nieuwegemeente == null) throw new StraatException("ZetGemeente - null");
            if (nieuwegemeente == Gemeente) throw new StraatException("ZetGemeente - niet nieuw");
            Gemeente = nieuwegemeente;
        }
        public override string ToString()
        {
            return $"Id : {Id} - StraatNaam : {StraatNaam} - NIScode : {Gemeente.NIScode} - gemeenteNaam : {Gemeente.Gemeentenaam}";
        }
    }
}
