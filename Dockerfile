FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/Microblog.Api/Microblog.Api.csproj", "Microblog.Api/"]

RUN dotnet restore "Microblog.Api/Microblog.Api.csproj"
COPY . ../
WORKDIR /src/Microblog.Api
RUN dotnet build "Microblog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Microblog.Api.dll"]