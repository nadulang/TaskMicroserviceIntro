FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-customers
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out/customer

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-customers /src/out/customer .
ENTRYPOINT ["dotnet", "CustomerServices.dll"]
