# GraphQLBlazorClient
Example Blazor client utilizing GraphQL queries

# How to run the app

* If you do not have it installed, first install the .NET SDK (this code example uses .NET 9.0) from Microsoft
* On a Mac, you will need to establish a link from the SDK install location. Assuming your install is at /usr/local/share/dotnet/x64/dotnet:
```
ln -s /usr/local/share/dotnet/x64/dotnet /usr/local/bin/
```
* If done correctly, you should now have the dotnet command available in your terminal.
* You will also need `npm` installed on your machine.
* You will also need `Docker` installed and running.
  * If you do NOT wish to use `Docker`, you will need to replace any occurrences of `host.docker.internal` with `localhost`, and run using `dotnet run`.
  * TODO: Look into making the GraphQL API URL dynamic based on whether running in Docker or not
* Ensure you are in the `GraphQLBlazorClient` sub-directory (not the root of the repository)
* Run the command:
```
npm run publish
```
* This should start up the web application, and is accessible from http://localhost:5152/.  This will also start the app in a container (which you can see in Docker)
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
-- To run the Playwright tests:
npm run test:acceptance
-- To run the bUnit tests:
npm run test:unit
```
* The `npm run test:acceptance` script will stop any running containers, re-publish, then run the acceptance tests.
  * A test is identified as an acceptance test if it has a namespace of `GraphQLBlazorClient.Acceptance`.
  * Anything not in that namesapce is considered a unit test.
* If you wish to run a specific test, you can apply a filter e.g.
```
dotnet test --filter "FullyQualifiedName~HomePageTests"
```
* If you want to debug the Playwright tests in a browser, you can run a command like
```
PWDEBUG=1 dotnet test
```