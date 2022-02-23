FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EasyCargo.Api/EasyCargo.Api.csproj", "EasyCargo.Api/"]
RUN dotnet restore "EasyCargo.Api/EasyCargo.Api.csproj"
COPY . .
WORKDIR "/src/EasyCargo.Api"
RUN dotnet build "EasyCargo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyCargo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyCargo.Api.dll"]
