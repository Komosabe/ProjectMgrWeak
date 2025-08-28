# ===== BUILD =====
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Pliki csproj (cache restore)
COPY CarWorkshop.sln ./
COPY CarWorkshop.MVC/CarWorkshop.MVC.csproj CarWorkshop.MVC/
COPY CarWorkshop.Application/CarWorkshop.Application.csproj CarWorkshop.Application/
COPY CarWorkshop.Domain/CarWorkshop.Domain.csproj CarWorkshop.Domain/
COPY CarWorkshop.Infrastructure/CarWorkshop.Infrastructure.csproj CarWorkshop.Infrastructure/

RUN dotnet restore CarWorkshop.MVC/CarWorkshop.MVC.csproj

# Reszta źródeł i publish
COPY . ./
RUN dotnet publish CarWorkshop.MVC/CarWorkshop.MVC.csproj -c Release -o /app/publish /p:UseAppHost=false

# ===== RUNTIME =====
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CarWorkshop.MVC.dll"]
