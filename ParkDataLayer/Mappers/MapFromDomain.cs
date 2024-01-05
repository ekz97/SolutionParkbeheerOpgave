using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class MapFromDomain
    {
        public static ParkEF MapPark(Park businessPark)
        {
            try
            {
                return new ParkEF
                {
                    Id = businessPark.Id,
                    Naam = businessPark.Naam,
                    Locatie = businessPark.Locatie
                    
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static HuisEF MapHuis(Huis businessHuis)
        {
            try
            {
                return new HuisEF
                {
                    Id = businessHuis.Id,
                    Straat = businessHuis.Straat,
                    Nr = businessHuis.Nr,
                    Actief = businessHuis.Actief,
                    Park = MapPark(businessHuis.Park)
                 
                    
                    
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static HuurderEF MapHuurder(Huurder businessHuurder)
        {
            try
            {
                return new HuurderEF
                {
                    Id = businessHuurder.Id,
                    Naam = businessHuurder.Naam,
                    Telefoon = businessHuurder.Contactgegevens.Tel,
                    Adres = businessHuurder.Contactgegevens.Adres,
                    Email = businessHuurder.Contactgegevens.Email
                   
                    
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static HuurcontractEF MapHuurcontract(Huurcontract businessHuurcontract)
        {
            try
            {
                return new HuurcontractEF
                {
                    Id = businessHuurcontract.Id,
                    StartDatum = businessHuurcontract.Huurperiode.StartDatum,
                    EindDatum = businessHuurcontract.Huurperiode.EindDatum,
                    AantalDagen = businessHuurcontract.Huurperiode.Aantaldagen,
                    Huis = MapHuis(businessHuurcontract.Huis),
                    HuisId = businessHuurcontract.Huis.Id,

                    Huurder = MapHuurder(businessHuurcontract.Huurder),
                    HuurderId = businessHuurcontract.Huurder.Id
                   
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

  
    }
}
