FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/VideoBench.Web/VideoBench.Web.csproj", "src/VideoBench.Web/"]
COPY ["src/VideoBench.Application/VideoBench.Application.csproj", "src/VideoBench.Application/"]
COPY ["src/VideoBench.Domain/VideoBench.Domain.csproj", "src/VideoBench.Domain/"]
COPY ["src/VideoBench.Infrastructure/VideoBench.Infrastructure.csproj", "src/VideoBench.Infrastructure/"]
RUN dotnet restore "src/VideoBench.Web/VideoBench.Web.csproj"
COPY . .
WORKDIR "/src/src/VideoBench.Web"
RUN dotnet build "VideoBench.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VideoBench.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VideoBench.Web.dll"]
