# Game Concept: EXTRACT

*Created: 2026-05-04*
*Status: Draft*

---

## Elevator Pitch

> **EXTRACT**는 좀비가 점령한 도시에서 갇힌 사람들을 한 명씩 구출해 안전지대로
> 데려오는 솔로 추출 슈터다. 모든 NPC는 영구 캐릭터고, 그들의 사연을 한 조각씩
> 모아야 도시의 진실과 감염의 기원이 드러난다. 좀비를 처치하는 손맛은 도구일
> 뿐 — 진짜 게임은 **누구를 구할지, 어떻게 구할지, 그 결정의 무게**에 있다.

---

## Core Identity

| Aspect | Detail |
| ---- | ---- |
| **Genre** | Solo PvE Extraction Shooter + NPC Companion Narrative |
| **Platform** | PC (Steam / Itch.io) |
| **Target Audience** | PvE 인디 서사 게이머 (This War of Mine, Hades, XCOM 청중) |
| **Player Count** | Single-player (AI 동료 NPC) |
| **Session Length** | 30-60분 (미션 1-3회 + 안전지대 대화) |
| **Monetization** | Premium (one-time purchase) — 라이브 서비스·DLC 없음 |
| **Estimated Scope** | Large (12-24 months, solo) — MVP는 몇 주 |
| **Comparable Titles** | XCOM (영구 손실 운영), This War of Mine (정서 무게), Hades (NPC 관계), Left 4 Dead 2 (좀비 디렉터 정서) |

---

## Core Fantasy

플레이어는 **잿빛 도시에서 갇힌 사람들을 구해내는 마지막 운영자**가 된다. 게임의
정서 중심은 좀비 처치가 아니라 **"내가 가지 않으면 저 사람은 죽는다"**라는
구원자 판타지다. 자원·시간·자기 안전을 양보해 다른 누군가를 끌어내는 결정의
무게, 그리고 그 사람을 안전지대까지 데려왔을 때의 안도와 유대.

이 핵심 정서는 두 가지 다른 게임에서는 직접 충족되지 않는다:
- 일반적인 좀비 슈터: "쏘는 행위" 자체에 보상이 집중되어 동료 구원 정서가 표면적
- 일반적인 협동 슈터: 멀티플레이어가 필요해 솔로 진입장벽이 높고, 동료가 영구
  캐릭터가 되지 않는다

EXTRACT는 **"AI 동료의 영구 관계 + 솔로 운영의 무게 + 좀비 IP의 직관적 압박"**을
한 게임에 묶는다.

---

## Unique Hook

> **"좀비를 쏘는 게 아니라 사람을 구한다."**

좀비 슈터의 표면을 입었지만, 게임의 메인 보상 루프는 **NPC 영구 동료 영입과
사연 해금**이다. 다른 좀비 게임과의 결정적 차이:

- **AND ALSO** AI 동료가 일회용이 아니라 영구 캐릭터다 — 매 미션 같은 사람이
  돌아오고, 죽으면 영구 손실
- **AND ALSO** 한 명을 구할 때마다 도시의 비밀이 한 조각 풀린다 (Hades의
  House 모델 차용)
- **AND ALSO** 4인 협동의 정서를 멀티플레이 없이 NPC와의 관계로 충족 — 솔로
  플레이의 외로움이 아니라 솔로 운영자의 책임감

이 훅은 **사용자(개발자)의 정서 앵커**와 직접 연결된다: "동료가 위험에 빠졌을 때
구해주는 플레이"가 가장 강하게 끌렸다는 출발 신호.

---

## Player Experience Analysis (MDA Framework)

### Target Aesthetics (What the player FEELS)

| Aesthetic | Priority | How We Deliver It |
| ---- | ---- | ---- |
| **Sensation** (sensory pleasure) | 4 | 처치 임팩트 사운드 + 히트스톱 + 매트한 라이팅의 분위기 |
| **Fantasy** (make-believe, role-playing) | 3 | "마지막 운영자" 정체성, 안전지대의 책임자 역할 |
| **Narrative** (drama, story arc) | **1** (Primary) | NPC 사연 누적 + 도시의 비밀 + 영구 손실의 무게 |
| **Challenge** (obstacle course, mastery) | 5 | 결정의 무게와 정직한 손맛 — 마스터리 게임은 아님 |
| **Fellowship** (social connection) | **2** (Strong support) | AI 동료의 영구 관계 + 안전지대 대화 + 호위 협동 |
| **Discovery** (exploration, secrets) | 3 | NPC 사연으로 도시·감염·과거의 진실을 한 조각씩 발견 |
| **Expression** (self-expression, creativity) | 8 (N/A) | 핵심 미학 아님 — 빌드 다양성 최소 |
| **Submission** (relaxation, comfort zone) | 8 (N/A) | 안전지대는 휴식이지만 게임의 코어는 긴장 |

### Key Dynamics (Emergent player behaviors)

- 플레이어는 **누구를 먼저 구할지** 사연·시너지·시급도를 따져 결정하기 시작한다
- 플레이어는 안전지대 대화에서 **NPC 간 관계를 재구성**한다 (누가 누구를 알았는지)
- 플레이어는 **위험 정보를 충분히 모은 뒤** 출발하는 행동을 학습한다 (P2 Pillar 강제)
- 플레이어는 한 미션의 실수가 **장기 결과로 이어진다는 의식**을 갖는다 (P4 Pillar)
- 플레이어는 영구 손실 가능성 앞에서 **회피·후퇴 결정의 가치**를 발견한다

### Core Mechanics (Systems we build)

1. **추출 미션 시스템** — 진입 → NPC 발견 → 호위 → 탈출의 5분 루프
2. **NPC 영구 동료 시스템** — 구출된 NPC는 안전지대 거주, 다음 미션 AI 파트너로
   선택 가능, 사망 시 영구 손실
3. **사연·관계 시스템** — 안전지대 대화에서 NPC 사연 해금, 도시의 진실 누적 공개
4. **호위 AI** — NPC가 따라오기·정지·위협 회피하는 단순하지만 신뢰감 있는 동작
5. **손맛 처치 시스템** — 임팩트 사운드, 히트스톱, VFX로 시원함 보장
6. **위협 정보 가용성** — 모든 큰 위협은 시각·청각으로 사전 경고 (AP1 강제)

---

## Player Motivation Profile

### Primary Psychological Needs Served

| Need | How This Game Satisfies It | Strength |
| ---- | ---- | ---- |
| **Autonomy** | 어떤 NPC를 먼저 구할지 / 어떤 동료를 데려갈지 / 어떤 위험을 감수할지 모두 플레이어 결정 | Core |
| **Competence** | 처치·회피의 정직한 손맛 + 무사 귀환 + 무손실 캠페인 도전 | Supporting |
| **Relatedness** | NPC 영구 동료와의 관계 + 안전지대 대화 + 사연 누적 — 멀티 없이 깊은 정서적 연결 | Core |

### Player Type Appeal (Bartle Taxonomy)

- [x] **Achievers** — 모든 NPC 구출 + 무손실 캠페인 + 사연 100% 해금
- [x] **Explorers** — 도시의 비밀 + 감염의 기원 + NPC 간 관계망 발견
- [x] **Socializers** — NPC와의 영구 관계 (실제 멀티가 아닌 의사 사회적 연결)
- [ ] **Killers/Competitors** — 의도적으로 배제. PvP 없음, 경쟁 없음

### Flow State Design

- **Onboarding curve**: 첫 10분에 한 명의 NPC를 구해 안전지대까지 데려오는 짧은
  튜토리얼 미션. 호위·추출·탈출의 코어 동작을 손에 익힘
- **Difficulty scaling**: 미션 단위로 난이도 상승 (적 수, 위협 다양성, 추출
  거리). 플레이어가 어떤 NPC를 데려가느냐에 따른 자체 조절
- **Feedback clarity**: 모든 위협은 사전 경고, 모든 결정은 명시적 결과. "왜
  졌는지 모르는" 죽음은 디자인 단계에서 차단 (P2)
- **Recovery from failure**: 영구 손실은 무겁지만 캠페인은 지속. 한 NPC 손실이
  게임오버는 아니며, 다른 NPC들과의 새 운영 가능. 결정적 손실(주요 NPC 다수
  사망) 시에만 분기 또는 게임오버

---

## Core Loop

### Moment-to-Moment (30 seconds)

**관찰 (위치·소음 파악) → 접근 (이동·자원 결정) → 위협 처리 (회피 또는 처치) →
호위 (NPC 끌고 이동) → 다음 위협**

핵심 만족: 한 발의 시원한 처치감 + 호위 중 위협 회피의 긴장감. 30초 단위로
플레이어는 "처치할까, 우회할까, NPC를 두고 갈까"의 작은 결정을 반복한다.

### Short-Term (5-15 minutes)

**한 추출 미션**:
미션 출발 (안전지대 → 도시 진입) → NPC 발견 → 호위 시작 → 추출 압박 (시간·소음
누적) → 탈출 (안전지대 도착)

미션 단위로 보상이 명확: 살아 돌아오면 새 동료 + 사연 해금. "한 명만 더 구해
오자" 심리가 다음 미션을 자연스럽게 끌어낸다.

### Session-Level (30-120 minutes)

**한 세션 = 1-3 미션 + 안전지대 시간**

1. 안전지대에서 다음 NPC 선택 + 동료 파트너 선택
2. 출발 → 미션 수행 → 귀환 (또는 손실)
3. 안전지대 복귀 → 새 동료 영입 또는 추모 → 사연 대화 → 다음 결정

자연 스톱 포인트: 미션 직후 또는 사연 듣고 난 직후. 사연 해금이 "다음 세션에서
누구의 이야기를 들을지"의 호기심으로 이어짐.

### Long-Term Progression

- **NPC 풀 확장**: 6-10명 영구 캐릭터를 한 명씩 모음
- **도시의 진실 누적**: 사연마다 도시·감염·과거의 한 조각 공개
- **운영자의 무게**: 누구를 잃었는지의 기억이 후반 결정에 영향
- **결말**: 모든 NPC 구출 = 엔딩. 결정적 손실 = 분기 엔딩 또는 게임오버

### Retention Hooks

- **Curiosity**: NPC 사연이 도시의 비밀로 이어짐 — 다음 사연이 무엇을 풀 것인가
- **Investment**: 영구 동료에 대한 애착 — 잃고 싶지 않은 캐릭터가 생김
- **Social**: (의사 사회적) 안전지대 대화에서의 NPC 관계 발견
- **Mastery**: 무손실 캠페인 도전 + 사연 100% 해금

---

## Game Pillars

### Pillar 1: Every Rescue is a Person

NPC는 컨텐츠 단위가 아니라 영구 캐릭터이며, 한 명을 구할 때마다 세계가 한
조각씩 드러난다.

*Design test*: 구출 보상으로 X(추가 무기·자원)를 줄까, Y(NPC 사연 한 챕터)를
줄까? → **항상 Y**.

### Pillar 2: Decision Has Weight, Skill is Honest

미션 결과는 운영 판단 + 정직한 실력으로 결정된다. "내가 뭘 모르는지 몰라서
졌다"는 절대 안 됨.

*Design test*: 위험 정보를 숨겨 긴장감을 줄까, 보여주고 결정을 무겁게 할까?
→ **항상 보여준다, 그리고 결정을 무겁게**.

### Pillar 3: Compact Carnage

솔로 첫 게임의 한계 안에서, 5분 미션 안에서도 시원한 손맛이 살아있어야 한다.
적 다양성·맵 크기보다 한 발의 임팩트.

*Design test*: 적 종류를 5개로 늘릴까, 현재 3개의 처치감을 더 다듬을까? →
**항상 다듬는다**.

### Pillar 4: Permanent Loss, Honest Goodbye

동료가 죽으면 영구적이다. 죽음은 무겁지만 플레이어가 사전에 충분히 경고받은
후의 일이어야 한다.

*Design test*: 이 NPC가 빈사 상태일 때 즉사 시킬까, 한 번 더 결정할 기회를 줄까?
→ **항상 한 번의 결정 기회**.

### Anti-Pillars (What This Game Is NOT)

- **NOT Hidden Damage**: "왜 죽었는지 몰랐던" 죽음은 만들지 않는다. 모든 큰
  위협은 사전에 시각·청각으로 경고된다. *Why: 사용자가 회피한 "모르면 죽는"
  불쾌 요소를 차단하기 위함. P2 직결.*
- **NOT Multiplayer in MVP**: 4인 협동, 매칭, 동기화는 MVP에 절대 들어가지
  않는다. AI 동료로 협동 정서를 만든다. *Why: 첫 게임 + 솔로 + 몇 주에 멀티
  네트워킹은 자살.*
- **NOT Live-Service Treadmill**: 시즌 패스, 일일 미션, 데일리 리워드는 들어가지
  않는다. *Why: 받는 입장의 매력과 만드는 입장의 비용이 다르다. 첫 게임에 운영
  부담 폭증.*
- **NOT Random Permadeath**: 영구 손실은 있어도, 무작위 운에 의한 즉사는 없다.
  모든 영구 손실은 플레이어 결정의 결과여야 한다. *Why: P2 직결.*

---

## Visual Identity Anchor

> *Lean review mode: AD-CONCEPT-VISUAL gate skipped. 이 섹션은 잠정이며 `/art-bible`
> 단계에서 본격 확정한다.*

### Direction Name
**"Matte Realistic Post-Apocalypse"**

### One-line Visual Rule
> *"사실적 라이팅과 매트한 PBR 머티리얼로 잿빛 도시의 무게를 표현한다 —
> 광택을 절제하고 자연스러운 손때를 강조."*

### Supporting Visual Principles

1. **사실적 라이팅이 분위기다** — UE5 Lumen 기반 동적 라이팅으로 시간·날씨·
   실내외 대비를 표현. 라이팅이 자산보다 분위기 결정 비중 큼. 안전지대의 따뜻한
   등불 + 도시의 차가운 자연 채광이 톤의 큰 축.
   *Design test*: 같은 환경 자산을 다른 라이팅으로 두면 다른 정서를 갖는가?

2. **매트한 PBR 머티리얼** — 광택을 절제한다. 사실적 머티리얼이지만 거칠고
   손때 묻은 표면 우선. 빛나는 표면(금속·물·신선한 혈흔)은 의도적 강조에만 사용.
   *Design test*: 한 자산의 머티리얼이 환경에 자연스럽게 녹아드는가?

3. **실루엣과 디테일 모두** — 멀리서는 실루엣으로 위협 식별, 가까이서는 손때·
   균열·디테일로 몰입. UE5 Nanite + Megascans로 디테일 비용 관리.
   *Design test*: 멀리서 적 종류 식별 + 가까이서 환경 디테일 모두 작동하는가?

### Color Philosophy
- 도시: 차가운 회청색·먼지 회색·바랜 갈색 (감염의 무채색, 자연 채광 강조)
- 안전지대: 따뜻한 등불 (오렌지·앰버) + 차가운 외곽 — 안식과 위협의 명확한 색채 대비
- 강조색: NPC 한 명당 하나의 액센트 색 (의류·소품 한 곳에 절제된 사용)

### Visual Reference Games
- **The Last of Us 1/2** — 매트 포스트아포칼립스 톤, 환경 스토리텔링, 자연 채광
- **State of Decay 2** — 미국 교외의 일상이 무너진 자리, 솔로/소수 인원 운영 톤
- **Days Gone** — 야외 좀비 액션의 매트 리얼리스틱 표현
- **Metro Exodus** — 라이팅으로 분위기 만들기, 안전지대 vs 위험지대 대비
- **Hunt: Showdown** — 매트한 PBR + 무거운 사운드 디자인의 시너지

---

## Inspiration and References

| Reference | What We Take From It | What We Do Differently | Why It Matters |
| ---- | ---- | ---- | ---- |
| **Left 4 Dead 2** | 좀비 디렉터의 동적 압박, 협동 위기 정서 | 멀티 대신 NPC 영구 동료 + 운영의 무게 | 좀비 IP의 직관적 매력 검증, 협동 정서가 솔로에서도 가능함을 보여줄 도전 |
| **This War of Mine** | NPC 운영 + 영구 손실 + 정서적 무게 | 좀비 IP + 처치 손맛으로 더 직관적 진입 | 인디 PvE 운영 게임의 시장 검증 (~600만 카피) |
| **Hades** | NPC 사연 누적 + House 허브 모델 + 영구 캐릭터의 깊이 | 로그라이크 메타 대신 캠페인 단방향 | NPC 관계 시스템의 검증 사례, 안전지대 대화 모델 |
| **XCOM** | 영구 손실의 무게 + 미션 운영 구조 | 턴제 대신 실시간 추출 액션 | 영구 손실이 솔로 PvE에서 통하는 시장 증거 |
| **Lethal Company** | 추출 압박 + 시간·자원 운영 | 멀티 대신 솔로 + 영구 동료 | 추출 게임 메커닉 검증, 짧은 미션 호흡 |

**Non-game inspirations**: 코맥 매카시 *The Road* (잿빛 톤, 부모-자식의 운반
정서), 영화 *Children of Men* (혼란 속 한 사람을 끌어내는 원샷 추격 시퀀스),
영화 *28 Weeks Later* (감염 도시의 다층적 위협 구조).

---

## Target Player Profile

| Attribute | Detail |
| ---- | ---- |
| **Age range** | 25-45 |
| **Gaming experience** | Mid-core (Hardcore 가까움) — 인디 + AAA 양쪽을 즐김 |
| **Time availability** | 평일 30-60분, 주말 더 길게. 세션 단위 게임 선호 |
| **Platform preference** | PC (Steam 주력) |
| **Current games they play** | This War of Mine, Hades, Frostpunk, Disco Elysium, XCOM 2, Darkest Dungeon |
| **What they're looking for** | **결정의 무게가 있는 PvE 서사 게임** + 인디 가격대 + 끝이 있는 캠페인 |
| **What would turn them away** | PvP 압박 / 라이브 서비스 그라인드 / "왜 졌는지 모르는" 불공정 죽음 / 무한 회차 강제 / 수십 시간 시간 투자 강요 |

---

## Technical Considerations

| Consideration | Assessment |
| ---- | ---- |
| **Recommended Engine** | **Unreal Engine 5** — 사용자가 숙련된 UE 클라이언트 프로그래머. UE5의 Lumen·Nanite·Megascans·MetaHuman 파이프라인이 매트·리얼리스틱 톤과 정확히 일치 |
| **Key Technical Challenges** | (1) NPC 호위 AI의 신뢰감 있는 동작 (2) 처치 손맛 폴리시 (사운드·히트스톱·Niagara VFX) (3) 영구 동료·세이브 시스템 (4) 매트 리얼리스틱 자산 파이프라인의 솔로 운용 |
| **Art Style** | 3D 매트 리얼리스틱 — 사실적 라이팅 + PBR 매트 머티리얼 + 환경 스토리텔링 |
| **Art Pipeline Complexity** | High — 사실적 자산 제작 비용 큼. Megascans/MetaHuman/마켓플레이스 활용 + 외주 옵션으로 솔로 가능 범위에 압축 가능. NPC 캐릭터 모델 6-10명이 가장 큰 작업량 (MetaHuman 활용 가능) |
| **Audio Needs** | Moderate — 처치·환경 사운드가 게임 정서에 핵심 (P3 강제). NPC 보이스는 텍스트 기반으로 절제 |
| **Networking** | None — 싱글플레이어 전제, MVP·풀 비전 모두 |
| **Content Volume** | 풀 비전 추정: 3-5 맵, 6-10 NPC, 4 적 종류, 30-40시간 플레이타임 |
| **Procedural Systems** | 최소 — 미션 변주를 위한 적 배치 무작위화 정도. 절차적 생성 의존하지 않음 (P2 결정의 명확성과 충돌 가능) |

---

## Risks and Open Questions

### Design Risks

- **NPC 호위 AI가 어색하면 코어 정서 무너짐** — 따라오기·정지·위협 회피의 신뢰감이
  핵심. AAA에서도 어려운 영역
- **사연 작문 분량의 솔로 부담** — 6-10명 NPC × 사연 = 게임의 메인 보상이지만
  솔로 작문은 시간 비용 큼
- **손맛이 "충분히 시원"하지 않으면 P3 무너짐** — Warframe 수준은 어려워도 한
  발의 임팩트는 폴리시 단계 비용 큼
- **5분 미션이 30회 이상 반복되면 지루해질 수 있음** — 변주 시스템(맵 변화·적
  배치·NPC 위치) 필요

### Technical Risks

- **호위 AI 구현** — UE5 Behavior Tree + EQS + Smart Objects로 가능하나 디테일이
  많음. 따라오기·정지·끼임 회피·위협 반응의 자연스러움이 게임 정서를 좌우
- **세이브 시스템** — 영구 동료 + NPC 상태 + 사연 진행을 안정적으로 직렬화. UE5
  SaveGame 시스템의 한계 확인 필요 (특히 NPC 상태 그래프 직렬화)
- **매트 리얼리스틱 자산 파이프라인** — Megascans + MetaHuman으로 환경·캐릭터
  부담을 압축할 수 있으나 NPC 한 명당 의상·표정·애니메이션 커스터마이징 비용
  여전히 큼. 6-10명 분량이 가장 큰 자산 작업량

### Market Risks

- **좀비 IP 포화** — 차별점은 "사람을 구한다" 한 줄 + NPC 영구성에 있음. 이 차별이
  게임 시장 메시지로 명확히 전달되어야 함
- **솔로 인디 PvE 서사 게임의 인지도 비용** — Steam 인디 페이지가 묻히기 쉬움.
  비주얼 정체성과 한 줄 훅이 마케팅의 거의 전부
- **첫 게임이라는 프로필 자체가 시장 진입 부담** — 개발자 브랜드 없음

### Scope Risks

- **풀 비전 12-24개월 솔로 추정 vs 사용자 명시 "몇 주" 타임라인의 큰 격차** —
  MVP는 몇 주 가능하나, 시장 출시 가능한 게임은 1-2년+. 이 격차를 명시적으로
  관리해야 함
- **매트 리얼리스틱 자산 제작이 개발 일정의 큰 비중** — Megascans/MetaHuman/
  마켓플레이스 활용 전제로도 NPC 6-10명 분량 + 환경 다양성은 솔로에 부담.
  외주·자산 마켓 활용 전략을 일찍 결정해야 함

### Open Questions

- **호위 AI의 실제 신뢰감** — MVP 1주차에 검증해야 할 가장 큰 질문. 따라오기 +
  정지가 자연스러운가?
- **5분 미션 + 안전지대 5분 비율이 맞는가** — 플레이테스트로 검증
- **Discovery 정서가 작문 분량에 비례하는가** — NPC 1명 사연으로 충분히 깊은
  몰입이 가능한지
- **MetaHuman + 매트 리얼리스틱 캐릭터 커스터마이징의 솔로 비용** — NPC 6-10명을
  매트 리얼리스틱 톤으로 만들 때 한 명당 의상·표정·애니메이션 작업 시간 추정 필요

---

## MVP Definition

**Core hypothesis**: *"한 명의 NPC를 좀비 도시에서 끌어내 안전지대로 데려오는
30초~5분 단위 정서가 플레이어에게 만족스러운가?"*

### Required for MVP

1. **1개 작은 맵** — 한 거리 분량, 진입·NPC 발견·탈출 경로가 분명한 디자인
2. **1명 NPC** — 호위 가능, 따라오기 + 정지 + 위협 회피의 최소 AI 셋
3. **1종 좀비 적** — 기본 추격형, 시각·청각 경고 가능
4. **1개 무기** — 처치 손맛 폴리시(임팩트 사운드·히트스톱·VFX) 적용된 단일 무기
5. **추출·호위 메커닉** — 진입·호위·탈출의 5분 루프 완성
6. **단순 안전지대** — 미션 시작·완료 화면, NPC 대사 한 줄

### Explicitly NOT in MVP (defer to later)

- 영구 동료 시스템 (MVP는 한 미션 단위 검증)
- 사연·관계 시스템 (Discovery 검증은 버티컬 슬라이스)
- 적 다양성·맵 다양성·무기 다양성
- UI 폴리시 (텍스트 + 박스로 충분)
- 음악 (앰비언트 한 트랙으로 충분, 배경음 + 처치 SFX 우선)
- 안전지대 허브의 비주얼 폴리시
- 부상·트라우마·시간 흐름 시스템

### Scope Tiers (if budget/time shrinks)

| Tier | Content | Features | Timeline (solo) |
| ---- | ---- | ---- | ---- |
| **MVP** | 1맵, 1 NPC, 1 적, 1 무기 | 추출·호위·탈출 + 처치 손맛 | 4-6주 |
| **Vertical Slice** | 1맵, 3 NPC, 2 적, 2 무기, 안전지대 허브 | + 영구 동료 시스템 + 사연 1개 | 3-6개월 |
| **Alpha** | 2-3맵, 6 NPC, 3 적 | + 미션 변주 + UI 폴리시 + 손실 시스템 | 9-12개월 |
| **Full Vision** | 3-5맵, 6-10 NPC, 4 적 | 모두 + 폴리시 + 엔딩 분기 | 12-24개월+ |

---

## Next Steps

- [ ] (사용자 결정 — Lean 모드라 디렉터 게이트 스킵됨, 필요 시 수동 리뷰 가능)
- [ ] **`/setup-engine`** — UE5 + Blueprint/C++ 비율, Enhanced Input, Lumen/Nanite 설정, Megascans/MetaHuman 통합 등 프로젝트 셋업
- [ ] **`/art-bible`** — Visual Identity Anchor를 art bible로 확정
- [ ] **`/design-review design/gdd/game-concept.md`** — 컨셉 완성도 검증
- [ ] **`/map-systems`** — 컨셉을 시스템 단위로 분해 (호위 AI / 영구 동료 / 사연 / 추출
  미션 / 처치 / 안전지대 등)
- [ ] **`/design-system [first-system]`** — MVP 시스템부터 GDD 작성 (호위 AI 또는 추출
  미션이 1순위 후보)
- [ ] **`/create-architecture`** — 마스터 아키텍처 + Required ADR 리스트
- [ ] **`/architecture-decision (×N)`** — 기술 결정 ADR 작성
- [ ] **`/gate-check pre-production`** — Pre-production 진입 게이트
- [ ] **`/prototype extract-mission`** — 호위·추출 코어 루프 프로토타입
- [ ] **`/playtest-report`** — 코어 가설 검증
- [ ] **`/sprint-plan new`** — 첫 스프린트 계획

---

*이 문서는 `/brainstorm` 세션에서 사용자와의 협업으로 작성되었습니다. Visual Identity
Anchor와 디렉터 게이트 일부는 Lean 리뷰 모드에 따라 잠정이며, 후속 스킬(`/art-bible`,
`/design-review`)에서 확정·검증됩니다.*
