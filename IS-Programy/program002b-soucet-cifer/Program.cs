string again = "a";
Console.Clear();
// .ToLower() převede vstup na malá písmena, takže program bude pokračovat při zadávání malého "a" tak i velkého "A"
while(again.ToLower() == "a")
{
    Console.Clear();
    Console.WriteLine("***************************************");
    Console.WriteLine("*** Součet a součin cifer - text ******");
    Console.WriteLine("***************************************");
    Console.WriteLine("************ Daniel Čeřovský **********");
    Console.WriteLine("***************************************");
    Console.WriteLine("***************************************");
    Console.WriteLine();

    // Vstup celého čísla - TryParse hlídá, že uživatel opravdu zadal celé číslo
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

    // Jiný způsob řešení: místo dělení a modula převedeme číslo na text
    // a projdeme ho znak po znaku zleva doprava.
    string text = number.ToString();

    int sum = 0;        // 0 je neutrální prvek pro sčítání
    int product = 1;    // 1 je neutrální prvek pro násobení
    int digit;

    Console.WriteLine("Rozklad čísla na cifry (zleva doprava):");
    foreach (char c in text)
    {
        // Znaménko minus není cifra, přeskočíme ho
        if (c == '-')
        {
            continue;
        }

        // Znaky '0' až '9' jdou v tabulce znaků po sobě,
        // takže odečtením '0' dostaneme hodnotu cifry ('7' - '0' = 7)
        digit = c - '0';
        sum = sum + digit;
        product = product * digit;
        Console.WriteLine($"Cifra: {digit}");
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
