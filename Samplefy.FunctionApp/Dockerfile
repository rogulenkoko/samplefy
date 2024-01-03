FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR app

COPY . ./
RUN dotnet publish -o Samplefy.FunctionApp/publish

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4.0-dotnet-isolated6.0-appservice
FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4-dotnet-isolated7.0
ENV AzureWebJobsScriptRoot=Samplefy.FunctionApp/publish \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=build ["app/Samplefy.FunctionApp/publish", "app/Samplefy.FunctionApp/publish"]