#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TSEP.Api/TSEP.Api.csproj", "TSEP.Api/"]
COPY ["TSEP.StamData.Infrastructor/TSEP.StamData.Infrastructor.csproj", "TSEP.StamData.Infrastructor/"]
COPY ["TSEP.StamData.Application/TSEP.StamData.Application.csproj", "TSEP.StamData.Application/"]
COPY ["TSEP.StamData.Domain/TSEP.StamData.Domain.csproj", "TSEP.StamData.Domain/"]
COPY ["TSEP.SqlDbContext/TSEP.SqlDbContext.csproj", "TSEP.SqlDbContext/"]
COPY ["TSEP.SqlDbContext.Migrations/TSEP.SqlDbContext.Migrations.csproj", "TSEP.SqlDbContext.Migrations/"]
RUN dotnet restore "TSEP.Api/TSEP.Api.csproj"
COPY . .
WORKDIR "/src/TSEP.Api"
RUN dotnet build "TSEP.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TSEP.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TSEP.Api.dll"]