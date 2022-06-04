FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

ARG SERVICE
ARG PORT

RUN echo "Build ARG: ${SERVICE} ${PORT}"

WORKDIR /app
EXPOSE ${PORT}

# copy csproj and restore as distinct layers
COPY *.sln .

COPY ExampleAPI/*.csproj ./ExampleAPI/

RUN dotnet restore 

COPY ExampleAPI/. ./ExampleAPI/

WORKDIR /app/${SERVICE}
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

ARG SERVICE
ARG PORT

WORKDIR /app
COPY --from=build-env /app/${SERVICE}/out .

ENV ASPNETCORE_URLS=http://+:${PORT}
ENV SERVICE=$SERVICE

ENTRYPOINT dotnet ${SERVICE}.dll
