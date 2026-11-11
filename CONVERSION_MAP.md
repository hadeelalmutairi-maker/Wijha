# Wijha – Laravel 10 → ASP.NET Core MVC (.NET 8) Conversion Map

## Project overview

A 1:1 structural translation of the Wijha Laravel 10 application into ASP.NET Core MVC (.NET 8),
targeting SQL Server (the existing wijha_db — no migrations were run). The .NET code is a faithful
structural replica; not all files will compile without further wiring but fidelity is the priority.

---

## Directory mapping

| Laravel path | .NET path |
|---|---|
| `app/Models/` | `Wijha/Models/` |
| `app/Http/Controllers/` | `Wijha/Controllers/` |
| `resources/views/` | `Wijha/Views/` |
| `resources/views/layouts/` | `Wijha/Views/layouts/` |
| `resources/views/components/` | `Wijha/Views/components/` |
| `resources/views/partials/` | `Wijha/Views/partials/` |
| `resources/views/auth/` | `Wijha/Views/auth/` |
| `resources/views/customer/` | `Wijha/Views/customer/` |
| `resources/views/provider/` | `Wijha/Views/provider/` |
| `resources/views/admin/` | `Wijha/Views/admin/` |
| `resources/views/public/` | `Wijha/Views/public/` |
| `resources/views/vendor/pagination/` | `Wijha/Views/vendor/pagination/` |
| `public/css/` | `Wijha/wwwroot/css/` |
| `public/images/` | `Wijha/wwwroot/images/` |
| `app/Http/Requests/` | (no direct equiv.; FormRequest → ViewModel + ErrorBag pattern) |
| `config/app.php` | `Wijha/appsettings.json` |
| `database/migrations/` | (skipped — existing SQL Server database retained as-is) |

---

## Blade → Razor translation patterns

| Blade | Razor |
|---|---|
| `@extends('layouts.x')` | `Layout = "~/Views/layouts/_x.cshtml";` |
| `@section('content') … @endsection` | Content goes directly in view body |
| `@yield('content')` | `@RenderBody()` |
| `@push('scripts') … @endpush` | `@section scripts { … }` |
| `@stack('scripts')` | `@RenderSection("scripts", required: false)` |
| `@once @push('scripts')` | JS guard: `if (window._flagLoaded) return; window._flagLoaded = true;` |
| `@include('path', [...])` | `@await Html.PartialAsync("~/Views/...", (object)new { … })` |
| `<x-component />` | `@await Html.PartialAsync("~/Views/components/_component.cshtml", …)` |
| `{{ route('name') }}` | `@Url.RouteUrl("name")` |
| `{{ route('name', ['p'=>v]) }}` | `@Url.RouteUrl("name", new { p = v })` |
| `@csrf` | `@Html.AntiForgeryToken()` |
| `@method('PUT')` | `<input type="hidden" name="_method" value="PUT">` |
| `@error('field') … @enderror` | `@if (errors.Has("field")) { … }` with `var errors = new ErrorBag(ViewContext);` |
| `old('field')` | `Flash.Old(ViewContext.HttpContext, "field")` |
| `@json($data)` | `@Html.Raw(System.Text.Json.JsonSerializer.Serialize(data))` |
| `@forelse($items as $x) … @empty … @endforelse` | `@foreach` + separate `@if (!items.Any()) { }` empty block |
| `@selected($x === $y)` | `@(x == y ? "selected" : "")` |
| `@checked($x)` | `@(x ? "checked" : "")` |
| `{{ now('Asia/Riyadh')->format('d M Y') }}` | `DateTime.Now.ToString("dd MMM yyyy")` |
| `{{ Str::plural('x', $n) }}` | `(n == 1 ? "x" : "xs")` inline ternary |
| `@@media` / `@@keyframes` in `<style>` | Same — Razor requires `@@` to escape the `@` in CSS at-rules |

---

## Auth / guard mapping

| Laravel guard | ASP.NET Core cookie scheme |
|---|---|
| `auth('customer')` | `"customer"` scheme, `[Authorize(AuthenticationSchemes = "customer")]` |
| `auth('provider')` | `"provider"` scheme, `[Authorize(AuthenticationSchemes = "provider")]` |
| `auth('admin')` | `"admin"` scheme, `[Authorize(AuthenticationSchemes = "admin")]` |

---

## Key support classes

| Class | Location | Purpose |
|---|---|---|
| `WijhaDbContext` | `Wijha/Data/WijhaDbContext.cs` | EF Core DbContext for wijha_db |
| `LengthAwarePaginator<T>` | `Wijha/Support/LengthAwarePaginator.cs` | Paginator with `Links()` HTML helper |
| `Flash` | `Wijha/Support/Flash.cs` | TempData helper: `Flash.Get<T>()`, `Flash.Old()`, `Flash.Set()` |
| `ErrorBag` | `Wijha/Support/Http/ErrorBag.cs` | Validation errors from TempData, `Has(field)`, `Get(field)`, `HasAny()` |
| `DateRange` | `Wijha/Support/DateRange.cs` | Date range filter: `Key`, `From`, `To`, `Presets`, `Params()`, `Describe()` |
| `WijhaHelpers` | `Wijha/Helpers/WijhaHelpers.cs` | `ImageUrl()`, `PriceUnit()`, `Cities()` |
| `IWijhaPaginator` | `Wijha/Support/IWijhaPaginator.cs` | Interface used by pagination partials |

---

## EF Core column type notes

| SQL Server type | C# type |
|---|---|
| `date` | `DateOnly` |
| `time(0)` | `TimeOnly` |
| `datetime` / `datetime2` | `DateTime` |
| `decimal(10,2)` | `decimal` |
| `bit` | `bool` |
| `nvarchar(max)` nullable | `string?` |

---

## Route name conventions

Routes follow the Laravel `Route::name()` pattern mapped 1:1, e.g.:
- `home`, `login`, `register`, `logout`
- `providers.index`, `providers.show`, `providers.discover`, `providers.reviews`
- `compare.add`, `compare.remove`, `compare.clear`
- `customer.bookings.create`, `customer.bookings.index`, etc.
- `provider.dashboard`, `provider.availability.index`, etc.
- `admin.dashboard`, `admin.bookings.index`, etc.

---

## Files NOT translated

- Laravel-specific: `routes/web.php`, `config/`, `bootstrap/`, `artisan`, composer files
- Database: migrations, seeders (existing SQL Server database retained)
- Tests: `tests/`
