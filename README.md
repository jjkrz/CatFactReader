# CatFactReader

## Opis projektu
**CatFactReader** to proste REST API napisane w ASP.NET Core 8.0, które pobiera losowe fakty o kotach z zewnętrznego API ([catfact.ninja](https://catfact.ninja)). Każdy pobrany fakt jest zapisywany do pliku `catfacts.txt` i zwracany w odpowiedzi JSON. Projekt wykorzystuje wzorce jak dependency injection, obsługę wyjątków i logowanie z Serilog.

To zadanie rekrutacyjne dla firmy **Netwise**, demonstrujące podstawowe umiejętności w tworzeniu API, integracji z zewnętrznymi usługami oraz dockeryzacji.

## Technologie
- **.NET 8.0** (ASP.NET Core Web API) — framework do budowy aplikacji webowych.
- **HttpClient** — do integracji z zewnętrznym API (catfact.ninja).
- **Serilog** — biblioteka do logowania zdarzeń.
- **Swagger/OpenAPI** — do automatycznej dokumentacji API.
- **Docker** — do konteneryzacji aplikacji.

## Wymagania
- .NET 8.0 SDK
- Docker (opcjonalnie dla konteneryzacji)

## Jak uruchomić aplikację

### Opcja 1: Uruchomienie lokalne (bez Dockera)
1. Przejdź do katalogu z projektem API:
   ```
   cd CatFactReaderApi
   ```

2. Przywróć zależności:
   ```
   dotnet restore
   ```

3. Uruchom aplikację:
   ```
   dotnet run
   ```

4. Otwórz przeglądarkę i przejdź do:
   - **Swagger UI** (dokumentacja API): `https://localhost:7116/swagger` (lub `http://localhost:5174/swagger` jeśli używasz profilu HTTP).
   - Porty są zdefiniowane w `launchSettings.json`. Jeśli porty są zajęte, sprawdź logi w konsoli — ASP.NET Core wyświetli rzeczywiste URL-e.

### Opcja 2: Uruchomienie z Dockerem
1. Przejdź do głównego katalogu projektu:
   ```
   cd CatFactReader
   ```

2. Zbuduj obraz Docker (wskaż ścieżkę do Dockerfile):
   ```
   docker build -f CatFactReaderApi/Dockerfile -t catfactreader .
   ```

3. Uruchom kontener:
   ```
   docker run -p 8080:8080 catfactreader
   ```

4. Otwórz przeglądarkę i przejdź do:
   - **Swagger UI**: `http://localhost:8080/swagger`.
   - **Swagger UI**: `http://localhost:8080/swagger`.

Aplikacja będzie dostępna w kontenerze, co pozwala na łatwe wdrażanie w środowiskach produkcyjnych.

## Użycie API
- Główny endpoint: `POST /cat-facts` — pobiera fakt o kocie i zapisuje go do pliku.
- Przykład testu z curl:
  ```
  curl -X POST https://localhost:7116/cat-facts
  ```
- Odpowiedź JSON zawiera fakt i jego długość.

Więcej szczegółów w kodzie źródłowym lub przez Swagger.

## Struktura projektu
- `CatFactReaderApi/`: Główny kod aplikacji (kontrolery, serwisy, modele).
- `Dockerfile`: Konfiguracja kontenera.
- `catfacts.txt`: Plik z zapisanymi faktami.
