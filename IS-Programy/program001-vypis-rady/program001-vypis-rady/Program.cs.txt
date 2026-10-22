// Toto je jednořádkový komentář

/* Toto je
víceřádkový
komentář */ 


// Nejprve budeme řešit opakování programu

string again = "a";
Console.Clear();
// .ToLower() převede vstup na malá písmena, takže program bude pokračovat při zadávání malého "a" tak i velkého "A"
while(again.ToLower() == "a")
{
    Console.Clear();
    Console.WriteLine("***************************************");
    Console.WriteLine("************ Výpis řady ***************");
    Console.WriteLine("***************************************");
    Console.WriteLine("************ Daniel Čeřovský **********");
    Console.WriteLine("***************************************");
    Console.WriteLine("***************************************");
    Console.WriteLine();

    // Vstup počáteční hodnoty - špatně řešený
    // Console.Write("Zadejte první číslo řady (celé číslo): ");
    // int first =int.Parse(Console.ReadLine()); 

    // Vstup počáteční hodnoty - řešený správně 
    Console.Write("Zadejte první číslo řady (celé číslo): ");
    int first;
    while(!int.TryParse(Console.ReadLine(), out first))
    {
        Console.Write("Nezadali jste celé číslo! Zadejte první číslo řady znovu (celé číslo): ");
    }

    // Vstup konečné hodnoty
    Console.Write("Zadejte poslední číslo řady (celé číslo): ");
    int last;
    while(!int.TryParse(Console.ReadLine(), out last))
    {
        Console.Write("Nezadali jste celé číslo! Zadejte poslední číslo řady znovu (celé číslo): ");
    }

    // Vstup pro diferenci s kontrolou na kladnou hodnotu
    Console.Write("Zadejte diferenci (kladné celé číslo): ");
    int step;
    while(!int.TryParse(Console.ReadLine(), out step) || step <= 0 )
    {
        Console.Write("Nezadali jste kladné celé číslo! Zadejte diferenci znovu (kladné celé číslo): ");
    }

    // Výpis řady
    Console.WriteLine();
    Console.WriteLine($"Řada od {first} do {last} s diferencí {step}:");
    for (int i = first; i <= last; i = i + step)
    {
        Console.WriteLine(i);
    }

    // Dotaz směrem k uživateli na opakování
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Pro opakování programu stiskněte klávesu a. Následně potvrďte klávesou Enter. ");
    Console.WriteLine("Jakoukoli jinou klávesou program ukončíte.");
    Console.WriteLine();
    Console.Write("Chcete program spustit znovu? ");
    again = Console.ReadLine() ?? "";
}