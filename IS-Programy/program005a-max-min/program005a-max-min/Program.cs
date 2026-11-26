// UTF-8 zajistí, že se linka a diakritika zobrazí správně i ve Windows cmd
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Clear();
string again = "a";
// .ToLower() převede vstup na malá písmena, takže program bude pokračovat při zadávání "a" tak i "A"
while(again.ToLower() == "a" )
{
    Console.WriteLine();
    Console.Clear();
    // Hlavička: název programu velkými proloženými písmeny modře, pod ním podpis
    string title = "Maximum a minimum";
    string author = "Daniel Čeřovský";
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("  ");
    int headerWidth = 0;
    foreach (char c in title.ToUpper())
    {
        if (c == ' ')
        {
            // Mezera mezi slovy je širší než mezera mezi písmeny, aby šla slova přečíst
            Console.Write("  ");
            headerWidth = headerWidth + 2;
        }
        else
        {
            Console.Write(c + " ");
            headerWidth = headerWidth + 2;
        }
    }
    Console.WriteLine();

    // Linka i podpis mají stejnou šířku jako název, takže hlavička sedí pro jakýkoli název
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("  " + new string('─', headerWidth - 1));
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("  " + ("~ " + author).PadLeft(headerWidth - 1));
    Console.ResetColor();
    Console.WriteLine();

    // Vstup pro počet generovaných čísel
    Console.Write("Zadejte počet generovaných (kladné celé číslo): ");
    int n;
    while(!int.TryParse(Console.ReadLine(), out n) || n<=0 )
    {
        Console.Write("Nezadali jste celé kladné celé číslo! Zadejte počet čísel znovu: ");
    }

    // Vstup pro dolní mez
    Console.Write("Zadejte dolní mez (celé číslo): ");
    int lowerBound;
    while(!int.TryParse(Console.ReadLine(), out lowerBound))
    {
        Console.Write("Nezadali jste celé číslo! Zadejte dolní mez znovu: ");
    }

    // Vstup pro horní mez
    Console.Write("Zadejte horní mez (celé číslo větší nebo rovno hodnotě pro dolní mez): ");
    int upperBound;
    while(!int.TryParse(Console.ReadLine(), out upperBound) || upperBound < lowerBound)
    {
        Console.Write("Nezadali jste celé číslo nebo je horní mez menší než dolní mez! Zadejte horní mez znovu: ");
    }


    // Rekapitulace zadaných hodnot
    Console.WriteLine();
    Console.WriteLine("==================================");
    // Výpis zadaných hodnot do jednoho řádku
    Console.WriteLine($"Počet generovaných čísel: {n}; Dolní mez: {lowerBound}; Horní mez: {upperBound}");
    Console.WriteLine("==================================");
    Console.WriteLine();



    // Deklarace pole a alokace v paměti
    int[] myRandNumbs = new int[n];

    // Inicializace generátoru náhodných čísel
    Random myRandNumb = new Random();
    // Random myRandNumb = new Random(50); // Pevný seed pro testovací účely (vždy stejná čísla)

    Console.WriteLine("Generovaná čísla: ");
    for(int i = 0; i < myRandNumbs.Length; i++ )
    {
        // Generování i-tého náhodného čísla
        myRandNumbs[i] = myRandNumb.Next(lowerBound, upperBound+1);
        Console.Write($"{myRandNumbs[i]}; ");
    }


    // Jádro konkrétního algortimu

    // Hledání maxima, minima a jejich umístění
    int max = myRandNumbs[0]; // Předpokládáme, že nultý prvek v poli je maximem
    int min = myRandNumbs[0]; // Předpokládáme, že nultý prvek v poli je minimem
    int posMax = 0;
    int posMin = 0;

    for(int i = 1; i < n; i++)
    {
        if(myRandNumbs[i] > max)
        {
            max = myRandNumbs[i];
            posMax = i;
        }

        if(myRandNumbs[i] < min)
        {
            min = myRandNumbs[i];
            posMin = i;
        }
    }

    // Domácí úkol: počet výskytů a pozice všech maxim a minim.
    // Maximum a minimum už známe, proto stačí projít pole ještě jednou a porovnávat.
    int countMax = 0;
    int countMin = 0;
    string allPosMax = "";
    string allPosMin = "";

    for(int i = 0; i < n; i++)
    {
        if(myRandNumbs[i] == max)
        {
            countMax++;
            allPosMax = allPosMax + i + "; ";
        }

        if(myRandNumbs[i] == min)
        {
            countMin++;
            allPosMin = allPosMin + i + "; ";
        }
    }

    Console.WriteLine();
    Console.WriteLine("==============================================");
    Console.WriteLine($"Maximum: {max}");
    Console.WriteLine($"Pozice prvního maxima: {posMax}");
    if (countMax > 1)
    {
        Console.WriteLine($"Maximum se vyskytuje {countMax}x, na pozicích: {allPosMax}");
    }
    Console.WriteLine($"Minimum: {min}");
    Console.WriteLine($"Pozice prvního minima: {posMin}");
    if (countMin > 1)
    {
        Console.WriteLine($"Minimum se vyskytuje {countMin}x, na pozicích: {allPosMin}");
    }
    Console.WriteLine("==============================================");
    Console.WriteLine();

    if (max >= 3)
    {
        // Vnější cyklus řídí vykreslování jednotlivých řádků
        for(int i = 0; i < max; i++) {
            // Budeme vykreslovat
            int spaces = 0;
            int stars = 0;

            if(i < max / 2)
            {
                spaces = i;
                stars = max  - (2 * i);

                // Horní polovina hodin - písek, který ještě nepropadl
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                // Dolní polovina je zrcadlem horní: řádek i odpovídá řádku max - 1 - i odshora.
                // U sudého maxima vyjdou uprostřed dva řádky se dvěma hvězdičkami,
                // u lichého jeden řádek s jednou hvězdičkou.
                spaces = max - 1 - i;
                stars = max - (2 * spaces);

                // Dolní polovina hodin - písek, který už propadl
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }

            // Vykreslení úvodních mezer (dvě mezery, protože hvězdička i s mezerou zabírá dva znaky)
            for(int sp = 0; sp < spaces; sp++)
            {
                Console.Write("  ");
            }


            // Vykreslení hvězdiček s mezerou jako v ukázce ze zadání
            for(int st = 0; st < stars; st++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();


        }
        Console.ResetColor();

    }
    else
    {
        // Nebudeme vykreslovat
        Console.WriteLine("Maximum je menší než 3 => obrazec se nevykreslí");
    }


    // Konec jádra konkrétního algoritmu


    // Dotaz směrem k uživateli na opakování
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a. Následně potvrďte klávesou Enter. ");
    Console.WriteLine("Jakokouli jinou klávesou program ukončíte.");
    Console.WriteLine();
    Console.Write("Chcete program spustit znovu? ");
    again = Console.ReadLine() ?? "";

}
