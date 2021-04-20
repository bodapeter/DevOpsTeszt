FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HelloWord.Api/HelloWord.Api.csproj", "HelloWord.Api/"]
COPY ["HelloWord.Bll/HelloWord.Bll.csproj", "HelloWord.Bll/"]
COPY ["HelloWord.Dal/HelloWord.Dal.csproj", "HelloWord.Dal/"]
RUN dotnet restore "HelloWord.Api/HelloWord.Api.csproj"
COPY . .
WORKDIR "/src/HelloWord.Api"
RUN dotnet build "HelloWord.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloWord.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWord.Api.dll"]