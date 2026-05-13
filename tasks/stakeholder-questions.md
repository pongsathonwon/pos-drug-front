# Stakeholder Questions — Pre-Session 2

Answers to these questions are required before Session 2 design can begin.
Check off each item once confirmed and add the answer inline.

---

## Business Owner / Pharmacy Manager

### Pricing & Discounts

- [ ] **Discount stacking order** — When a sale has multiple discounts (line-item, group, promotion, manual), what is the exact application sequence? Do they compound or is there a cap?
  > _Answer:_

- [ ] **Promotion + loyalty combo** — Can a customer receive both a promotion discount AND a loyalty point bonus on the same sale, or does one exclude the other?
  > _Answer:_

- [ ] **Member price display** — When `pAllowOnlyMembPrice = "1"`, does the cashier see both the general price and member price on-screen, or only the member price?
  > _Answer:_

- [ ] **VAT inclusion** — Is VAT already included in the shelf/sticker price, or is it added on top at checkout?
  > _Answer:_

- [ ] **Employee purchase limit enforcement** — When a sale exceeds `pEmplBuyLimit`, is the sale hard-blocked or is it a warning the cashier can bypass?
  > _Answer:_

### Loyalty Points

- [ ] **Redemption rate** — What is the point-to-baht redemption rate (e.g., 1 point = 1 baht)?
  > _Answer:_

- [ ] **Point expiry** — Do loyalty points expire? If yes, after how long and how is expiry currently enforced?
  > _Answer:_

- [ ] **Points on return** — When a sale is refunded, are points earned on that sale deducted? Are previously redeemed points restored?
  > _Answer:_

- [ ] **Point balance update timing** — Is `CustInfo.custPoint` updated immediately after each sale or in a batch process?
  > _Answer:_

### Promotions

- [ ] **Multiple promotion stacking** — If a customer qualifies for multiple active promotions at once, do all apply or only the best/last one?
  > _Answer:_

- [ ] **Promotion management authority** — Who can set promotion start/end dates — branch manager only, or head office only, or both?
  > _Answer:_

### Returns & Refunds

- [ ] **Return on closed sale** — Can a sale with `closeNumb ≠ "0"` (already accounting-closed) be returned? If yes, does it require a manager override?
  > _Answer:_

- [ ] **Return stock timing** — Does a return restore stock immediately or only after a receiving confirmation step?
  > _Answer:_

### Buy Exchange Vouchers

- [ ] **Expired voucher behaviour** — What happens when a cashier scans an expired voucher — silent rejection or an error message?
  > _Answer:_

- [ ] **Partial voucher redemption** — Can a voucher be partially used (e.g., a 500 ฿ voucher applied to a 300 ฿ sale)?
  > _Answer:_

### Accounting Close

- [ ] **Close trigger** — Is end-of-day close triggered manually by the branch manager or scheduled automatically?
  > _Answer:_

- [ ] **Failed close recovery** — If the close process fails halfway (e.g., network drops mid-close), what is the recovery procedure today?
  > _Answer:_

- [ ] **Close reversal authority** — Can a completed close be reopened/reversed, and who has authority to do so?
  > _Answer:_

### Allergy Checking

- [ ] **Override audit** — When a pharmacist overrides an allergy warning, should that override be logged with their name and a reason? (Currently not logged at all.)
  > _Answer:_

---

## IT / System Administrator

### Hardware — Fingerprint Reader

- [ ] **Device model** — What is the exact make and model of the fingerprint reader installed at branches? (Required to source or replicate the SDK.)
  > _Answer:_

- [ ] **SDK availability** — Is the fingerprint SDK a vendor-provided DLL? If yes, can IT provide the SDK package and documentation?
  > _Answer:_

- [ ] **Fingerprint-enabled branches** — Which branches currently have `pAllowFingerScan = "1"` active?
  > _Answer:_

### Hardware — Receipt Printer

- [ ] **Printer model(s)** — What printer model(s) are in use across branches?
  > _Answer:_

- [ ] **Printer connection type** — Is the printer connected via USB, serial (COM), parallel (LPT), or network IP?
  > _Answer:_

### Server & Network

- [ ] **MyService2 purpose** — `MyService2` points to the same URL as `MyService`. Is it a failover endpoint, load-balanced, or unused?
  > _Answer:_

- [ ] **MyService3 purpose** — What does `MyService3` at `110.170.201.18` serve, and which branches use it?
  > _Answer:_

- [ ] **SOAP backend database** — Is the SOAP service backed by SQL Server or Microsoft Access on the server side?
  > _Answer:_

- [ ] **Terminals per branch** — How many POS terminals are currently active per branch? (Needed for offline-first architecture planning.)
  > _Answer:_

### Offline Sync

- [ ] **Sync conflict resolution today** — When two terminals sell the same product during an outage and both sync back, how is the stock conflict resolved? Is this a known issue?
  > _Answer:_

- [ ] **Upload trigger** — Is the server upload (`frmUploadServer`) triggered manually by staff or automatic on transaction complete?
  > _Answer:_

- [ ] **Known data loss incidents** — Has data loss from sync conflicts ever been observed in production?
  > _Answer:_

### Licensing

- [ ] **Registry key path** — What registry key does the license check read? (The code references `pRegistry` but the full path is not visible in source.)
  > _Answer:_

- [ ] **License scope** — Is licensing per-terminal or per-branch? Who manages license issuance and renewal?
  > _Answer:_

---

## Project Manager

### Scope & Priorities

- [ ] **Pilot branches** — Which branches will be in the v2 pilot? (Determines terminal count and load targets for the first deployment.)
  > _Answer:_

- [ ] **Fingerprint in v2 scope** — Is fingerprint authentication required for v2 launch, or can it ship as a phase 2 feature?
  > _Answer:_

- [ ] **Reports format** — Are Crystal Reports required for v2, or can reports be rebuilt in a new format (e.g., PDF export)?
  > _Answer:_

### Data Migration

- [ ] **Historical data migration** — Will existing data from the current Access database be migrated to v2, or does v2 start fresh from go-live?
  > _Answer:_

- [ ] **Go-live deadline** — Is there a cutover date or hard deadline for v2 go-live?
  > _Answer:_

---

## Pharmacy Regulatory / Compliance

- [ ] **Allergy override audit requirement** — Is there a Thai pharmacy regulation that requires allergy override events to be audited and logged with a responsible pharmacist's name?
  > _Answer:_

- [ ] **PDPA compliance** — Does the system need to comply with Thailand's PDPA for customer PII (addresses, birth dates, drug allergy records stored in the database)?
  > _Answer:_

- [ ] **Tax invoice requirement** — Is a tax invoice (`pAllowTaxInvoice`) required for all sales, or only when the customer requests one?
  > _Answer:_

- [ ] **Record retention period** — Are there regulatory requirements for how long transaction records must be retained?
  > _Answer:_

---

## Summary

| Group | Total Questions | Answered |
|---|---|---|
| Business Owner / Pharmacy Manager | 19 | 0 |
| IT / System Administrator | 14 | 0 |
| Project Manager | 5 | 0 |
| Pharmacy Regulatory / Compliance | 4 | 0 |
| **Total** | **42** | **0** |

### Blocking for Session 2 design (must answer first)

- [ ] Fingerprint device model & SDK availability (IT)
- [ ] Discount stacking order (Business)
- [ ] Offline sync conflict resolution policy (IT / Business)
- [ ] Historical data migration decision (PM)
- [ ] PDPA compliance requirement (Compliance)
