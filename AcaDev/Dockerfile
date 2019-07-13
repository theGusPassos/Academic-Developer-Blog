FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /app
EXPOSE 8080

COPY . .
RUN dotnet restore "AcaDev/AcaDev.csproj"

WORKDIR /app/AcaDev
RUN dotnet publish "AcaDev.csproj" -c Release -o /out

FROM microsoft/aspnetcore:2.0 AS final
WORKDIR /app

RUN apt-get -qq update && apt-get -qqy --no-install-recommends install wget gnupg \
    git \
    unzip

RUN curl -sL https://deb.nodesource.com/setup_6.x |  bash -
RUN apt-get install -y nodejs

COPY --from=build /out .
ENTRYPOINT ["dotnet", "AcaDev.dll"] 
