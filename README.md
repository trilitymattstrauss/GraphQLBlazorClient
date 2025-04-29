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

# Playwright setup

* To run Playwright tests on your machine, follow the instructions here: https://playwright.dev/dotnet/docs/intro (using the xUnit instructions)
* I found after running `pwsh bin/Debug/net8.0/playwright.ps1 install` and then attempting to run the tests, I had to move the drivers in the bin folder to match where it was looking.

# How to run tests

* This project contains unit tests (using bUnit) and integration tests (using Playwright).
* Playwright tests can be found at GraphQLBlazorClient/Test
* bUnit tests can be found at GraphQLBlazorClient/Components/Test
* To run the test suite, first ensure that the web app is up and running (you will also need the GraphQL API up)
* Then run the following command to execute the tests:
```
dotent test
```
* If you wish to run a specific test, you can apply a filter e.g.
```
dotnet test --filter "FullyQualifiedName~HomePageTests"
```
* If you want to debug the Playwright tests in a browser, you can run a command like
```
PWDEBUG=1 dotnet test
```