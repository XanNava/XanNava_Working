FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["XanNava_Working/XanNava_Working.csproj", "XanNava_Working/"]
RUN dotnet restore "XanNava_Working/XanNava_Working.csproj"
COPY . .
WORKDIR "/src/XanNava_Working"
RUN dotnet build "XanNava_Working.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XanNava_Working.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XanNava_Working.dll"]
