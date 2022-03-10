FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EasyCargo.Api.Queries/EasyCargo.Api.Queries.csproj", "EasyCargo.Api.Queries/"]
RUN dotnet restore "EasyCargo.Api.Queries/EasyCargo.Api.Queries.csproj"
COPY . .
WORKDIR "/src/EasyCargo.Api.Queries"
RUN dotnet build "EasyCargo.Api.Queries.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyCargo.Api.Queries.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Docker
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyCargo.Api.Queries.dll"]
