# GraphQLBlazorClient
Example Blazor client utilizing GraphQL queries

# How to run the app

* If you do not have it installed, first install the .NET SDK (this code example uses .NET 9.0) from Microsoft
* On a Mac, you will need to establish a link from the SDK install location. Assuming your install is at /usr/local/share/dotnet/x64/dotnet:
```
ln -s /usr/local/share/dotnet/x64/dotnet /usr/local/bin/
```
* If done correctly, you should now have the dotnet command available in your terminal.
* Ensure you are in the `GraphQLBlazorClient` sub-directory (not the root of the repository)
* Run the command:
```
dotnet run
```
* This should start up the web application, and is accessible from http://localhost:5152/
* In order for the GraphQL requests to work, you will also need to have the GraphQL APIs and Apollo router running (see https://github.com/trilitymattstrauss/GraphQLExample)
