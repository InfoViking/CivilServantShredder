#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


ENV ASPNETCORE_URLS=http://+:80


RUN apt update && apt install tzdata -y
ENV TZ="Europe/Berlin"

#RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
#USER appuser


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CivilServantShredderApi/CivilServantShredderApi.csproj", "CivilServantShredderApi/"]



RUN dotnet restore "CivilServantShredderApi/CivilServantShredderApi.csproj"
COPY . .
WORKDIR "/src/CivilServantShredderApi"
RUN dotnet build "CivilServantShredderApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CivilServantShredderApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CivilServantShredderApi.dll"]