#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/SimmonsVoss.RegistrationApp.HttpApi.Host/SimmonsVoss.RegistrationApp.HttpApi.Host.csproj", "src/SimmonsVoss.RegistrationApp.HttpApi.Host/"]
COPY ["src/SimmonsVoss.RegistrationApp.Application/SimmonsVoss.RegistrationApp.Application.csproj", "src/SimmonsVoss.RegistrationApp.Application/"]
COPY ["src/SimmonsVoss.RegistrationApp.Domain/SimmonsVoss.RegistrationApp.Domain.csproj", "src/SimmonsVoss.RegistrationApp.Domain/"]
COPY ["src/SimmonsVoss.RegistrationApp.Domain.Shared/SimmonsVoss.RegistrationApp.Domain.Shared.csproj", "src/SimmonsVoss.RegistrationApp.Domain.Shared/"]
COPY ["src/SimmonsVoss.RegistrationApp.Application.Contracts/SimmonsVoss.RegistrationApp.Application.Contracts.csproj", "src/SimmonsVoss.RegistrationApp.Application.Contracts/"]
COPY ["src/SimmonsVoss.RegistrationApp.EntityFrameworkCore/SimmonsVoss.RegistrationApp.EntityFrameworkCore.csproj", "src/SimmonsVoss.RegistrationApp.EntityFrameworkCore/"]
COPY ["src/SimmonsVoss.RegistrationApp.HttpApi/SimmonsVoss.RegistrationApp.HttpApi.csproj", "src/SimmonsVoss.RegistrationApp.HttpApi/"]
RUN dotnet restore "src/SimmonsVoss.RegistrationApp.HttpApi.Host/SimmonsVoss.RegistrationApp.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/SimmonsVoss.RegistrationApp.HttpApi.Host"
RUN dotnet build "SimmonsVoss.RegistrationApp.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimmonsVoss.RegistrationApp.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimmonsVoss.RegistrationApp.HttpApi.Host.dll"]