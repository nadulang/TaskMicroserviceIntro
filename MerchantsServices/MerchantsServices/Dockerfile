FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-merchant
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 
WORKDIR /app
COPY --from=build-merchant /src/out .
ENTRYPOINT ["dotnet", "MerchantsServices.dll"]
