using Assignment.Models;
using Newtonsoft.Json;

namespace Assignment.Services;

internal class FileService
{
    private static readonly string savedFile = @"C:\Assignment\customers.json";     //denna sträng leder oss till en JSON-fil 
    public static async Task SaveToFileAsync(string contentAsJson)      // Med SaveToFileAsync så är det möjligt i kombination med andra funktioner i Services
    {                                                                   // att spara kundprofiler till json-filen

        using StreamWriter customerfile = new StreamWriter(savedFile);
        await customerfile.WriteLineAsync(contentAsJson);               // koden skapar en fil som här kallas för file,
        await Task.Delay(5000);
        Console.WriteLine("");                                           // 5 sekunders delay tills texten sparas
        Console.WriteLine("File has been saved");                        // meddelande som kommer när texten sparas i filen
    }

    public static string? ReadFromFile()                                //för att kunna läsa/hämta profiler från filen
    {
        if (File.Exists(savedFile))                                     // om filen finns, så med hjälp av StreamReader och "read"
        {                                                               // så kan man returnera den lästa texten från filen
            using StreamReader read = new StreamReader(savedFile);       // dvs. koden kan nu läsa text från filen i valda (filvägen)
            return read.ReadToEnd();
        }
        return null!;                                                   // värdet eller profilen i detta fall förväntas inte vara null

    }

    public static async Task RemoveFromFile(string email)                           // för att radera en specifik profil från filen, så länks det till "email"
    {                                                                                // "email" är det mail som matas in i consol-appen, och på så sätt
        var customers = JsonConvert.DeserializeObject<List<Customer>>(File.ReadAllText(savedFile)); // kan vi med hjälp av denna hitta i filen
        using StreamWriter customerdelete = new StreamWriter(savedFile);                // med hjälp av streamwriter så kan man nu radera
        await customerdelete.WriteLineAsync(email);                                     //här skriver man email för den profil man vill raderna

    }
}