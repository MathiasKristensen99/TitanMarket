FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY ./bin/Debug/net5.0 /app/publish 
ENTRYPOINT ["dotnet", "/app/publish/TitanMarket.WebApi.dll"]