FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR webapp

EXPOSE 80
EXPOSE 5024

#COPY PROJECT FILES
COPY ./*.csproj ./
RUN dotnet restore

#COPY EVERYTHING ELSE
COPY . .
RUN dotnet publish -c Release -o out

#Build Image
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /webapp
COPY --from=build /webapp/out .
ENTRYPOINT [ "dotnet","test_tryCatch.dll" ]