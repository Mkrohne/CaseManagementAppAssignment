using CaseManagementApp.Contexts;
using CaseManagementApp.Models;
using CaseManagementApp.Models.Entities;

namespace CaseManagementApp.Services
{
    internal class MenuService
    {
        private readonly CaseService _caseService;

        public MenuService()
        {
            var dataContext = new DataContext();
            _caseService = new CaseService(dataContext);
        }

        public async Task CreateNewCaseAsync()
        {
            Console.Clear();
            Console.WriteLine("Skapa nytt ärende");
            Console.WriteLine();

            // Fråga användaren efter titel och beskrivning av ärendet
            Console.Write("Titel På Ärendet: ");
            var title = Console.ReadLine();

            Console.Write("Beskrivning På Ärendet: ");
            var description = Console.ReadLine();

            // Fråga användaren efter sitt för- och efternamn
            Console.Write("Ditt förnamn: ");
            var firstName = Console.ReadLine();

            Console.Write("Ditt efternamn: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Din Epostadress: ");
            var email = Console.ReadLine();

            Console.WriteLine("Ditt Telefonnummer: ");
            var phonenumber = Console.ReadLine();

            var UpdatedAt = DateTime.Now;

            // Skapa ett nytt CaseEntity-objekt med användarens inmatade data
            var newCase = new CaseEntity
            {
                Title = title ?? "",
                Description = description ?? "",
                CreatedBy = $"{firstName} {lastName}"
            };

            var newUser = new User
            {
                FirstName = firstName ?? "",
                LastName = lastName ?? "",
                Email = email ?? "",
                PhoneNumber = phonenumber ?? ""
            };

            // Lägg till ärendet i databasen
            await _caseService.AddCase(newCase);
            await _caseService.AddUser(newUser);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Ärendet har skapats.");
        }


        public async Task ListAllCasesAsync()
        {
            Console.Clear();
            Console.WriteLine("Alla ärenden:");
            Console.WriteLine();

            var cases = _caseService.GetAllCases();

            if (cases.Any())
            {
                foreach (var caseItem in cases)
                {
                    Console.WriteLine($"Id: {caseItem.CaseId}");
                    Console.WriteLine($"Titel: {caseItem.Title}");
                    Console.WriteLine($"Beskrivning: {caseItem.Description}");
                    Console.WriteLine($"Skapad av: {caseItem.CreatedBy}");
                    Console.WriteLine($"Status: {caseItem.Status}");
                    Console.WriteLine($"Skapad datum: {DateTime.Parse(caseItem.CreationDate.ToString()).ToShortDateString()}");
                    Console.WriteLine($"Uppdaterad datum: {(caseItem.UpdatedAt == null ? "N/A" : DateTime.Parse(caseItem.UpdatedAt.ToString()).ToShortDateString())}");
                    Console.WriteLine();
                }
            }
            else
            {
                
                Console.WriteLine("Inga ärenden hittades.");
            }
        }


        public async Task ListSpecificCaseAsync()
        {
            Console.Clear();
            Console.WriteLine("Visa specifikt ärende");
            Console.WriteLine();

            // Be användaren mata in ärendets ID
            Console.Write("Ange ärendets ID: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Ogiltigt ID");
                return;
            }

            // Hämta ärendet från databasen
            var theCase = _caseService.GetCaseById(id);
            if (theCase == null)
            {
                Console.WriteLine($"Ärende med ID {id} hittades inte");
                return;
            }

            // Visa information om ärendet
            Console.WriteLine($"ID: {theCase.CaseId}");
            Console.WriteLine($"Titel: {theCase.Title}");
            Console.WriteLine($"Beskrivning: {theCase.Description}");
            Console.WriteLine($"Skapad av: {theCase.CreatedBy}");
            Console.WriteLine($"Status: {theCase.Status}");
            Console.WriteLine($"Skapad datum: {theCase.CreationDate}");
            Console.WriteLine($"Senast uppdaterad: {theCase.UpdatedAt}");
        }


        public async Task UpdateSpecificCaseAsync()
        {
            Console.Clear();
            Console.WriteLine("Uppdatera ärende");
            Console.WriteLine();

            // Be användaren mata in id för det ärende som ska uppdateras
            Console.Write("Ange id för ärendet som ska uppdateras: ");
            var id = int.Parse(Console.ReadLine());

            // Hämta ärendet från databasen
            var existingCase = _caseService.GetCaseById(id);

            if (existingCase == null)
            {
                Console.WriteLine($"Kunde inte hitta ärende med id {id}.");
                return;
            }

            // Be användaren mata in nya uppgifter för ärendet
            Console.WriteLine();
            Console.Write("Ny titel (lämna tomt för att behålla befintlig): ");
            var newTitle = Console.ReadLine();

            Console.Write("Ny beskrivning (lämna tomt för att behålla befintlig): ");
            var newDescription = Console.ReadLine();

            Console.Write("Ny status (Ange: Påbörjat, Avslutat eller lämna tomt för att behålla befintlig): ");
            var newStatus = Console.ReadLine();

            // Skapa ett nytt CaseEntity-objekt med de uppdaterade uppgifterna
            var updatedCase = new CaseEntity
            {
                CaseId = existingCase.CaseId,
                Title = string.IsNullOrEmpty(newTitle) ? existingCase.Title : newTitle,
                Description = string.IsNullOrEmpty(newDescription) ? existingCase.Description : newDescription,
                Status = string.IsNullOrEmpty(newStatus) ? existingCase.Status : newStatus
            };


            // Uppdatera ärendet i databasen
            _caseService.UpdateCase(updatedCase);

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Ärendet har uppdaterats.");
        }


        public async Task DeleteSpecificCaseAsync()
        {
            Console.Clear();
            Console.WriteLine("Ta bort ärende");
            Console.WriteLine();

            Console.Write("Ange ID på ärendet du vill ta bort: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Ogiltigt ID, försök igen.");
                return;
            }

            try
            {
                Console.Clear();
                _caseService.DeleteCase(id);
                Console.WriteLine("Ärendet har tagits bort.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}