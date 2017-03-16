# Kentico Cloud .NET MVC Boilerplate

This boilerplate includes a set of features and best practices to kick off your website development with Kentico Cloud smoothly.

## What's included

- Kentico Delivery SDK
- Setup for Dev and Production environment
- Unit tests ([xUnit](https://xunit.github.io))
- Error handling (404, 500, ...)
- 301 URL Rewriting
- Logging (TODO: add how to change logging provider to Azure or EventLog)

## Quick start

1. Download/clone this project into your disk
2. Run `RenameProject.ps1 <projectName>` in PowerShell console (e.g.: `RenameProject.ps1 ChunkyMonkey`)
3. Open in Visual Studio 2017/Code and Run

## How to's


### How to change Project Id and Delivery Preview API key

Project Id is stored inside `appsettings.json` file. This setting is automatically loaded [using Options and configuration objects](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration) (See [HomeController](/src/CloudBoilerplateNet/Controllers/HomeController.cs) for example).

Delivery Preview API Key shouldn't be stored within project tree for security reasons. Use [Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets#security-app-secrets) to store sensitive data. 

TODO: add preview API into the project


### How to generate Strongly Typed Models for Content Types

Content Type Models are generated by [models generator utility](https://github.com/Kentico/cloud-generators-net). By convention, all Content Type Models are stored within the `Models/ContentTypes` folder. All generated classes are partial, that means, you can extend the model with custom methods in a separate file. Do not modify generated models, they can be regenerated and your changes will be lost.


### How to handle 404 errors or any other error

Error handling is setup by default. Any server exception or error response within 400-600 status code range is handled by ErrorController. By default, it's configured to display Not Found error page for 404 error and General Error for anything else. 


### How to handle 301 Permanent redirect


The Boilerplate is configured to load all [URL Rewriting](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/url-rewriting) rules from [IISUrlRewrite.xml](/src/CloudBoilerplateNet/IISUrlRewrite.xml) file. Add or modify existing rules to match your expected behavior.

:warning: ASP.NET Core 1.1 currently [doesn't support Rewrite Maps](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/url-rewriting#unsupported-features), but there is a simple workaround for `/oldUrl -> /newUrl` mapping (see [IISUrlRewrite.xml](/src/CloudBoilerplateNet/IISUrlRewrite.xml) for example).

## Feedback & Contributing
Any feedback is much appreciated. Check out the [contributing](https://github.com/Kentico/Home/blob/master/CONTRIBUTING.md) to see the best places to file issues, start discussions and begin contributing.
