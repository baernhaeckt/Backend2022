#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MixMeal.Web/MixMeal.Web.csproj", "MixMeal.Web/"]
COPY ["MixMeal.Core/MixMeal.Core.csproj", "MixMeal.Core/"]
COPY ["MixMeal.Modules/MixMeal.Modules.csproj", "MixMeal.Modules/"]
RUN dotnet restore "MixMeal.Web/MixMeal.Web.csproj"
COPY . .
WORKDIR "/src/MixMeal.Web"
RUN dotnet build "MixMeal.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MixMeal.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MixMeal.Web.dll"]