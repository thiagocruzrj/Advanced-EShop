#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ApiGateways/AES.BFF.Purchases/AES.BFF.Purchases.csproj", "src/ApiGateways/AES.BFF.Purchases/"]
RUN dotnet restore "src/ApiGateways/AES.BFF.Purchases/AES.BFF.Purchases.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/AES.BFF.Purchases"
RUN dotnet build "AES.BFF.Purchases.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AES.BFF.Purchases.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AES.BFF.Purchases.dll"]