#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 21
EXPOSE 20
EXPOSE 30000-30009

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PoweTCP.Vert/PoweTCP.Vert.csproj", "PoweTCP.Vert/"]
RUN dotnet restore "PoweTCP.Vert/PoweTCP.Vert.csproj"
COPY . .
WORKDIR "/src/PoweTCP.Vert"
RUN dotnet build "PoweTCP.Vert.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PoweTCP.Vert.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PoweTCP.Vert.dll"]
