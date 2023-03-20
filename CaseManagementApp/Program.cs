using CaseManagementApp.Services;



namespace CaseManagementApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Välkommen till ärendehanteraren!");
            Console.WriteLine();

            var menuService = new MenuService();

            while (true)
            {
                Console.WriteLine("Välj en åtgärd:");
                Console.WriteLine("1. Skapa nytt ärende");
                Console.WriteLine("2. Lista alla ärenden");
                Console.WriteLine("3. Visa specifikt ärende");
                Console.WriteLine("4. Uppdatera ärende");
                Console.WriteLine("5. Ta bort ärende");
                Console.WriteLine("0. Avsluta programmet");

                Console.WriteLine();
                Console.Write("Ange ditt val: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        await menuService.CreateNewCaseAsync();
                        break;
                    case 2:
                        await menuService.ListAllCasesAsync();
                        break;
                    case 3:
                        await menuService.ListSpecificCaseAsync();
                        break;
                    case 4:
                        await menuService.UpdateSpecificCaseAsync();
                        break;
                    case 5:
                        await menuService.DeleteSpecificCaseAsync();
                        break;
                    case 0:
                        Console.WriteLine("Tack för att du använde ärendehanteraren!");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
