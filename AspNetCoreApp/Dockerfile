FROM microsoft/aspnetcore:lts
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "AspNetCoreApp.dll"]
