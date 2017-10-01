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
 |               Method | Character | Length | LoopNum |        Mean |       Error |     StdDev |
 |--------------------- |---------- |------- |-------- |------------:|------------:|-----------:|
 |   **CharEnumeratorTest** |        **18** |      **1** |    **1000** |    **32.65 us** |   **2.7864 us** |  **0.1574 us** |
 | ConvertWithFramework |        18 |      1 |    1000 |    37.67 us |  16.1159 us |  0.9106 us |
 |   **CharEnumeratorTest** |        **18** |     **16** |    **1000** |    **49.00 us** |  **11.0142 us** |  **0.6223 us** |
 | ConvertWithFramework |        18 |     16 |    1000 |    51.87 us |   2.9427 us |  0.1663 us |
 |   **CharEnumeratorTest** |        **18** |    **256** |    **1000** |   **397.23 us** |  **23.7893 us** |  **1.3441 us** |
 | ConvertWithFramework |        18 |    256 |    1000 |   221.27 us |  10.8647 us |  0.6139 us |
 |   **CharEnumeratorTest** |       **291** |      **1** |    **1000** |    **22.42 us** |   **3.7778 us** |  **0.2134 us** |
 | ConvertWithFramework |       291 |      1 |    1000 |    41.89 us |  10.9257 us |  0.6173 us |
 |   **CharEnumeratorTest** |       **291** |     **16** |    **1000** |    **68.28 us** |  **12.3259 us** |  **0.6964 us** |
 | ConvertWithFramework |       291 |     16 |    1000 |   146.39 us |  64.2426 us |  3.6298 us |
 |   **CharEnumeratorTest** |       **291** |    **256** |    **1000** |   **859.27 us** | **207.9270 us** | **11.7483 us** |
 | ConvertWithFramework |       291 |    256 |    1000 |   983.76 us | 107.3534 us |  6.0657 us |
 |   **CharEnumeratorTest** |      **4660** |      **1** |    **1000** |    **21.71 us** |   **2.8576 us** |  **0.1615 us** |
 | ConvertWithFramework |      4660 |      1 |    1000 |    44.83 us |   0.4428 us |  0.0250 us |
 |   **CharEnumeratorTest** |      **4660** |     **16** |    **1000** |    **56.31 us** |   **5.4365 us** |  **0.3072 us** |
 | ConvertWithFramework |      4660 |     16 |    1000 |   194.09 us |   9.8323 us |  0.5555 us |
 |   **CharEnumeratorTest** |      **4660** |    **256** |    **1000** |   **637.96 us** | **314.4702 us** | **17.7681 us** |
 | ConvertWithFramework |      4660 |    256 |    1000 | 1,617.20 us | 270.4328 us | 15.2800 us |
