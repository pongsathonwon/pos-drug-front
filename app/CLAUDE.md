# app/ — Development Commands

All commands run from the `app/` directory unless noted.

## Daily development

| Task | Command |
|------|---------|
| Start full app (Tauri + Vite) | `npm run tauri dev` |
| Frontend only (Vite) | `npm run dev` |
| TypeScript check | `npx tsc --noEmit` |
| Rust check | `cargo check` (from `app/src-tauri/`) |
| Rust tests | `cargo test` (from `app/src-tauri/`) |

## Before committing

```bash
npx tsc --noEmit --skipLibCheck   # must pass — zero errors
cd src-tauri && cargo check        # must pass — zero warnings
```

## Build

```bash
npm run build           # frontend only (tsc + vite build)
npm run tauri build     # full production build (Tauri installer)
```

## Key paths

| What | Where |
|------|-------|
| Tauri commands (Rust) | `src-tauri/src/commands/` |
| TypeScript API wrappers | `src/api/` |
| Feature pages | `src/features/<domain>/` |
| Zustand session store | `src/store/session.ts` |
| SQLite migrations | `src-tauri/src/db/migrations/` |
| MUI theme | `src/theme.ts` |
| AppError types | `src/types/errors.ts` |
