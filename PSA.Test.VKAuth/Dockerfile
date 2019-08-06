FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

FROM base AS final
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PSA.Test.VKAuth.dll
