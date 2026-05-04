# Active Session State

*Last updated: 2026-05-05*

## Current Task
Pre-production — systems decomposition complete, GDD authoring next.

## Status
- ✅ `/brainstorm` — game-concept.md authored (Perfect Frame 가칭)
- ✅ `/art-bible` — Sections 1~4 authored (Visual Identity / Mood / Shape / Color). Sections 5~9 deferred.
- ✅ `/map-systems` — systems-index.md authored. 9 GDDs to author, 5 use UE standards, 3 reference art bible.
- ⏳ `/design-system combat-core` — IN PROGRESS (A·B·C ✅, Section D: Formulas next)

## Files
- `design/gdd/game-concept.md` — game concept (Draft)
- `design/art/art-bible.md` — Sections 1–4 (Draft)
- `design/gdd/systems-index.md` — systems decomposition (Draft)
- `production/review-mode.txt` — `lean`

## Key Decisions Locked
- Engine: Unreal Engine 5.7 (Lumen + Nanite + GAS + Behavior Tree)
- Visual Anchor: Faithful Cinematic Realism (no rim lights)
- Combat balance: Parry 60:40 우세 (스텔라블레이드 + 세키로 향)
- Boss AI: UE Behavior Tree + Blackboard
- Danger Tells: 4채널 백업 (색+형태+모션+오디오)
- Hit Vignette: 차별화된 빨강 (H 0°, S 70%, V 60%, opacity 60%)
- 9개 GDD 작성 대상, 5개 UE 표준, 3개 art bible 참조

## Next
Run `/design-system combat-core` to start the first GDD (highest-priority bottleneck).
