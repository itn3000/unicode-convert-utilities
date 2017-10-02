``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 8.1 (6.3.9600)
Processor=Intel Core i7-4770 CPU 3.40GHz (Haswell), ProcessorCount=8
Frequency=3312641 Hz, Resolution=301.8739 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]   : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  ShortRun : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
 |               Method | CharacterCode | Length | LoopNum |         Mean |       Error |     StdDev |    Gen 0 | Allocated |
 |--------------------- |-------------- |------- |-------- |-------------:|------------:|-----------:|---------:|----------:|
 |    **UnsafeUtf8ToUtf16** |            **18** |      **1** |    **1000** |    **16.661 us** |   **0.5081 us** |  **0.0287 us** |   **7.6599** |   **32256 B** |
 | ConvertWithFramework |            18 |      1 |    1000 |    35.861 us |   2.4045 us |  0.1359 us |   7.6294 |   32256 B |
 |    **UnsafeUtf8ToUtf16** |            **18** |     **16** |    **1000** |    **24.537 us** |   **0.8530 us** |  **0.0482 us** |  **15.3198** |   **64320 B** |
 | ConvertWithFramework |            18 |     16 |    1000 |    49.207 us |   6.1819 us |  0.3493 us |  15.3198 |   64320 B |
 |    **UnsafeUtf8ToUtf16** |            **18** |    **256** |    **1000** |   **148.647 us** |  **46.6679 us** |  **2.6368 us** | **129.8828** |  **545520 B** |
 | ConvertWithFramework |            18 |    256 |    1000 |   194.958 us |  72.1146 us |  4.0746 us | 129.8828 |  545520 B |
 |    **UnsafeUtf8ToUtf16** |           **291** |      **1** |    **1000** |     **9.551 us** |   **0.1832 us** |  **0.0103 us** |   **0.0458** |     **256 B** |
 | ConvertWithFramework |           291 |      1 |    1000 |    39.569 us |   5.2824 us |  0.2985 us |   7.6294 |   32256 B |
 |    **UnsafeUtf8ToUtf16** |           **291** |     **16** |    **1000** |    **35.218 us** |   **2.0811 us** |  **0.1176 us** |  **11.4746** |   **48336 B** |
 | ConvertWithFramework |           291 |     16 |    1000 |   127.875 us |   3.3533 us |  0.1895 us |  15.1367 |   64336 B |
 |    **UnsafeUtf8ToUtf16** |           **291** |    **256** |    **1000** |   **302.141 us** |  **22.2030 us** |  **1.2545 us** |  **68.8477** |  **289776 B** |
 | ConvertWithFramework |           291 |    256 |    1000 |   837.383 us |  60.2338 us |  3.4033 us | 129.8828 |  545776 B |
 |    **UnsafeUtf8ToUtf16** |          **4660** |      **1** |    **1000** |     **9.248 us** |   **0.2107 us** |  **0.0119 us** |   **0.0458** |     **256 B** |
 | ConvertWithFramework |          4660 |      1 |    1000 |    41.637 us |   5.0957 us |  0.2879 us |   7.6294 |   32256 B |
 |    **UnsafeUtf8ToUtf16** |          **4660** |     **16** |    **1000** |    **27.864 us** |   **4.8488 us** |  **0.2740 us** |   **9.6130** |   **40352 B** |
 | ConvertWithFramework |          4660 |     16 |    1000 |   172.632 us |  16.1172 us |  0.9107 us |  15.1367 |   64352 B |
 |    **UnsafeUtf8ToUtf16** |          **4660** |    **256** |    **1000** |   **250.246 us** |  **99.4280 us** |  **5.6179 us** |  **48.0957** |  **202032 B** |
 | ConvertWithFramework |          4660 |    256 |    1000 | 1,362.740 us | 294.1477 us | 16.6199 us | 128.9063 |  546032 B |
