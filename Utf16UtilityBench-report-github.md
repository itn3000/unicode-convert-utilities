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
 |               Method | CharacterCode | Length | LoopNum |        Mean |      Error |     StdDev |    Gen 0 | Allocated |
 |--------------------- |-------------- |------- |-------- |------------:|-----------:|-----------:|---------:|----------:|
 |         **GetUtf8Bytes** |            **18** |      **1** |    **1000** |    **22.06 us** |   **1.318 us** |  **0.0744 us** |  **10.2234** |  **31.47 KB** |
 | ConvertWithFramework |            18 |      1 |    1000 |    31.60 us |  12.860 us |  0.7266 us |  10.1929 |  31.47 KB |
 |         **GetUtf8Bytes** |            **18** |     **16** |    **1000** |    **64.42 us** |   **3.417 us** |  **0.1931 us** |  **22.9492** |  **70.59 KB** |
 | ConvertWithFramework |            18 |     16 |    1000 |    51.62 us |   2.715 us |  0.1534 us |  12.7563 |  39.34 KB |
 |         **GetUtf8Bytes** |            **18** |    **256** |    **1000** |   **810.64 us** |  **32.835 us** |  **1.8552 us** | **251.9531** | **774.65 KB** |
 | ConvertWithFramework |            18 |    256 |    1000 |   201.29 us |  10.079 us |  0.5695 us |  89.3555 | 274.65 KB |
 |         **GetUtf8Bytes** |           **291** |      **1** |    **1000** |    **22.68 us** |   **1.422 us** |  **0.0804 us** |  **10.2234** |  **31.47 KB** |
 | ConvertWithFramework |           291 |      1 |    1000 |    32.48 us |   3.569 us |  0.2016 us |  10.1929 |  31.47 KB |
 |         **GetUtf8Bytes** |           **291** |     **16** |    **1000** |    **80.41 us** |   **5.440 us** |  **0.3074 us** |  **22.9492** |  **70.59 KB** |
 | ConvertWithFramework |           291 |     16 |    1000 |   120.36 us |  71.099 us |  4.0173 us |  17.8223 |  54.96 KB |
 |         **GetUtf8Bytes** |           **291** |    **256** |    **1000** | **1,065.72 us** |  **83.015 us** |  **4.6905 us** | **251.9531** | **774.65 KB** |
 | ConvertWithFramework |           291 |    256 |    1000 |   764.13 us |  56.374 us |  3.1852 us | 169.9219 | 524.65 KB |
 |         **GetUtf8Bytes** |          **4660** |      **1** |    **1000** |    **23.06 us** |   **4.174 us** |  **0.2358 us** |  **10.2234** |  **31.47 KB** |
 | ConvertWithFramework |          4660 |      1 |    1000 |    34.32 us |   5.973 us |  0.3375 us |  10.1929 |  31.47 KB |
 |         **GetUtf8Bytes** |          **4660** |     **16** |    **1000** |   **123.05 us** |  **16.984 us** |  **0.9596 us** |  **22.9492** |  **70.59 KB** |
 | ConvertWithFramework |          4660 |     16 |    1000 |   143.69 us |  11.472 us |  0.6482 us |  22.9492 |  70.59 KB |
 |         **GetUtf8Bytes** |          **4660** |    **256** |    **1000** | **1,476.93 us** | **114.174 us** |  **6.4511 us** | **251.9531** | **774.65 KB** |
 | ConvertWithFramework |          4660 |    256 |    1000 | 1,148.44 us | 437.796 us | 24.7363 us | 251.9531 | 774.65 KB |
