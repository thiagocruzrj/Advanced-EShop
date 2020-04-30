#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Services/AES.ShopCart.API/AES.ShopCart.API.csproj", "src/Services/AES.ShopCart.API/"]
RUN dotnet restore "src/Services/AES.ShopCart.API/AES.ShopCart.API.csproj"
COPY . .
WORKDIR "/src/src/Services/AES.ShopCart.API"
RUN dotnet build "AES.ShopCart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AES.ShopCart.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AES.ShopCart.API.dll"]