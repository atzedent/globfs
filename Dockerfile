FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/*.csproj ./src/
RUN dotnet restore

# copy everything else and build app
COPY src/. ./src/
WORKDIR /app/src
RUN dotnet publish -c Release -o out

# build final image
FROM mcr.microsoft.com/dotnet/core/runtime:3.0 AS runtime

LABEL version="1.0.0"
LABEL maintainer="Matthias Hurrle"
LABEL maintainer_email="cry4hurrle@gmail.com"

WORKDIR /app
COPY --from=build /app/src/out ./
RUN chmod 700 globfs
ENTRYPOINT ["./globfs"]