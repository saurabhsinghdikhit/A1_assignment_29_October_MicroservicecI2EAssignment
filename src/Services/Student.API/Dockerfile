FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Student.API/Student.API.csproj", "src/Services/Student.API/"]
RUN dotnet restore "src\Services\Student.API\Student.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Student.API"
RUN dotnet build "Student.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Student.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Student.API.dll"]
