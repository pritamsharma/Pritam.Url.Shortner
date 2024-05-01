#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#
#ARG BUILD_CONFIGURATION=Relea
#
#WORKDIR /src
#
#COPY ["Pritam.Url.Shortner.Api/Pritam.Url.Shortner.Api.csproj", "Pritam.Url.Shortner.Api/"]
#COPY ["Pritam.Url.Shortner.Application/Pritam.Url.Shortner.Application.csproj", "Pritam.Url.Shortner.Application/"]
#COPY ["Pritam.Url.Shortner.Domain/Pritam.Url.Shortner.Domain.csproj", "Pritam.Url.Shortner.Domain/"]
#COPY ["Pritam.Url.Shortner.Interface/Pritam.Url.Shortner.Interface.csproj", "Pritam.Url.Shortner.Interface/"]
#COPY ["Pritam.Url.Shortner.Infrastructure/Pritam.Url.Shortner.Infrastructure.csproj", "Pritam.Url.Shortner.Infrastructure/"]
#
#RUN dotnet restore "./Pritam.Url.Shortner.Api/Pritam.Url.Shortner.Api.csproj"
#
#COPY . .
#
#WORKDIR "/src/Pritam.Url.Shortner.Api"
#
#RUN dotnet build "./Pritam.Url.Shortner.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./Pritam.Url.Shortner.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Pritam.Url.Shortner.Api.dll"]

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