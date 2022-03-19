FROM mcr.microsoft.com/dotnet/sdk:6.0 AS sdk

EXPOSE 80
EXPOSE 5555

WORKDIR /app

COPY ./ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=sdk /app/out .
ENTRYPOINT ["dotnet", "PodcastManager.Api.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["PodcastManager.Api/PodcastManager.Api.csproj", "PodcastManager.Api/"]
#RUN dotnet restore "PodcastManager.Api/PodcastManager.Api.csproj"
#COPY . .
#WORKDIR "/src/PodcastManager.Api"
#RUN dotnet build "PodcastManager.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "PodcastManager.Api.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "PodcastManager.Api.dll"]
