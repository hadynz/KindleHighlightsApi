build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	dotnet watch --project src/WebApi/WebApi.csproj run
start:
	dotnet run --project src/WebApi/WebApi.csproj
