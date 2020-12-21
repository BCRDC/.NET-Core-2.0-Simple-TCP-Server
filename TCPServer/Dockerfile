FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1-bionic AS base

WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ./TCPServer TCPServer/
COPY ./TCPNetworkLib TCPNetworkLib/

RUN dotnet restore "TCPServer/TCPServer/TCPServer.csproj" -r linux-x64

FROM build AS publish
RUN dotnet publish "TCPServer/TCPServer/TCPServer.csproj" -c Release -o /app -r linux-x64 --self-contained true --no-restore /p:PublishTrimmed=true /p:PublishReadyToRun=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app .


# Needed because https://stackoverflow.com/questions/51977474/install-dotnet-core-tool-dockerfile
# ENV PATH="${PATH}:/root/.dotnet/tools"

#CMD ["dotnet", "TCPServer.dll"]

ENTRYPOINT ["./TCPServer"]