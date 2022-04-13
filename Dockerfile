FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore "src/GerenciamentoJogos.WebApi/GerenciamentoJogos.WebApi.csproj"
RUN dotnet publish "src/GerenciamentoJogos.WebApi/GerenciamentoJogos.WebApi.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GerenciamentoJogos.WebApi.dll"]