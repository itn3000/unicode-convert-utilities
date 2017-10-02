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
 |               Method | CharacterCode | Length | LoopNum |      Mean |      Error |    StdDev |    Gen 0 | Allocated |
 |--------------------- |-------------- |------- |-------- |----------:|-----------:|----------:|---------:|----------:|
 |         **GetUtf8Bytes** |            **18** |      **1** |    **1000** |  **10.78 us** |  **0.6269 us** | **0.0354 us** |  **10.2386** |  **31.47 KB** |
 | ConvertWithFramework |            18 |      1 |    1000 |  31.09 us |  2.7831 us | 0.1572 us |  10.1929 |  31.47 KB |
 |         **GetUtf8Bytes** |            **18** |     **16** |    **1000** |  **28.26 us** |  **1.2378 us** | **0.0699 us** |  **22.9492** |  **70.59 KB** |
 | ConvertWithFramework |            18 |     16 |    1000 |  51.96 us | 19.8918 us | 1.1239 us |  12.7563 |  39.34 KB |
 |         **GetUtf8Bytes** |            **18** |    **256** |    **1000** | **240.62 us** | **85.3294 us** | **4.8213 us** | **251.9531** | **774.65 KB** |
 | ConvertWithFramework |            18 |    256 |    1000 | 201.10 us |  2.4748 us | 0.1398 us |  89.3555 | 274.65 KB |
