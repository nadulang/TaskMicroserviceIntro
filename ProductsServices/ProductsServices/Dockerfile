FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-products
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out/product

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-products /src/out/product .
ENTRYPOINT ["dotnet", "ProductsServices.dll"]
