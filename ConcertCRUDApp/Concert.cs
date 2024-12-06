using System;

namespace ConcertCRUDApp;

public class Concert
{
    public int Id {get; set;} 
    public string ArtistName {get; set;}
    public string Venue {get; set;}
    public int AudienceCapacity {get; set;} 
    public DateTime Date {get; set;}
    

    public string ToString(int Id, string ArtistName, string Venue, int AudienceCapacity, DateTime Date)
    {
    
        return $"Id:{Id}, ArtistName:{ArtistName}, AudienceCapacity:{AudienceCapacity}, Date{Date}, Venue{Venue}";   
       
    }

      public static Concert FromString(string data)
    {
        var parts = data.Split(',');
        return new Concert
        {
            Id = int.Parse(parts[0]),
            ArtistName = parts[1],
            Venue = parts[2],
            AudienceCapacity = int.Parse(parts[3]),
            Date = DateTime.Parse(parts[4]),
            
        };
    }

    
   /* public class Concert
{
    public int Id { get; set; }
    public string Performer { get; set; }
    public string Venue { get; set; }
    public DateTime Date { get; set; }
    public int Capacity { get; set; }

    public override string ToString()
    {
        return $"{Id},{Performer},{Venue},{Date},{Capacity}";
    }

  
}*/

}
