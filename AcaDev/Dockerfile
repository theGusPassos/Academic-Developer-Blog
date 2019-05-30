FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /app
EXPOSE 80

COPY . .
RUN dotnet restore "AcaDev/AcaDev.csproj"

WORKDIR /app/AcaDev
RUN dotnet publish "AcaDev.csproj" -c Release -o /out

FROM microsoft/aspnetcore:2.0 AS final
WORKDIR /app
COPY --from=build /out .
ENTRYPOINT ["dotnet", "AcaDev.dll"] 
