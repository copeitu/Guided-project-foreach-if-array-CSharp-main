using System.Diagnostics;
using System.Globalization;
using System.Net.Security;
using System.Runtime.CompilerServices;

using Microsoft.VisualBasic;

namespace MyProject;

public record Cheep(string Author, string Message, long Timestamp);


public class CheepFunction
/*
    CheepFunction contains functions writing to the terminal.
    Data storage operations will be called from here when necessary.
*/
{

    public static void Skriv(Cheep c)
    {
        DateTimeOffset tl = DateTime.UtcNow;

        //Cheep c = new Cheep(Environment.UserName, m, tl.ToUnixTimeSeconds());


        //            string newRow = "\"" + Environment.UserName + ",\"\"" + a + "\"\"," + tl.ToUnixTimeSeconds() + "\"";

        // Console.WriteLine("CheepFunction :" + cheep.Author + ", " + cheep.Timestamp + ", " + cheep.Message);
        Console.WriteLine("CheepFunction : {0}, {1}, {2}", c.Author, c.Timestamp, c.Message);
    }

}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start");
        if (args.Length > 0)
        {
            if (args[0].ToLower() == "chirp" && args.Length == 2) // chirp + tekst
            {
                DateTimeOffset tl = DateTime.UtcNow;
                Cheep c = new Cheep(Environment.UserName, args[1], tl.ToUnixTimeSeconds());

                CheepFunction.Skriv(c);
            }
            else if (args[0].ToLower() == "read" && args.Length == 2) // read + antal rækker til udskrivning
            {
                if (args[1].All(char.IsDigit))
                {
                    Laes(args[1]);
                }
                else
                {
                    Console.WriteLine("Type the number og messages you want to see.");
                }

            }
        }
        else
        {
            Console.WriteLine("No arguments");
        }
    }

    public static void Laes(string a)
    {        // Chirp.CLI cheep "Welcome to the course!"

        string path = @"C:\Users\cope\OneDrive - ITU\Desktop\ChirpCLI\chirp_cli_db.csv";
        int i = int.Parse(a);
        int j = 0;
        StreamReader sr = new(path);
        string[] row = new string[5];

        string? line;
        while ((line = sr.ReadLine()) != null && j < i)
        {
            row = line.Split(',');

            Console.WriteLine(line);
            j = j + 1;
        }

        sr.Close();
    }


    public static void Skriv(string a)
    {
        Console.WriteLine("Start Skriv");
        // Chirp.CLI cheep "Welcome to the course!"

        //Dim c = new Cheep(string Author, string Message, long Timestamp);

        string path = @"C:\Users\cope\OneDrive - ITU\Desktop\ChirpCLI\chirp_cli_db.csv";

        using (StreamWriter writer = File.AppendText(path))
        {
            DateTime t = DateTime.Now;

            DateTimeOffset tl = DateTime.UtcNow;

            string newRow = "\"" + Environment.UserName + ",\"\"" + a + "\"\"," + tl.ToUnixTimeSeconds() + "\"";
            string printRow = Environment.UserName + ", " + t.ToString() + ", " + a;

            Console.WriteLine(printRow);

            writer.WriteLine(newRow);

            writer.Close();
        }

    }

}

