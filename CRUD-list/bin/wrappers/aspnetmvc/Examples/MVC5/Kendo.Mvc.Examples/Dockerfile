FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /app
ARG TELERIK_NUGET_API_KEY

COPY *.sln .
COPY NuGet.Config .

# copy csproj and restore as distinct layers
COPY demos/Kendo.Mvc.Examples/*.csproj ./demos/Kendo.Mvc.Examples/
COPY demos/Kendo.Mvc.Examples/*.config ./demos/Kendo.Mvc.Examples/
RUN nuget restore
RUN rm ./NuGet.Config

# copy everything else and build app
COPY demos/Kendo.Mvc.Examples/. ./demos/Kendo.Mvc.Examples/
WORKDIR /app/demos/Kendo.Mvc.Examples
RUN msbuild /p:Configuration=Debug -r:False

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS runtime

WORKDIR /inetpub/wwwroot
COPY --from=build /app/demos/Kendo.Mvc.Examples/. ./

ADD https://download.microsoft.com/download/1/2/8/128E2E22-C1B9-44A4-BE2A-5859ED1D4592/rewrite_amd64_en-US.msi /install/rewrite_amd64.msi
RUN msiexec.exe /i c:\install\rewrite_amd64.msi /passive
RUN "Powershell ./permissions.ps1"