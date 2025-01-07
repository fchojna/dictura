# BASE
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# BUILD
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Dictura.Api/Dictura.Api.csproj", "Dictura.Api/"]
COPY ["Dictura.Application/Dictura.Application.csproj", "Dictura.Application/"]
COPY ["Dictura.Domain/Dictura.Domain.csproj", "Dictura.Domain/"]
COPY ["Dictura.Infrastructure/Dictura.Infrastructure.csproj", "Dictura.Infrastructure/"]
RUN dotnet restore "./Dictura.Api/Dictura.Api.csproj"
COPY version.json ./version.json
COPY . .
WORKDIR "/src/Dictura.Api"
RUN dotnet build "./Dictura.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# PUBLISH
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Dictura.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# FINAL
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/version.json ./version.json
ENTRYPOINT ["dotnet", "Dictura.Api.dll"]