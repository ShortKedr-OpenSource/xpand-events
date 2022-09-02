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
Source code for benchmark presented in `Xpand.Events.Benchmark` project.  

WARNING! There is a big chance current benchmark presents non-end and not clear results, since it's not well researched yet and dont present end state of project. So, follow the project to get updates about this state in future.

There are lastest benchmark results:

### Event Invoke:

``` ini
BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1889/21H2/November2021Update)
Intel Core i5-9300H CPU 2.40GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.410
  [Host]     : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2
  Job-HEUXOK : .NET 5.0.17 (5.0.1722.21314), X64 RyuJIT AVX2

MaxAbsoluteError=1.0000 ms  MaxRelativeError=0.009999999776482582
```

|                       Method | ListenersCount |         Mean |       Error |      StdDev |       Median |        Ratio | RatioSD |
|----------------------------- |--------------- |-------------:|------------:|------------:|-------------:|-------------:|--------:|
|     `DefaultEvent?.Invoke()` |             10 |     129.0 ns |     1.32 ns |     3.78 ns |     128.3 ns |     baseline |         |
|            `XEvent.Invoke()` |             10 |     119.1 ns |     0.53 ns |     1.47 ns |     118.6 ns | 1.09x faster |   0.03x |
|        `SafeXEvent.Invoke()` |             10 |     142.2 ns |     1.70 ns |     4.87 ns |     140.2 ns | 1.10x slower |   0.05x |
|     `OrderedXEvent.Invoke()` |             10 |     144.9 ns |     0.74 ns |     2.01 ns |     144.5 ns | 1.12x slower |   0.03x |
| `OrderedSafeXEvent.Invoke()` |             10 |     154.5 ns |     0.60 ns |     1.73 ns |     154.0 ns | 1.20x slower |   0.04x |
|                              |                |              |             |             |              |              |         |
|     `DefaultEvent?.Invoke()` |             50 |     904.0 ns |     3.02 ns |     8.56 ns |     901.0 ns |     baseline |         |
|            `XEvent.Invoke()` |             50 |     946.6 ns |     9.21 ns |    25.51 ns |     935.2 ns | 1.05x slower |   0.03x |
|        `SafeXEvent.Invoke()` |             50 |   1,007.5 ns |     1.91 ns |     5.36 ns |   1,006.1 ns | 1.11x slower |   0.01x |
|     `OrderedXEvent.Invoke()` |             50 |     981.5 ns |     1.90 ns |     4.98 ns |     980.3 ns | 1.09x slower |   0.01x |
| `OrderedSafeXEvent.Invoke()` |             50 |     990.4 ns |     1.88 ns |     3.62 ns |     990.5 ns | 1.10x slower |   0.01x |
|                              |                |              |             |             |              |              |         |
|     `DefaultEvent?.Invoke()` |            100 |   1,843.7 ns |     4.26 ns |    12.00 ns |   1,840.0 ns |     baseline |         |
|            `XEvent.Invoke()` |            100 |   1,906.3 ns |     3.74 ns |     6.94 ns |   1,905.5 ns | 1.03x slower |   0.01x |
|        `SafeXEvent.Invoke()` |            100 |   2,065.9 ns |     3.65 ns |     9.56 ns |   2,065.5 ns | 1.12x slower |   0.01x |
|     `OrderedXEvent.Invoke()` |            100 |   1,932.7 ns |     4.38 ns |    12.35 ns |   1,930.6 ns | 1.05x slower |   0.01x |
| `OrderedSafeXEvent.Invoke()` |            100 |   1,992.9 ns |     3.90 ns |    11.26 ns |   1,991.7 ns | 1.08x slower |   0.01x |
|                              |                |              |             |             |              |              |         |
|     `DefaultEvent?.Invoke()` |           1000 |  20,792.1 ns |    30.51 ns |    76.55 ns |  20,788.3 ns |     baseline |         |
|            `XEvent.Invoke()` |           1000 |  21,057.6 ns |    31.05 ns |    85.53 ns |  21,047.0 ns | 1.01x slower |   0.01x |
|        `SafeXEvent.Invoke()` |           1000 |  22,896.4 ns |    32.21 ns |    91.38 ns |  22,897.1 ns | 1.10x slower |   0.01x |
|     `OrderedXEvent.Invoke()` |           1000 |  21,048.6 ns |    37.27 ns |   100.77 ns |  21,033.7 ns | 1.01x slower |   0.01x |
| `OrderedSafeXEvent.Invoke()` |           1000 |  21,947.2 ns |    28.56 ns |    57.70 ns |  21,947.7 ns | 1.06x slower |   0.01x |
|                              |                |              |             |             |              |              |         |
|     `DefaultEvent?.Invoke()` |          10000 | 235,524.5 ns |   344.82 ns |   983.78 ns | 235,298.6 ns |     baseline |         |
|            `XEvent.Invoke()` |          10000 | 236,681.6 ns |   568.22 ns | 1,611.95 ns | 236,343.8 ns | 1.00x slower |   0.01x |
|        `SafeXEvent.Invoke()` |          10000 | 247,938.3 ns |   486.83 ns | 1,194.21 ns | 247,926.1 ns | 1.05x slower |   0.01x |
|     `OrderedXEvent.Invoke()` |          10000 | 232,189.5 ns |   348.01 ns |   940.85 ns | 231,928.1 ns | 1.01x faster |   0.01x |
| `OrderedSafeXEvent.Invoke()` |          10000 | 261,601.9 ns | 2,499.61 ns | 7,330.93 ns | 260,833.5 ns | 1.11x slower |   0.03x |

### Subscribe:
There will listener subscribe benchmark soon

# <a id="migrating"></a>Migrating from default events
There will be some useful info soon

# <a id="async-use"></a>Async usage
There will be some useful info soon

# <a id="multithreading"></a>Multithreading
There will be some useful info soon

# <a id="use-with-unity"></a>Use with Unity Engine
There will be some useful info soon
