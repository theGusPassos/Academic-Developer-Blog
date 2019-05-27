FROM microsoft/aspnetcore-build:2.0 AS base
WORKDIR /app
EXPOSE 80

WORKDIR /src
COPY . .
RUN dotnet restore "AcaDev/AcaDev.csproj"

WORKDIR	/src/AcaDev
RUN dotnet publish "AcaDev.csproj" -c Release -o /app

WORKDIR /app
ENTRYPOINT ["dotnet", "AcaDev.dll"] 
