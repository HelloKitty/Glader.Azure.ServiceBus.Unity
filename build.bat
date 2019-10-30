dotnet publish src/Microsoft.Azure.ServiceBus.csproj -c RELEASE
if not exist "build" mkdir build
xcopy src\bin\Release\netstandard2.0\publish build /s /y

EXIT 0