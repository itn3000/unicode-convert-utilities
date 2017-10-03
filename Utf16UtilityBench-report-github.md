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
 |                   Method | CharacterCode | Length | LoopNum |       Mean |       Error |     StdDev |    Gen 0 | Allocated |
 |------------------------- |-------------- |------- |-------- |-----------:|------------:|-----------:|---------:|----------:|
 |             **GetUtf8Bytes** |            **18** |      **1** |    **1000** |   **9.677 us** |   **3.3494 us** |  **0.1892 us** |   **7.6752** |   **32224 B** |
 |     ConvertWithFramework |            18 |      1 |    1000 |  26.729 us |   6.4295 us |  0.3633 us |   7.6599 |   32224 B |
 | GetUtf8BytesPreallocated |            18 |      1 |    1000 |   5.974 us |   1.0807 us |  0.0611 us |   0.0534 |     256 B |
 |             **GetUtf8Bytes** |            **18** |     **16** |    **1000** |  **16.001 us** |   **1.4492 us** |  **0.0819 us** |  **17.2119** |   **72280 B** |
 |     ConvertWithFramework |            18 |     16 |    1000 |  43.972 us |   9.9484 us |  0.5621 us |   9.5825 |   40280 B |
 | GetUtf8BytesPreallocated |            18 |     16 |    1000 |  10.643 us |   1.1223 us |  0.0634 us |   0.0763 |     352 B |
 |             **GetUtf8Bytes** |            **18** |    **256** |    **1000** | **137.166 us** |  **14.4425 us** |  **0.8160 us** | **188.9648** |  **793240 B** |
 |     ConvertWithFramework |            18 |    256 |    1000 | 173.621 us |  66.9239 us |  3.7813 us |  66.8945 |  281240 B |
 | GetUtf8BytesPreallocated |            18 |    256 |    1000 |  95.160 us |  11.9143 us |  0.6732 us |   0.3662 |    2032 B |
 |             **GetUtf8Bytes** |           **291** |      **1** |    **1000** |   **9.915 us** |   **1.5319 us** |  **0.0866 us** |   **7.6752** |   **32224 B** |
 |     ConvertWithFramework |           291 |      1 |    1000 |  27.431 us |   5.7277 us |  0.3236 us |   7.6599 |   32224 B |
 | GetUtf8BytesPreallocated |           291 |      1 |    1000 |   6.374 us |   2.2465 us |  0.1269 us |   0.0534 |     256 B |
 |             **GetUtf8Bytes** |           **291** |     **16** |    **1000** |  **39.446 us** |  **12.9066 us** |  **0.7292 us** |  **17.2119** |   **72280 B** |
 |     ConvertWithFramework |           291 |     16 |    1000 | 101.637 us |  13.0102 us |  0.7351 us |  13.3057 |   56280 B |
 | GetUtf8BytesPreallocated |           291 |     16 |    1000 |  36.267 us |   2.3018 us |  0.1301 us |   0.0610 |     352 B |
 |             **GetUtf8Bytes** |           **291** |    **256** |    **1000** | **413.046 us** | **162.5116 us** |  **9.1822 us** | **188.9648** |  **793240 B** |
 |     ConvertWithFramework |           291 |    256 |    1000 | 652.142 us | 192.7003 us | 10.8879 us | 127.9297 |  537240 B |
 | GetUtf8BytesPreallocated |           291 |    256 |    1000 | 363.042 us |  45.4072 us |  2.5656 us |        - |    2032 B |
 |             **GetUtf8Bytes** |          **4660** |      **1** |    **1000** |  **10.951 us** |   **1.6727 us** |  **0.0945 us** |   **7.6752** |   **32224 B** |
 |     ConvertWithFramework |          4660 |      1 |    1000 |  28.783 us |   1.2688 us |  0.0717 us |   7.6599 |   32224 B |
 | GetUtf8BytesPreallocated |          4660 |      1 |    1000 |   7.291 us |   0.6557 us |  0.0370 us |   0.0534 |     256 B |
 |             **GetUtf8Bytes** |          **4660** |     **16** |    **1000** |  **52.962 us** |   **7.5747 us** |  **0.4280 us** |  **17.2119** |   **72280 B** |
 |     ConvertWithFramework |          4660 |     16 |    1000 | 121.967 us |   6.6613 us |  0.3764 us |  17.2119 |   72280 B |
 | GetUtf8BytesPreallocated |          4660 |     16 |    1000 |  43.805 us |   9.8443 us |  0.5562 us |   0.0610 |     352 B |
 |             **GetUtf8Bytes** |          **4660** |    **256** |    **1000** | **547.252 us** |  **55.4781 us** |  **3.1346 us** | **188.4766** |  **793240 B** |
 |     ConvertWithFramework |          4660 |    256 |    1000 | 952.998 us | 100.7889 us |  5.6948 us | 188.4766 |  793240 B |
 | GetUtf8BytesPreallocated |          4660 |    256 |    1000 | 507.978 us |  69.3190 us |  3.9167 us |        - |    2032 B |
