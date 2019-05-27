FROM microsoft/aspnetcore-build AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build AS build
WORKDIR /src
COPY ["AcaDev/AcaDev.csproj", "AcaDev/"]
COPY ["AcaDev.Shared/AcaDev.Shared.csproj", "AcaDev.Shared/"]
COPY ["AcaDev.Domain/AcaDev.Domain.csproj", "AcaDev.Domain/"]
COPY ["AcaDev.Persistance/AcaDev.Persistance.csproj", "AcaDev.Persistance/"]
RUN dotnet restore "AcaDev/AcaDev.csproj"
COPY . .
WORKDIR "/src/AcaDev"

FROM build AS publish
RUN dotnet publish "AcaDev.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AcaDev.dll"]
