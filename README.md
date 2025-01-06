# MyTeams

**Aplikacja do zarządzania członkami zespołu**

Aplikacja umożliwia:
- Dodawanie nowego zespołu.
- Dodawanie, edycję oraz zmianę statusu członków zespołu.

## Treść zadania rekrutacyjnego

Należy utworzyć serwer Web API napisany w języku C# przy użyciu najnowszej wersji platformy .NET. Aplikacja powinna zostać podzielona na projekty zgodnie z Clean Architecture. Komunikacja z API powinna odbywać się przy użyciu protokołu HTTP, stosując zasady RESTful API. Autoryzacja nie jest wymagana.

Wymagania:
1. Aplikacja powinna wykorzystywać mediatora do implementacji wzorca CQRS. Część związana z odczytem nie musi posiadać własnej bazy danych, jednak idealna implementacja będzie wyżej punktowana.
2. Aplikacja powinna implementować wzorzec DDD.
3. Do obsługi zapisu danych należy wykorzystać Entity Framework Core, a jako silnik danych PostgreSQL.

## Jak uruchomić aplikację?

### 1. Klonowanie repozytorium

Najpierw sklonuj to repozytorium:
```bash
git clone https://github.com/Radek128/MyTeams.git
cd MyTeams
```

### 2. Podłączenie bazy danych

Uruchom kontener PostgreSQL:
```bash
docker-compose up -d
```

### 3. Uruchomienie aplikacji

Aplikację można uruchomić na dwa sposoby:

#### a) Z użyciem IDE
1. Otwórz projekt w preferowanym IDE (np. Visual Studio, Visual Studio Code).
2. Skonfiguruj środowisko (jeśli to konieczne).
3. Kliknij **Start** lub użyj skrótu `F5`, aby uruchomić aplikację.

#### b) Z poziomu terminala
1. Otwórz terminal (cmd, PowerShell, Terminal itp.).
2. Przejdź do katalogu, w którym znajduje się plik projektu.
3. Wpisz polecenie:
```bash
dotnet run
```

## Przykłady zapytań do API

### Endpointy

#### Teams:
- **Dodawanie zespołu** (POST): `http://localhost:5001/teams`
  - Body:
    ```json
    {
      "teamId": "?",
      "name": "string"
    }
    ```
- **Pobranie zespołu** (GET): `http://localhost:5001/teams/{teamId:guid}`

#### Members:
- **Pobranie członka zespołu** (GET): `http://localhost:5001/teams/members/{memberId}`
- **Lista członków zespołu** (GET): `http://localhost:5001/teams/{teamId}/members`
- **Dodawanie członka** (POST): `http://localhost:5001/teams/{teamId}/members`
  - Body:
    ```json
    {
      "teamId": "string",
      "avatar": "string",
      "isActive": "boolean",
      "firstName": "string",
      "lastName": "string",
      "email": "string",
      "phoneNumber": "string",
      "memberId": "?"
    }
    ```
- **Aktualizacja członka** (PUT): `http://localhost:5001/teams/members/{memberId}`
  - Body:
    ```json
    {
      "firstName": "string",
      "lastName": "string",
      "email": "string",
      "phoneNumber": "string",
      "memberId": "string"
    }
    ```
- **Zmiana statusu członka** (PUT): `http://localhost:5001/teams/members/{memberId}/status`
  - Body:
    ```json
    {
      "isActiveStatus": "boolean",
      "memberId": "string"
    }
    ```

---

# MyTeams

**Application for managing team members**

The application allows:
- Adding a new team.
- Adding, editing, and changing the status of team members.

## Recruitment Task Description

Create a Web API server written in C# using the latest .NET platform. The application should be structured into projects according to Clean Architecture. Communication with the API should use the HTTP protocol following RESTful API principles. Authorization is not required.

Requirements:
1. The application should use a mediator to implement the CQRS pattern. The read part does not need its own database, but an ideal implementation will score higher.
2. The application should implement the DDD pattern.
3. Data storage should use Entity Framework Core with PostgreSQL as the database engine.

## How to Run the Application?

### 1. Clone the Repository

First, clone this repository:
```bash
git clone https://github.com/Radek128/MyTeams.git
cd MyTeams
```

### 2. Connect the Database

Start the PostgreSQL container:
```bash
docker-compose up -d
```

### 3. Run the Application

You can run the application in two ways:

#### a) Using an IDE
1. Open the project in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
2. Configure the environment if necessary.
3. Click **Start** or use the `F5` shortcut to start the application.

#### b) From the Terminal
1. Open a terminal (cmd, PowerShell, Terminal, etc.).
2. Navigate to the directory where the project file is located.
3. Run the following command:
```bash
dotnet run
```

## API Query Examples

### Endpoints

#### Teams:
- **Add a Team** (POST): `http://localhost:5001/teams`
  - Body:
    ```json
    {
      "teamId": "?",
      "name": "string"
    }
    ```
- **Get a Team** (GET): `http://localhost:5001/teams/{teamId:guid}`

#### Members:
- **Get a Member** (GET): `http://localhost:5001/teams/members/{memberId}`
- **List Team Members** (GET): `http://localhost:5001/teams/{teamId}/members`
- **Add a Member** (POST): `http://localhost:5001/teams/{teamId}/members`
  - Body:
    ```json
    {
      "teamId": "string",
      "avatar": "string",
      "isActive": "boolean",
      "firstName": "string",
      "lastName": "string",
      "email": "string",
      "phoneNumber": "string",
      "memberId?": "guid"
    }
    ```
- **Update a Member** (PUT): `http://localhost:5001/teams/members/{memberId}`
  - Body:
    ```json
    {
      "firstName": "string",
      "lastName": "string",
      "email": "string",
      "phoneNumber": "string",
      "memberId": "string"
    }
    ```
- **Change Member Status** (PUT): `http://localhost:5001/teams/members/{memberId}/status`
  - Body:
    ```json
    {
      "isActiveStatus": "boolean",
      "memberId": "string"
    }
    ```


