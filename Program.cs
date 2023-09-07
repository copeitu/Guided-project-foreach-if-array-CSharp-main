using System.Diagnostics;
using System.Globalization;
using System.Net.Security;
using System.Runtime.CompilerServices;

using Microsoft.VisualBasic;

namespace MyProject;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            if (args[0].ToLower() == "chirp")
            {
                Skriv(args[1]);
            }
            else if (args[0].ToLower() == "read")
            {
                Laes(args[1]);
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
        // Chirp.CLI cheep "Welcome to the course!"

        string path = @"C:\Users\cope\OneDrive - ITU\Desktop\ChirpCLI\chirp_cli_db.csv";

        using (StreamWriter writer = File.AppendText(path))
        {
            //int t = DateTimeOffset.Now.FromUnixTimeSeconds.ToString();

            //string t = DateTimeOffset.Now.Offset.TotalMicroseconds.ToString(); // Rigtigt format

            DateTime t = DateTime.Now;

            //t = t.Substring(0, t.Length - 2);
            //t =  cast  t.Substring(0, t.Length - 2);

            string newRow = "\"" + Environment.UserName + ",\"\"" + a + "\"\"," + t.ToString() + "\"";
            string printRow = Environment.UserName + ", " + t.ToString() + ", " + a;

            Console.WriteLine(printRow);

            writer.WriteLine(newRow);

            writer.Close();
        }

    }
}

