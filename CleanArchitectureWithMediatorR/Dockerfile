# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the solution file and project files
COPY *.sln ./
COPY CleanArchitectureWithMediatorR/CleanArchitectureWithMediatorR.csproj CleanArchitectureWithMediatorR/
COPY CleanArchitectureWithMediatorRCore/CleanArchitectureWithMediatorRCore.csproj CleanArchitectureWithMediatorRCore/
COPY CleanArchitectureWithMediatorRApplication/CleanArchitectureWithMediatorRApplication.csproj CleanArchitectureWithMediatorRApplication/
COPY CleanArchitectureWithMediatorRInfrastructure/CleanArchitectureWithMediatorRInfrastructure.csproj CleanArchitectureWithMediatorRInfrastructure/

# Restore dependencies
RUN dotnet restore

# Copy the remaining files
COPY . .

# Build the application
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Expose the port that the app runs on
EXPOSE 5004

# Set the entry point for the container
ENTRYPOINT ["dotnet", "CleanArchitectureWithMediatorR.dll"]
