# K čemu se hodí ciferný součet a součin

Úvaha k úkolu 005, vymyšlená společně s AI.

## Ciferný součet - má reálné použití

### 1. Kontrolní číslice - Luhnův algoritmus

Luhnův algoritmus kontroluje čísla platebních karet nebo IMEI mobilních telefonů. Zachytí překlep v jedné číslici a většinu prohození dvou sousedních číslic. Je postavený přímo na ciferném součtu:

1. Zprava se každá druhá číslice zdvojnásobí.
2. Když je výsledek dvouciferný, sečtou se jeho cifry (z 7 je 14, z toho 1 + 4 = 5).
3. Sečtou se všechny číslice.
4. Číslo je platné, když je součet dělitelný 10.

Příklad: číslo `79927398713` dá součet 70, je tedy platné. Když se jedna číslice změní, součet už dělitelný 10 nebude.

Podobně fungují kontrolní číslice čárových kódů EAN a knih ISBN. Ty používají **vážený** součet cifer: každá cifra se před sečtením vynásobí svou vahou.

### 2. Dělitelnost 3 a 9

Číslo je dělitelné 3 (nebo 9) právě tehdy, když je jeho ciferný součet dělitelný 3 (nebo 9). Například 357 má ciferný součet 15 a 15 je dělitelné 3, takže i 357 je dělitelné 3 (357 = 3 x 119).

### 3. Zkouška devítkou

Je to stará kontrola ručních výpočtů. Ciferný součet se opakuje, dokud nezbude jedna cifra (ciferný kořen). Ciferný kořen součinu `a x b` musí vyjít stejně jako ciferný kořen součinu ciferných kořenů `a` a `b`. Když nevyjde, je ve výpočtu chyba. Opačně to neplatí: když vyjde, chyba tam pořád být může, třeba prohozené číslice.

## Ciferný součin - prakticky skoro nic

- **Test na nulu:** ciferný součin je 0 právě tehdy, když číslo obsahuje cifru 0. To jde ale zjistit jednodušeji.
- **Multiplikativní perzistence:** kolikrát se musí ciferný součin opakovat, než zbude jedna cifra. Například 39 → 27 → 14 → 4 jsou tři kroky. Je to matematická hříčka bez praktického využití. Nejmenší známé číslo s perzistencí 11 je 277777788888899 a číslo s perzistencí 12 se zatím nenašlo.

## Závěr

Ciferný součet má praktické využití hlavně v **kontrolních číslicích**, protože levně odhalí překlep při ručním opisování čísla. Ciferný součin je spíš cvičení na práci s cyklem a s neutrálním prvkem násobení.
