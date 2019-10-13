FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MutantDetector/MutantDetector.csproj", "MutantDetector/"]
RUN dotnet restore "MutantDetector/MutantDetector.csproj"
COPY . .
WORKDIR "/src/MutantDetector"
RUN dotnet build "MutantDetector.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MutantDetector.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MutantDetector.dll"]