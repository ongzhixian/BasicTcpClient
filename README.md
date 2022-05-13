# BasicTcpClient

A basic .NET Core TCP client console application use for simple deployments in Kubernetes. 

## dotnet CLI

dotnet CLI used to create this project:

```ps1: In C:\src\github.com\ongzhixian\BasicTcpClient
dotnet new sln -n BasicTcpClient
dotnet new console -n BasicTcpClient.ConsoleApp
dotnet sln .\BasicTcpClient.sln add .\BasicTcpClient.ConsoleApp\

dotnet add .\BasicTcpClient.ConsoleApp\ package Microsoft.Extensions.Configuration
dotnet add .\BasicTcpClient.ConsoleApp\ package Microsoft.Extensions.Configuration.Json

```

Other packages that we may want to include to expand on configuration options:
Microsoft.Extensions.Configuration.CommandLine
Microsoft.Extensions.Configuration.Binder
Microsoft.Extensions.Configuration.EnvironmentVariables 