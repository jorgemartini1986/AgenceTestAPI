#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["AgenceIntro.Web/AgenceIntro.Web.csproj", "AgenceIntro.Web/"]
RUN dotnet restore "AgenceIntro.Web/AgenceIntro.Web.csproj"
COPY . .
WORKDIR "/src/AgenceIntro.Web"
RUN dotnet build "AgenceIntro.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AgenceIntro.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AgenceIntro.Web.dll"]