#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["dockcon/dockcon.csproj", "dockcon/"]
RUN dotnet restore "dockcon/dockcon.csproj"
COPY . .
WORKDIR "/src/dockcon"
RUN dotnet build "dockcon.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dockcon.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dockcon.dll"]