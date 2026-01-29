# Eventify – Database First Console App (.NET)

## 🎯 Scenario – Vad bygger vi och varför

Vi har byggt **Eventify**, ett bokningssystem för events och biljetter.

Systemet hanterar:
- Kunder
- Events
- Ordrar
- Biljetter
- Betalningar
- Arenor (venues)

Syftet är att skapa en **realistisk datadriven applikation** där databasen är källan till sanningen.  
Projektet är byggt enligt **Database First-principen**, där databasen designas först och applikationen genereras från databasen.

Vi valde detta scenario eftersom det:
- är realistiskt
- innehåller tydliga relationer
- lämpar sig mycket bra för relationsdatabaser, JOINs och rapporter

---

## 🗄 Hur man kör SQL-filerna i rätt ordning

Alla SQL-filer finns i mappen `/sql`.

Kör dem i följande ordning i **SQL Server Management Studio (SSMS):**

01_create_database.sql  
02_create_tables.sql  
03_seed_data.sql  
04_crud_examples.sql  
05_queries_joins.sql  
06_views.sql  
07_security.sql  

Om du vill rensa databasen helt och börja om:

08_cleanup.sql

---

## ▶ Hur man startar appen

1. Öppna projektet i Visual Studio
2. Starta Console App-projektet
3. Menyn visas automatiskt

---

## 🧭 Hur man använder konsolappen (för användare)

När programmet startar visas huvudmenyn:

==== EVENTIFY ====  
1. List Customers  
2. List Events  
3. Create Order  
4. Buy Ticket  
5. Update Order Status  
6. Delete Order  
7. Reports  
0. Exit  

### 1. List Customers

Visar alla kunder i databasen.  
Används för att se kund-ID inför skapande av order.

### 2. List Events

Visar alla events med titel, datum, plats och pris.  
Används för att se vilka events som finns och välja event vid biljettköp.

### 3. Create Order

Skapar en ny order för en kund.

Flöde:
- Välj kund-ID
- En ny order skapas med status **Pending**

### 4. Buy Ticket

Köper biljett till ett event.

Flöde:
- Välj OrderID
- Välj EventID
- Ange platsnummer (Seat Number)

Programmet skapar:
- Ticket
- OrderRow
- Korrekt koppling mellan order, event och kund

### 5. Update Order Status

Uppdaterar orderstatus.

Tillåtna värden:
- Pending
- Paid
- Cancelled

### 6. Delete Order

Tar bort en order samt alla tillhörande orderrader.

### 7. Reports

Visar rapportmeny:

1. Top Customers  
2. Sales per Event  

Report 1 – Top Customers  
Visar kunder med flest ordrar.

Report 2 – Sales per Event  
Visar total omsättning per event.

---

## 🧪 Exempel på 3–5 menyflöden att testa

Flöde 1 – Skapa order + köp biljett  
3 → välj kund → skapa order  
4 → välj order → välj event → välj plats → biljett skapas  

Flöde 2 – Visa alla events  
2 → listar alla events  

Flöde 3 – Uppdatera orderstatus  
5 → välj order → ändra status till Paid  

Flöde 4 – Visa rapporter  
7 → 1 → Top Customers  
7 → 2 → Sales per Event  

Flöde 5 – Radera order  
6 → välj order → order + orderrader tas bort
