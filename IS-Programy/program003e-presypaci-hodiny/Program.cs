// UTF-8 zajistí, že se linka a diakritika zobrazí správně i ve Windows cmd
Console.OutputEncoding = System.Text.Encoding.UTF8;

string again = "a";

while (again.ToLower() == "a")
{
    Console.Clear();
    // Hlavička: název programu velkými proloženými písmeny modře, pod ním podpis
    string title = "Přesýpací hodiny";
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
    Console.Write("Zadejte velikost hodin (celé číslo alespoň 2): ");
    int size;
    while (!int.TryParse(Console.ReadLine(), out size) || size < 2)
    {
        Console.Write("Velikost musí být celé číslo alespoň 2. Zadejte znovu: ");
    }

    Console.WriteLine();

    // 2. Vnořený cyklus přes čtverec size x size, řádky i sloupce číslujeme od 0 jako na obrázku ze zadání
    // Vnější cyklus počítá řádky (shora dolů)
    for (int i = 0; i < size; i++)
    {
        // Vnitřní cyklus prochází sloupce v aktuálním řádku (zleva doprava)
        for (int j = 0; j < size; j++)
        {
            // Obrazec 19 ze zadání: každý řádek je vyplněný mezi dvěma úhlopříčkami.
            // Na řádku i leží úhlopříčky ve sloupcích i a size - 1 - i. V horní polovině je
            // levá hranice i, v dolní polovině se role prohodí, proto Math.Min a Math.Max.
            int left = Math.Min(i, size - 1 - i);
            int right = Math.Max(i, size - 1 - i);
            if (j >= left && j <= right)
            {
                Console.Write("* ");
            }
            else
            {
                // Mezera místo hvězdičky drží ostatní hvězdičky na správném místě
                Console.Write("  ");
            }
        }

        // Konec řádku -> přesun kurzoru na nový řádek
        Console.WriteLine();
    }

    // Dotaz na opakování
    Console.WriteLine();
    Console.Write("Pro opakování programu stiskněte 'a' a potvrďte Enterem: ");
    again = Console.ReadLine() ?? "";
}
