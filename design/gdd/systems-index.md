# Systems Index: Perfect Frame (가칭)

> **Status**: Draft
> **Created**: 2026-05-05
> **Last Updated**: 2026-05-05
> **Source Concept**: design/gdd/game-concept.md
> **Source Art Bible**: design/art/art-bible.md

---

## Overview

Perfect Frame는 스텔라블레이드의 모던 액션 전투 시스템을 충실 재현한 **1보스 결전 프로토타입**이다. 시스템 스코프는 4개 필러에 의해 강하게 좁혀진다 — Input Fidelity / Visible Mastery / Boss as Music / Depth Over Breadth. 인벤토리·진행·스토리·다중 보스는 모두 Anti-pillar로 명시 제외.

총 **17개 시스템**을 식별했으나, 5개(Core 카테고리)는 **UE5 표준 패턴(Enhanced Input / Character / Animation Blueprint / Spring Arm Camera / Game Mode·State)** 그대로 사용하여 GDD를 작성하지 않는다. 3개(VFX·Audio·Mood-PP)는 **art bible에 시스템 명세가 충분**히 들어가 있어 별도 GDD 생략. **9개 시스템에 대해서만 GDD를 작성**한다.

이 결정은 Pillar 4 (Depth Over Breadth)와 정합 — 새 시스템을 만들기보다 UE 표준 + art bible 결정의 깊이를 활용. 솔로 4~8주 스코프 내 9개 GDD + 시스템 구현이 도전적이지만 달성 가능한 범위.

---

## Systems Enumeration

| # | System Name | Category | Priority | Status | Design Doc | Depends On |
|---|-------------|----------|----------|--------|------------|------------|
| 1 | Input System (UE Enhanced Input) | Core | MVP | UE Standard — no GDD | — | — |
| 2 | Player Controller (UE Character) | Core | MVP | UE Standard — no GDD | — | Input |
| 3 | Player Animation State Machine (Animation Blueprint) | Core | MVP | UE Standard — no GDD | — | Player Controller |
| 4 | Camera System (Spring Arm + Camera) | Core | MVP | UE Standard — no GDD | — | Player Controller |
| 5 | Game Flow Manager (Game Mode + Game State) | Core | MVP | UE Standard — no GDD | — | — |
| 6 | **Combat Core** | Gameplay | MVP | Not Started | `design/gdd/combat-core.md` | Player Controller, Player Anim (UE 기본) |
| 7 | **Light/Heavy Combo** | Gameplay | MVP | Not Started | `design/gdd/light-heavy-combo.md` | Combat Core |
| 8 | **Perfect Parry System** | Gameplay | MVP | Not Started | `design/gdd/perfect-parry.md` | Combat Core, Danger Tell (data) |
| 9 | **Perfect Dodge System** | Gameplay | MVP | Not Started | `design/gdd/perfect-dodge.md` | Combat Core |
| 10 | **Beta Gauge & Skills** | Gameplay | MVP | Not Started | `design/gdd/beta-gauge-skills.md` | Combat Core, Perfect Parry, Perfect Dodge |
| 11 | **Stagger System** | Gameplay | MVP | Not Started | `design/gdd/stagger-system.md` | Combat Core, Perfect Parry, Boss AI (Observer) |
| 12 | **Danger Tell System** | Gameplay | MVP | Not Started | `design/gdd/danger-tell-system.md` | Boss AI |
| 13 | **Boss AI** (UE Behavior Tree + Blackboard) | AI | MVP | Not Started | `design/gdd/boss-ai.md` | Combat Core |
| 14 | **HUD System** | UI | MVP | Not Started | `design/gdd/hud-system.md` | Combat Core, Beta, Stagger |
| 15 | Mood / PP State Manager | UI | MVP | art bible 참조 — no GDD | art-bible.md §2 | Game Flow, Combat Core, Stagger, Beta |
| 16 | VFX System (Niagara) | UI | MVP | art bible 참조 — no GDD | art-bible.md §4.5, §4.6 | Combat Core, Perfect Parry, Beta, Stagger |
| 17 | Audio System | Audio | MVP | art bible 참조 — no GDD | art-bible.md §4.6 | Combat Core, Danger Tell, Game Flow |

**GDD 작성 대상: 9개** (#6~14 중 #15·#16·#17 제외).

---

## Categories

| Category | 설명 | 이 게임의 시스템 |
|----------|------|---------------|
| **Core** | 모든 시스템의 토대 — UE5 표준 그대로 | Input, Player Controller, Player Animation, Camera, Game Flow |
| **Gameplay** | 게임을 재미있게 만드는 메커닉 | Combat Core, Combo, Parry, Dodge, Beta, Stagger, Danger Tell |
| **AI** | NPC 행동 — 이 게임은 보스 1체만 | Boss AI |
| **UI** | 플레이어 정보 표시 | HUD, Mood/PP, VFX |
| **Audio** | 사운드·음악 시스템 | Audio (Tell SFX, Hit SFX, BGM) |

이 게임에 없는 카테고리: Progression, Economy, Persistence, Narrative, Meta (Anti-pillar 위반).

---

## Priority Tiers

| Tier | 정의 | 이 게임의 적용 |
|------|------|---------------|
| **MVP** | 코어 루프 검증을 위한 필수 시스템 | **9개 GDD 모두 + UE 표준 5개 + art bible 참조 3개 = 17개 모두** |
| **Vertical Slice** | + 폴리시 (사운드 작곡, 시네마틱 인트로 1컷, VFX 디테일 패스, 햅틱) | 신규 시스템 없음, 기존 시스템 폴리시 패스 |
| **Tier 2 (출시 검토)** | 보스 2~3체, 사이 도장 룸, 챌린지 모달리티 | Boss Roster, Challenge Modes (신규) |
| **Full Vision** | 보스 러시 5~10체, 메타 진행 | Meta Progression, Multi-Arena, Tutorial Trial (신규) |

---

## Dependency Map

### Foundation Layer (zero deps)
- Input System (UE Enhanced Input) — 모든 액션의 진입점
- Game Flow Manager (Game Mode + Game State) — 상태 머신 자체는 다른 시스템에 의존하지 않음

### Core Layer (depends on Foundation)
- Player Controller ← Input
- Player Animation State Machine ← Player Controller
- Camera System ← Player Controller
- **Combat Core** ← Player Controller, Player Animation **— Bottleneck #1 (10+ 시스템 의존)**

### Feature Layer (depends on Core)
- Light/Heavy Combo ← Combat Core
- Perfect Parry ← Combat Core, Danger Tell System (data only)
- Perfect Dodge ← Combat Core
- **Boss AI** ← Combat Core **— Bottleneck #2**
- Danger Tell System ← Boss AI
- Beta Gauge & Skills ← Combat Core, Perfect Parry, Perfect Dodge
- Stagger System ← Combat Core, Perfect Parry, Boss AI (Observer)

### Presentation Layer (depends on Features)
- HUD System ← Combat Core, Beta Gauge, Stagger
- Mood / PP State Manager ← Game Flow, Combat Core, Stagger, Beta
- VFX System ← Combat Core, Perfect Parry, Beta, Stagger
- Audio System ← Combat Core, Danger Tell, Game Flow

### Polish Layer
없음 — MVP 스코프에 폴리시 시스템 없음. Vertical Slice 단계에 추가.

---

## Recommended Design Order

GDD 작성 대상 9개의 디자인 순서. Dependency를 따르되 같은 layer 내에서는 위험·중요도 순.

| 순서 | System | Priority | Layer | Agent(s) | Est. Effort | Why |
|------|--------|----------|-------|----------|-------------|-----|
| 1 | **Combat Core** | MVP | Core | game-designer, ue-gas-specialist | M (2~3 sessions) | Bottleneck — 8개 시스템이 의존. 가장 일찍 안정화. HP/데미지/Hit Detection + 게임 특유 룰(패링 카운터 보정·베타 데미지 공식·스태거 배수) 종합. Pillar 4의 토대. |
| 2 | **Boss AI** | MVP | Feature | game-designer, ai-programmer, unreal-specialist | L (4+ sessions) | Pillar 3 (Boss as Music) 직접 구현. 패턴 결정적 시퀀스가 게임 필을 결정. Tell·Stagger가 여기 의존하므로 일찍. **UE Behavior Tree + Blackboard 기반.** |
| 3 | **Danger Tell System** | MVP | Feature | game-designer, ue-gas-specialist | M | Pillar 1 (Input Fidelity) 핵심. Boss AI 직후 — 어떤 Tell을 발동하는지 정의되어야 Parry가 매칭 가능. **art bible Section 4.6 4채널 백업 (색+형태+모션+오디오) 명세 포함.** |
| 4 | **Light/Heavy Combo** | MVP | Feature | game-designer, gameplay-programmer | S (1 session) | Combat Core 이후 가장 독립적인 평타 시퀀스. Pillar 2 표현 축. |
| 5 | **Perfect Parry** | MVP | Feature | game-designer, ue-gas-specialist | M | Pillar 1·2 핵심. Tell이 정의된 후 매칭 검증 작성 가능. **퍼펙트 패링 1→3→5→7 카테고리 보상 곡선 (art bible Section 4.5)** 명세. |
| 6 | **Perfect Dodge** | MVP | Feature | game-designer, gameplay-programmer | S | Parry와 대칭 시스템. 같은 Tell 매칭 패턴이므로 함께 안정화. |
| 7 | **Stagger System** | MVP | Feature | game-designer, ue-gas-specialist | M | Boss AI와 양방향 사이클 (Observer 패턴 해결). Parry 연쇄가 누적 트리거. **아크형 게이지 형태 (art bible Section 3.3)** 명세. |
| 8 | **Beta Gauge & Skills** | MVP | Feature | game-designer, ue-gas-specialist | M | Parry/Dodge 성공이 충전 트리거. Beta 스킬 도중 보스 경직 보장 (art bible Section 2.5 가정). 베타 스킬 2~3종 정의. |
| 9 | **HUD System** | MVP | Presentation | ux-designer, ue-umg-specialist | S | 모든 게임플레이 시스템의 시각화. **분절형 베타 / 아크형 스태거 / 페이즈 분절 보스 HP** (art bible Section 3.3·4.4). 마지막 — 다른 시스템 안정화 후. |

**Effort 합계**: S × 3 + M × 5 + L × 1 = 약 16~20 디자인 세션. 솔로 페이스 1~2주에 GDD 완성, 4~8주 구현.

---

## Circular Dependencies

| 사이클 | 설명 | 해결 |
|--------|------|------|
| **Stagger System ↔ Boss AI** | Stagger가 Boss 상태 변경, Boss AI가 Stagger 트리거 | **Observer 패턴** — Stagger는 `OnStaggered` 이벤트만 발행, Boss AI가 구독해서 자기 BT Blackboard 키 업데이트. 양방향 호출 끊음. |
| **Perfect Parry ↔ Danger Tell** | Tell이 Parry 검증에 영향, Parry가 Tell 처리 | **단방향 데이터 흐름** — Tell이 데이터(Tell 타입 enum + 활성 시간)만 발행, Parry가 단방향으로 읽고 검증. |

---

## High-Risk Systems

| System | Risk Type | Risk Description | Mitigation |
|--------|-----------|-----------------|------------|
| **Combat Core** | Technical | Bottleneck — 변경 시 8개 시스템 파급. 데미지 공식 잘못 잡으면 모든 게 어긋남 | **`/prototype` 박스 vs 박스로 입력·HP·데미지 우선 검증.** 자산 작업 전 단계에서 Combat Core 안정화. |
| **Perfect Parry (입력 윈도우)** | Design | game-concept Risk #1 — 윈도우 정밀도 실패 = 컨셉 사망. Pillar 1 직접 위반 | 박스 vs 박스 환경에서 윈도우 프레임 수치 튜닝. 자체 플레이테스트 매주. |
| **Boss AI** | Design | 패턴 시퀀스가 "음악적"이지 못하면 Pillar 3 무너짐. BT 패턴 로직이 단순 무작위로 빠지기 쉬움 | 페이즈 1 패턴 N개 작업 후 즉시 자체 플레이테스트. 가중 결정적 시퀀스 vs 무작위 비교. |
| **Beta Gauge & Skills** | Design | 충전 속도·소비량 튜닝이 게임 필 결정. 너무 느리면 표현 막힘, 너무 빠르면 콤보 카타르시스 사라짐 | Hot reload 가능한 Data Asset 기반 튜닝. UE Editor 안에서 수치 변경 → 즉시 재생 검증. |

---

## Progress Tracker

| Metric | Count |
|--------|-------|
| Total systems identified | 17 |
| GDDs to author (subset) | 9 |
| Systems using UE standard (no GDD) | 5 |
| Systems referencing art bible (no GDD) | 3 |
| Design docs started | 0 |
| Design docs reviewed | 0 |
| Design docs approved | 0 |
| MVP systems designed | 0 / 9 |

---

## Next Steps

- [ ] Review and approve this systems index
- [ ] Run `/design-system combat-core` — first GDD (highest priority bottleneck)
- [ ] Run `/design-review design/gdd/combat-core.md` after each GDD
- [ ] Continue down the design order with `/map-systems next` for automatic selection
- [ ] Run `/prototype combat-core` early — box-vs-box validation before art assets
- [ ] Run `/gate-check pre-production` when all 9 MVP GDDs are complete
