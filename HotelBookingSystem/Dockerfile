# Use the SDK to build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src


# copy csproj and restore as distinct layers
COPY *.sln .
COPY HotelBookingSystem/*.csproj ./HotelBookingSystem/
RUN dotnet restore


# copy everything else and publish
COPY . .
WORKDIR /src/HotelBookingSystem
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false


# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app


# create a non-root user (optional, but good practice)
RUN useradd -m appuser


# copy publish output
COPY --from=build /app/publish .


# add entrypoint script
COPY ./docker/entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh


USER appuser
EXPOSE 80
ENTRYPOINT ["/entrypoint.sh"]
CMD ["dotnet", "HotelBookingSystem.dll"]