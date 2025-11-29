# ⏱️ TickerQ Auto-Registration Source Generator

A Roslyn source generator that automatically registers TickerQ jobs using attributes — no manual registration, no boilerplate, just clean developer experience.

## ✨ Overview

TickerQ normally requires developers to manually register time-based jobs.  
This source generator removes that friction by scanning your code at compile time and generating the necessary registration logic automatically.

It introduces **time-based scheduling attributes** and generates the required job registration code behind the scenes.

👉 **Example project**: [`tickerq-sample`](https://github.com/hosgha/tickerq-sample)

## 🚀 Features

- 🟢 **Auto-registration** of time-based jobs (`OffsetSeconds` / `ExecutionTime`)
- 🛠 **Zero manual configuration** — works automatically at build time
- 🔍 **Compile-time diagnostics** for incorrect attribute usage
- 🧩 **Fully compatible** with existing TickerQ runtime
- 💡 **Cleaner DX** — define jobs using simple attributes
- 📦 **One-time and delayed jobs** fully supported

> ⚠️ **Note**: Cron support through unified `TickerFunctionAttribute` is planned as the next major enhancement.

## 📦 Installation

Add the generator to your project:

```xml
<PackageReference Include="TickerQSourceGenerator" Version="1.0.0" />
```

## 🎯 Quick Start

### 1. Define your jobs with attributes

```csharp
public class SampleJobs
{
    // Runs once after 30 seconds
    [TimeJob(OffsetSeconds = 30)]
    public static Task DelayedJob(TickerFunctionContext ctx, CancellationToken ct)
        => Task.CompletedTask;

    // Runs at a specific time (UTC)
    [TimeJob(ExecutionTime = "2025-11-30T09:00:00Z")]
    public static Task ScheduledJob(TickerFunctionContext ctx, CancellationToken ct)
        => Task.CompletedTask;
}
```

### 2. The source generator produces this automatically

```csharp
// Auto-generated job registration code (simplified)
public partial class JobRegistrationService
{
    partial void RegisterJobs(ITimeTickerManager<TimeTickerEntity> timeManager)
    {
        _ = RegisterJobsAsync(timeManager);
    }

    private async Task RegisterJobsAsync(ITimeTickerManager<TimeTickerEntity> timeManager)
    {
        await timeManager.AddAsync(new TimeTickerEntity {
            Function = "DelayedJob",
            ExecutionTime = DateTime.UtcNow.AddSeconds(30)
        });

        await timeManager.AddAsync(new TimeTickerEntity {
            Function = "ScheduledJob",
            ExecutionTime = DateTime.Parse("2025-11-30T09:00:00Z").ToUniversalTime()
        });
    }
}
```

🎉 **No more manual registration!**

## 🔧 TimeJob Attribute Options

```csharp
[TimeJob(
    OffsetSeconds = 60,                    // Run after X seconds
    ExecutionTime = "2025-11-30T09:00:00Z" // ISO-8601 time
)]
```

> **Note**: Only one scheduling mode can be set per job.

## ⚡ Supported Job Types

| Type | Icon | Description |
|------|------|-------------|
| **Relative delay** | ⏳ | Run after `OffsetSeconds` |
| **Absolute time** | 🕘 | Run at specific ISO-8601 date/time |
| **One-time jobs** | 🎯 | Automatically executed once |
| **Cron jobs** | 🕒 | *Planned (via unified TickerFunctionAttribute)* |

## 🔍 Diagnostics

The source generator provides compile-time feedback:

| Code | Description | Fix |
|------|-------------|-----|
| **TQ001** | Both `OffsetSeconds` and `ExecutionTime` are set | Use only one scheduling method |
| **TQ002** | Invalid ISO-8601 datetime | Fix the datetime format |
| **TQ003** | Negative `OffsetSeconds` | Use a positive value |

## 🏗 Project Structure

```
TickerQSourceGenerator/
├── JobAutoRegistrationGenerator.cs     # Main Roslyn generator
├── TimeJobAttribute.cs                 # Attribute for time-based jobs
└── Samples/
    ├── SampleJobs.cs                   # Example job class
    └── Program.cs                      # How to run jobs
```

## 🎯 Use Cases

- 📨 **Send scheduled emails**
- 🧹 **Cleanup temporary files**
- 📊 **Nightly report generation**
- 🕒 **Delayed event processing**
- 🔧 **Maintenance tasks** at a specific datetime

## 🔮 Future Enhancements

- [ ] **Unified cron + time scheduling** via `TickerFunctionAttribute`
- [ ] **Config-driven job definitions**
- [ ] **Scheduler analytics & dashboards**
- [ ] **Visual Studio job management tooling**
- [ ] **Job dependency graph support**

## 🛠 Development

### Prerequisites
- .NET 6.0 or later
- Visual Studio 2022 or VS Code with C# Dev Kit

### Building from Source
```bash
git clone https://github.com/hosgha/tickerq-source-generator.git
cd tickerq-source-generator
dotnet build
```

### Running Tests
```bash
dotnet test
```

## ❓ FAQ

### Q: Does this work with existing TickerQ projects?
**A:** Yes! It's designed to work seamlessly with existing TickerQ installations without breaking changes.

### Q: What happens if I have both manual and auto-registered jobs?
**A:** Both will work together. The source generator adds to your existing registration.

### Q: Can I use this in library projects?
**A:** Yes, the source generator works in any project type that supports TickerQ.

### Q: How do I debug generated code?
**A:** Generated code appears in your project's `obj` folder under `SourceGeneratorFiles`.

## 🤝 Contributing

1. **Fork the repo**
2. **Create a feature branch** (`git checkout -b feature/amazing-feature`)
3. **Commit your changes** (`git commit -m 'Add amazing feature'`)
4. **Push your branch** (`git push origin feature/amazing-feature`)
5. **Open a Pull Request**

## 📄 License

MIT License — see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Built on [TickerQ](https://github.com/tickerq/tickerq) scheduling library
- Uses [Roslyn](https://github.com/dotnet/roslyn) source generators
- Inspired by the need for better DX in job scheduling

## 📞 Support

- **Issues**: [GitHub Issues](https://github.com/hosgha/tickerq-source-generator/issues)
- **Discussions**: [GitHub Discussions](https://github.com/hosgha/tickerq-source-generator/discussions)

---

**⭐ If this project improves your DX, please star the repo! It helps visibility and future development.**

---

*This project demonstrates the power of source generators for improving developer experience. The ultimate goal is to contribute these enhancements to the main TickerQ library.*
