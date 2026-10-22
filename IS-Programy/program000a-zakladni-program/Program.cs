// Základní program - kostra pro další projekty
// Obsahuje opakování programu a jeden ošetřený vstup.

string again = "a";
Console.Clear();
while(again.ToLower() == "a")
{
    Console.Clear();
    Console.WriteLine("***************************************");
    Console.WriteLine("********** Základní program ***********");
    Console.WriteLine("***************************************");
    Console.WriteLine("************ Daniel Čeřovský **********");
    Console.WriteLine("***************************************");
    Console.WriteLine("***************************************");
    Console.WriteLine();

    // Vstup celého čísla s kontrolou
    Console.Write("Zadejte celé číslo: ");
    int number;
    while(!int.TryParse(Console.ReadLine(), out number))
    {
        Console.Write("Nezadali jste celé číslo! Zadejte celé číslo znovu: ");
    }

    // Sem přijde algoritmus konkrétního programu
    Console.WriteLine();
    Console.WriteLine($"Zadali jste číslo {number}.");

    // Dotaz směrem k uživateli na opakování
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a. Následně potvrďte klávesou Enter. ");
    Console.WriteLine("Jakoukoli jinou klávesou program ukončíte.");
    Console.WriteLine();
    Console.Write("Chcete program spustit znovu? ");
    again = Console.ReadLine() ?? "";
}
