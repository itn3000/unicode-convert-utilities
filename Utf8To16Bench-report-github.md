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
 |    **UnsafeUtf8ToUtf16** |            **18** |      **1** |    **1000** |    **16.595 us** |   **1.0522 us** |  **0.0595 us** |   **7.6599** |   **32256 B** |
 | ConvertWithFramework |            18 |      1 |    1000 |    35.562 us |   2.4606 us |  0.1390 us |   7.6294 |   32256 B |
 |    **UnsafeUtf8ToUtf16** |            **18** |     **16** |    **1000** |    **27.723 us** |   **9.1128 us** |  **0.5149 us** |  **15.3198** |   **64320 B** |
 | ConvertWithFramework |            18 |     16 |    1000 |    49.190 us |   5.8230 us |  0.3290 us |  15.3198 |   64320 B |
 |    **UnsafeUtf8ToUtf16** |            **18** |    **256** |    **1000** |   **150.752 us** |  **20.3639 us** |  **1.1506 us** | **129.8828** |  **545520 B** |
 | ConvertWithFramework |            18 |    256 |    1000 |   192.565 us |  60.6413 us |  3.4263 us | 129.8828 |  545520 B |
 |    **UnsafeUtf8ToUtf16** |           **291** |      **1** |    **1000** |     **9.835 us** |   **0.3240 us** |  **0.0183 us** |   **0.0458** |     **256 B** |
 | ConvertWithFramework |           291 |      1 |    1000 |    39.624 us |   6.9231 us |  0.3912 us |   7.6294 |   32256 B |
 |    **UnsafeUtf8ToUtf16** |           **291** |     **16** |    **1000** |    **32.739 us** |   **2.7882 us** |  **0.1575 us** |  **11.4746** |   **48336 B** |
 | ConvertWithFramework |           291 |     16 |    1000 |   128.090 us |   4.2586 us |  0.2406 us |  15.1367 |   64336 B |
 |    **UnsafeUtf8ToUtf16** |           **291** |    **256** |    **1000** |   **306.646 us** |  **21.2178 us** |  **1.1988 us** |  **68.8477** |  **289776 B** |
 | ConvertWithFramework |           291 |    256 |    1000 |   828.869 us |  89.0687 us |  5.0325 us | 129.8828 |  545776 B |
 |    **UnsafeUtf8ToUtf16** |          **4660** |      **1** |    **1000** |     **9.441 us** |   **0.3063 us** |  **0.0173 us** |   **0.0458** |     **256 B** |
 | ConvertWithFramework |          4660 |      1 |    1000 |    42.292 us |   1.2672 us |  0.0716 us |   7.6294 |   32256 B |
 |    **UnsafeUtf8ToUtf16** |          **4660** |     **16** |    **1000** |    **28.016 us** |   **0.9056 us** |  **0.0512 us** |   **9.6130** |   **40352 B** |
 | ConvertWithFramework |          4660 |     16 |    1000 |   171.144 us |  13.9258 us |  0.7868 us |  15.1367 |   64352 B |
 |    **UnsafeUtf8ToUtf16** |          **4660** |    **256** |    **1000** |   **235.784 us** |  **27.6937 us** |  **1.5647 us** |  **48.0957** |  **202032 B** |
 | ConvertWithFramework |          4660 |    256 |    1000 | 1,401.151 us | 498.9297 us | 28.1905 us | 128.9063 |  546032 B |
