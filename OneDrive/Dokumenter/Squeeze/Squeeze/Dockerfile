# Base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["Squeeze.csproj", "./"]
RUN dotnet restore "Squeeze.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "Squeeze.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Squeeze.csproj" -c Release -o /app/publish

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Squeeze.dll"]
