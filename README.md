# Darts Practice Tracker
### .NET MAUI Blazor — Stub Project

---

## What's included

| File | Purpose |
|------|---------|
| `Models/SessionModels.cs` | All data models: `CricketSession`, `X01Session`, stat POCOs |
| `Services/SessionHistoryService.cs` | Singleton storing sessions; computes aggregate stats; stubs MAUI `Preferences` persistence |
| `Pages/Index.razor` | Home screen — game picker |
| `Pages/Cricket.razor` | Cricket game tracker |
| `Pages/X01.razor` | 301 / 501 tracker (parameterized route `/x01/301` and `/x01/501`) |
| `Pages/History.razor` | Aggregate stats + session log |
| `Shared/X01StatsPanel.razor` | Reusable stats grid for 301/501 |
| `wwwroot/css/app.css` | Full app styles — dark pub-board aesthetic |

---

## Tracked stats

### Cricket
- **Ochre count** — visits to the oche per game
- **Total marks thrown** — across all 7 targets (15–20, Bull)
- Target-by-target mark tracker (Single / Double / Triple buttons)
- Session duration

### 301 & 501
- **Darts to double-in** — how many darts before the opening double lands
- **Time to double-in** — wall clock from session start to landing the double
- **Average score per ochre** — classic 3-dart average, counted only post double-in
- **Time to double-out** — from double-in to the finishing double
- **Bust count** — number of bust ochres per leg

---

## Setup

**Requirements**
- Visual Studio 2022 17.8+ with .NET MAUI workload  
- .NET 8 SDK

**Steps**
```bash
# Clone / place project folder
dotnet restore DartsPractice/DartsPractice.csproj

# Run on Android emulator
dotnet build -t:Run -f net8.0-android

# Run on Windows
dotnet build -t:Run -f net8.0-windows10.0.19041.0
```

---

## Architecture notes & next steps

1. **Persistence** — `SessionHistoryService` stubs MAUI `Preferences` (string key-value). For production, replace with SQLite via `sqlite-net-pcl` or EF Core + SQLite provider. The polymorphic JSON converter in `SessionBaseConverter` is also stubbed — wire up a `$type` discriminator for full round-trip serialization.

2. **Double-out flow** — Currently the X01 page assumes that entering a score of exactly 0 means double-out. In a future iteration, add a "Double Out" button that starts the double-out timer separately, letting you track *attempts* before the final dart lands.

3. **Statistics charts** — The ochre log (`OchreLog` list) is wired up and ready for a sparkline or bar chart component (e.g. Telerik Blazor, Syncfusion, or a lightweight JS interop chart).

4. **Multiple legs / matches** — Sessions are currently single-leg. A `Match` wrapper class with multiple `X01Session` legs (best-of-N) would be a natural extension.

5. **Navigation** — `MainLayout.razor` uses a top nav bar. For mobile, consider switching to a bottom tab bar using MAUI Shell tabs alongside the BlazorWebView.
