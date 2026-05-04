# Game Concept: Perfect Frame (가칭)

*Created: 2026-05-04*
*Status: Draft*

---

## Elevator Pitch

> 스텔라블레이드의 모던 액션 전투 시스템을 충실 재현한 1보스 결전 프로토타입. 평타 콤보, 퍼펙트 패링, 퍼펙트 닷지, 베타 게이지·스킬, 적 스태거 — 모든 핵심 메커닉을 한 보스, 한 아레나에 응축하여 "reactive mastery + active expression"의 카타르시스를 검증한다.

---

## Core Identity

| Aspect | Detail |
| ---- | ---- |
| **Genre** | 3D Action, Boss-Focused Combat (Soulslike-influenced, Modern Action) |
| **Platform** | PC (Steam / Itch — 키보드/마우스 + 게임패드) |
| **Target Audience** | Mastery-driven action players (Achievers + Mastery 모티베이션) |
| **Player Count** | Single-player |
| **Session Length** | 30분~2시간 (시도 5~15분 × N회) |
| **Monetization** | None — 학습·검증 프로토타입, 출시 게임 아님 |
| **Estimated Scope** | Small (4~8주, solo) — 프로토타입 검증 빌드 |
| **Comparable Titles** | Stellar Blade, Sekiro: Shadows Die Twice, Furi |

---

## Core Fantasy

플레이어 판타지: **"스텔라블레이드의 7연속 패링 같은 그 순간 — 학습 곡선이 한순간에 가시화되는 폭발적 카타르시스를 내 손가락으로 만들어낸다."**

수동적 방어 일변도(소울라이크)에서 벗어나, 패링·회피로 만든 틈을 콤보·베타 스킬로 폭발시키는 능동적 마스터리. 처음에는 보스의 한 합도 받지 못하지만, 시간이 쌓이면 풀 패턴을 한 호흡으로 흘리고 콤보로 마무리한다.

설계자 판타지: **"이 전투 시스템을 내 손으로 만들 수 있는가"** 의 학습 검증 — 시장 차별화가 아니라 시스템 충실도가 곧 산출물의 가치.

---

## Unique Hook

이 프로젝트는 시장 차별화 게임이 아니라 **"스텔라블레이드 전투 시스템 충실 재현 + 1보스 응축"** 의 학습·검증 프로토타입이다. "Like Stellar Blade, AND ALSO 1보스에 모든 핵심 시스템 응축 + 패링 60:40 우세로 세키로 향이 약간 섞인 변형."

차별화의 부담이 사라지면 모든 에너지가 시스템 정확도와 게임 필에 집중된다. 솔로 개발자가 가장 많이 배울 수 있는 프로젝트 형태.

---

## Player Experience Analysis (MDA Framework)

### Target Aesthetics

| Aesthetic | Priority | How We Deliver It |
| ---- | ---- | ---- |
| **Sensation** | 2 | 스냅·펀치 임팩트 피드백, 시네마틱 라이팅, 게이지 UI 반응 |
| **Fantasy** | 3 | "마스터리 영웅" + "이 보스를 내가 알게 된다" 의인화 관계 |
| **Narrative** | N/A | 컷씬·다이얼로그·서사 없음 |
| **Challenge** | **1 (Primary)** | 패링 윈도우 정확도, 보스 패턴 학습 곡선, 페이즈 2 강도 |
| **Fellowship** | N/A | 솔로 |
| **Discovery** | N/A | 탐험 없음 (시스템 깊이의 emergent 발견은 매우 약하게) |
| **Expression** | 4 | 평타 콤보 시퀀스, 베타 스킬 선택, 패링·회피 비중 결정 |
| **Submission** | N/A | 휴식 게임 아님 |

### Key Dynamics
- 보스 패턴 학습 → 반복 시도 → 점진적 깊이 발견 ("이 패턴은 이렇게도 받을 수 있구나")
- 패링·회피 성공 → 카운터 윈도우 → 콤보·베타 폭딜 → 보스 스태거 → 추가 폭딜 윈도우
- Self-imposed mastery challenges (노 데미지 / 시간 단축 / 베타 무사용 / 패링 100%)

### Core Mechanics
1. **평타 콤보** — Light/Heavy 평타 시퀀스 (1~2 패턴)
2. **퍼펙트 패링** — 좁은 윈도우, 적 스태거 누적 + 베타 게이지 충전
3. **퍼펙트 회피** — 회피 윈도우, 슬로우모션 + 카운터 트리거
4. **베타 게이지·스킬** — 충전 → 베타 스킬 2~3종 소비
5. **적 스태거 게이지** — 누적 → 무방비 상태 + 폭딜 윈도우
6. **위험 큐 시스템** — 빨강(패링 불가) / 노랑(회피 전용) / 일반(자유) 텔

---

## Player Motivation Profile

### Primary Psychological Needs Served

| Need | How This Game Satisfies It | Strength |
| ---- | ---- | ---- |
| **Autonomy** | 콤보 시퀀스 구성, 패링·회피 선택, 학습 페이스 | Supporting |
| **Competence** | 패링 정확도·패턴 학습·콤보 정확도 모두 즉시 가시화 | **Core** |
| **Relatedness** | 솔로, NPC 없음. "보스를 알게 된다"는 의인화만 약하게 | Minimal |

### Player Type Appeal (Bartle Taxonomy)

- [x] **Achievers** — 마스터리 완성, self-imposed challenge 추구
- [ ] **Explorers** — 시스템 깊이 발견은 약하게 작동
- [ ] **Socializers** — 해당 없음
- [x] **Killers/Competitors** — 보스 정복 욕구로 약하게 매핑

### Flow State Design

- **Onboarding**: 첫 10분에 보스 1회 시도, 텔 인식 학습, 첫 시도는 의도적으로 패배 (소울라이크 첫 보스 패턴)
- **Difficulty scaling**: 보스 패턴이 결정적 시퀀스로 학습 가능 + 페이즈 2 진입으로 강도·복잡도 상승
- **Feedback clarity**: 게이지 UI, 시각·청각·햅틱 임팩트, 보스 스태거 시 슬로우모션 큐
- **Recovery**: 즉시 재시도 (로딩 ≤ 2초), 패배가 학습으로 전환되는 페이싱

---

## Core Loop

### Moment-to-Moment (30초)
보스 공격 텔(빨강/노랑/일반) 인식 → 대응 입력(패링/회피/방어) → 성공 시 적 스태거 누적 + 베타 게이지 충전 + 카운터 윈도우 → 평타 콤보 또는 베타 스킬 폭딜 → 다시 다음 텔.

매 입력의 입력→보상 거리가 0. 스냅·펀치 톤이 그 거리감을 더 짧게 만든다.

### Short-Term (5~15분)
보스 페이즈 1 진입 → 패턴 N종 학습 (사이클 2~3회) → 페이즈 1 처치 또는 패배 → 즉시 재시도 → 페이즈 2 진입 (새 패턴, 강도↑) → 클리어 또는 다음 시도. "한 번 더" 심리는 매 시도마다 깊어지는 패턴 인식이 만든다.

### Session-Level (30~120분)
한 세션은 학습-시도-패배-개선 순환의 반복. 결국 클리어 또는 "그 패링 시퀀스를 다음번엔 더 깔끔하게"라는 다음 세션 후크로 종료.

### Long-Term Progression
프로토타입 스코프에는 거대한 진행 루프가 **없다**. 보스 1체 클리어가 종착. Longevity는 **self-imposed mastery challenges** (노 데미지·시간 단축·베타 무사용 등)와 **숨은 깊이 발견**(emergent expression)에서 옴.

### Retention Hooks
- **Curiosity**: "이 패턴은 또 어떻게 받을 수 있을까"
- **Investment**: 매 시도마다 누적되는 패턴 인식
- **Social**: 해당 없음 (프로토타입 단계)
- **Mastery**: 가장 강한 후크 — 스킬을 닦을 여지가 보스 안에 깊게 내장됨

---

## Game Pillars

### Pillar 1: Input Fidelity Above All
패링 윈도우·입력 응답성·애니메이션 캔슬·피드백 지연이 다른 모든 것보다 우선한다.

*Design test*: "시각 효과를 더 화려하게 vs 입력 응답성 4프레임 단축" → **응답성**을 고른다.

### Pillar 2: Visible Mastery
플레이어의 성장이 매 순간 보여야 한다. 보상은 선형이 아니라 **기하급수적**이어야 한다.

*Design test*: "단발 패링 성공 vs 5연속 패링 성공" → 후자는 5번이 아니라 **30~50배** 더 큰 임팩트.

### Pillar 3: Boss as Music
보스 패턴은 무작위 즉흥이 아니라 학습 가능한 시퀀스로 디자인된다. 플레이어는 결국 보스를 "연주"하게 된다.

*Design test*: "랜덤 패턴 셀렉션 vs 가중 결정적 시퀀스" → **결정적 시퀀스**.

### Pillar 4: Depth Over Breadth
새 시스템을 추가하기 전에 기존 시스템의 깊이를 더 판다.

*Design test*: "장비 슬롯 추가 vs 패링 캔슬 옵션 추가" → **후자**.

### Anti-Pillars

- **NOT a soulslike** — 수동적 방어 일변도 회피·롤 게임이 아니다. 베타·콤보 능동 표현이 핵심 (Pillar 2 보호).
- **NOT a story game** — 컷씬·NPC·다이얼로그 없음. 모든 의미는 전투 안에서 (Pillar 4 보호).
- **NOT an open game** — 탐험·인벤토리·장비 강화 없음. 단일 아레나 결전 (Pillar 4 보호).
- **NOT a content-rich game** — 보스 1체. 수십 시간이 아니라 마스터리 깊이로 longevity (Pillar 3·4 보호).

---

## Visual Identity Anchor

**Direction: Faithful Cinematic Realism**

> **One-line rule**: 스텔라블레이드의 사실적 SF 모더니즘을 그대로 — 단일 아레나 + 단일 보스에 응축한다.

### Visual Principles

1. **사실적 PBR 머티리얼이 기본값**
   *Design test*: 머티리얼 결정 시 항상 사실 PBR 우선. 스타일라이즈드/셀셰이딩으로 우회하지 않는다.

2. **시네마틱 키 라이팅 + 강한 림 라이트**
   *Design test*: 라이팅 셋업은 시네마틱 카메라 기준으로 잡는다. 게임플레이 카메라가 시네마틱과 충돌하면 게임플레이를 우선하되 시네마틱 톤 유지.

3. **위험 큐(빨강/노랑) 절대 가독성**
   *Design test*: 환경 색상이 위험 큐와 충돌하면 환경을 양보한다. 빨강/노랑은 화면에서 가장 밝은 단일 색.

### Color Philosophy
어두운 환경 베이스 + 캐릭터는 채도 높은 디테일 + 위험 큐는 화면 최강 색. 시네마틱 톤이지만 게임플레이 가독성이 항상 우선.

---

## Inspiration and References

| Reference | What We Take From It | What We Do Differently | Why It Matters |
| ---- | ---- | ---- | ---- |
| **Stellar Blade** | 패링·회피·베타 게이지·스태거 시스템 통째 | 보스 1체 단일 결전으로 응축, 패링 비중 60:40으로 약간 상향 | 시스템 충실 재현이 곧 학습 가치 |
| **Sekiro: Shadows Die Twice** | 패링 위주 정밀 마스터리 톤, 보스 페이즈 학습 곡선 | 베타·콤보 표현으로 능동성 강화 | 패링 60:40 우세 결정의 근거 |
| **Furi** | 1대1 결투 챔버 구조, 단일 보스 깊이 | 모던 액션 비주얼·콤보 표현 추가 | MVP 콘텐츠 구조 모델 |

**Non-game inspirations**: 메탈기어 라이징의 블레이드 모드 카타르시스 (콤보 폭발의 시각적 임팩트 참고).

---

## Target Player Profile

| Attribute | Detail |
| ---- | ---- |
| **Age range** | 20~40 |
| **Gaming experience** | Hardcore action |
| **Time availability** | 짧고 집중된 세션 (30분~2시간) |
| **Platform preference** | PC |
| **Current games they play** | Stellar Blade, Sekiro, Bayonetta, DMC, Lies of P |
| **What they're looking for** | Reactive mastery + active expression이 동시에 만족되는 모던 액션 |
| **What would turn them away** | 캐주얼화, 자동 타겟팅 보정, 컷씬 주도, 오픈월드 분산, 방치형 요소 |

---

## Technical Considerations

| Consideration | Assessment |
| ---- | ---- |
| **Recommended Engine** | Unreal Engine 5.7 (이미 결정 — Lumen·Nanite·MetaHuman·Megascans 활용) |
| **Key Technical Challenges** | 입력 응답성·패링 윈도우 정밀도 (가장 큼), 보스 패턴·릭·애니메이션 비용, 베타 게이지·스태거 시스템 게임 필 튜닝 |
| **Art Style** | 3D Faithful Cinematic Realism |
| **Art Pipeline Complexity** | High (3D 사실), Megascans + MetaHuman + Fab 마켓플레이스 활용으로 솔로 부담 완화 |
| **Audio Needs** | Moderate — 액션 SFX 풍부, 보스 패턴별 시각·청각 큐 동기화 필수 (MVP는 placeholder OK) |
| **Networking** | None |
| **Content Volume** | 보스 1체 / 단일 아레나 / 5~15분 전투 × N회 학습 = 총 1~3시간 (마스터리 깊이에 따라 확장) |
| **Procedural Systems** | None — 결정적 패턴 시퀀스 (Pillar 3) |

---

## Risks and Open Questions

### Design Risks
- **입력 정밀도 튜닝 실패 → 컨셉 사망**: 패링 윈도우·캔슬·피드백 지연이 정확하지 않으면 게임 자체가 무너진다. 가장 큰 단일 위험.
- **"겉보기만 비슷한 짝퉁"으로 끝남**: 6 시스템이 깊이 작동하려면 각 시스템에 충분한 튜닝 시간이 필요. 매주 자체 플레이테스트 의무화.
- **밸런스·페이싱 영역의 새로움**: 사용자는 클라이언트 프로그래머로 게임 디자인 영역(밸런스·페이싱)이 새로움. 외부 1~2명 테스터 권장.

### Technical Risks
- **보스 패턴·애니메이션 비용 폭증**: 패턴 N개 × 애니메이션 N개의 곱이 일정을 잡는다. 마켓플레이스 + 짧고 임팩트 강한 패턴 셋으로 완화.
- **베타 게이지·스태거 시스템의 게임 필**: 수치 튜닝이 핵심. UE 데이터 에셋 기반 핫 리로드 환경 권장.

### Market Risks
- 출시 게임이 아니므로 직접적 시장 리스크는 낮음. 다만 Tier 2 출시 검토 시 "스텔라블레이드 짝퉁"으로 인식될 위험 — Tier 2 진입 시 차별화 축 재정의 필요.

### Scope Risks
- "몇 주" 약속 폭증: 보스 1체조차 4~8주 풀 로드. 핵심 시스템 우선 + 비주얼은 placeholder로 시작 → 후순위 폴리시.

### Open Questions
- Q1: 패링 윈도우는 몇 프레임이 "스냅·펀치" 톤에 정확한가? → **바닐라 박스 vs 박스 프로토타입**으로 검증 (자산 작업 보류 상태에서 먼저).
- Q2: 베타 스킬 2종 vs 3종 중 어느 쪽이 표현·학습 곡선 균형이 좋은가? → 핵심 시스템 통합 후 1주차 자체 플레이테스트.
- Q3: 페이즈 2 진입 트리거는 HP 50% vs 시간 vs 패턴 시퀀스 클리어 중 어느 쪽이 결정적 학습에 가장 유리한가? → 보스 1차 패턴 작업 후 결정.

---

## MVP Definition

**Core hypothesis**: 단일 보스 vs 플레이어의 5~15분 전투가 **패링 마스터리의 카타르시스**를 만들어내는가.

**Required for MVP**:
1. 입력 응답성 정밀 튜닝 (가장 우선)
2. 패링·회피·베타 게이지·스킬·스태거 핵심 시스템 풀 작동
3. 보스 1체 페이즈 1~2 결정적 패턴
4. 위험 큐 시스템 가독성 (빨강/노랑/일반)
5. 즉시 재시도 루프 (≤ 2초 로딩)
6. 단일 아레나 (placeholder 환경 OK)

**Explicitly NOT in MVP**:
- 다중 보스 / 다중 아레나
- 잡몹·미니언
- 인벤토리·장비·강화·진행 시스템
- 스토리·컷씬·NPC·다이얼로그
- 메타 진행·언락
- 사운드트랙 풀 작곡 (placeholder OK)
- 시네마틱 인트로/아웃트로

### Scope Tiers

| Tier | Content | Features | Timeline |
| ---- | ---- | ---- | ---- |
| **MVP (현재 목표)** | 보스 1체 페이즈 1~2, 단일 아레나 (placeholder) | 핵심 시스템 6종, 즉시 재시도 | **4~8주, solo — 검증용, 출시 아님** |
| **Vertical Slice** | + 폴리시 (사운드, VFX, 시네마틱 인트로 1컷) | + 음향 패스, 카메라 셰이크, 햅틱 | 추가 4~8주 |
| **Tier 2 (출시 검토)** | 보스 2~3체 + 사이 도장 룸 | + 챌린지 모달리티, Steam 페이지·트레일러 | 추가 2~4개월 |
| **Full Vision (가상)** | 보스 러시 5~10체, 다양한 아레나 | + 메타 진행, 점진적 패턴 가이드 | 다년 |

---

## Next Steps

- [ ] `/setup-engine` 검토 — 엔진 이미 UE5.7로 설정, 버전 레퍼런스 docs 확인만
- [ ] `/art-bible` 작성 — Visual Identity Anchor를 비주얼 정체성 사양으로 확장
- [ ] `/design-review design/gdd/game-concept.md` — 컨셉 완성도 검증
- [ ] `/map-systems` — 컨셉을 시스템 6종으로 분해, 의존성 매핑
- [ ] `/design-system` (×N) — 시스템별 GDD 작성 (입력·패링·회피·베타·스태거·위험큐)
- [ ] `/create-architecture` — 아키텍처 마스터 청사진
- [ ] `/architecture-decision` (×N) — 핵심 ADR 작성
- [ ] `/gate-check` — 프리프로덕션 → 프로덕션 전환 게이트
- [ ] `/prototype` — 가장 위험한 시스템(입력 정밀도)부터 바닐라 박스 vs 박스 프로토
- [ ] `/playtest-report` — 프로토 결과 검증
- [ ] `/sprint-plan new` — 첫 스프린트 계획
