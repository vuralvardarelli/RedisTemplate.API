#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["RedisTemplate.API/RedisTemplate.API.csproj", "RedisTemplate.API/"]
COPY ["RedisTemplate.Infrastructure/RedisTemplate.Infrastructure.csproj", "RedisTemplate.Infrastructure/"]
COPY ["RedisTemplate.Core/RedisTemplate.Core.csproj", "RedisTemplate.Core/"]
RUN dotnet restore "RedisTemplate.API/RedisTemplate.API.csproj"
COPY . .
WORKDIR "/src/RedisTemplate.API"
RUN dotnet build "RedisTemplate.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RedisTemplate.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RedisTemplate.API.dll"]
