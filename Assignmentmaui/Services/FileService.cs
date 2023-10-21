using System.Diagnostics;
using Assignmentmaui.Mvvm.Models;
using Assignmentmaui.Services;
namespace Assignmentmaui.Services;

public class FileService
{
    // statisk metod för att spara innehållet till sökvägen savedFile, och texten sparas i Json string.
    public static void SaveToFile(string savedFile, string contentAsJson)
    {
        // om filen inte finns, skapa filen sen stäng. Med hälp av Streamwriter och vår filpath så
        try
        {   
            if (!File.Exists(savedFile))
            {
                File.Create(savedFile).Close();
            }

            // Streamwriter hjälper att skriva data till den angivna filen, och med hjälp av
            // Writeline, så kan det man skriver omvandlas till Json format.
            using StreamWriter filesaver = new StreamWriter(savedFile);
            filesaver.WriteLine(contentAsJson);
        }

        // Om det uppstår problem / undnatag, får vi felsökningsmeddelande.
        catch (Exception ex) { Debug.WriteLine(ex.Message);}
        
    }
    // statisk metod som hjälper att läsa innehållet från filen i sökvägen savedFile
    public static string ReadFromFile(string savedFile)
    {
        // Om filen finns, hämta all text / innehåll, i det här fallet kundlistor.
        try
        {
            if (File.Exists(savedFile))
            {
                return File.ReadAllText(savedFile);
            }
        } 
        
        // Om det uppstår problem / undantag, så får vi felsökningsmeddelande.
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        { 
            // om filen inte finns, så returneras inget.
            return null!;
        }

    }
        
}