// See https://aka.ms/new-console-template for more information



using ConcertCRUDApp;

class Program 
{
    static void Main(string[] args)
    {
        var concerts = LoadConcerts();

        while (true)
        {
        Console.WriteLine("\n--- Concert Manager ---");
        Console.WriteLine("1. Add Concert");
        Console.WriteLine("2. View All Concerts");
        Console.WriteLine("3. Update Concert");
        Console.WriteLine("4. Delete Concert");
        Console.WriteLine("5. Save and Exit");
        Console.Write("Choose an option: ");

        string? option = Console.ReadLine();
        switch (option)
        {
            case "1":
                ConcertAdministrator.AddConcert(concerts);
                break;
            case "2":
                Console.WriteLine("\nAll Concerts:");
                foreach (var concert in concerts)
                {
                    Console.WriteLine($"{concert.Id}: {concert.ArtistName} at {concert.Venue} with Audience capacity of: {concert.AudienceCapacity} on {concert.Date.ToShortDateString()} ");
                }
                break;
            case "3":
                ConcertAdministrator.UpdateConcert(concerts);
                break;
            case "4":
                ConcertAdministrator.DeleteConcert(concerts);
                break;
            case "5":
                ConcertAdministrator.SaveConcerts(concerts);
                Console.WriteLine("Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    }

    private static List<Concert> LoadConcerts()
    {
        throw new NotImplementedException();
    }
}

