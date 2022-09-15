# Xpand Events
Xpand-Project events realization.  
The addition to default .NET events, that solve some of it's problems.

# Xpand-Project links
- [Xpand-Events](https://github.com/ShortKedr-OpenSource/xpand-events)


# Table of contents
 * [Requirements](#requirements)
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

|                       Method | Listeners |         Mean |        Ratio |
|----------------------------- |---------- |-------------:|-------------:|
|     `DefaultEvent?.Invoke()` |        10 |     129.0 ns |     baseline |
|            `XEvent.Invoke()` |        10 |     119.1 ns | 1.09x faster |
|        `SafeXEvent.Invoke()` |        10 |     142.2 ns | 1.10x slower |
|     `OrderedXEvent.Invoke()` |        10 |     144.9 ns | 1.12x slower |
| `OrderedSafeXEvent.Invoke()` |        10 |     154.5 ns | 1.20x slower |
|                              |           |              |              |
|     `DefaultEvent?.Invoke()` |        50 |     904.0 ns |     baseline |
|            `XEvent.Invoke()` |        50 |     946.6 ns | 1.05x slower |
|        `SafeXEvent.Invoke()` |        50 |   1,007.5 ns | 1.11x slower |
|     `OrderedXEvent.Invoke()` |        50 |     981.5 ns | 1.09x slower |
| `OrderedSafeXEvent.Invoke()` |        50 |     990.4 ns | 1.10x slower |
|                              |           |              |              |
|     `DefaultEvent?.Invoke()` |       100 |   1,843.7 ns |     baseline |
|            `XEvent.Invoke()` |       100 |   1,906.3 ns | 1.03x slower |
|        `SafeXEvent.Invoke()` |       100 |   2,065.9 ns | 1.12x slower |
|     `OrderedXEvent.Invoke()` |       100 |   1,932.7 ns | 1.05x slower |
| `OrderedSafeXEvent.Invoke()` |       100 |   1,992.9 ns | 1.08x slower |
|                              |           |              |              |
|     `DefaultEvent?.Invoke()` |      1000 |  20,792.1 ns |     baseline |
|            `XEvent.Invoke()` |      1000 |  21,057.6 ns | 1.01x slower |
|        `SafeXEvent.Invoke()` |      1000 |  22,896.4 ns | 1.10x slower |
|     `OrderedXEvent.Invoke()` |      1000 |  21,048.6 ns | 1.01x slower |
| `OrderedSafeXEvent.Invoke()` |      1000 |  21,947.2 ns | 1.06x slower |
|                              |           |              |              |
|     `DefaultEvent?.Invoke()` |     10000 | 235,524.5 ns |     baseline |
|            `XEvent.Invoke()` |     10000 | 236,681.6 ns | 1.00x slower |
|        `SafeXEvent.Invoke()` |     10000 | 247,938.3 ns | 1.05x slower |
|     `OrderedXEvent.Invoke()` |     10000 | 232,189.5 ns | 1.01x faster |
| `OrderedSafeXEvent.Invoke()` |     10000 | 261,601.9 ns | 1.11x slower |

### Subscribe:
There will listener subscribe benchmark soon

# <a id="requirements"></a>Requirements
**Min language version:** C# 8.0;
**Target Framework:** .NET Standard 2.0, .NET Framework 4.5;

# <a id="migrating"></a>Migrating from default events
There will be some useful info soon

# <a id="async-use"></a>Async usage
There will be some useful info soon

# <a id="multithreading"></a>Multithreading
There will be some useful info soon

# <a id="use-with-unity"></a>Use with Unity Engine
There will be some useful info soon
