# Combat Core

> **Status**: In Design
> **Author**: user + game-designer + ue-gas-specialist
> **Last Updated**: 2026-05-05
> **Last Verified**: 2026-05-05
> **Implements Pillar**: Pillar 1 (Input Fidelity Above All), Pillar 4 (Depth Over Breadth)

## Summary

Combat Core는 Perfect Frame의 모든 HP·데미지·Hit Detection을 통합하는 GAS 기반 데이터 레이어다. 8개 후속 시스템(Combo·Parry·Dodge·Beta·Stagger·Tell·Boss AI·HUD)이 이 시스템이 정의하는 인터페이스를 통해 작동한다.

> **Quick reference** — Layer: `Core` · Priority: `MVP` · Key deps: `UE Player Controller (standard), UE Player Animation (standard)`

## Overview

Combat Core는 Perfect Frame의 전투 핵심 데이터 레이어다. 플레이어와 보스의 HP, 데미지 계산 공식, 데미지 적용·완화·증폭 로직, 그리고 Hit Detection (애니메이션 노티파이 트리거 + 캡슐 트레이스)을 한 곳에 모은다. UE5의 Gameplay Ability System(GAS)을 토대로 — Attribute Set으로 HP를 관리하고, Gameplay Effect로 데미지를 적용하며, Gameplay Tag로 상태(피격·무적·스태거 등)를 표현한다.

플레이어가 직접 경험하는 것은 단순하다 — 보스 공격이 닿으면 자신의 HP가 줄어들고, 자신의 평타·베타가 닿으면 보스 HP와 스태거 게이지가 줄어든다. 그 단순함 뒤에는 이 게임 특유의 룰이 들어 있다: **퍼펙트 패링 직후 카운터 윈도우 동안 플레이어 데미지가 증폭**, **베타 스킬은 자기만의 데미지 공식과 보스 경직 보장**, **스태거 상태의 보스는 데미지 배수가 적용**된다.

이 시스템이 안정화되지 않으면 8개 후속 시스템이 모두 무너진다. 가장 먼저, 가장 깊이 정의되는 이유 — Pillar 4 (Depth Over Breadth)의 토대이자, Pillar 1 (Input Fidelity)의 데이터 측 절반이 여기서 작동한다.

## Player Fantasy

> **"내가 받은 한 대도, 내가 넣은 한 대도, 가짜로 들어가지 않는다."**

### 앵커 플레이어 모먼트

HP가 위험 구간 약 18%까지 떨어진 상황. 보스의 Crimson Unblockable이 들어온다. 회피로 받지만 모서리가 살짝 닿는다. HP 바가 **정확히** 닿은 만큼만 — 크지도 작지도 않게 — 줄어든다. 플레이어는 즉시 "11% 남았다, 다음 한 대까지는 견딘다"를 안다. 직후 보스 스태거 윈도우가 열리고 평타 5타로 마무리. 마지막 타격에서 보스 HP가 0이 되는 그 프레임 — 한 픽셀도 더하지도 빼지도 않은, 정확히 0. 플레이어는 한 번도 "운으로 살았다"거나 "헛맞은 것 같다"고 의심하지 않는다.

### 본문

HP는 흐리지 않다. 데미지는 부풀려지지도, 깎이지도 않는다. 닿은 것은 정확히 그만큼, 닿지 않은 것은 정확히 0 — 매 충돌이 거짓말 없이 **정직한 무게**로 기록된다. 이 정직함이 있어야 플레이어는 자신의 죽음을 "납득"하고, 자신의 클리어를 "벌어낸 것"으로 받아들인다.

### 연결되는 필러

- **Pillar 1 (Input Fidelity Above All)** — Input fidelity의 데이터 측 절반. 입력이 정확히 적힌다.
- **Pillar 4 (Depth Over Breadth)** — 8개 후속 시스템의 깊이가 작동하려면 데이터 레이어가 거짓말하지 않아야 한다. 정직함이 깊이의 토대.

### 이 framing이 이끄는 디자인 결정

- 데미지 부풀림(트릭 +N%) → ❌ 금지
- 데미지 ±랜덤 보정 → ❌ 금지 (운으로 살았다 인식 발생)
- 보스 HP 바 흔들림·블러 시각 효과 → ❌ 금지 (정확한 수치 가독성 훼손)
- 데미지 카테고리 가시 차등(평타·베타·스태거 폭딜이 시각적으로 다름) → ✅ OK (양은 거짓 아님, 형태만 차이)
- art bible §4.5 퍼펙트 패링 1→3→5→7 시각 차등 → ✅ OK (인과 표시 강화이지 데미지 양 트릭 아님)

### 이 framing이 양보하는 것

**즉시성은 Combat Core 자체에서 보장 대상이 아니다.** 인과 즉시성(피격 인지·데미지 표시 즉시성)은 후속 VFX·Audio·HUD 시스템이 책임진다 — Combat Core는 "정확한 양이 발생했다"까지 책임진다. 이 분리는 의도적이며, Pillar 4 (Depth Over Breadth)의 명료한 책임 분할을 따른다.

## Detailed Design

### Core Rules

**HP & Death**

- **CR-01** 플레이어와 보스는 각자 `CurrentHP`, `MaxHP` 두 개의 GAS Attribute를 가진다. 두 값은 항상 `0 ≤ CurrentHP ≤ MaxHP` 범위를 유지한다 (PostGameplayEffectExecute에서 clamp).
- **CR-02** `CurrentHP`가 0에 도달한 프레임에 `State.Defeated` 태그가 부여되고, 이후 추가 데미지는 무시한다 (재계산·재적용 없음).
- **CR-03** Defeated 상태는 외부에서 해제할 수 없다 (Game Flow가 다음 시도를 시작할 때 Actor 자체를 새로 스폰).
- **CR-04** `MaxHP`는 런타임에 변하지 않는다 (Stagger·Beta·Counter는 데미지 측에서 작동, HP 풀 자체는 고정).
- **CR-05** 보스는 Phase 전환 시점에 `MaxHP`가 갱신되지 않는다 — Phase는 단일 HP 풀 위에서 행동 패턴만 변화 (Boss AI 책임).

**Damage Application**

- **CR-06** 모든 데미지는 단일 `UDamageExecution` (UGameplayEffectExecutionCalculation)을 거쳐 계산된다. 시스템마다 별도 Execution을 만들지 않는다.
- **CR-07** 입력 변수: `BaseDamage`, `DamageCategory` (Set By Caller로 전달), `IsCounterWindow` (Source의 Tag로 판정), `IsStagger` (Target의 Tag로 판정).
- **CR-08** 데미지는 항상 정수로 적용된다 (`FMath::RoundToInt32`로 최종 단계에서 한 번만 반올림). 중간 계산은 float 유지.
- **CR-09** 동일 프레임에 다중 데미지 이벤트가 발생하면 TimeStamp(서브-프레임 정확도) 순서대로 순차 적용. 동시성 모호함 없음.
- **CR-10** 데미지 ±랜덤 보정 금지 (Pillar 1 / Honest Weight). RNG 호출이 데미지 경로에 들어가면 디자인 위반.
- **CR-11** Meta Attribute `IncomingDamage`를 사용한다. PostGameplayEffectExecute에서 `IncomingDamage`만큼 `CurrentHP` 차감 후 `IncomingDamage`는 0으로 drain.
- **CR-12** Healing은 MVP에서 정의하지 않는다 (보스전에서 회복 수단 없음 — Pillar 4 / Depth Over Breadth).

**Damage Categories**

- **CR-13** 5개 카테고리: `DMG_Light` (평타), `DMG_Heavy` (강타), `DMG_Beta` (베타 스킬), `DMG_Counter` (카운터 윈도우 평타), `DMG_StaggerFinish` (스태거 중 데미지).
- **CR-14** 카테고리는 Source 측에서 결정된다 (어빌리티가 Set By Caller로 전달). Target은 카테고리를 변경하지 않는다.
- **CR-15** 카테고리별 배수는 Execution 내부에서 적용 (자세한 공식은 §Formulas).
- **CR-16** `DMG_Counter`는 Source가 `State.CounterWindow` 태그를 보유한 동안의 평타·강타에만 부여된다 (별도 어빌리티 아님 — 같은 어빌리티가 카테고리만 승격).
- **CR-17** `DMG_StaggerFinish`는 Target이 `State.Staggered` 태그를 보유한 동안의 모든 입력 데미지에 부여된다 (Target 측 카테고리 승격).
- **CR-18** `DMG_Counter`와 `DMG_StaggerFinish`는 동시 적용 가능 (배수는 곱연산).

**Counter Window**

- **CR-19** Perfect Parry 성공 직후 0.6초간 플레이어에게 `State.CounterWindow` 태그 부여 (지속시간은 Tuning Knob).
- **CR-20** Counter Window 동안 플레이어 평타·강타는 자동으로 `DMG_Counter` 카테고리로 승격.
- **CR-21** **Counter Window 중 플레이어가 피격되면 태그 즉시 소멸** (Hit Stun이 카운터를 끊는다 — Pillar 1 / Input Fidelity, 회피 안 한 책임).
- **CR-22** Counter Window 중 Beta Skill 사용 시 `DMG_Counter`는 부여되지 않음 (Beta는 자기 카테고리 유지 — `DMG_Counter` × `DMG_Beta` 중첩 금지).
- **CR-23** Counter Window 만료는 별도 알림 없음 (HUD가 시각으로 표시 — HUD System 책임).

**Beta Gauge & Skills**

- **CR-24** `BetaGauge`, `MaxBetaGauge` 두 개의 GAS Attribute를 `UPlayerAttributeSet`에 둔다. 외부 Component로 분리하지 않는다 (전투 데이터의 단일 진실 소스).
- **CR-25** `BetaGauge`는 항상 `0 ≤ BetaGauge ≤ MaxBetaGauge` 범위를 유지 (PostGameplayEffectExecute에서 clamp).
- **CR-26** Beta Gauge 충전·소비는 Gameplay Effect로 적용 (충전: 평타·강타·Perfect Parry 성공 시 / 소비: Beta Skill 발동 시). 정확한 양은 Beta Gauge & Skills GDD가 정의.
- **CR-27** Beta Skill은 자기 데미지 공식과 자기 카테고리(`DMG_Beta`)를 가진다 (CR-22 참조). Combat Core는 카테고리 정의·게이지 풀만 책임, 발동 로직은 Beta GDD가 책임.
- **CR-28** Beta Skill 시전 중에는 `State.BetaCasting` 태그 부여 — 이 동안 플레이어는 피격 가능하지만 Beta Skill의 Hit Detection은 끊기지 않는다 (이미 발동된 GA는 cancellation 없이 완료).

**Stagger**

- **CR-29** 보스는 `StaggerGauge`, `MaxStaggerGauge` 두 개의 GAS Attribute를 `UBossAttributeSet`에 둔다.
- **CR-30** Stagger Gauge 누적 규칙은 Stagger System GDD가 정의 (Combat Core는 Attribute 풀과 도달 트리거만 책임).
- **CR-31** `StaggerGauge`가 `MaxStaggerGauge`에 도달한 프레임에 보스에게 `State.Staggered` 태그 부여, **5.0초 후 자동 해제**, 동시에 `StaggerGauge` 0으로 리셋.
- **CR-32** Staggered 상태에서 입력되는 모든 데미지는 `DMG_StaggerFinish` 카테고리 승격 (CR-17). Stagger 자체는 데미지를 가하지 않음 — 데미지 배수만 적용.
- **CR-33** **Staggered와 Invulnerable은 동시 보유 불가** — Staggered 부여 시 Invulnerable 태그가 있으면 Staggered가 우선, Invulnerable은 강제 해제. 역순(Invul → Stagger)은 Stagger 부여 자체가 무시됨.
- **CR-34** Staggered 동안 보스 AI는 행동을 멈춘다 — Boss AI가 `State.Staggered` 태그를 관찰(Observer 패턴, `SendGameplayEventToActor`)하여 BT 중단·재개 결정.

**Hit Detection**

- **CR-35** Hit Detection은 `AnimNotifyState_HitboxActive` (애니메이션 노티파이) + `AbilityTask_HitDetection` (캡슐 트레이스)의 조합으로 구현.
- **CR-36** AnimNotifyState의 `Begin` 시점에 AbilityTask가 활성화, `End` 시점에 비활성화. 윈도우 외부에서는 트레이스 호출 없음.
- **CR-37** Hit Trace는 활성 윈도우 동안 매 게임 틱마다 실행 (서브-프레임 누락 방지). 캡슐 형상·반경·길이는 어빌리티 데이터 자산이 정의.
- **CR-38** 동일 어빌리티의 동일 활성 윈도우 내에서 같은 Target은 1회만 히트 처리 (`IgnoredActors` 리스트로 관리). 윈도우 종료 시 리스트 초기화.
- **CR-39** Hit 발생 시 어빌리티는 GameplayEvent를 자기 자신에게 발사 (`SendGameplayEventToActor`), 이벤트 페이로드에 Target과 카테고리 포함. Damage Effect 적용은 Event 핸들러에서.
- **CR-40** Hit Detection 결과는 클라이언트 권위 (싱글플레이어 전제). Replication은 MVP에서 미정의.

**Determinism**

- **CR-41** 데미지 경로는 결정적이어야 한다 — 동일 입력은 동일 결과 (Pillar 1 / Input Fidelity, Pillar 2 / Visible Mastery의 데이터 전제).
- **CR-42** 부동소수 의존 연산(예: 캡슐 트레이스 결과의 정렬)은 안정적인 비교 함수 사용 (TimeStamp + ActorID).
- **CR-43** Tick rate에 의존하는 로직 금지 (예: "0.1초마다 데미지" → 누적 시간 기반으로 작성, FixedTick 보장 없음).

### States and Transitions

상태는 모두 Gameplay Tag로 표현된다. 한 액터가 여러 상태 태그를 동시에 보유할 수 있으나, 충돌 규칙은 §C.1에 명시된 대로 적용된다.

**Player States**

| State Tag | 진입 조건 | 해제 조건 | 동안의 효과 | 충돌 |
|-----------|----------|----------|-----------|------|
| `State.Normal` | 기본 (다른 상태 태그 부재) | 다른 상태 부여 시 | 모든 입력 정상 처리 | — |
| `State.HitStun` | 데미지 적용 직후 (지속시간 = 어빌리티별 정의) | 시간 경과 | 입력 큐 무시, 이동 잠김 | CounterWindow를 강제 해제 (CR-21) |
| `State.Invulnerable` | Perfect Dodge 발동 / Beta Skill i-frame 구간 | 어빌리티별 정의 (시간 또는 노티파이) | 모든 입력 데미지 무시 | Staggered와 동시 보유 불가 (보스 측), 플레이어는 단독 |
| `State.CounterWindow` | Perfect Parry 성공 직후 | 0.6초 경과 OR 피격 (CR-21) | 평타·강타가 `DMG_Counter`로 승격 | HitStun이 즉시 해제 |
| `State.BetaCasting` | Beta Skill GA 활성화 | GA 종료 (성공·실패·취소 모두) | 다른 GA 차단, Hit Detection은 GA 내부에서 진행 | CounterWindow와 동시 보유 시 Counter 승격 무시 (CR-22) |
| `State.Defeated` | `CurrentHP == 0` | 해제 불가 (CR-03) | 모든 입력·데미지 무시 | 단일 종착 상태 |

**Boss States**

보스는 Phase가 변해도 동일한 Attribute Set을 유지한다 (`MaxHP` 불변, CR-04). Phase는 Boss AI의 행동 변화일 뿐 Combat Core 데이터는 동일.

| State Tag | 진입 조건 | 해제 조건 | 동안의 효과 | 충돌 |
|-----------|----------|----------|-----------|------|
| `State.Normal` | 기본 | 다른 상태 부여 시 | 모든 입력 정상 처리, AI 가동 | — |
| `State.HitStun` | 데미지 적용 직후 (어빌리티별 정의) | 시간 경과 | AI 행동 일시 중단, 입력 데미지 정상 수신 | Staggered가 우선 |
| `State.Invulnerable` | Boss AI가 명시 부여 (예: 무적 패턴 중) | AI가 해제 | 모든 입력 데미지 무시 | Staggered와 동시 보유 불가 — Stagger가 우선, Invul 강제 해제 (CR-33) |
| `State.Staggered` | `StaggerGauge >= MaxStaggerGauge` (CR-31) | **5.0초 경과** (자동) | 입력 데미지가 `DMG_StaggerFinish` 승격, AI 중단 | Invulnerable 강제 해제 |
| `State.Phase1` | 보스 스폰 시 부여 | `CurrentHP <= MaxHP * 0.5` (정확한 임계는 Boss AI GDD가 정의) | AI가 Phase 1 BT 사용 | Phase2와 동시 보유 불가 (Boss AI가 전환 보장) |
| `State.Phase2` | Phase1 해제 시 부여 | 해제 불가 (Defeated 외) | AI가 Phase 2 BT 사용 | — |
| `State.Defeated` | `CurrentHP == 0` | 해제 불가 | 모든 입력·데미지 무시, AI 정지 | 단일 종착 상태 |

**전이 우선순위 (동일 프레임 내 충돌 시)**

1. `Defeated` (CR-02)
2. `Staggered` (CR-33)
3. `Invulnerable`
4. `HitStun`
5. 그 외

이 우선순위는 같은 프레임에 여러 상태가 부여되려 할 때만 적용. 일반적으로 GA의 시간 분리로 자연스럽게 회피된다.

### Interactions with Other Systems

Combat Core는 8개 후속 시스템에 대해 **데이터 인터페이스 + 이벤트 채널**을 제공한다. 각 시스템은 Combat Core의 Attribute·Tag·GameplayEvent를 소비하며, Combat Core는 어떤 후속 시스템의 내부 로직도 모른다 (단방향 의존).

| 후속 시스템 | Combat Core가 제공 | 후속 시스템이 제공 | 인터페이스 종류 |
|------------|------------------|------------------|---------------|
| **Light-Heavy Combo** | `DMG_Light` / `DMG_Heavy` 카테고리, Hit Detection 프레임워크 | 어빌리티 데이터(BaseDamage, 캡슐 형상, 노티파이) | GA + Set By Caller |
| **Perfect Parry** | `State.CounterWindow` 부여 권한, `DMG_Counter` 승격 | 입력 타이밍 판정, Parry 성공 신호 | Tag 부여 (GE) |
| **Perfect Dodge** | `State.Invulnerable` 부여 권한 | i-frame 윈도우 정의, Dodge 성공 신호 | Tag 부여 (GE) |
| **Beta Gauge & Skills** | `BetaGauge` Attribute, `DMG_Beta` 카테고리, `State.BetaCasting` | 충전·소비 룰, Beta Skill 어빌리티 정의 | Attribute 변경 (GE) |
| **Stagger System** | `StaggerGauge` Attribute, `State.Staggered` 부여 권한, `DMG_StaggerFinish` 승격 | Stagger 누적 룰 (어떤 데미지가 얼마나 누적), 시각 피드백 | Attribute 변경 (GE) + GameplayEvent |
| **Danger Tell System** | 보스 어빌리티의 GA 활성화 시점 (Crimson/Amber 분기 정보) | Tell 시각·오디오 트리거 | GameplayEvent (Boss → Tell) |
| **Boss AI** | `State.Staggered` / `State.HitStun` / `State.Defeated` 태그, `CurrentHP` Attribute, Phase 태그 | BT 행동 결정, 어빌리티 시퀀싱, 무적 패턴 부여 | Tag/Attribute 관찰 + Tag 부여 |
| **HUD System** | 모든 Attribute (CurrentHP, BetaGauge, StaggerGauge), 모든 State 태그 | 시각 표현 (HP 바, 게이지, 카운터 윈도우 인디케이터) | Attribute Listener + Tag Listener |

**핵심 의존 방향 룰**

- Combat Core → **어떤 후속 시스템의 코드도 참조하지 않는다**. 후속 시스템이 Combat Core의 Attribute·Tag·Event를 구독한다.
- 모든 카테고리 승격(`DMG_Counter`, `DMG_StaggerFinish`)은 Combat Core 내부 Execution에서 처리 — 후속 시스템이 Source/Target Tag를 보고 자기 카테고리를 직접 결정하지 않는다 (룰 분산 방지).
- Stagger ↔ Boss AI 순환 의존은 **Observer 패턴으로 해결**: Stagger System은 `State.Staggered` 부여만 책임, Boss AI는 태그 변화를 `SendGameplayEventToActor`로 관찰. 두 시스템은 서로의 코드를 직접 호출하지 않는다.

**HUD 동기화 보장**

HUD는 Combat Core Attribute의 `OnAttributeChange` 델리게이트를 구독한다. PostGameplayEffectExecute가 끝난 같은 프레임에 HUD 갱신이 발사되므로 — HP 바와 실제 HP 사이에 의도된 지연(애니메이션) 외의 데이터 불일치는 발생할 수 없다.

**Replication 관련 (MVP 제외)**

모든 Attribute는 클라이언트 권위로 작동 (싱글플레이어 전제). Replication 어노테이션(`Replicated`, `RepNotify`)은 추가하지 않는다 — 추후 멀티 확장 시 별도 ADR로 결정.

## Formulas

[To be designed]

## Edge Cases

[To be designed]

## Dependencies

[To be designed]

## Tuning Knobs

[To be designed]

## Visual/Audio Requirements

[To be designed]

## Game Feel

[To be designed]

## UI Requirements

[To be designed]

## Cross-References

[To be designed]

## Acceptance Criteria

[To be designed]

## Open Questions

[To be designed]
