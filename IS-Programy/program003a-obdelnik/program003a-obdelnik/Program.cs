// UTF-8 zajistí, že se linka a diakritika zobrazí správně i ve Windows cmd
Console.OutputEncoding = System.Text.Encoding.UTF8;

string again = "a";

while (again.ToLower() == "a")
{
    Console.Clear();
    // Hlavička: název programu velkými proloženými písmeny modře, pod ním podpis
    string title = "Vykreslení obdélníku";
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

    // 1. Bezpečné načtení šířky s kontrolou na kladnou hodnotu
    Console.Write("Zadejte šířku obrazce (přirozené číslo): ");
    int width;
    while (!int.TryParse(Console.ReadLine(), out width) || width <= 0)
    {
        Console.Write("Šířka musí být celé kladné číslo větší než 0. Zadejte znovu: ");
    }

    // 2. Bezpečné načtení výšky s kontrolou na kladnou hodnotu
    Console.Write("Zadejte výšku obrazce (přirozené číslo): ");
    int height;
    while (!int.TryParse(Console.ReadLine(), out height) || height <= 0)
    {
        Console.Write("Výška musí být celé kladné číslo větší než 0. Zadejte znovu: ");
    }

    Console.WriteLine();
    Console.WriteLine($"Vykresluji obrazec o rozměrech {width} × {height}:");
    Console.WriteLine();

    // 3. Jádro algoritmu: Vnořený cyklus pro 2D rastr
    // Vnější cyklus počítá řádky (shora dolů)
    for (int i = 1; i <= height; i++)
    {
        // Vnitřní cyklus sází sloupce v aktuálním řádku (zleva doprava)
        for (int j = 1; j <= width; j++)
        {
            Console.Write("* ");
            System.Threading.Thread.Sleep(System.TimeSpan.FromMilliseconds(100)); // Efekt animace vykreslování
        }

        // Konec řádku -> přesun kurzoru na nový řádek
        Console.WriteLine();
    }

    // 4. Dotaz na opakování
    Console.WriteLine();
    Console.Write("Pro opakování programu stiskněte 'a' a potvrďte Enterem: ");
    again = Console.ReadLine() ?? "";
}
