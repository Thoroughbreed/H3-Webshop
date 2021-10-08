# Webshop DB layer

## Webshop for veganske produkter
Dette projekt er første del af en webshop der sælger veganske produkter og har mulighed for et loyalty programme med bl.a. rabatkoder og summering af hvor ofte/meget kunderne bestiller.

### Program oversigt/plan
Programmet er i første omgang bygget op i to lag - et datalayer med dertilhørende models, samt et servicelayer som udfører alle kald.
I anden del af projektet bliver der bygget en webapp frontend på.

Hver ordre får et internt unik ID (int, SQL identity auto increment) samt en UUID som bruges i den faktura som kunden skal modtage (på et senere tidspunkt). I fakturaen får kunden det første segment af det UUID som man senere hen kan bruge til at finde tidligere ordrer med (uden man behøver at logge ind)

Hvis kunden er logget ind (kommer når frontend bliver bygget på) kan kunden samtidig se alle sine tidligere ordrer på en oversigtsside, uden at behøve at søge efter ordre-id'et (UUID)

Kunder bliver oprettet i databasen ved hvert køb, og man kan så tilvælge at oprette en bruger (frontend) så man lettere kan købe flere gange. 

### Service Layer
I servicelayer er der pt. 4 metoder:
- AddUser()
- EditUser()
- DeleteUser()
- AddOrder()

I AddUser() er navn og adresse selvfølgeligt et krav, men telefonnumer er optional

### Unit tests
Der er tilknyttet nogle enkelte unit-tests der tester de kald der er i servicelayer, AddUser(), DeleteUser(), EditUser() og AddOrder()

### Krav
- Microsoft .Net (local)
- Microsoft ASP.Net Razor (til kommende frontend)
- SQL Database

### Installerede NuGet pakker og udvidelser:
|Bibliotek|Version|
|-|-|
|Microsoft.EntityFrameworkCore.SqlServer|5.0.10|
|Microsoft.EntityFrameworkCore.Tools|5.0.10|
|Microsoft.Extensions.Logging.Console|5.0.0|
|Microsoft.EntityFrameworkCore.Design|5.0.10|
|Microsoft.NET.Test.SDK|16.5.0|
|XUnit|2.4.0|
|XUnit.Runner|2.4.0|
---
### Database
Databasen er en MSSQL Express
#### ER Diagram
![ER diagram over databasen](https://github.com/Thoroughbreed/H3-Webshop/blob/feature/ER%20Diagram%20WebShop.png?raw=true)
