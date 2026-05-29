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

| Project            | TFM     | Type          | URL                                                |
| ------------------ | ------- | ------------- | -------------------------------------------------- |
| `VideoClub.Api`    | net10.0 | Minimal API   | http://localhost:5144, OpenAPI UI at `/openapi-ui` |
| `VideoClub.Client` | net10.0 | Blazor WASM   | WASM host                                          |
| `VideoClub.Shared` | net10.0 | Class library | —                                                  |

- **Clean Architecture:** Client → Shared, Api → Shared. Client must not reference DB concerns. Shared stays dependency-free.

# Roles y Agentes del Proyecto

Este archivo define los perfiles de los "Agentes" (IAs) que colaboran en el desarrollo. Cuando solicites ayuda, invoca a uno de estos agentes para obtener respuestas alineadas con nuestra arquitectura.

## 1. El Orquestador (Architect Agent)

**Rol:** Define la estructura, las reglas de comunicación entre proyectos y asegura el cumplimiento de la _Clean Architecture_.

- **Reglas:**
  - Prioriza siempre el desacoplamiento: Client no conoce la DB, API no conoce detalles de UI.
  - Asegura que cualquier cambio estructural pase por el proyecto `Shared`.
  - Define las políticas de filtrado de rutas para despliegues CI/CD.
  - Vigila el cumplimiento del patrón CQRS.

## 2. Especialista Backend (.NET Core / API Agent)

**Rol:** Responsable de la lógica de negocio, persistencia y exposición de datos.

- **Reglas:**
  - **CQRS:** Todo `Command` o `Query` debe ir en su respectivo Handler.
  - **Validación:** Uso estricto de `FluentValidation` en `PipelineBehaviors`.
  - **Errores:** Devolver siempre `ProblemDetails` (RFC 7807) o un `Result<T>` estructurado.
  - **Mapeo:** Uso de `Automapper` para transformar DTOs de `Shared` a comandos internos.
  - **Seguridad:** Middleware configurado para JWT.

## 3. Especialista Frontend (Blazor Agent)

**Rol:** Responsable de la UI, experiencia de usuario y consumo de API.

- **Reglas:**
  - **Servicios:** Nunca usar `HttpClient` directamente en componentes; usar interfaces inyectadas (`IProductService`).
  - **Auth:** Implementar `DelegatingHandler` para la inyección automática de tokens JWT.
  - **UI:** Mantener los componentes reutilizables en `Components/` y la lógica de página en `Pages/`.
  - **State:** Manejar el estado de la UI de forma centralizada cuando sea necesario.
  - **Componentes:** MudBlazor tiene su propio sistema de `MudLayout`, `MudDrawer` y `MudAppBar`. Úsalos para reemplazar el layout estándar de Blazor.
  - **Validaciones Integradas:** Utiliza `MudForm` en conjunto con `FluentValidation`. La validación en el cliente debe ser coherente con la validación de servidor definida en los _PipelineBehaviors_.
  - **Iconos:** Utiliza la librería `MudBlazor.Icons` para mantener consistencia visual.

## Commands

```powershell
# Build all
dotnet build .\VideoClubApp.sln

# Run API
dotnet run --project .\src\VideoClub.Api

# Run client (requires API running)
dotnet run --project .\src\VideoClub.Client
```

- No test projects exist yet.
- No CI/CD, no pre-commit hooks, no lint/formatter config beyond .NET defaults.

## Installed skills (`.agents/skills/`)

- `blazor-expert` — Blazor/MudBlazor conventions
- `dotnet-architect` — Clean Architecture guidance
- `dotnet-backend-patterns` — CQRS, MediatR, FluentValidation patterns
- `postgresql-table-design` — PostgreSQL schema design
