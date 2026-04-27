FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files first for layer caching
COPY AlblueMES.sln ./
COPY AlblueMES.API/AlblueMES.API.csproj AlblueMES.API/
COPY src/BuildingBlocks/AlblueMES.BuildingBlocks.Common/AlblueMES.BuildingBlocks.Common.csproj src/BuildingBlocks/AlblueMES.BuildingBlocks.Common/
COPY src/BuildingBlocks/AlblueMES.BuildingBlocks.EventBus/AlblueMES.BuildingBlocks.EventBus.csproj src/BuildingBlocks/AlblueMES.BuildingBlocks.EventBus/
COPY src/Modules/Tenancy/AlblueMES.Modules.Tenancy.Domain/AlblueMES.Modules.Tenancy.Domain.csproj src/Modules/Tenancy/AlblueMES.Modules.Tenancy.Domain/
COPY src/Modules/Tenancy/AlblueMES.Modules.Tenancy.Application/AlblueMES.Modules.Tenancy.Application.csproj src/Modules/Tenancy/AlblueMES.Modules.Tenancy.Application/
COPY src/Modules/Tenancy/AlblueMES.Modules.Tenancy.Infrastructure/AlblueMES.Modules.Tenancy.Infrastructure.csproj src/Modules/Tenancy/AlblueMES.Modules.Tenancy.Infrastructure/
COPY src/Modules/Tenancy/AlblueMES.Modules.Tenancy.Api/AlblueMES.Modules.Tenancy.Api.csproj src/Modules/Tenancy/AlblueMES.Modules.Tenancy.Api/
COPY src/Modules/Identity/AlblueMES.Modules.Identity.Domain/AlblueMES.Modules.Identity.Domain.csproj src/Modules/Identity/AlblueMES.Modules.Identity.Domain/
COPY src/Modules/Identity/AlblueMES.Modules.Identity.Application/AlblueMES.Modules.Identity.Application.csproj src/Modules/Identity/AlblueMES.Modules.Identity.Application/
COPY src/Modules/Identity/AlblueMES.Modules.Identity.Infrastructure/AlblueMES.Modules.Identity.Infrastructure.csproj src/Modules/Identity/AlblueMES.Modules.Identity.Infrastructure/
COPY src/Modules/Identity/AlblueMES.Modules.Identity.Api/AlblueMES.Modules.Identity.Api.csproj src/Modules/Identity/AlblueMES.Modules.Identity.Api/
COPY src/Modules/Production/AlblueMES.Modules.Production.Domain/AlblueMES.Modules.Production.Domain.csproj src/Modules/Production/AlblueMES.Modules.Production.Domain/
COPY src/Modules/Production/AlblueMES.Modules.Production.Application/AlblueMES.Modules.Production.Application.csproj src/Modules/Production/AlblueMES.Modules.Production.Application/
COPY src/Modules/Production/AlblueMES.Modules.Production.Infrastructure/AlblueMES.Modules.Production.Infrastructure.csproj src/Modules/Production/AlblueMES.Modules.Production.Infrastructure/
COPY src/Modules/Production/AlblueMES.Modules.Production.Api/AlblueMES.Modules.Production.Api.csproj src/Modules/Production/AlblueMES.Modules.Production.Api/
COPY src/Modules/Orders/AlblueMES.Modules.Orders.Domain/AlblueMES.Modules.Orders.Domain.csproj src/Modules/Orders/AlblueMES.Modules.Orders.Domain/
COPY src/Modules/Orders/AlblueMES.Modules.Orders.Application/AlblueMES.Modules.Orders.Application.csproj src/Modules/Orders/AlblueMES.Modules.Orders.Application/
COPY src/Modules/Orders/AlblueMES.Modules.Orders.Infrastructure/AlblueMES.Modules.Orders.Infrastructure.csproj src/Modules/Orders/AlblueMES.Modules.Orders.Infrastructure/
COPY src/Modules/Orders/AlblueMES.Modules.Orders.Api/AlblueMES.Modules.Orders.Api.csproj src/Modules/Orders/AlblueMES.Modules.Orders.Api/

RUN dotnet restore

# Copy everything and build
COPY . .
RUN dotnet publish AlblueMES.API/AlblueMES.API.csproj -c Release -o /app/publish --no-restore

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

RUN mkdir -p /app/uploads

# Render uses PORT env var
ENV ASPNETCORE_URLS=http://+:${PORT:-10000}
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 10000

ENTRYPOINT ["dotnet", "AlblueMES.API.dll"]
