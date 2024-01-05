using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private ParkbeheerContext _context;

        public ContractenRepositoryEF(ParkbeheerContext context)
        {
            _context = context;
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            // Voorbeeld: Contract annuleren
            var contractEF = _context.Huurcontracten.Where(c => c.Id == contract.Id).FirstOrDefault();
          
            _context.Huurcontracten.Remove(contractEF);
            _context.SaveChanges();
        }

        public Huurcontract GeefContract(string id)
        {
            try
            {
                var contract = _context.Huurcontracten
                                    .Where(x => x.Id == id).FirstOrDefault();

                if (contract != null)
                {
                    return MapToDomain.MapHuurcontract(contract);
                }
                else
                {
                   
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            try
            {
                IQueryable<HuurcontractEF> huurcontracts = null;

                if (dtEinde.HasValue)
                {
                    huurcontracts = _context.Huurcontracten
                        .Include(c => c.Huurder)
                        .Include(c => c.Huis)
                        .Where(x => x.StartDatum >= dtBegin && x.EindDatum <= dtEinde);
                }
                else
                {
                    huurcontracts = _context.Huurcontracten
                        .Include(c => c.Huurder)
                        .Include(c => c.Huis)
                        .Where(x => x.StartDatum >= dtBegin);
                }

                List<HuurcontractEF> contracts = huurcontracts.ToList();
                List<Huurcontract> mappedContracts = new List<Huurcontract>();

                foreach (var contractEF in contracts)
                {
                    Huurcontract contract = MapToDomain.MapHuurcontract(contractEF);
                    mappedContracts.Add(contract);
                }

                return mappedContracts;
            }
            catch (Exception ex)
            {
                throw new Exception("Er is een fout opgetreden bij het ophalen van contracten.", ex);
            }
        }







        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return _context.Huurcontracten
                    .Any(c => c.StartDatum == startDatum && c.Huurder.Id == huurderid && c.Huis.Id == huisid);
            }
            catch (Exception ex)
            {
     
                throw ex; 
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return _context.Huurcontracten.Any(c => c.Id == id);
            }
            catch (Exception ex)
            {
               
                throw ex; 
            }
        }

      public void UpdateContract(Huurcontract contract)
      {
             try
             {
                    HuurcontractEF huurcontractEF = MapFromDomain.MapHuurcontract(contract);
        
                    // Zoek het bijgehouden exemplaar van het contract in de context
                    var trackedContract = _context.Huurcontracten.Find(huurcontractEF.Id);
                    if (trackedContract != null)
                    {
                        // Update alleen de eigenschappen van het bijgehouden exemplaar
                        _context.Entry(trackedContract).CurrentValues.SetValues(huurcontractEF);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException("Contract not found in the context.");
                    }
             }

             catch (Exception ex)
             {
                    throw ex;
             }

      }


        public void VoegContractToe(Huurcontract contract)
        {
            try
            {
                _context = new ParkbeheerContext();
                HuurcontractEF huurcontractEF = MapFromDomain.MapHuurcontract(contract);
                _context.Huurcontracten.Add(huurcontractEF);
                


                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex; // Of een specifiekere foutmelding teruggeven
            }
        }



    }
}
