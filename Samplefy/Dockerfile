FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet publish Samplefy -c Release -o Samplefy/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/Samplefy/publish .
ENTRYPOINT ["dotnet", "Samplefy.dll"]