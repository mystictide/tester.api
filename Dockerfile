FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tester.api/tester.api.csproj", "tester.api/"]
RUN dotnet restore "tester.api/tester.api.csproj"
COPY . .
WORKDIR "/src/tester.api"
RUN dotnet build "tester.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tester.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=https://+:7001
ENV ASPNETCORE_HTTP_PORT=https://+:7001
EXPOSE 7001
ENTRYPOINT ["dotnet", "tester.api.dll", "--urls", "https://+:7001"]