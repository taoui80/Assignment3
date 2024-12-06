using System;
using System.Security.Cryptography.X509Certificates;

namespace ConcertCRUDApp;

public class ConcertAdministrator
{
    public static void AddConcert(List<Concert> concerts)
    {
    Console.Write("Enter Artistname: ");
    string? artistname = Console.ReadLine();

    Console.Write("Enter Venue: ");
    string? venue = Console.ReadLine(); 
    
    Console.Write("Enter Audience capacity: ");
    int audiencecapacity = int.Parse(Console.ReadLine());

    Console.Write("Enter Date (YYYY-MM-DD): ");
    DateTime date = DateTime.Parse(Console.ReadLine());

   

    int newId = concerts.Count > 0 ? concerts.Max(c => c.Id) + 1 : 1;

    var newConcert = new Concert
    {
        Id = newId,
        ArtistName = artistname,
        Venue = venue,
        AudienceCapacity = audiencecapacity,
        Date = date,
        
    };

    concerts.Add(newConcert);
    Console.WriteLine("Concert added successfully!");
    }  

    const string filePath = "concerts.txt";
    public List<Concert> LoadConcerts()
    {
    var concerts = new List<Concert>();

    if (File.Exists(filePath))
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            concerts.Add(Concert.FromString(line));
        } 
    }
    return concerts;
    }

    

    public static void UpdateConcert(List<Concert> concerts)
    {
    Console.Write("Enter Concert ID to update: ");
    int id = int.Parse(Console.ReadLine());

    var concert = concerts.FirstOrDefault(c => c.Id == id);
    if (concert != null)
    {
        Console.Write("Enter new Artistname (leave blank to keep current): ");
        string? artistname = Console.ReadLine();
        if (!string.IsNullOrEmpty(artistname)) concert.ArtistName = artistname;

        Console.Write("Enter new Venue (leave blank to keep current): ");
        string? venue = Console.ReadLine();
        if (!string.IsNullOrEmpty(venue)) concert.Venue = venue;

        Console.Write("Enter new Audience capacity (leave blank to keep current): ");
        string? capacityInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(capacityInput)) concert.AudienceCapacity = int.Parse(capacityInput);

        Console.Write("Enter new Date (YYYY-MM-DD) (leave blank to keep current): ");
        string? dateInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(dateInput)) concert.Date = DateTime.Parse(dateInput);

        
        Console.WriteLine("Concert updated successfully!");
    }
    else
    {
        Console.WriteLine("Concert not found.");
    }
    }

    public static void DeleteConcert(List<Concert> concerts)
    {
    Console.Write("Enter Concert ID to delete: ");
    int id = int.Parse(Console.ReadLine());

    var concert = concerts.FirstOrDefault(c => c.Id == id);
    if (concert != null)
    {
        concerts.Remove(concert);
        Console.WriteLine("Concert deleted successfully!");
    }
    else
    {
        Console.WriteLine("Concert not found.");
    }
    }

    public static void SaveConcerts(List<Concert> concerts)
{
    var lines = concerts.Select(c => c.ToString()).ToList();
    File.WriteAllLines(filePath, lines);
    Console.WriteLine("Concerts saved to file.");
}
} 

