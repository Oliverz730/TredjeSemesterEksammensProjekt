#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TSEP.App/TSEP.App.csproj", "TSEP.App/"]
COPY ["TSEP.UserDbContext/TSEP.UserDbContext.csproj", "TSEP.UserDbContext/"]
COPY ["TSEP.UserDbMigration/TSEP.UserDbMigration.csproj", "TSEP.UserDbMigration/"]
RUN dotnet restore "TSEP.App/TSEP.App.csproj"
COPY . .
WORKDIR "/src/TSEP.App"
RUN dotnet build "TSEP.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TSEP.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TSEP.App.dll"]