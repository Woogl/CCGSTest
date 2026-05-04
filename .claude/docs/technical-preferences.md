# Technical Preferences

<!-- Populated by /setup-engine. Updated as the user makes decisions throughout development. -->
<!-- All agents reference this file for project-specific standards and conventions. -->

## Engine & Language

- **Engine**: Unreal Engine 5.7
- **Language**: C++ (primary, systems and game logic), Blueprint (gameplay prototyping, content variation, designer-facing scripting)
- **Rendering**: Lumen (dynamic global illumination + reflections), Nanite (virtualized geometry for static meshes)
- **Physics**: Chaos Physics

## Input & Platform

<!-- Written by /setup-engine. Read by /ux-design, /ux-review, /test-setup, /team-ui, and /dev-story -->
<!-- to scope interaction specs, test helpers, and implementation to the correct input methods. -->

- **Target Platforms**: PC (Steam / Itch.io)
- **Input Methods**: Keyboard/Mouse (primary), Gamepad (partial)
- **Primary Input**: Keyboard/Mouse
- **Gamepad Support**: Partial — 모든 액션은 매핑 가능, 일부 UI는 K/M 우선
- **Touch Support**: None
- **Platform Notes**: Enhanced Input 기반 입력 시스템. UI는 hover-friendly가 기본이지만 d-pad 네비게이션도 지원 가능하도록 설계 (CommonUI 권장).

## Naming Conventions

(Unreal C++ 표준 — Epic 공식 코딩 스타일)

- **Classes**:
  - `A` 접두사 + PascalCase (Actor, e.g., `AExtractMission`)
  - `U` 접두사 + PascalCase (UObject, e.g., `UCompanionComponent`)
  - `F` 접두사 + PascalCase (struct, e.g., `FMissionResult`)
  - `E` 접두사 + PascalCase (enum, e.g., `ECompanionState`)
  - `I` 접두사 + PascalCase (interface, e.g., `IRescueable`)
- **Variables**: PascalCase (e.g., `MoveSpeed`, `CurrentHealth`)
- **Booleans**: `b` 접두사 + PascalCase (e.g., `bIsAlive`, `bCanRescue`)
- **Functions**: PascalCase (e.g., `TakeDamage`, `BeginExtraction`)
- **Files**: 클래스명에서 접두사 제거 + .h/.cpp (e.g., `ExtractMission.h`, `CompanionComponent.cpp`)
- **Blueprint Assets**: PascalCase + 타입 접두사 (e.g., `BP_Survivor_Marcus`, `WBP_HUD_Main`, `M_Concrete_Wet`)
- **Constants**: 매크로 `#define UPPER_SNAKE_CASE` 또는 `static constexpr PascalCase`

## Performance Budgets

- **Target Framerate**: 60 fps (PC stable)
- **Frame Budget**: 16.6 ms
- **Draw Calls**: < 3000 per frame (UE5 Lumen + Nanite 환경 권장 상한)
- **Memory Ceiling**: 8 GB VRAM 사용 (RTX 3060 ~ 4060 베이스라인)
- **Notes**: Lumen + Nanite 활용 시 draw call 한도가 일반 프로젝트보다 높아도 됨. CPU 측 game thread 8 ms, render thread 8 ms 이내 목표.

## Testing

- **Framework**: Unreal Automation Testing (Functional Test + Automation Spec)
- **Minimum Coverage**: 핵심 게임플레이 로직(추출 미션·호위 AI·세이브) 단위 테스트 필수
- **Required Tests**: 호위 AI 상태 전이, 세이브/로드 무결성, GAS 능력 효과 적용

## Forbidden Patterns

<!-- Add patterns that should never appear in this project's codebase -->
- [None configured yet — add as architectural decisions are made]

## Allowed Libraries / Addons

<!-- Add approved third-party dependencies here -->
- [None configured yet — add as dependencies are approved]

## Architecture Decisions Log

<!-- Quick reference linking to full ADRs in docs/architecture/ -->
- [No ADRs yet — use /architecture-decision to create one]

## Engine Specialists

<!-- Written by /setup-engine when engine is configured. -->
<!-- Read by /code-review, /architecture-decision, /architecture-review, and team skills -->
<!-- to know which specialist to spawn for engine-specific validation. -->

- **Primary**: unreal-specialist
- **Language/Code Specialist**: ue-blueprint-specialist (Blueprint graphs) / unreal-specialist (C++)
- **Shader Specialist**: unreal-specialist (no dedicated shader specialist — primary covers materials)
- **UI Specialist**: ue-umg-specialist (UMG widgets, CommonUI, input routing, widget styling)
- **Additional Specialists**: ue-gas-specialist (Gameplay Ability System, attributes, gameplay effects), ue-replication-specialist (property replication, RPCs, client prediction — EXTRACT는 싱글플레이어 전제이지만 멀티 확장 시 활용)
- **Routing Notes**: Invoke primary for C++ architecture and broad engine decisions. Invoke Blueprint specialist for Blueprint graph architecture and BP/C++ boundary design. Invoke GAS specialist for all ability and attribute code. Invoke replication specialist for any future multiplayer or networked systems. Invoke UMG specialist for all UI implementation.

### File Extension Routing

<!-- Skills use this table to select the right specialist per file type. -->
<!-- If a row says [TO BE CONFIGURED], fall back to Primary for that file type. -->

| File Extension / Type | Specialist to Spawn |
|-----------------------|---------------------|
| Game code (.cpp, .h files) | unreal-specialist |
| Shader / material files (.usf, .ush, Material assets) | unreal-specialist |
| UI / screen files (.umg, UMG Widget Blueprints) | ue-umg-specialist |
| Scene / prefab / level files (.umap, .uasset) | unreal-specialist |
| Native extension / plugin files (Plugin .uplugin, modules) | unreal-specialist |
| Blueprint graphs (.uasset BP classes) | ue-blueprint-specialist |
| General architecture review | unreal-specialist |
