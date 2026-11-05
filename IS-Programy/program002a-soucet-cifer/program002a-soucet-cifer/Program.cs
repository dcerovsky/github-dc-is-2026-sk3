string again = "a";
Console.Clear();
// .ToLower() převede vstup na malá písmena, takže program bude pokračovat při zadávání malého "a" tak i velkého "A"
while(again.ToLower() == "a")
{
    Console.Clear();
    Console.WriteLine("***************************************");
    Console.WriteLine("****** Součet a součin cifer **********");
    Console.WriteLine("***************************************");
    Console.WriteLine("************ Daniel Čeřovský **********");
    Console.WriteLine("***************************************");
    Console.WriteLine("***************************************");
    Console.WriteLine();

    // Vstup celého čísla
    Console.Write("Zadejte celé číslo: ");
    int number;
    while(!int.TryParse(Console.ReadLine(), out number))
    {
        Console.Write("Nezadali jste celé číslo! Zadejte celé číslo znovu: ");
    }

    // Rekapitulace zadané hodnoty
    Console.WriteLine();
    Console.WriteLine("====================================");
    Console.WriteLine($"Zadané číslo: {number}");
    Console.WriteLine("====================================");
    Console.WriteLine();


    // Začátek konkrétního algoritmu

    // Pracovní kopie čísla, původní number zůstane pro závěrečný výpis.
    // Je typu long, protože -int.MinValue se do int nevejde.
    long workNumber = number;

    // Záporné číslo převedeme na kladné, znaménko na cifry nemá vliv
    if (workNumber < 0)
    {
        workNumber = -workNumber;
    }

    int sum = 0;        // 0 je neutrální prvek pro sčítání
    int product = 1;    // 1 je neutrální prvek pro násobení
    int digit;

    if (workNumber == 0)
    {
        // Číslo 0 má jedinou cifru 0, cyklus níže by vůbec neproběhl
        sum = 0;
        product = 0;
    }
    else
    {
        Console.WriteLine("Rozklad čísla na cifry (zprava doleva):");
        while (workNumber > 0)
        {
            digit = (int)(workNumber % 10);     // zbytek po dělení 10 je poslední cifra
            sum = sum + digit;
            product = product * digit;
            Console.WriteLine($"Cifra: {digit}");
            workNumber = workNumber / 10;       // celočíselné dělení 10 odstraní poslední cifru
        }
    }

    // Výpis výsledků
    Console.WriteLine();
    Console.WriteLine("====================================");
    Console.WriteLine($"Ciferný součet čísla {number}: {sum}");
    Console.WriteLine($"Ciferný součin čísla {number}: {product}");
    Console.WriteLine("====================================");

    // Konec konkrétního algoritmu


    // Dotaz směrem k uživateli na opakování
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a. Následně potvrďte klávesou Enter. ");
    Console.WriteLine("Jakoukoli jinou klávesou program ukončíte.");
    Console.WriteLine();
    Console.Write("Chcete program spustit znovu? ");
    again = Console.ReadLine() ?? "";
}
