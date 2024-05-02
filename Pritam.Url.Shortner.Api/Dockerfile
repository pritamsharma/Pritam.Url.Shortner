FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# EXPOSE 7145
# EXPOSE 8081
# EXPOSE 8080
# EXPOSE 6000

# Copy all Solution content to the working directory of build-env
COPY .. .

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release ./Pritam.Url.Shortner.Api/Pritam.Url.Shortner.Api.csproj -o OutLoc

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /App

COPY --from=build-env /App/OutLoc .

ENTRYPOINT ["dotnet", "Pritam.Url.Shortner.Api.dll"]