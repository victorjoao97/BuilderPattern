FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /src
COPY */*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*} && mv $file ${file%.*}; done
COPY BuilderPattern.sln .
RUN dotnet restore
COPY . .
RUN dotnet test
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/runtime:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
ENTRYPOINT ["dotnet", "ConsoleClient.dll"]