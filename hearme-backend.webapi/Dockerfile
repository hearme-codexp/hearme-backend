FROM microsoft/aspnetcore
WORKDIR /app
COPY ./bin/Release/netcoreapp2.0/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet hearme-backend.webapi.dll