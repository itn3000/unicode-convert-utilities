``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4712MQ CPU 2.30GHz (Haswell), ProcessorCount=8
Frequency=2240913 Hz, Resolution=446.2467 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]   : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  ShortRun : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
 |               Method | CharacterCode | Length | LoopNum |        Mean |       Error |    StdDev |
 |--------------------- |-------------- |------- |-------- |------------:|------------:|----------:|
 |    **UnsafeUtf8ToUtf16** |            **18** |      **1** |    **1000** |    **17.81 us** |  **10.3103 us** | **0.5825 us** |
 | ConvertWithFramework |            18 |      1 |    1000 |    37.78 us |  13.5036 us | 0.7630 us |
 |    **UnsafeUtf8ToUtf16** |            **18** |     **16** |    **1000** |    **30.12 us** |   **7.7396 us** | **0.4373 us** |
 | ConvertWithFramework |            18 |     16 |    1000 |    51.43 us |  13.1100 us | 0.7407 us |
 |    **UnsafeUtf8ToUtf16** |            **18** |    **256** |    **1000** |   **277.96 us** | **148.3220 us** | **8.3805 us** |
 | ConvertWithFramework |            18 |    256 |    1000 |   220.55 us |  56.4920 us | 3.1919 us |
 |    **UnsafeUtf8ToUtf16** |           **291** |      **1** |    **1000** |    **10.81 us** |   **0.6888 us** | **0.0389 us** |
 | ConvertWithFramework |           291 |      1 |    1000 |    42.00 us |   2.2490 us | 0.1271 us |
 |    **UnsafeUtf8ToUtf16** |           **291** |     **16** |    **1000** |    **41.31 us** |  **16.8139 us** | **0.9500 us** |
 | ConvertWithFramework |           291 |     16 |    1000 |   146.81 us |   1.4975 us | 0.0846 us |
 |    **UnsafeUtf8ToUtf16** |           **291** |    **256** |    **1000** |   **375.84 us** |  **28.3610 us** | **1.6024 us** |
 | ConvertWithFramework |           291 |    256 |    1000 |   968.56 us |  35.8456 us | 2.0253 us |
 |    **UnsafeUtf8ToUtf16** |          **4660** |      **1** |    **1000** |    **10.26 us** |   **1.8687 us** | **0.1056 us** |
 | ConvertWithFramework |          4660 |      1 |    1000 |    44.33 us |   9.3102 us | 0.5260 us |
 |    **UnsafeUtf8ToUtf16** |          **4660** |     **16** |    **1000** |    **33.41 us** |  **11.9960 us** | **0.6778 us** |
 | ConvertWithFramework |          4660 |     16 |    1000 |   193.11 us |  13.9341 us | 0.7873 us |
 |    **UnsafeUtf8ToUtf16** |          **4660** |    **256** |    **1000** |   **300.56 us** |  **13.8704 us** | **0.7837 us** |
 | ConvertWithFramework |          4660 |    256 |    1000 | 1,598.22 us | 167.6437 us | 9.4722 us |
