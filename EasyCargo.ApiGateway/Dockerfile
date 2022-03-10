FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EasyCargo.ApiGateway/EasyCargo.ApiGateway.csproj", "EasyCargo.ApiGateway/"]
RUN dotnet restore "EasyCargo.ApiGateway/EasyCargo.ApiGateway.csproj"
COPY . .
WORKDIR "/src/EasyCargo.ApiGateway"
RUN dotnet build "EasyCargo.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyCargo.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Docker
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyCargo.ApiGateway.dll"]
