# VideoClubApp

## Structure

```
src/
├── VideoClub.Shared/       # Shared DTOs, Enums, Result<T>
│   ├── DTOs/
│   ├── Enums/
│   └── Result.cs
├── VideoClub.Api/          # Minimal API — entrypoint
│   ├── Features/
│   │   └── Productos/
│   │       ├── Commands/
│   │       ├── Handlers/
│   │       └── Validators/
│   ├── Controllers/
│   ├── Data/
│   │   ├── Entities/           # EF Core entity classes
│   │   ├── Configurations/     # EF Core IEntityTypeConfiguration
│   │   ├── AppDbContext.cs
│   │   └── ServiceCollectionExtensions.cs
│   ├── Middleware/
│   └── Program.cs
└── VideoClub.Client/       # Blazor WASM — entrypoint
    ├── Components/
    ├── Layout/
    ├── Pages/
    ├── Services/
    │   ├── Http/
    │   └── Interfaces/
    └── Program.cs
```

## Projects

| Project | TFM | Type | URL |
|---|---|---|---|
| `VideoClub.Api` | net10.0 | Minimal API | http://localhost:5144, OpenAPI UI at `/openapi-ui` |
| `VideoClub.Client` | net10.0 | Blazor WASM | WASM host |
| `VideoClub.Shared` | net10.0 | Class library | — |

- **Clean Architecture:** Client → Shared, Api → Shared. Client must not reference DB concerns. Shared stays dependency-free.

## Architecture conventions (intended)

- **CQRS:** Every Command/Query must have a corresponding Handler.
- **Validation:** `FluentValidation` in `PipelineBehaviors`.
- **Errors:** Return `ProblemDetails` (RFC 7807) or `Result<T>`.
- **Mapping:** `AutoMapper` for Shared DTOs → internal commands.
- **Security:** JWT middleware on the API.
- **DB:** PostgreSQL + Entity Framework Core via Npgsql. All DB code in `Data/`.
- **Client services:** Inject interfaces (`IProductService`), never `HttpClient` directly in components.
- **Client auth:** `DelegatingHandler` for automatic JWT injection.
- **UI:** Reusable components in `Components/`, page logic in `Pages/`. Use MudBlazor layout (`MudLayout`, `MudDrawer`, `MudAppBar`) over standard Blazor layout.
- **Client validation:** `MudForm` + `FluentValidation`, consistent with server.
- **Client icons:** `MudBlazor.Icons`.

## Commands

```powershell
# Start PostgreSQL
docker compose up -d

# Build all
dotnet build .\VideoClubApp.sln

# Run API
dotnet run --project .\src\VideoClub.Api

# Run client (requires API running)
dotnet run --project .\src\VideoClub.Client

# EF Core migrations
dotnet ef migrations add InitialCreate --project .\src\VideoClub.Api
dotnet ef database update --project .\src\VideoClub.Api
```

- No test projects exist yet.
- No CI/CD, no pre-commit hooks, no lint/formatter config beyond .NET defaults.

## Installed skills (`.agents/skills/`)

- `blazor-expert` — Blazor/MudBlazor conventions
- `dotnet-architect` — Clean Architecture guidance
- `dotnet-backend-patterns` — CQRS, MediatR, FluentValidation patterns
- `postgresql-table-design` — PostgreSQL schema design
