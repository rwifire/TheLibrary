FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TheLibrary.API.Core/TheLibrary.API.Core.csproj", "TheLibrary.API.Core/"]
RUN dotnet restore "TheLibrary.API.Core/TheLibrary.API.Core.csproj"
COPY . .
WORKDIR "/src/TheLibrary.API.Core"
RUN dotnet build "TheLibrary.API.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheLibrary.API.Core.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheLibrary.API.Core.dll"]
