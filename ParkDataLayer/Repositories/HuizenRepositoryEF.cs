using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private ParkbeheerContext _context;

        public HuizenRepositoryEF(ParkbeheerContext context)
        {
            _context = context;
        }

        public Huis GeefHuis(int id)
        {
            var huisDL =  _context.Huizen
          
            .FirstOrDefault(h => h.Id == id);
            Huis huisBL = MapToDomain.MapHuis(huisDL);
            return huisBL;

         
        }

        

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            ParkEF parkDL = MapFromDomain.MapPark(park);
            return _context.Huizen.Any(h => h.Straat == straat && h.Nr == nummer && h.Park == parkDL);
        }

        public bool HeeftHuis(int id)
        {
            return _context.Huizen.Any(h => h.Id == id);
        }

        public bool HuisHeeftHuurder(int id)
        {
            return _context.HuisHuurders.Any(h => h.HuisEFId == id);
        }
        public void UpdateHuis(Huis huis)
        {
             try
                
             {
                    var existingHuis = _context.Huizen.Find(huis.Id);
                    if (existingHuis != null)
                    {
                     
                        var bestaandPark = _context.Parken.FirstOrDefault(p => p.Id == existingHuis.Park.Id);
                        if(bestaandPark != null)
                        {

                           existingHuis.Park = bestaandPark;
                        }

                        else
                        {
                          existingHuis.Park = MapFromDomain.MapPark(huis.Park);

                        }

                                existingHuis.Park = existingHuis.Park;
                                existingHuis.Park.Naam = huis.Park.Naam;
                                existingHuis.Park.Locatie = huis.Park.Locatie;





                    _context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("Huis not found in the context.");
                    }
                }
                catch (Exception ex)
                {
                    throw ex; // Of een specifiekere foutmelding teruggeven
                }
            }


        public Huis VoegHuisToe(Huis h)
        {
            HuisEF huisDL = MapFromDomain.MapHuis(h);

            // Controleer of het park al bestaat in de database op basis van het ID
            var bestaandPark = _context.Parken.FirstOrDefault(p => p.Id == h.Park.Id);

            if (bestaandPark != null)
            {
                // Gebruik het bestaande park
                huisDL.Park = bestaandPark;
            }
            else
            {
                // Voeg het nieuwe park toe aan het huis als het niet bestaat
                huisDL.Park = MapFromDomain.MapPark(h.Park);
            }

            // Voeg het huis toe aan de context
            _context.Huizen.Add(huisDL);
            _context.SaveChanges();

            // Haal de ID op van het toegevoegde huis vanuit de databasecontext
            h.ZetId(huisDL.Id);

            return h;
        }


    }
}
