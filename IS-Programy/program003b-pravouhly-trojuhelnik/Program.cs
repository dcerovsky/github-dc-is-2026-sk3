// UTF-8 zajistí, že se linka a diakritika zobrazí správně i ve Windows cmd
Console.OutputEncoding = System.Text.Encoding.UTF8;

string again = "a";

while (again.ToLower() == "a")
{
    Console.Clear();
    // Hlavička: název programu velkými proloženými písmeny modře, pod ním podpis
    string title = "Pravoúhlý trojúhelník";
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

    // 1. Bezpečné načtení velikosti - menší obrazec by neměl rozpoznatelný tvar
    Console.Write("Zadejte výšku trojúhelníku (celé číslo alespoň 1): ");
    int size;
    while (!int.TryParse(Console.ReadLine(), out size) || size < 1)
    {
        Console.Write("Výška musí být celé číslo alespoň 1. Zadejte znovu: ");
    }

    Console.WriteLine();

    // 2. Vnořený cyklus: počet hvězdiček na řádku roste s číslem řádku
    // Vnější cyklus počítá řádky (shora dolů)
    for (int i = 1; i <= size; i++)
    {
        // Na i-tém řádku je přesně i hvězdiček, proto se vnitřní cyklus zastaví na i
        for (int j = 1; j <= i; j++)
        {
            Console.Write("* ");
        }

        // Konec řádku -> přesun kurzoru na nový řádek
        Console.WriteLine();
    }

    // Dotaz na opakování
    Console.WriteLine();
    Console.Write("Pro opakování programu stiskněte 'a' a potvrďte Enterem: ");
    again = Console.ReadLine() ?? "";
}
