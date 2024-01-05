using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using ParkDataLayer.Repositories;
using ParkDataLayer;
using ParkBusinessLayer.Model;
using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;
using ParkDataLayer.Mappers;
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;

namespace ConsoleAppDLtest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\32495\Desktop\Specialisatieopdrachten\SolutionParkbeheerOpgave\ConsoleAppDLtest\appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("Parkbeheer");

            Console.WriteLine(connectionString);
            

            using (var context = new ParkbeheerContext()) 
            {
                IContractenRepository contractenRepository = new ContractenRepositoryEF(context);
                var contractenRepo = new BeheerContracten(contractenRepository);

                IHuizenRepository huizenRepository = new HuizenRepositoryEF(context);
                var huizenRepo = new BeheerHuizen(huizenRepository);

                IHuurderRepository huurderRepository = new HuurderRepositoryEF(context);

                var huurderRepo = new BeheerHuurders(huurderRepository);
             

                TestRepositories(contractenRepo, huizenRepo, huurderRepo);
    
            }

            Console.ReadLine();
        }


        static void TestRepositories(BeheerContracten contractenRepo, BeheerHuizen huizenRepo, BeheerHuurders huurderRepo)
        {
          


            TestContractenRepository(contractenRepo);

            TestVoegGeefEnUpdateHuis(huizenRepo);

            TestHuurderRepository(huurderRepo);


      
        }


        static void TestContractenRepository(BeheerContracten contractenRepo)
        {
            Console.WriteLine("Test ContractenRepository:");

          
            var eersteContract = contractenRepo.GeefContracten(DateTime.Now.AddYears(-2), null).FirstOrDefault();

            if (eersteContract != null)
            {
            
                var oudeWaarden = $"Oude waarden: Contract ID: {eersteContract.Id}, StartDatum: {eersteContract.Huurperiode.StartDatum}, EindDatum: {eersteContract.Huurperiode.EindDatum}";

            
                eersteContract.Huurperiode.StartDatum = DateTime.Now.AddMonths(-1);
                contractenRepo.UpdateContract(eersteContract);

         
                var bijgewerktContract = contractenRepo.GeefContract(eersteContract.Id);
                var nieuweWaarden = $"Nieuwe waarden: Contract ID: {bijgewerktContract.Id}, StartDatum: {bijgewerktContract.Huurperiode.StartDatum}, EindDatum: {bijgewerktContract.Huurperiode.EindDatum}";

         
                Console.WriteLine("Update Contract:");
                Console.WriteLine(oudeWaarden);
                Console.WriteLine(nieuweWaarden);

             
                Console.WriteLine("\nSamenvatting acties:");
                Console.WriteLine($" - Oud contractgegevens: {oudeWaarden}");
                Console.WriteLine($" - Contract succesvol bijgewerkt naar: {nieuweWaarden}");
            }
            else
            {
                Console.WriteLine("Geen contract gevonden om te updaten.");
            }
        }


        static void TestVoegGeefEnUpdateHuis(BeheerHuizen huizenRepo)
        {
            Console.WriteLine("Testing VoegHuisToe, GeefHuis, and UpdateHuis methods...");

            var context = new ParkbeheerContext();
            var beschikbareParken = context.Parken.ToList();

           
            Console.WriteLine("Beschikbare parken:");
            foreach (var park in beschikbareParken)
            {
                Console.WriteLine($"Park ID: {park.Id}, Naam: {park.Naam}");
            }
            Console.Write("Voer het ID in van het gewenste park om toe te voegen aan het huis: ");
            string gekozenParkId = Console.ReadLine();

            var nieuwPark = new Park(gekozenParkId,"Nieuw Park", "Nieuwe Locatie");
            var newHouse = new Huis("NieuweStraat", 555, nieuwPark);

            Huis toegevoegdHuis;
            huizenRepo.VoegNieuwHuisToe(newHouse.Straat, newHouse.Nr, newHouse.Park, out toegevoegdHuis);

     
            
            Console.WriteLine($"Added house ID: {toegevoegdHuis.Id}");

        
            var houseId = toegevoegdHuis.Id; 
            var foundHouse = huizenRepo.GeefHuis(houseId);
            Console.WriteLine($"Found house: {foundHouse?.Id}");

 
            if (foundHouse != null)
            {
                foundHouse.ZetStraat("New Street");
                huizenRepo.UpdateHuis(foundHouse);
                Console.WriteLine($"Updated house ID: {foundHouse.Id}");



            }

         
            Console.WriteLine("\nResultaten:");
            Console.WriteLine($" - Toegevoegd huis ID: {toegevoegdHuis.Id}");
            Console.WriteLine($" - Gevonden huis ID: {(foundHouse != null ? foundHouse.Id.ToString() : "Geen huis gevonden")}");
            if (foundHouse != null)
            {
                Console.WriteLine($" - Bijgewerkt huis ID: {foundHouse.Id}");
            }
        }


        static void TestHuurderRepository(BeheerHuurders huurderRepo)
        {
            Console.WriteLine("Test HuurderRepository:");

            
            var nieuweContactgegevens = new Contactgegevens("nieuwe@example.com", "123456789", "Adres van nieuwe huurder");

      
            var nieuweHuurder = new Huurder("Nieuwe Huurder Naam", nieuweContactgegevens);

     
            huurderRepo.VoegNieuweHuurderToe(nieuweHuurder.Naam,nieuweHuurder.Contactgegevens);
            Console.WriteLine("Nieuwe huurder toegevoegd.");


            var eersteHuurder = huurderRepo.GeefHuurders("").FirstOrDefault();

            if (eersteHuurder != null)
            {
                eersteHuurder.ZetNaam("Gewijzigde Naam");
                huurderRepo.UpdateHuurder(eersteHuurder);
                Console.WriteLine("Eerste huurder gewijzigd.");

                // Haal de gewijzigde huurder op
                var gewijzigdeHuurder = huurderRepo.GeefHuurder(eersteHuurder.Id);
                Console.WriteLine($"Naam van gewijzigde huurder: {gewijzigdeHuurder.Naam}");
            }

  
            var alleHuurders = huurderRepo.GeefHuurders("");
            Console.WriteLine("\nAlle huurders:");
            foreach (var h in alleHuurders)
            {
                Console.WriteLine($"Huurder ID: {h.Id}, Naam: {h.Naam}, Telefoon: {h.Contactgegevens.Tel}");
            }
        }



    }


}

