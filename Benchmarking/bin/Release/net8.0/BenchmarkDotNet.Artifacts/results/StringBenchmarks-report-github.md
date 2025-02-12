```

BenchmarkDotNet v0.13.10, Windows 11 (10.0.26100.2894)
Intel Core i5-14400F, 1 CPU, 16 logical and 10 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                  | Mean     | Error   | StdDev  | Ratio |
|------------------------ |---------:|--------:|--------:|------:|
| StringConcatenationTest | 204.9 ns | 3.16 ns | 2.64 ns |  1.00 |
| StringBuilderTest       | 170.3 ns | 2.13 ns | 1.99 ns |  0.83 |
