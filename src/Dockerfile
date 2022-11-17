FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /src
COPY . ./

WORKDIR /src/graph-ql-sample.Api
RUN dotnet restore 
RUN dotnet publish -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0

COPY --from=build-env /src/graph-ql-sample.Api/out .
ENTRYPOINT ["dotnet", "graph-ql-sample.Api.dll"]

# RUN apt-get update && apt-get install -y curl
# HEALTHCHECK CMD curl --fail http://localhost:80/health

EXPOSE 80