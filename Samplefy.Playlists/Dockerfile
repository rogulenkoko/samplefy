FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet publish Samplefy.Playlists -c Release -o Samplefy.Playlists/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/Samplefy.Playlists/publish .
ENTRYPOINT ["dotnet", "Samplefy.Playlists.dll"]