# Xpand Events
Xpand-Project events realization.  
The main idea is to solve most of event problems in your project, such as native C# events null pointers, exception-catching, method call order and so on.

# Xpand-Project links
- [Xpand-Events](https://github.com/ShortKedr-OpenSource/xpand-events)


# Table of contents
 * [Hot to use](#how-to-use)
 * [Install](#install)
   * [Assembly DLL](#install-assembly)
   * [Nuget package](#install-nuget)
 * [Performance](#performance)
 * [Migrating from default events](#migrating)
 * [Async use](#async-use)
 * [Multithreading](#multithreading)
 * [Use with Unity Engine](#use-with-unity)


# <a id="how-to-use"></a>Hot to use
There will be some useful info soon
 
# <a id="install"></a>Install
There will be some useful info soon

## <a id="install-assembly"></a>Assembly DLL
There will be some useful info soon

## <a id="install-nuget"></a>Nuget package
There will be some useful info soon
 
# <a id="performance"></a>Performance
Source code for benchmarks presented in `Xpand.Events.Benchmark` project.  
There are lastest benchmark results:

### Event Invoke:
``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1889/21H2/November2021Update)
Intel Core i5-9300H CPU 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.410
  [Host]     : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2
  DefaultJob : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2


```
|     Real Method |         Benchmark Method |       Mean |     Error |    StdDev |     Median |
|-----------------|------------------------- |-----------:|----------:|----------:|-----------:|
|   `ev.Invoke();`|      DefaultEvent_Invoke | 289.106 ns | 5.7360 ns | 8.0410 ns | 284.526 ns |
|  `ev?.Invoke();`|  DefaultEvent_SafeInvoke | 243.694 ns | 2.7536 ns | 2.1498 ns | 242.925 ns |
|  `xEv.Invoke();`|            XEvent_Invoke |   6.304 ns | 0.0379 ns | 0.0336 ns |   6.296 ns |
| `sxEv.Invoke();`|        SafeXEvent_Invoke |   8.481 ns | 0.0378 ns | 0.0354 ns |   8.475 ns |
| `oxEv.Invoke();`|     OrderedXEvent_Invoke |  27.669 ns | 0.2816 ns | 0.2634 ns |  27.638 ns |
|`osxEv.Invoke();`| OrderedSafeXEvent_Invoke |  30.416 ns | 0.1796 ns | 0.1680 ns |  30.372 ns |

### Subscribe:

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1889/21H2/November2021Update)
Intel Core i5-9300H CPU 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.410
  [Host]     : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2
  DefaultJob : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2


```
|             Real Method |                      Method |     Mean |    Error |   StdDev |
|-------------------------|---------------------------- |---------:|---------:|---------:|
|    `ev += eventHandler;`|      DefaultEvent_Subscribe | 80.80 ns | 1.102 ns | 0.860 ns |
|   `xEv.AddListener(eh);`|            XEvent_Subscribe | 49.79 ns | 0.124 ns | 0.103 ns |
|  `sxEv.AddListener(eh);`|        SafeXEvent_Subscribe | 50.36 ns | 0.733 ns | 0.685 ns |
|  `oxEv.AddListener(eh);`|     OrderedXEvent_Subscribe | 42.99 ns | 0.128 ns | 0.100 ns |
| `osxEv.AddListener(eh);`| OrderedSafeXEvent_Subscribe | 40.64 ns | 0.373 ns | 0.331 ns |


# <a id="migrating"></a>Migrating from default events
There will be some useful info soon

# <a id="async-use"></a>Async usage
There will be some useful info soon

# <a id="multithreading"></a>Multithreading
There will be some useful info soon

# <a id="use-with-unity"></a>Use with Unity Engine
There will be some useful info soon
