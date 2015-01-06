## Cross Plaform C# FreeAgent library

A portable, cross platform .Net library for accessing the [FreeAgent](http://freeagent.com) v2 API.  

This library supports all *known* (because the documentation isn't always up to date!) capabilities of the API without you needing to worry about JSON serialisation, oauth token expiration, etc.    

See [http://dev.freeagent.com/docs](http://dev.freeagent.com/docs) for API details.

All methods are async so you get the best performance for mobile and UI heavy interfaces. 

## The Basics

Create an instance of the `FreeAgentClient` class and start getting your data.

```csharp

var client = new FreeAgentClient(config);
var accounts = await client.GetBankAccounts();
```

### Where does this work?

We use the excellent [refit](http://github.com/paulcbetts/refit) library to handle the underlying rest calls, as a result this library currently supports the following platforms:

* Xamarin.Android
* Xamarin.Mac
* Xamarin.iOS 64-bit (Unified API)
* Desktop .NET 4.5 
* Windows Phone 8
* Windows Store (WinRT) 8.0/8.1
* Windows Phone 8.1 Universal Apps

The following platforms are not supported:

* Xamarin.iOS 32-bit - build system doesn't support targets files

### What's missing?

* Cancellation Tokens - waiting for an update to refit.

### What's still being worked on?

Quite a few things as the API documentation and the actual API results occassionally differ.  I'm currently working on:

* Verifying invoice behaviour
* Bank Transactions
* Bank Transaction Explanations
* Lots of tests to verify the calls work 
* Samples to show it working

### Can I help?

Sure, let me know or raise an issue if you find a problem.

I've added everything in the API but I'm only using some of the functions right now.
