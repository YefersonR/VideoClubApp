# ─────────────────────────────────────────────
# Stage 1: Build
# ─────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar archivos de proyecto para restaurar dependencias
COPY ["src/VideoClub.Client/VideoClub.Client.csproj", "VideoClub.Client/"]
COPY ["src/VideoClub.Shared/VideoClub.Shared.csproj", "VideoClub.Shared/"]

# Restaurar dependencias
RUN dotnet restore "VideoClub.Client/VideoClub.Client.csproj"

# Copiar el resto del código fuente
COPY src/VideoClub.Client/ VideoClub.Client/
COPY src/VideoClub.Shared/ VideoClub.Shared/

# Publicar la aplicación en modo Release
WORKDIR /src/VideoClub.Client
RUN dotnet publish "VideoClub.Client.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

# ─────────────────────────────────────────────
# Stage 2: Serve (Nginx)
# ─────────────────────────────────────────────
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html

# Limpiar contenido default de Nginx
RUN rm -rf ./*

# Copiar los archivos publicados de Blazor WASM
COPY --from=build /app/publish/wwwroot .

# Copiar configuración personalizada de Nginx
COPY src/VideoClub.Client/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

ENTRYPOINT ["nginx", "-g", "daemon off;"]

