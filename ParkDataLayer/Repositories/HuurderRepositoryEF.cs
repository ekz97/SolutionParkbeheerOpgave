using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private ParkbeheerContext _context;

        public HuurderRepositoryEF(ParkbeheerContext context)
        {
            _context = context;
        }

        public Huurder GeefHuurder(int id)
        {
            var huurderEF = _context.Huurders.FirstOrDefault(h => h.Id == id);
            return MapToDomain.MapHuurder(huurderEF);
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            List<HuurderEF> huurderEFs;

            if (string.IsNullOrEmpty(naam))
            {
                huurderEFs = _context.Huurders.ToList();
            }
            else
            {
                huurderEFs = _context.Huurders.Where(h => h.Naam == naam).ToList();
            }

            var huurders = huurderEFs.Select(MapToDomain.MapHuurder).ToList();
            return huurders;
        }


        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            return _context.Huurders.Any(h => h.Naam == naam || h.Telefoon == contact.Tel || h.Email == contact.Email || h.Adres == contact.Adres);
        }

        public bool HeeftHuurder(int id)
        {
            return _context.Huurders.Any(h => h.Id == id);
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                var existingHuurder = _context.Huurders.Find(huurder.Id);
                if (existingHuurder != null)
                {
                    _context.Entry(existingHuurder).State = EntityState.Detached; // Ontkoppel de bestaande entiteit

                    HuurderEF huurderEf = MapFromDomain.MapHuurder(huurder);
                    _context.Huurders.Update(huurderEf);
                    _context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Huurder not found in the context.");
                }
            }
            catch (Exception ex)
            {
                throw ex; // Of een specifiekere foutmelding teruggeven
            }
        }



        public Huurder VoegHuurderToe(Huurder huurder)
        {
            HuurderEF huurderEf = MapFromDomain.MapHuurder(huurder);
            _context.Huurders.Add(huurderEf);
            _context.SaveChanges();
            return huurder;
        }
    }
}
