FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app/ExampleAPI
EXPOSE 8888
# copy csproj and restore as distinct layers
COPY *.sln .
COPY ExampleAPI/*.csproj ./ExampleAPI/
RUN dotnet restore

# copy everything else and build app
COPY ExampleAPI/. ./ExampleAPI/
WORKDIR /app/ExampleAPI/ExampleAPI
RUN dotnet publish -c release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app/ExampleAPI/ExampleAPI
COPY --from=build-env /app/ExampleAPI/ExampleAPI/out .

ENV ASPNETCORE_URLS=http://+:8888
#ENV SERVICE=ExampleAPI

ENTRYPOINT ["dotnet", "ExampleAPI.dll"]