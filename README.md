# Webshop DB layer

## Webshop for veganske produkter
Dette projekt er en webshop der sælger veganske produkter og har mulighed for et loyalty programme med bl.a. rabatkoder og summering af hvor ofte/meget kunderne bestiller.

### Program oversigt/plan
Programmet er i tre lag - et datalayer med dertilhørende models, samt et servicelayer som udfører alle kald. Oven på disse er der hhv. en CLI (brugt til test, kan bruges af shop admin) samt en web frontend i Razor Pages (ASP.Net)

Hver ordre får et internt unik ID (int, SQL identity auto increment) samt en UUID som bruges i den faktura som kunden skal modtage (på et senere tidspunkt). I fakturaen får kunden det første segment af det UUID som man senere hen kan bruge til at finde tidligere ordrer med (uden man behøver at logge ind)
Dette UUID bliver også brugt på admin-siden til at identificerer de igangværende ordrer

Kunder bliver oprettet i databasen ved hvert køb, og man kan så tilvælge at oprette en bruger så man lettere kan købe flere gange. 

SKU er "Stock keeping unit" og er en intern "kode" per produkt der bliver brugt på lageret. Den bliver bl.a. også brugt til at identificere produktbilledet med i frontend

#### Class diagram
![ER diagram over klasser](https://github.com/Thoroughbreed/H3-Webshop/blob/master/Webshop_Class_Diagram.png?raw=true)

### Service Layer
Servicelayer er bygget op i to niveauer, en ShopService og en AdminService

I ShopService er alle de funktioner der kræves til shoppen, hvor der i AdminService er de dele der er nødvendig for administrationsdelen af siden (f.eks. CRUD metoder m.m.)

### Unit tests
Der er tilknyttet nogle enkelte unit-tests der tester de kald der er i servicelayer, AddUser(), DeleteUser(), EditUser() og AddOrder()

### Krav
#### Krav til forsiden
[x]Forsiden viser et antal produkter med et billede af hver, prisen, navn og en knap til at lægge varen i kurven
[x]Der benyttes Paging således at forsiden kun viser et bestemt antal produkter ad gangen. Man kan se at der evt. er flere produkter
[x]Der er mulighed for at søge på "Brand" og på "Type" eller lignende
[x]Der er også fritekst-søgning
[x]Der er mulighed for stigende og faldende sortering
[x]Der vises et ikon med en varekurv og et antal varer i kurven. Klikkes på ikonet, vises varekurven
[x]Lægges en vare i kurven, vises den opdaterede varekurv

#### Krav til varekurven
[ ]Varekurven viser en opdateret liste af valgte produkter, med billede, navn, styk-pris, antal (skal kunne ændres) samt linjepriseen.
[ ]Der skal være en Update knap, som opdaterer priserne hvis man ændrer antallet.
[x]Det skal være muligt at fjerne et produkt fra varekurven, hvis man fortryder valget
[x]Der skal være en Checkout knap, som fører til Checkout-siden
[ ]Der skal være en knap, der giver mulighed for at fortsætte med at handle, inden man går til checkout
*Der er intet billede i kurven, da jeg ikke synes det passede ind. Dertil er der heller ikke en update eller tilbage knap da det ikke gav meningen når siden opdaterer løbende og ikke kun ved refresh*

#### Krav til checkout
[x]Brugeren skal afgive oplysninger om email, navn, adresse, valg af betalingsmiddel og forsendelse
[ ]Når brugeren trykke på Køb knappen, skal der udsendes en mail som bekræftelse af købet
*Jeg prøvede flere gange jf. guiden hos Microsoft Docs, men jeg fik aldrig mail til at virke*

#### Administration
[x]En Admin side, der giver en administrator en liste over alle produkter 
[x]Admin siden skal have mulighed for at redigere produkterne og deres data.
[x]Der er fokus på at demonstrere update og delete af en graf af data.

#### Optionelle krav til applikationen
[ ]Forsiden viser "featured" produkter
[x]Når musen passerer henover et billede af et produkt, fremhæves billedet (evt. med en skygge eller ramme)
[ ]Mulighed for at logge ind, f.eks. når man går til Checkout. 
[ ]Hvis brugeren er logget ind, slipper brugeren for at registrere sig igen
[ ]Når brugeren er logget ind, vises produkter som anses for at være interessante for netop denne kunde, baseret på en profil

#### Andre krav til design og implementation
[x]Designet laves således at det opfylder best practice indenfor databasedesign
[x]Der benyttes Entity Framework Core
[x]Der foretages en funktionstest, der viser at de funktionelle krav er opfyldt
[x]Der skal indbygges en Logging facilitet (f.eks. NLog)
[x]Der skal indbygges exception handling.

### Installerede NuGet pakker og udvidelser:
|Bibliotek|Version|
|-|-|
|Microsoft.AspNet.WebPages|3.2.7|
|Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation|5.0.10|
|Microsoft.EntityFrameworkCore.Design|5.0.11|
|Microsoft.VisualStudio.Web.BrowserLink|2.2.0|
|Microsoft.NET.Test.SDK|16.5.0|
|XUnit|2.4.0|
|XUnit.Runner|2.4.0|
|Microsoft.EntityFrameworkCore.SqlServer|5.0.10|
|Microsoft.EntityFrameworkCore.Tools|5.0.10|
|Microsoft.Extensions.Logging.Console|5.0.0|
---
### Database
Databasen er en MSSQL Express
#### ER Diagram
![ER diagram over databasen](https://github.com/Thoroughbreed/H3-Webshop/blob/master/ER%20Diagram%20WebShop.png?raw=true)
