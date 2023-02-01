#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SRG_SYSTEM/SRG_SYSTEM.csproj", "SRG_SYSTEM/"]
RUN dotnet restore "SRG_SYSTEM/SRG_SYSTEM.csproj"
COPY . .
WORKDIR "/src/SRG_SYSTEM"
RUN dotnet build "SRG_SYSTEM.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SRG_SYSTEM.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SRG_SYSTEM.dll"]