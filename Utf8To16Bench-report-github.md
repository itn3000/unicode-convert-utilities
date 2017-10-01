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
 |               Method | CharacterCode | Length | LoopNum |        Mean |      Error |    StdDev |
 |--------------------- |-------------- |------- |-------- |------------:|-----------:|----------:|
 |    **UnsafeUtf8ToUtf16** |            **18** |      **1** |    **1000** |    **33.58 us** |  **29.718 us** | **1.6791 us** |
 | ConvertWithFramework |            18 |      1 |    1000 |    38.07 us |  16.337 us | 0.9231 us |
 |    **UnsafeUtf8ToUtf16** |            **18** |     **16** |    **1000** |    **49.55 us** |  **11.357 us** | **0.6417 us** |
 | ConvertWithFramework |            18 |     16 |    1000 |    52.26 us |   3.637 us | 0.2055 us |
 |    **UnsafeUtf8ToUtf16** |            **18** |    **256** |    **1000** |   **399.30 us** |  **22.139 us** | **1.2509 us** |
 | ConvertWithFramework |            18 |    256 |    1000 |   226.22 us |  65.847 us | 3.7205 us |
 |    **UnsafeUtf8ToUtf16** |           **291** |      **1** |    **1000** |    **22.53 us** |   **3.248 us** | **0.1835 us** |
 | ConvertWithFramework |           291 |      1 |    1000 |    41.41 us |   5.601 us | 0.3164 us |
 |    **UnsafeUtf8ToUtf16** |           **291** |     **16** |    **1000** |    **69.06 us** |   **4.795 us** | **0.2709 us** |
 | ConvertWithFramework |           291 |     16 |    1000 |   145.06 us |  27.466 us | 1.5519 us |
 |    **UnsafeUtf8ToUtf16** |           **291** |    **256** |    **1000** |   **853.32 us** |  **72.593 us** | **4.1016 us** |
 | ConvertWithFramework |           291 |    256 |    1000 |   979.85 us |  71.521 us | 4.0411 us |
 |    **UnsafeUtf8ToUtf16** |          **4660** |      **1** |    **1000** |    **21.89 us** |   **1.253 us** | **0.0708 us** |
 | ConvertWithFramework |          4660 |      1 |    1000 |    44.79 us |   4.284 us | 0.2420 us |
 |    **UnsafeUtf8ToUtf16** |          **4660** |     **16** |    **1000** |    **56.05 us** |   **7.071 us** | **0.3995 us** |
 | ConvertWithFramework |          4660 |     16 |    1000 |   194.52 us |  28.291 us | 1.5985 us |
 |    **UnsafeUtf8ToUtf16** |          **4660** |    **256** |    **1000** |   **628.05 us** |  **59.092 us** | **3.3388 us** |
 | ConvertWithFramework |          4660 |    256 |    1000 | 1,608.28 us | 166.299 us | 9.3962 us |
