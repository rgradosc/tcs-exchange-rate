#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/TCSExchangeRateAPI.Services.WebAPI/TCSExchangeRateAPI.Services.WebAPI.csproj", "src/Services/TCSExchangeRateAPI.Services.WebAPI/"]
COPY ["src/Application/TCSExchangeRateAPI.Application.Interfaces/TCSExchangeRateAPI.Application.Interfaces.csproj", "src/Application/TCSExchangeRateAPI.Application.Interfaces/"]
COPY ["src/Transversal/TCSExchangeRateAPI.Transversal.Common/TCSExchangeRateAPI.Transversal.Common.csproj", "src/Transversal/TCSExchangeRateAPI.Transversal.Common/"]
COPY ["src/Application/TCSExchangeRateAPI.Application.DTO/TCSExchangeRateAPI.Application.DTO.csproj", "src/Application/TCSExchangeRateAPI.Application.DTO/"]
COPY ["src/Application/TCSExchangeRateAPI.Application.Main/TCSExchangeRateAPI.Application.Main.csproj", "src/Application/TCSExchangeRateAPI.Application.Main/"]
COPY ["src/Domain/TCSExchangeRateAPI.Domain.Entity/TCSExchangeRateAPI.Domain.Entity.csproj", "src/Domain/TCSExchangeRateAPI.Domain.Entity/"]
COPY ["src/Domain/TCSExchangeRateAPI.Domain.Interfaces/TCSExchangeRateAPI.Domain.Interfaces.csproj", "src/Domain/TCSExchangeRateAPI.Domain.Interfaces/"]
COPY ["src/Domain/TCSExchangeRateAPI.Domain.Core/TCSExchangeRateAPI.Domain.Core.csproj", "src/Domain/TCSExchangeRateAPI.Domain.Core/"]
COPY ["src/Infrastructure/TCSExchangeRateAPI.Infrastructure.Interfaces/TCSExchangeRateAPI.Infrastructure.Interfaces.csproj", "src/Infrastructure/TCSExchangeRateAPI.Infrastructure.Interfaces/"]
COPY ["src/Infrastructure/TCSExchangeRateAPI.Infrastructure.Data/TCSExchangeRateAPI.Infrastructure.Data.csproj", "src/Infrastructure/TCSExchangeRateAPI.Infrastructure.Data/"]
COPY ["src/Infrastructure/TCSExchangeRateAPI.Infrastructure.Repository/TCSExchangeRateAPI.Infrastructure.Repository.csproj", "src/Infrastructure/TCSExchangeRateAPI.Infrastructure.Repository/"]
COPY ["src/Transversal/TCSExchangeRateAPI.Transversal.Logging/TCSExchangeRateAPI.Transversal.Logging.csproj", "src/Transversal/TCSExchangeRateAPI.Transversal.Logging/"]
COPY ["src/Transversal/TCSExchangeRateAPI.Transversal.Mapper/TCSExchangeRateAPI.Transversal.Mapper.csproj", "src/Transversal/TCSExchangeRateAPI.Transversal.Mapper/"]
RUN dotnet restore "src/Services/TCSExchangeRateAPI.Services.WebAPI/TCSExchangeRateAPI.Services.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Services/TCSExchangeRateAPI.Services.WebAPI"
RUN dotnet build "TCSExchangeRateAPI.Services.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCSExchangeRateAPI.Services.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN ln -fs /usr/share/zoneinfo/America/Lima /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata

ENTRYPOINT ["dotnet", "TCSExchangeRateAPI.Services.WebAPI.dll"]