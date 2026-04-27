# Alblue MES (Backend) — Handoff for new Claude session

> **Read this first.** Companion doc to the FE repo's `HANDOFF.md` — most context lives there. This file covers BE-specific notes.

## Repo

- BE (this repo): https://github.com/m1ck333/alblue-tracker-be
- FE: https://github.com/m1ck333/alblue-tracker-fe (`HANDOFF.md` there has full project context)
- Local path: `/Users/milosmitrovic/Projects/skysoft/alblue-tracker/AlblueMES`

## Quickstart

```bash
# Build (sanity)
dotnet build

# Run locally on port 5031
dotnet run --project AlblueMES.API
```

Local dev DB connection (`appsettings.Development.json`):
- Host: `localhost:5433`
- DB: `alblue_mes` (must be created manually first time)
- User: `milosmitrovic` / no password

## Architecture

.NET 9 modular monolith. Modules:
- **Identity** — users, roles, refresh tokens, shifts
- **Tenancy** — tenants + tenant settings
- **Production** — processes, sub-processes, product categories, dependencies, special-request types
- **Orders** — orders, items, attachments, block/change requests, work sessions, notifications, push subscriptions

Each module has `Domain`, `Application`, `Infrastructure`, `Api` projects. MediatR pipeline (handlers + validators + behaviors), Mapster for DTO mapping, FluentValidation, EF Core with snake_case naming.

Top-level `AlblueMES.API` is the host; references all module `.Api` projects.

## Database

- Postgres 16 (Docker container in production, local Postgres for dev)
- Each module owns its own schema: `identity`, `tenancy`, `production`, `orders`
- EF Core migrations applied automatically at startup (`Program.cs`)
- Connection string lives in `appsettings.Production.json` on the server (rsync excludes it)

## Production deploy

```bash
./deploy.sh
```

What it does:
1. `dotnet publish AlblueMES.API/AlblueMES.API.csproj -c Release -o ./publish`
2. `rsync -az --delete --exclude='appsettings.Production.json' --exclude='uploads/' ./publish/ root@46.101.166.137:/opt/alblue/api/`
3. `ssh root@46.101.166.137 "systemctl restart alblue-api"`

> ⚠️ **The `--exclude='uploads/'` is load-bearing.** Without it, every deploy wipes `/opt/alblue/api/uploads/` if anything is ever stored there. (Algreen had this exact bug — files were wiped, DB rows orphaned.) The proper fix is the `FileStorage.BasePath` override in `appsettings.Production.json` pointing at `/opt/alblue/uploads` (outside the rsync target).

## Production server config (lives only on server)

`/opt/alblue/api/appsettings.Production.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=alblue_tracker;Username=algreen;Password=AlGr33n_Pr0d_2026!"
  },
  "JwtSettings": {
    "Secret": "AlblueMES_...",
    "Issuer": "AlblueMES",
    "Audience": "AlblueMES",
    "ExpirationMinutes": 60
  },
  "WebPush": { "Enabled": false, ... },
  "FileStorage": { "BasePath": "/opt/alblue/uploads" }
}
```

`/etc/systemd/system/alblue-api.service`:
- Runs as root (legacy from algreen — fine for now, fix when sold)
- Binds to `127.0.0.1:5031`
- nginx exposes externally on port 5040

## Key patterns to follow

- **Commands** under `Application/Commands/<Verb><Entity>/` with `*Command.cs` + `*CommandHandler.cs`. Validator (FluentValidation) lives in `Application/Validators/`.
- **Queries** under `Application/Queries/<Get<Whatever>>/`.
- **DTOs** in `Application/DTOs/`. Mapping config in `Application/Mapping/<Module>MappingConfig.cs`.
- **Repositories** = interface in `Domain/Repositories/`, implementation in `Infrastructure/Repositories/`.
- **Aggregates** in `Domain/Entities/`. Always `private set;` on properties; mutate via methods that throw `DomainException` on invariants.
- **Migrations**: `dotnet ef migrations add <Name> --context <DbContext> --project src/Modules/<Module>/AlblueMES.Modules.<Module>.Infrastructure --startup-project AlblueMES.API`

## Critical gotchas (BE-side)

1. **Case-insensitive search** — repos use `.ToLower().Contains(s)` pattern; if you add a new search filter, follow the same pattern (Npgsql translates to `LOWER()...LIKE`, case-insensitive).
2. **`ProductName` is nullable** in `OrderItem`, validators, and API request DTOs. Don't add `[Required]` — empty product names are valid.
3. **DateTime UTC**: Postgres uses `timestamptz`; if you receive a `DateTime` from API (potentially `Unspecified` kind), call `DateTime.SpecifyKind(d, DateTimeKind.Utc)` before saving. See `Order.Update` for the pattern.
4. **`MarkCompleted` sets `CompletedAt = DateTime.UtcNow`**; `UndoComplete` resets to `null`. Don't break that pair.
5. **CheckInCommandHandler auto-closes stale cross-day sessions** — preserves the "if user left yesterday's session open, just close it and create a new one today" UX. Don't undo this.
6. **Order/process cascade**: deleting an `Order` cascades through items → processes → sub-processes → logs. Do NOT also delete attachments on `MarkCompleted` (was a bug; we removed it; attachments stay forever now).
7. **DataSeeder** runs on first startup if DB is empty. Seeds DEMO tenant, admin, processes, categories. Idempotent — checks before inserting.
8. **Block request fields**: `RequestNote` = operator's text from tablet ("Razlog blokade"); `BlockReason` = manager's response when approving ("Odgovor"). Names are misleading; don't rename without coordinating UI.
9. **Positional record constructors**: `UpdateOrderCommand`, `CreateOrderCommand`, etc. are positional. Adding a parameter in the middle silently breaks all callsites. Append at the end where possible.

## Don't break Algreen

The original BE (frozen) is at `https://github.com/NikolaMilanovic22/AlgreenMES`. They run on the **same droplet** but separate DB and separate systemd service. Anything you do here can't touch Algreen DATA, but watch out for shared resources:
- nginx (don't modify the algreen vhosts)
- postgres (you have your own DB, but the user `algreen` is shared)
- file paths (`/opt/algreen/*` is theirs, `/opt/alblue/*` is yours)

Bug fixes that apply to both: port manually.

## Memory

```
/Users/milosmitrovic/.claude/projects/-Users-milosmitrovic-Projects-skysoft-alblue-tracker-AlblueMES/memory/
```
