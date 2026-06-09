# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SimpleNoteApp/SimpleNoteApp.csproj", "SimpleNoteApp/"]
RUN dotnet restore "SimpleNoteApp/SimpleNoteApp.csproj"

COPY . .
WORKDIR "/src/SimpleNoteApp"
RUN dotnet publish "SimpleNoteApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render uses PORT env variable — must listen on 0.0.0.0
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "SimpleNoteAPP.dll"]