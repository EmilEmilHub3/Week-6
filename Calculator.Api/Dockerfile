FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Calculator.sln .
COPY Calculator/Calculator.csproj Calculator/
COPY Calculator.Api/Calculator.Api.csproj Calculator.Api/

RUN dotnet restore Calculator.Api/Calculator.Api.csproj

COPY . .

RUN dotnet publish Calculator.Api/Calculator.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Calculator.Api.dll"]