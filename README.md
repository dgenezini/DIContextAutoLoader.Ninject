# DIContextAutoLoader.Ninject

[![NuGet version (DIContextAutoLoader.Ninject)](https://img.shields.io/nuget/v/DIContextAutoLoader.Ninject.svg?style=flat-square)](https://www.nuget.org/packages/DIContextAutoLoader.Ninject/)

Extension of [DIContextAutoLoader](https://github.com/dgenezini/DIContextAutoLoader) to use with Ninject.

# Package

```
    Install-Package DIContextAutoLoader.Ninject
```

# Usage

```csharp
private static void RegisterServices(IKernel kernel)
{
    kernel.AutoLoadServices(typeof(SomeTypeInAssembly).Assembly);

    ...
}
```
