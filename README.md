## Cross Plaform C# FreeAgent library

This library provides a portable, cross platform implementation of the [FreeAgent](http://freeagent.com) v2 api.  

All access methods are async to provide the best possible support for mobile and UI heavy interfaces. 

## The Basics

Create an instance of the `FreeAgentClient` class and start getting your data.

```csharp

var client = new FreeAgentClient(config);
var accounts = await client.GetBankAccounts();
```

### Where does this work?

We use [refit](http://github.com/paulcbetts/refit) to handle the underlying rest calls, as a result this library currently supports the following platforms:

* Xamarin.Android
* Xamarin.Mac
* Xamarin.iOS 64-bit (Unified API)
* Desktop .NET 4.5 
* Windows Phone 8
* Windows Store (WinRT) 8.0/8.1
* Windows Phone 8.1 Universal Apps

The following platforms are not supported:

* Xamarin.iOS 32-bit - build system doesn't support targets files


