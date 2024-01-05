using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class MapToDomain
    {
        public static Park MapPark(ParkEF dataPark)
        {
            try
            {
                return new Park(dataPark.Id, dataPark.Naam, dataPark.Locatie);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Huis MapHuis(HuisEF dataHuis)
        {
            try
            {
                if (dataHuis == null)
                    return null; // Of een default waarde voor een niet-bestaand huis

                if (dataHuis.ParkId == null)
                    throw new Exception("Park is vereist voor een huis.");

                var park = MapPark(dataHuis.Park); 

                var huurcontracten = new Dictionary<Huurder, List<Huurcontract>>();

                
                return new Huis(dataHuis.Id, dataHuis.Straat, dataHuis.Nr, dataHuis.Actief, park, huurcontracten);
            }
            catch (Exception)
            {
                throw;
            }

        
        }






        public static Huurder MapHuurder(HuurderEF dataHuurder)
        {
            try
            {
                return new Huurder(dataHuurder.Id, dataHuurder.Naam, new Contactgegevens(dataHuurder.Email, dataHuurder.Telefoon, dataHuurder.Adres));
             
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Huurcontract MapHuurcontract(HuurcontractEF dataHuurcontract)
        {
            try
            {
                return new Huurcontract(dataHuurcontract.Id, new Huurperiode(dataHuurcontract.StartDatum, dataHuurcontract.AantalDagen), MapHuurder(dataHuurcontract.Huurder),MapHuis(dataHuurcontract.Huis));
              
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
