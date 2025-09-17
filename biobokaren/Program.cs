namespace biobokaren
{
    internal class Program
    {
        static string[] filmer = {
        "Dune: Part Two",
        "Oppenheimer",
        "Barbie",
        "Mission: Impossible – Dead Reckoning"
    };

        static string[] tider = {
        "14:00",
        "17:30",
        "20:00"
    };

        static string valdFilm = "";
        static string valdTid = "";
        static int antalBiljetter = 0;
        static bool studentRabatt = false;
        const int biljettPris = 120;

        static void Main(string[] args)
        {
            bool kör = true;

            while (kör)
            {
                Console.WriteLine("HUVUDMENY");
                Console.WriteLine("1. Lista filmer");
                Console.WriteLine("2. Välj film, tid och antal biljetter");
                Console.WriteLine("3. Lägg till/ta bort studentrabatt");
                Console.WriteLine("4. Skriv ut kvitto");
                Console.WriteLine("5. Avsluta");
                Console.Write("Välj ett alternativ (1-5): ");
                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        ListaFilmer();
                        break;
                    case "2":
                        VäljFilmOchTid();
                        break;
                    case "3":
                        HanteraRabatt();
                        break;
                    case "4":
                        SkrivKvitto();
                        break;
                    case "5":
                        kör = false;
                        Console.WriteLine("Programmet avslutas. Tack för att du bokade!");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        static void ListaFilmer()
        {
            Console.Clear();
            Console.WriteLine("Tillgängliga filmer:");
            for (int i = 0; i < filmer.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {filmer[i]}");
            }
        }

        static void VäljFilmOchTid()
        {
            Console.Clear();
            ListaFilmer();
            Console.Write("Välj film (1-4): ");
            int filmVal = int.Parse(Console.ReadLine());
            if (filmVal < 1 || filmVal > filmer.Length)
            {
                Console.WriteLine("Ogiltigt filmval.");
                return;
            }
            valdFilm = filmer[filmVal - 1];

            Console.Clear();

            Console.WriteLine("Tillgängliga tider:");
            for (int i = 0; i < tider.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {tider[i]}");
            }

            Console.Write("Välj tid (1-3): ");
            int tidVal = int.Parse(Console.ReadLine());
            if (tidVal < 1 || tidVal > tider.Length)
            {
                Console.WriteLine("Ogiltigt tidsval.");
                return;
            }
            valdTid = tider[tidVal - 1];

            Console.Clear();

            Console.Write("Ange antal biljetter: ");
            antalBiljetter = int.Parse(Console.ReadLine());

            Console.WriteLine($"Du har valt \"{valdFilm}\" kl {valdTid} med {antalBiljetter} biljett(er).");
        }

        static void HanteraRabatt()
        {
            Console.Clear();
            studentRabatt = !studentRabatt;
            string status = studentRabatt ? "Studentrabatt är AKTIVERAD." : "Studentrabatt är AVSTÄNGD.";
            Console.WriteLine($"{status}");
        }

        static void SkrivKvitto()
        {
            Console.Clear();
            if (string.IsNullOrEmpty(valdFilm) || string.IsNullOrEmpty(valdTid) || antalBiljetter == 0)
            {
                Console.WriteLine("Ingen bokning har gjorts ännu.");
                return;
            }

            double totalPris = biljettPris * antalBiljetter;
            double rabatt = studentRabatt ? totalPris * 0.15 : 0;
            double slutPris = totalPris - rabatt;

            Console.WriteLine("KVITTO");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Film: {valdFilm}");
            Console.WriteLine($"Tid: {valdTid}");
            Console.WriteLine($"Antal biljetter: {antalBiljetter}");
            Console.WriteLine($"Pris per biljett: {biljettPris} kr");
            if (studentRabatt)
                Console.WriteLine($"Studentrabatt: -{rabatt:F2} kr");
            Console.WriteLine($"Totalt att betala: {slutPris:F2} kr");
            Console.WriteLine("----------------------------");
        }
    }
}
