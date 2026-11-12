// UTF-8 zajistí, že se linka a diakritika zobrazí správně i ve Windows cmd
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Řídicí proměnná pro opakování programu
string again = "a";

// Hlavní smyčka programu: běží znovu, pokud uživatel zadá 'a' nebo 'A'
while (again.ToLower() == "a")
{
    Console.Clear();
    // Hlavička: název programu velkými proloženými písmeny modře, pod ním podpis
    string title = "Ciferný součet a součin";
    string author = "Daniel Čeřovský";
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("  ");
    int width = 0;
    foreach (char c in title.ToUpper())
    {
        if (c == ' ')
        {
            // Mezera mezi slovy je širší než mezera mezi písmeny, aby šla slova přečíst
            Console.Write("  ");
            width = width + 2;
        }
        else
        {
            Console.Write(c + " ");
            width = width + 2;
        }
    }
    Console.WriteLine();

    // Linka i podpis mají stejnou šířku jako název, takže hlavička sedí pro jakýkoli název
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("  " + new string('─', width - 1));
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("  " + ("~ " + author).PadLeft(width - 1));
    Console.ResetColor();
    Console.WriteLine();

    // 1. Bezpečné načtení celého čísla od uživatele
    Console.Write("Zadejte celé číslo: ");
    int number;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.Write("Nezadali jste celé číslo. Zadejte celé číslo znovu: ");
    }

    // 2. Příprava pomocných proměnných pro výpočet
    int numberBackup = number; // Záloha původního čísla pro závěrečný výpis
    int sum = 0;               // Neutrální prvek pro sčítání je 0
    int product = 1;           // Neutrální prvek pro násobení je 1 (s 0 by součin vyšel vždy 0)
    int digit;                // Proměnná pro uložení právě oddělené cifry

    // 3. Ošetření záporných čísel (znaménko nemá vliv na cifry)
    if (number < 0)
    {
        number = -number;
    }

    // 4. Zvláštní případ pro nulu
    if (number == 0)
    {
        sum = 0;
        product = 0;               // Číslo 0 má jedinou cifru 0, součin je tedy 0
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Průběh rozkladu čísla na cifry (zprava doleva):");

        // 5. Matematický rozklad čísla pomocí cyklu
        while (number > 0)
        {
            digit = number % 10;            // Modulo 10 získá poslední číslici
            sum = sum + digit;              // Přičtení cifry k celkovému součtu
            product = product * digit;      // Vynásobení cifrou (cifra 0 udělá ze součinu 0)

            Console.WriteLine($"Získána cifra: {digit}");

            number = number / 10;           // Celočíselné dělení 10 odstraní poslední číslici
        }
    }

    // 6. Výpis výsledků
    Console.WriteLine();
    Console.WriteLine("====================================");
    Console.WriteLine($"Původní číslo:  {numberBackup}");
    Console.WriteLine($"Ciferný součet: {sum}");
    Console.WriteLine($"Ciferný součin: {product}");
    Console.WriteLine("====================================");
    Console.WriteLine();

    // 7. Dotaz na opakování programu
    Console.Write("Pro opakování programu stiskněte 'a' a potvrďte klávesou Enter: ");
    again = Console.ReadLine() ?? "";
}