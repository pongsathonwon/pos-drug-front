# DrugFront POS v2 — Migration Project

## What This Project Is

A full pharmacy POS system rewrite from VB.NET WinForms + Microsoft Access + SOAP
to Tauri + React/TypeScript + SQLite. ~160+ source files, 209+ UI forms being ported.
Thai localization, fingerprint hardware, offline-first operation, and a mature
pharmacy domain (pricing tiers, promotions, loyalty, allergy checking) must be preserved exactly.

---

## Repository Structure

```
drugfront-v2/
├── legacy/DrugFront               ← VB.NET source — READ-ONLY, never modify
│   ├── src/                       ← .vb form and module files
│   ├── data/                      ← data.mdb, config files
│   └── Web References/            ← SOAP .asmx service definitions
├── docs/                          ← migration brain, source of truth
│   ├── data-archaeology.md
│   ├── operational-archaeology.md
│   ├── auth-spec.md
│   ├── business-rules.md
│   ├── schema-proposals.md
│   ├── command-mapping.md
│   ├── eav-strategy.md
│   ├── vb-gotchas.md
│   ├── system-requirements.md
│   ├── migration-tracker.md
│   └── session-handoff.md
├── src-tauri/                     ← Rust backend
│   ├── src/
│   │   ├── main.rs
│   │   ├── commands/              ← one file per SOAP operation ported
│   │   └── db/
│   │       ├── schema.sql
│   │       └── migrations/
│   └── Cargo.toml
├── src/                           ← React + TypeScript frontend
│   ├── api/                       ← typed invoke() wrappers, one per command
│   ├── features/                  ← feature-sliced by domain module
│   │   ├── auth/
│   │   ├── sales/
│   │   ├── inventory/
│   │   ├── loyalty/
│   │   ├── promotions/
│   │   ├── accounting/
│   │   └── reports/
│   ├── components/
│   └── types/
├── migration-scripts/             ← one-time .mdb → SQLite migration tools
├── .claude/
│   ├── CLAUDE.md                  ← this file
│   ├── settings.json
│   ├── agents/
│   └── skills/
└── tauri.conf.json
```

---

## Legacy Stack (Source)

| Layer          | Technology                                                    |
| -------------- | ------------------------------------------------------------- |
| Language       | VB.NET Windows Forms                                          |
| Database       | Microsoft Access (.mdb) — 32-bit, no row locking              |
| API            | SOAP .asmx web services                                       |
| Queries        | Raw string concatenation — SQL injection at every entry point |
| Auth           | Plaintext string comparison in DB                             |
| Offline        | Manual sync via frmUploadServer.vb — no conflict resolution   |
| Reports        | Crystal Reports v10.2.3600 (EOL)                              |
| Config         | Registry keys + hardcoded IP addresses                        |
| Licensing      | Physical disk serial number via registry                      |
| Localization   | Thai                                                          |
| Hardware       | Fingerprint reader integration                                |
| Error handling | String codes: "1" success, "0" no rows, "-1" error            |
| State          | Single public module DrugMod.vb — global mutable state        |

---

## Target Stack (v2)

| Layer          | Technology                                      |
| -------------- | ----------------------------------------------- |
| Desktop shell  | Tauri (Rust backend)                            |
| Frontend       | React 18 + TypeScript                           |
| Local database | SQLite (per-terminal, offline-first)            |
| API pattern    | Tauri IPC commands (replace SOAP 1:1)           |
| Auth           | bcrypt password hashing + session tokens        |
| Offline        | SQLite local queue + background sync            |
| Reports        | [Decide after core is stable]                   |
| Config         | tauri.conf.json + .env per environment          |
| Licensing      | Cloud validation + offline grace period         |
| Localization   | Thai — preserve all existing strings            |
| Hardware       | Fingerprint — Tauri plugin or native bridge     |
| Error handling | Rust Result<T, Error> → typed TypeScript errors |
| State          | Scoped session objects, no global mutable state |

---

## Deployment Scale

```
Active branches:        ~100
POS per branch:         3-5  (300-500 terminals total)
Daily transactions:     ~8,000
Peak load:              ~2 requests/sec
Offline requirement:    Branch must operate fully during network outage
Sync model:             Eventually consistent, not real-time
```

**Architecture implication:** One Tauri instance per branch acting as local server.
POS terminals are React frontend hitting the branch Tauri backend.
Transactions queue locally if central sync is down. Never block a sale for network.

---

## THE MOST CRITICAL RULES

### 1. legacy/ is read-only

No file inside `legacy/` is ever modified. It is reference material, not part of the build.
If Claude attempts to write to `legacy/`, stop immediately.

### 2. Business logic is preserved exactly

The pricing tier system, promotion engine, loyalty points, allergy checking,
and accounting close flow represent years of pharmacy domain knowledge.
Port the behavior. Do not improve, simplify, or normalize it without explicit instruction.
If legacy behavior seems wrong, preserve it and add a comment — never silently fix it.

### 3. No production code before design is approved

Sessions are gated:

- Session 1 (Explore): docs/ only
- Session 2 (Design): docs/ proposals only, I approve before any .rs or .ts is written
- Session 3+ (Implementation): one module at a time, using approved docs as spec

### 4. Thai localization must be preserved

All user-facing strings are in Thai. Do not translate, replace, or restructure them.
Preserve existing Thai text character-for-character from legacy forms.

---

## VB.NET Behavioral Traps — Must Reproduce in Port

### String Comparison

VB default: case-insensitive (`"Admin" = "admin"` is True)
TypeScript/Rust: case-sensitive
→ All auth, permission, and code lookups MUST use `.toLowerCase()` / `.to_lowercase()`

### Global State (DrugMod.vb)

Legacy stores session in public module globals:
`pUserCode`, `pUserName`, `pBranchCode`, `pServerAddr`, and dozens more.
These must map to a scoped session object in v2 — never re-create globals.

### Error Code Strings

Legacy: `mGet(0)` returns `"1"`, `"0"`, `"-1"` — check every call site.
v2: Rust `Result<T, AppError>` with typed error variants, not magic strings.

### Offline Fallback

Legacy writes to local .mdb when server unreachable.
v2 must queue to SQLite and sync automatically — never require manual upload.

### SQL String Concatenation

Every `pService.GetData("Drug", "SELECT ... WHERE x='" & input & "'")` is an injection point.
v2: parameterized queries only. Never string-build SQL.

### Date Formats

Legacy serializes dates in Thai locale-dependent format.
Parse using exact format found in data.mdb — not ISO 8601 — until migration is complete.

### 1-Based Collections

VB collections are 1-indexed. Audit every ported loop for off-by-one errors.

### On Error Resume Next

Legacy silently swallows errors. These hidden failure modes must be made explicit in Rust.
Find every instance and document the intended behavior in docs/vb-gotchas.md.

---

## Domain Modules — Migration Priority Order

```
Priority  Module                  Risk     Notes
────────────────────────────────────────────────────────────────
1         Auth / Session          HIGH     Global state → scoped session
2         Branch / Terminal sync  HIGH     Offline-first architecture
3         Inventory / Drug lookup MEDIUM   Core POS function
4         Sales transaction       HIGH     Pricing tiers + allergy check
5         Promotion engine        HIGH     Complex rules, years of tuning
6         Loyalty points          MEDIUM   Calculation must match exactly
7         Payment processing      HIGH     Never lose a transaction
8         Stock updates           MEDIUM   Must be atomic with sale
9         Accounting close        HIGH     Regulatory — preserve exactly
10        User management         LOW      Simpler once auth layer exists
11        Reports                 LOW      Port last, not blocking sales
12        Fingerprint hardware    MEDIUM   Needs Tauri native plugin
13        Licensing               LOW      Port last
```

---

## SOAP → Tauri Command Convention

Every SOAP operation becomes one Tauri command. Strict 1:1 mapping:

```
SOAP:     pService.GetData("Drug", sql)
Tauri:    get_drug_data(query: DrugQuery) → Result<DrugData, AppError>

SOAP:     pService.UpdateData("Sale", sql)
Tauri:    create_sale(sale: SaleInput) → Result<SaleResult, AppError>
```

**File locations:**

```
src-tauri/src/commands/drug.rs          ← Rust command
src/api/drug.ts                         ← TypeScript invoke() wrapper
src/features/inventory/                 ← React feature consuming it
```

Never combine multiple SOAP operations into one Tauri command.
Never create a Tauri command without a corresponding TypeScript wrapper.

---

## SQLite Architecture Decision

@docs/eav-strategy.md ← fill after Session 1, approve before Session 3

**Pending confirmation from legacy audit:**

- Is data per-terminal, per-branch, or central?
- How does offline sync currently work between terminals in same branch?
- What is the conflict resolution strategy (last-write-wins, or queue-based)?

---

## Session Rules

### Concurrency — never run simultaneously:

- Any migration-script agent + any porter agent (shared schema)
- Two porter agents working on modules that share tables
- Explore agents + any write agent

### Safe to parallelize:

- port-verifier + vb-reader (both read-only)
- Independent SOAP operation ports (confirmed no shared tables)

### Sequential dependencies (must complete in order):

```
Session 1 complete → Session 2 design
Schema approved    → Migration scripts
Migration scripts  → SOAP port
SOAP port done     → port-verifier sign-off
port-verifier pass → mark [x] in migration-tracker.md
```

---

## Agent Model Map

| Agent           | Model  | Reason                           |
| --------------- | ------ | -------------------------------- |
| archaeologist   | haiku  | Mechanical reading, high volume  |
| vb-reader       | sonnet | Pattern recognition in VB quirks |
| schema-designer | opus   | Architecture decisions           |
| sqlite-migrator | sonnet | Precise migration logic          |
| soap-porter     | sonnet | Business logic translation       |
| port-verifier   | haiku  | Read-only comparison             |
| react-component | sonnet | UI implementation                |

---

## What This Project Must Never Do

- Modify any file in `legacy/`
- Use raw string SQL in v2 code — parameterized queries only
- Store passwords in plaintext
- Hardcode IP addresses or credentials
- Silently drop a transaction due to network failure
- Change Thai user-facing strings without explicit instruction
- Create a Tauri command that combines what were two separate SOAP operations
- Mark a module complete in migration-tracker.md without port-verifier sign-off

---

## Current Status

@docs/migration-tracker.md
@docs/session-handoff.md
