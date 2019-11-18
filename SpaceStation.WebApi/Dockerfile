FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SpaceStation.WebApi/SpaceStation.WebApi.csproj", "SpaceStation.WebApi/"]
RUN dotnet restore "SpaceStation.WebApi/SpaceStation.WebApi.csproj"
COPY . .
WORKDIR "/src/SpaceStation.WebApi"
RUN dotnet build "SpaceStation.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceStation.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceStation.WebApi.dll"]