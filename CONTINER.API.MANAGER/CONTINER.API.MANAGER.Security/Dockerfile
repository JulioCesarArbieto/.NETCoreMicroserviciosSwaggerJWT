FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY ./publish/ /app
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT docker
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/CONTINER.API.MANAGER.Security.dll"]