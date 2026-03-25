# Funda Assignment - ASP.NET Web Api

This projects implements a backend service that retrieves real estate listings from the Funda Api and finds the top 10 real estate agents with the most listings in Amsterdam with the options to filter out the listings with gardens.

## Motivation

C# and ASP.NET are not my primary tech stack, however, I intentionally chose to use them for this assignment because of my interest in Funda and its technology stack. I wanted to challenge myself to work with the tools used in your environment and demonstrate my curiosity and adaptability.

This meant investing additional time to learn the ecosystem from scratch, including:
- ASP.NET Web API structure
- C# Constructs
- Polly for resilience and retry strategies
- xUnit for testing

I used AI tools selectively to:
- better understand and apply **LINQ**
- structure and separate the **Polly retry policy**

---
## Requirements
- Visual Studio 
- C# Dev Kit for Visual Studio Code
- .NET SDK

## Run
```sh
 dotnet run
 ```

navigate to http://localhost:\<port\>/api/makelaars

#### Endpoints
- GET /api/makelaars
- GET /api/makelaars/tuin

---

## Features
- Retrieve property listings from the Funda API
- Aggregate listings per real estate agent
- Return:
  - Top 10 agents in Amsterdam wih most listings
  - Top 10 agents in Amsterdam with most listings with gardens.
- Handle API rate limits using Polly, retry with exponential backoff 
- Seperation of concerns using Controllers, Services, and Models
- Basic test coverage with xUnit

## API Resilience Strategy

The Funda API enforces rate limits. The transient failures and rate limits are handled by **HttpClientFactory + Polly** with exponential backoff up to 6 times so the client can back off long enough for the rate-limit window to recover:

- Retries on:
  - Network errors
  - 5xx server errors
  - `429 Too Many Requests`

---

## Testing

Run tests:

```sh
 dotnet test
 ```

- Verifies service returns valid results
- Ensures output is limited to top 10
- Ensures the controller returns valid results

---

## Improvements

- Add unit tests with mocked API responses
- Move API key to environment variables
- Implement structured logging (`ILogger`)
- Add jitter to retry strategy

---
## Resources

[1) Create web APIs with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-10.0)

[2) Make HTTP requests using IHttpClientFactory in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-10.0)

[3) Dependency injection into controllers in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-10.0)


[4) Implement HTTP call retries with exponential backoff with IHttpClientFactory and Polly policies](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly)

[5) How to Build HTTP Clients with Polly Retry in .NET](https://oneuptime.com/blog/post/2026-01-25-http-clients-polly-retry-dotnet/view)

[6) Unit testing C# in .NET using dotnet test and xUnit](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit
)

[7) Unit Testing in C# 2022](
https://www.youtube.com/watch?v=MJhQCMnRggs&list=PL82C6-O4XrHeyeJcI5xrywgpfbrqdkQd4&index=2)

[8) ASP.NET Web API .NET 8 Tutorial 2024](https://www.youtube.com/playlist?list=PL82C6-O4XrHfrGOCPmKmwTO7M0avXyQKc)