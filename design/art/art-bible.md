# Art Bible — Perfect Frame (가칭)

*Created: 2026-05-05*
*Status: Draft (Sections 1–4 in progress, Sections 5–9 deferred)*

---

## Section 1: Visual Identity Statement

### 1.1 One-Line Visual Rule

> **게임플레이 가독성이 허락하는 모든 픽셀을, 스텔라블레이드 수준의 사실적 시네마틱 리얼리즘에 쓴다.**

**사용법:** 비주얼 결정이 충돌할 때 이 문장을 적용한다.
- "더 극적인 라이팅을 쓰고 싶다" → 가독성이 침해되지 않으면 **써라**.
- "이 파티클이 멋지지만 위험 큐와 색이 겹친다" → 위험 큐가 이기므로 **파티클을 바꿔라**.
- "스타일라이즈드 아웃라인을 추가하면 캐릭터가 더 뚜렷해진다" → 사실적 PBR로 해결 가능한지 먼저 시도하라, 해결 안 되면 **가독성을 선택하되 PBR 톤을 유지하라**.

---

### 1.2 Visual Principles

#### Principle A: PBR First, Always
**연결 필라:** Pillar 1 — Input Fidelity Above All, Pillar 4 — Depth Over Breadth

모든 머티리얼 결정의 출발점은 물리 기반 렌더링(PBR)이다. 스타일라이즈드 처리(셀 셰이딩, 토툰 아웃라인, 과장된 스페큘러)는 PBR로 목표를 달성할 수 없을 때만 검토하며, 검토 결과도 반드시 "PBR 톤 안에서의 변형"이어야 한다.

**Design test:** 머티리얼 결정 앞에서 "이것이 실제 소재처럼 보이는가?"를 먼저 물어라. No라면 PBR 파라미터(Roughness, Metallic, Normal)를 먼저 조정하라. 조정으로 해결되면 스타일라이즈드 처리는 없다.

**솔로 파이프라인 적용:** Megascans + UE5 Substrate 머티리얼 레이어가 기본 소싱 경로다. 커스텀 텍스처 페인팅 없이 Megascans 에셋의 파라미터 조정만으로 목표를 달성한다.

---

#### Principle B: Cinematic Key Lighting — Gameplay Tells First
**연결 필라:** Pillar 1 — Input Fidelity Above All, Pillar 2 — Visible Mastery

캐릭터와 보스는 키 라이트와 환경 라이팅 대비로 배경에서 분리된다. **림 라이트는 표준 사용하지 않으며**, 실루엣 가독성은 환경 라이팅 톤 다운 + 보스 자체 머티리얼 콘트라스트로 확보한다. 라이팅은 시네마틱 카메라 앵글을 기준으로 설계하되, 위험 큐(빨강/노랑 텔)의 가독성이 훼손되는 경우 해당 라이팅 결정을 즉시 번복한다.

**Design test:** 라이팅 셋업 완료 후, 보스의 빨강/노랑 텔 이펙트를 화면에 트리거하라. 0.5초 내에 즉시 인식되지 않으면 라이팅을 조정하라 — 이펙트를 키우지 말고, **환경 라이팅을 낮춰라**.

**내부 긴장 해결:** 시네마틱 라이팅은 드라마틱한 섀도우(배경 어둠)를 만들고, 어두운 배경은 이론적으로 위험 큐를 돋보이게 한다. 그러나 어두운 환경에서 적 애니메이션의 "텔 모션 시작 위치"가 보스 실루엣에 묻힐 수 있다. 해결 원칙: 위험 큐 이펙트는 반드시 **자발광(Emissive) 레이어**로 구현하여 씬 라이팅에 독립적으로 항상 발광 상태를 유지한다. 라이팅 패스와 위험 큐 가독성 패스는 별개의 검증 체크리스트로 관리한다.

---

#### Principle C: Danger Tells — Absolute Screen Hierarchy
**연결 필라:** Pillar 1 — Input Fidelity Above All, Pillar 2 — Visible Mastery, Pillar 3 — Boss as Music

위험 큐(빨강 = 패링 불가 텔, 노랑 = 회피 전용 텔)는 화면 내 모든 색 중 가장 채도 높고 가장 밝은 단일 색으로 예약된다. 이 두 색은 환경 머티리얼, VFX, UI 어디에도 사용되지 않는다. 빨강/노랑이 비-위험 맥락에 등장하는 순간, 플레이어의 조건반사 학습이 오염된다.

**Design test:** 화면의 모든 요소(환경, 캐릭터, UI, VFX)를 동시에 활성화한 스크린샷에서 빨강/노랑 요소를 모두 찾아라. 위험 큐 외에 빨강/노랑이 발견되면 해당 에셋을 색 조정하라. 위험 큐는 항상 리스트의 첫 번째 찾힘이어야 한다.

**색 예약 목록 (draft):**
- `위험-패링불가`: Emissive Red — HSV(0°, 100%, 100%) 기준 ±10° 범위 예약
- `위험-회피전용`: Emissive Yellow — HSV(50°, 100%, 100%) 기준 ±15° 범위 예약
- 환경 머티리얼, 캐릭터 코스튬, 베타 게이지 UI는 이 범위를 회피한다

---

### 1.3 Internal Tensions — Known and Resolved

| 긴장 | 어느 원칙이 충돌하는가 | 해결 원칙 |
|------|----------------------|-----------|
| 시네마틱 섀도우 vs 텔 가독성 | Principle B vs Principle C | 위험 큐는 Emissive 자발광으로 라이팅 독립 처리. Principle C 우선. |
| 사실적 PBR vs 솔로 아트 비용 | Principle A vs 4~8주 스코프 | Megascans + Substrate 파라미터 튜닝으로 커스텀 페인팅 불필요. 사실 톤을 유지하되 에셋 소싱으로 비용 흡수. |

---

### 1.4 What This Direction Is Not

이 항목은 팀(현재 솔로)이 "비슷하지만 다른 방향"으로 표류하는 것을 방지하기 위해 명시한다.

- **NOT 셀 셰이딩 / 토툰** — 스타일라이즈드 아웃라인은 이 게임의 톤 밖이다
- **NOT 소울라이크 미학** — 탁하고 어두운 채도 억제 팔레트는 Pillar 2(Visible Mastery)와 충돌한다. 어둠은 배경만, 캐릭터는 채도 높은 디테일을 유지한다
- **NOT 파스텔 / 카툰 SFX** — 히트 이펙트, 패링 스파크, 베타 스킬 VFX는 사실적 물리 기반 비주얼이어야 한다
- **NOT 과잉 포스트 프로세싱** — 블룸·DOF·크로마틱 어버레이션은 시네마틱 톤 보조 수단이지 주인공이 아니다. 모든 PP 이펙트는 입력 프레임 타이밍을 시각적으로 왜곡하지 않아야 한다

---

### 1.5 Reference Anchors (Section 1 범위)

| 레퍼런스 | Section 1에서 취하는 것 |
|----------|------------------------|
| **Stellar Blade** | 사실적 PBR 머티리얼 밀도, 텔 색 예약 |
| **Metal Gear Rising** | 히트/콤보 VFX의 물리적 임팩트감 — 과장이 아닌 밀도로 |
| **Sekiro** | 위험 큐의 즉각 판독성 — 미학이 기능을 한 번도 이기지 않는다 |

---

## Section 2: Mood & Atmosphere

*Foundation: Section 1 위에 구축됨 — 모든 상태는 PBR First / Cinematic Key Lighting (No Rim Light) / Danger Tells Absolute Hierarchy를 계승한다.*

### 2.0 범용 전제 — 모든 상태에 적용

| 규칙 | 내용 |
|------|------|
| **Danger Tells 절대 우선** | 어느 상태에서든 빨강/노랑 Emissive 텔이 가장 먼저 눈에 들어와야 한다. 상태 전환으로 인한 라이팅·포스트 프로세스 변경이 텔 인식 시간을 늘리면 즉시 번복한다. |
| **Emissive 독립성 보장** | Danger Tells는 씬 Exposure·PP Vignette·Color Grading LUT 변화와 무관하게 항상 자발광 상태를 유지한다. |
| **포스트 프로세스 볼륨 전환 전용** | 상태 간 무드 전환은 Post Process Volume 블렌드·Directional Light 강도 보간·카메라 FOV 변경으로만 구현한다. 완전히 별개의 라이팅 셋업을 새로 굽지 않는다 (솔로 스코프 제약). |
| **모션 블러 상한** | 0.8을 절대 상한으로 고정한다. 텔 모션의 시작 자세가 블러로 묻히면 가독성이 무너진다. |

---

### 2.1 Encounter Intro
*전투 시작 전 3~5초, 카메라가 보스를 reveal하는 시퀀스*

| 항목 | 내용 |
|------|------|
| **Primary Emotion** | 경외(awe)와 측정하는 긴장감 — "이 존재를 넘어설 수 있는가"라는 질문이 생겨나는 순간 |
| **Lighting Character** | 차가운 중성 백색(6000~7000K) 키 라이트가 보스를 정면 위 45° 각도에서 조명. 환경 앰비언트는 극도로 낮아 보스가 반사·질감으로만 읽힌다. Auto-Exposure는 보스 표면 기준으로 잡혀 배경은 자동으로 언더노출. |
| **Atmospheric Descriptors** | 냉정한(cold) / 기념비적(monumental) / 정적인(still) / 고요한 위압감(silent menace) |
| **Energy Level** | Contemplative — 숨을 참는 순간 |
| **Concrete Visual Carrier** | DOF: 보스에 초점, 전·후경 f/2.8 상당 블러(UE5 PP DOF Aperture ~4.0). Intro 끝에 DOF를 0으로 0.5초 블렌드 아웃하여 전투 돌입 신호. |

---

### 2.2 Active Combat — Phase 1
*보스 HP 100% ~ 50%, 표준 패턴 사이클 — **이 상태가 모든 비주얼 결정의 "기준선"이다***

| 항목 | 내용 |
|------|------|
| **Primary Emotion** | 집중된 경계심(alert focus) — 패턴을 읽고 패링 타이밍을 계산하는 "날이 선 존재감" |
| **Lighting Character** | 따뜻한 중간 톤(4500~5000K) 키 라이트, 중간 콘트라스트. 환경은 짙은 청회색 앰비언트. Lumen GI로 아레나 바닥에 보스의 약한 반사. |
| **Atmospheric Descriptors** | 날카로운(sharp) / 선명한(crisp) / 집중된(focused) / 미세하게 긴장된(taut) |
| **Energy Level** | Measured — 리듬감 있는 결투 |
| **Concrete Visual Carrier** | Vignette 0.3, FOV 75°, CA 0.0, Motion Blur 0.4. **이 값들이 baseline — 이후 모든 상태는 이 기준에서 이탈하는 양으로 읽힌다.** |

---

### 2.3 Active Combat — Phase 2
*보스 HP 50% → 사망, 패턴 복잡도·속도 상승*

| 항목 | 내용 |
|------|------|
| **Primary Emotion** | 통제력을 유지하려는 긴박감(controlled urgency) — 위협이 커졌지만 무너지지 않는 집중 |
| **Lighting Character** | 키 라이트 색온도를 Phase 1보다 약 500K 낮춘다(4000~4500K). 환경 앰비언트를 Phase 1 대비 20% 낮춰 배경 디테일 추가 어둡게. 보스의 비-위험 기저 Emissive 머티리얼 파라미터를 15% 증폭. |
| **Atmospheric Descriptors** | 억압적인(oppressive) / 발열하는(burning) / 조여드는(closing in) / 폭풍 전야(pre-storm) |
| **Energy Level** | Frenetic |
| **Concrete Visual Carrier** | **Phase 1과의 카테고리적 차이**: Chromatic Aberration 0 → 0.25 활성화. FOV 75° → 72°. Motion Blur 0.4 → 0.6 (상한 0.8 미만). |

> **Mood Collision Risk (Phase 1 ↔ Phase 2):** 라이팅 변화가 Danger Tells 인식에 영향을 줄 수 있음. 해결: Tells는 Emissive 자발광이라 씬 앰비언트와 무관. **검증 항목: Phase 2 전환 직후 0.5초 내에 빨강 텔이 즉시 인식되는지 반드시 테스트.** PP Volume blend는 2.0초 권장.

---

### 2.4 Boss Stagger Window
*퍼펙트 패링/회피 연속 성공 → 보스 무방비 상태, ~3~5초 폭딜 윈도우*

| 항목 | 내용 |
|------|------|
| **Primary Emotion** | 지배(dominance)와 카타르시스 폭발 직전 — "내가 만들어낸 이 틈" |
| **Lighting Character** | **씬 라이팅 변경 없음.** 보스 머티리얼만 국소 변화: 보스 기저 Emissive 급격 하락(취약한 표정), 보스 전용 Directional Light 강도 +10% (보스 표면이 "열린" 질감). |
| **Atmospheric Descriptors** | 폭발 직전의(charged) / 순간 포착된(suspended) / 지배하는(commanding) / 밀도 높은(dense) |
| **Energy Level** | Explosive (정지 직전의 폭발) |
| **Concrete Visual Carrier** | Time Scale 0.7 (Stagger 진입 순간 0.3초 슬로우 → 즉시 정상 복귀). 0.3초 동안 카메라 FOV 75° → 70° pull (시네마틱 줌인). |

> **Mood Collision Risk (Stagger ↔ Tells):** Stagger 상태에서 보스가 Stagger Break 이전 패턴을 발동하는 경우, Tells가 보스의 저채도 Emissive와 혼동될 수 있음. 해결: **Stagger 상태에서 보스 비-위험 Emissive 강도를 낮출 때, Tells Emissive 채널은 별도 파라미터로 격리하여 100% 강도 유지.**

---

### 2.5 Beta Skill Burst
*플레이어 베타 스킬 발동 — 카타르시스 정점, 슬로우모션*

| 항목 | 내용 |
|------|------|
| **Primary Emotion** | 능동적 카타르시스(active catharsis) — "내가 쌓아온 게이지를 지금 터뜨린다" |
| **Lighting Character** | **씬 전체 라이팅 변경 없음** (Tells 안전). Beta VFX 자체의 Emissive 밀도가 씬을 채움: 청백색(HSV 200°~220°) Emissive 파티클 폭발적 방출, 보스 주변 2~3m 순간적 Lumen GI. **이 색은 Tells(0°/50°)로부터 최소 150° 이상 분리된 색상대.** |
| **Atmospheric Descriptors** | 폭발적인(explosive) / 숨막히는(breathtaking) / 능동적인(assertive) / 순간적인(instantaneous) / 해방된(released) |
| **Energy Level** | Explosive — 게임 내 최고 에너지 |
| **Concrete Visual Carrier** | 발동 직후 0.2초 Time Scale 0.1(거의 정지) → 0.5초 ease-in 복귀. PP Volume에서 Bloom Intensity 1.5 → 3.0 순간 증폭 후 0.3초 안에 기준선 복귀. |

> **Mood Collision Risk (Beta Burst ↔ Tells) — 게임 디자인 의존:** **베타 스킬 발동 중 보스 경직(Hit Stun) 보장**으로 Tells 발동 자체를 막는다 (Stellar Blade와 동일). 이 가정이 깨질 경우, VFX 파티클 Emissive 강도를 즉각 40% 감소시키는 Material Parameter Collection 연동이 기술 요구사항.

---

### 2.6 Victory
*보스 사망, ~5~10초 아웃트로*

| 항목 | 내용 |
|------|------|
| **Primary Emotion** | 정화된 고요함(cathartic stillness) — "내가 해냈다"는 단순하고 강한 감각 |
| **Lighting Character** | Directional Light 색온도 +200~300K (더 차갑고 깨끗한), 강도 +10%. 환경 앰비언트 Phase 1 대비 +30%. **이 밝음이 "위협이 사라졌다"는 신호.** |
| **Atmospheric Descriptors** | 고요한(serene) / 열린(open) / 깨끗한(clean) / 무게가 빠진(weightless) |
| **Energy Level** | Contemplative |
| **Concrete Visual Carrier** | Vignette 0.4 → 0.0 (3초 페이드). CA 0.25 → 0.0 즉시 제거. FOV 72° → 80° (5초 확대). |

---

### 2.7 Defeat / Retry
*플레이어 사망 → 즉시 재시도(≤2초 로딩)*

| 항목 | 내용 |
|------|------|
| **Primary Emotion** | 날카로운 재점화(sharp re-ignition) — 좌절이 아니라 "다시"라는 즉각적 의지 |
| **Lighting Character** | 사망 순간: Desaturation 0 → 0.6 (0.3초), Exposure -0.5 stops. 그레이스케일 근접 0.3초 = "죽음의 프레임". 재시도 복귀: Desaturation/Exposure를 Phase 1 기준값으로 0.1초 컷-복구. **페이드인 없이 즉각 복귀.** |
| **Atmospheric Descriptors** | 즉각적인(immediate) / 차가운(cold) / 선명한(snapping back) |
| **Energy Level** | Suspended → Instant Reset |
| **Concrete Visual Carrier** | 사망 프레임 FOV +5° 순간 확장 후 Desaturation과 함께 0.3초 안에 암전. 암전-복귀: 검은 화면 0.5초 → Phase 1 장면 즉시 풀 컷(크로스페이드 없음). **"죽음을 드라마화하지 않는다."** |

> **Mood Collision Risk (Defeat Desaturation ↔ Tells) — 의도된 동작:** Desaturation은 사망 판정(HP=0) 이후 1프레임 딜레이로 시작하여 마지막 텔(나를 죽인 공격)이 색으로 완전히 인식된 후 시작.

---

### 2.8 State Transition Summary

| From → To | 전환 신호 | 전환 시간 | 핵심 변화 |
|-----------|----------|-----------|-----------|
| Intro → Phase 1 | DOF 페이드 아웃 | 0.5초 | DOF 제거, Vignette 0.3 활성 |
| Phase 1 → Phase 2 | 보스 HP 50% | 2.0초 blend | 색온도 -500K, 앰비언트 -20%, CA +0.25, FOV -3° |
| Phase 1/2 → Stagger | 스태거 게이지 만료 | 즉시(0.3초 슬로우) | Time Scale 0.7→1.0, FOV -5° pull |
| Any → Beta Burst | 베타 스킬 입력 | 0.2초 슬로우 | Bloom ×2.0 순간 증폭 후 0.3초 복귀 |
| Any → Victory | 보스 HP=0 | 3.0초 blend | Vignette 0, CA 0, FOV +8°, 앰비언트 +30% |
| Any → Defeat | 플레이어 HP=0 | 0.3초 | Desaturation +0.6, Exposure -0.5, 암전 |
| Defeat → Phase 1 | 로딩 완료 | 즉각 컷 | 모든 PP값 Phase 1 기준값으로 즉시 복귀 |

---

### 2.9 Section 2 Reference Anchors

| 레퍼런스 | Section 2에서 취하는 것 |
|----------|------------------------|
| **Stellar Blade** | 페이즈 전환 시각적 온도 변화, 베타 스킬 슬로우 + Bloom 처리 |
| **Sekiro** | Stagger 순간의 "멈추는" 에너지, 사망의 빠르고 드라마 없는 처리 |
| **Furi** | 결투 리듬감 — Phase 1이 "호흡 맞추는 시간" |
| **Metal Gear Rising** | Beta Burst의 능동적 카타르시스 — 블레이드 모드의 "내가 폭발시킨다" 주체성 |

---

## Section 3: Shape Language

*Foundation: Section 1·2 위에 구축됨. 모든 형태 원칙은 해당 Section의 제약을 계승한다.*

### 3.0 형태 언어의 역할 분리

이 게임에서 형태(shape)는 세 계층을 가진다.

| 계층 | 구성 | 형태의 역할 |
|------|------|-------------|
| **Hero** | 플레이어, 보스, Danger Tells | 주의를 능동적으로 이끌고 의사결정을 유발 |
| **Functional** | HUD 게이지 | 마스터리 상태를 정직하게 반영 |
| **Supporting** | 아레나 환경 | Hero가 읽히도록 배경으로 물러남 |

**운용 원칙:** "내가 지금 추가하려는 형태는 어느 계층인가?"를 매번 물어라. Supporting이 우연히 Hero 계층의 시각 복잡도를 얻는 순간, 그것이 가독성 붕괴의 시작이다.

---

### 3.1 캐릭터 실루엣 철학
**연결 필라:** Pillar 1 — Input Fidelity / Pillar 2 — Visible Mastery

#### 설계 목표
플레이어와 보스는 화면 높이 1cm 썸네일에서도 — 색·머티리얼이 읽히기 전에 — 즉시 다른 카테고리로 인식되어야 한다. 이건 미학이 아니라 **Pillar 1의 기능 요구사항**이다.

#### 플레이어 캐릭터 — 수직 경량 삼각형 (Vertical Taper)
- 어깨 너비 ≤ 골반, 머리에서 발끝까지 균일한 수직 라인
- 사지 형태 단순. 망토·과대 패드·볼륨 큰 어깨 장갑 금지
- **angle-invariant 구분 특성**: **머리 위에서 끝나는 깔끔한 상단 실루엣 라인** (조용한 상단). 엔진·뿔·거대 어깨 장갑 없음
- **감정**: "인간-스케일의 숙련자" — 거대하지 않아도 위협적이고 빠를 것이라는 예고

#### 보스 — 비대칭 수평 질량 (Asymmetric Horizontal Mass)
- 가로 실루엣이 플레이어의 2~3배 이상
- **비대칭이 핵심**: 좌우 완전 대칭 보스는 "정적 조형물"로 읽힘. 비대칭 무기·갑옷·신체가 "이 존재는 나의 언어로 설계되지 않았다"는 이질감 생성
- **angle-invariant 구분 특성**: **불규칙 상단 실루엣(irregular crown)** — 돌출·함몰이 섞인 상단. 플레이어의 조용한 상단과 정반대. 정면/측면/배면 모두에서 유효
- **감정**: 크기 압도가 아닌 **이질성의 압도** — Section 2.1 Encounter Intro와 직결

#### 실루엣 충돌 방지 규칙

| 금지 | 이유 |
|------|------|
| 플레이어에 망토·날개·헬름 | 상단 라인 복잡화 → 보스와 구분 특성 충돌 |
| 보스 좌우 완전 대칭 | 이질감 제거 → 위협 감소 |
| 보스에 수직-경량 비율 적용 | 두 실루엣 카테고리 병합 |

---

### 3.2 환경 지오메트리
**연결 필라:** Pillar 4 — Depth Over Breadth / Pillar 1 — Input Fidelity

#### 주도 형태: 수평 직선 + 완만한 곡면 (Horizontal Planar with Gradual Curves)

- **바닥**: 거의 완전한 수평 평면 또는 10° 이내 기울기. 이동성·텔 시야선 최우선
- **벽**: 낮은 곡률 아치 또는 완만한 경사면. 직각 코너 최소화 (보스 모션과 silhouette merge 방지)
- **천장/돔**: 완만한 돔 또는 열린 하늘. 보스 상단 실루엣이 단순한 배경 면에 대비되도록

**왜 이 형태인가**: 보스의 비대칭·불규칙 실루엣이 배경과 병합되지 않으려면, 배경은 **예측 가능하고 반복적**이어야 한다 (게슈탈트 연속성). 직선·완만한 곡면은 눈이 "이건 배경이다"로 빠르게 패턴 처리.

#### 금지 형태 — False Cue 방지

| 금지 | 이유 |
|------|------|
| 빨강·노랑 색조 환경 소재 (화산암, 녹슨 금속) | Danger Tells 색 예약 침범 |
| 보스 공격 모션과 같은 방향의 환경 요소 (가로 빔, 스윙 체인) | 정적 환경이 텔의 False Cue로 작동 → 조건반사 학습 오염 |
| 보스 크기에 근접하는 대형 환경 오브젝트 | Hero/Supporting 크기 경쟁 |
| 수직으로 날카로운 지형 돌출 (첨탑, 솟은 기둥 군집) | 보스 비규칙 상단과 시각 간섭 |

#### 솔로 스코프 적용
- **기본 접근**: UE5 Modeling Tools + Megascans 모듈러 키트(Cathedral/Arena 계열)
- **선호**: 실내 석조 홀 또는 열린 광장형 키트
- **금지**: bespoke hand-sculpted 지오메트리 (스코프 이탈)

---

### 3.3 UI 형태 문법
**연결 필라:** Pillar 2 — Visible Mastery / Pillar 1 — Input Fidelity

#### HUD 구성: Player HP / Beta Gauge / Boss HP·Stagger Gauge

(Diegetic vs Screen-Space 배치는 Section 7에서 확정. 이 섹션은 게이지 형태 자체를 정의.)

#### 게이지 형태 원칙 — Visible Mastery 구현

게이지는 단순 수치 막대가 아니라 **마스터리 상태를 형태로 전달**해야 한다.

**베타 게이지 — 분절형 선형 (Segmented Linear)**
- 연속 막대가 아닌 2~3개 개별 세그먼트 (각 = 베타 스킬 1회 발동 단위)
- 빈 세그먼트 = 어두운 홈 / 찬 세그먼트 = 빛나는 채색
- **이유**: "1.5칸 채워짐"이 "45%"보다 마스터리 상태를 직접 전달. 세그먼트 단위 피드백이 패링·회피 성공과 직결

**스태거 게이지 — 아크형 (Arc/Ring)**
- 보스 스태거는 선형이 아닌 아크(반원 또는 원호)
- 아크가 닫힐수록 "포위" 시각적 긴장 증가. 완성 직전 = 보스를 시각적으로 에워싸는 경험
- **이유**: 선형 = "진행률" / 아크 = "닫힘" — 압박·지배 감각 강화. Pillar 2의 "5연속 패링이 30배 임팩트"를 형태로 지지

**플레이어 HP — 단순 선형 (Plain Linear)**
- HP는 의사결정 정보. 마스터리 표현 불필요한 유일한 게이지
- 장식 최소화 → 베타·스태거와 역할 구분

**보스 HP — 페이즈 분절형 (Phase-Segmented)**
- 50% 페이즈 전환 지점에서 시각적 구획 (페이즈 구획선 물리적 표시)
- "지금 어느 페이즈인가" 즉시 읽힘
- Pillar 3 (Boss as Music) 지지: "악보의 어느 절을 연주하는가"

#### UI 형태 vs 세계 형태
- 아레나 = 완만한 곡면·수평 직선 (자연·건축적)
- UI 게이지 = 기하학적 정밀 직선·원호 (인공·추상)
- **PBR 머티리얼을 쓰지 않는 유일한 영역** — UI는 물질이 아닌 정보
- 단, 모서리는 미세한 rounded corner (~2~4px) — 완전 직각 금지, 세계와의 최소 연결

---

### 3.4 Hero vs Supporting — 오염 방지 규칙
**연결 필라:** Pillar 1 — Input Fidelity / Pillar 4 — Depth Over Breadth

#### Supporting이 Hero를 오염하는 메커니즘
1. **형태 복잡도 경쟁**: 아레나 디테일이 풍부해서 보스 실루엣 분리 실패
2. **색 경쟁**: 환경이 Danger Tells 색 침범 (Section 1.2 Principle C에서 해결)
3. **크기 경쟁**: 환경 단일 오브젝트가 보스에 근접 → 크기 계층 붕괴

#### Supporting 형태 상한

| 규칙 | 구체 기준 |
|------|----------|
| **크기 상한** | 단일 환경 오브젝트 높이 ≤ 보스 전체 높이의 40% |
| **형태 복잡도 상한** | 환경 오브젝트 실루엣 꺾임 수(convex hull 근사) ≤ 보스 실루엣 |
| **명도 상한** | 아레나 표면 최대 명도 < 보스 머티리얼 평균 명도 (환경은 보스보다 어둡다) |
| **Emissive 금지** | 환경 Emissive 머티리얼 금지. 단 기능적 조명 오브젝트는 예외이나 색은 Danger Tells 회피 필수 |

#### Danger Tells의 형태적 위상
- 형태 = 보스 실루엣 일부에 부착된 **Emissive 레이어**. 별도 HUD가 아닌 보스 몸에서 자라남
- **위치 의도**: 시선이 이미 보스를 추적 중인 상태에서 같은 시선 범위에서 텔 활성화 → 시선 이동 거리 최소화 (Pillar 1)
- **형태 언어**: 보스 유기적 비대칭 형태와 대비되는 **기하학적 규칙 형태** (방사형 Emissive 버스트 또는 맥동 원형 하이라이트)

---

### 3.5 Section 3 형태 원칙 요약

| 원칙 | 대상 | 핵심 형태 | 연결 필라 | 감정 |
|------|------|---------|----------|------|
| 수직 경량 실루엣 | 플레이어 | 날렵한 수직 라인, 조용한 상단 | P1, P2 | 인간-스케일 숙련자 |
| 비대칭 수평 질량 | 보스 | 거대한 좌우 비대칭 + 불규칙 상단 | P1, P3 | 이질적 위협 |
| 수평 플레이 평면 | 아레나 | 수평·완만한 곡면, 복잡도 억제 | P1, P4 | 전투에 집중하는 무대 |
| 분절형 베타 게이지 | HUD | 개별 세그먼트 청크 | P2 | 마스터리 현재 상태 |
| 아크형 스태거 게이지 | HUD | 닫히는 원호 | P2, P3 | 보스를 포위하는 압박 |
| Emissive 기하 텔 | Danger Tells | 규칙적 방사형/원형 | P1 | "즉각 반응해야 하는 신호" |

---

### 3.6 Section 3 Reference Anchors

| 레퍼런스 | Section 3에서 취하는 것 |
|----------|------------------------|
| **Stellar Blade** | 플레이어 캐릭터의 날렵한 수직 실루엣 비율, UI 게이지의 절제된 선형 처리 |
| **Elden Ring** | 보스 비대칭 질량 실루엣 — 거대 무기·비정형 갑옷이 만드는 이질감 |
| **Sekiro** | 스태거(체간) 게이지 형태 언어 — "차오르는 압박"의 원형적 구현 |
| **Furi** | 단일 아레나 환경이 보스와 경쟁하지 않는 방법 — 아레나가 배경으로 완전히 물러남 |

---

## Section 4: Color System

*Foundation: Sections 1·2·3 위에 구축됨. 모든 색 결정은 Danger Tells 절대 예약(Principle C)을 계승한다.*

### 4.0 색 시스템의 역할

세 가지 문제를 동시에 해결한다.
1. **가독성**: Danger Tells를 게임 내 모든 색으로부터 격리
2. **감정**: 각 전투 상태(Section 2) 무드를 색온도로 강화
3. **접근성**: 핵심 메커닉이 색각 이상 플레이어에게 붕괴하지 않도록 보조 큐 내장

**운용 원칙**: "이 색이 화면에서 무엇을 의미하는가?"를 항상 먼저 물어라. 색은 장식이 아닌 신호다.

---

### 4.1 Primary Palette — 7색

모든 색은 Megascans 머티리얼 파라미터 재색조 + Material Parameter Collection(MPC)으로 구현 가능한 범위.

| # | 이름 | HSV | HEX | 역할 | 연결 필라 |
|---|------|-----|-----|------|----------|
| 1 | **Arena Stone** | H 215°, S 10%, V 22% | `#2E3238` | 환경 베이스 (90%+) — 어두운 청회색. 채도 +30% 이상 금지 (MPC 상한) | P1, P4 |
| 2 | **Forge Amber** | H 30°, S 60%, V 45% | `#7A5520` | 환경 액센트 (10% 미만) — 화로·금속 장식. Tells 예약 사이 틈새(20°~35°). Emissive 채널 사용 금지 | P3 |
| 3 | **Edge Platinum** | H 220°, S 15%, V 85% | `#C8CDD6` | 플레이어 갑옷·무기 PBR 하이라이트. 림 라이트 없이 실루엣 분리 | P1, P2 |
| 4 | **Obsidian Depth** | H 270°, S 25%, V 12% | `#1A1520` | 보스 베이스 (80%) — 어둠의 보라. 인간 문법 반대편 색역 | P3, P1 |
| 5 | **Crimson Unblockable** | H 0°, S 100%, V 100% | `#FF0000` | **Danger Tell — 패링 불가**. 보스 Emissive 전용. **예약 범위: H 350°~10°, S 80%+, V 80%+** | P1 |
| 6 | **Amber Warning** | H 50°, S 100%, V 100% | `#FFD700` | **Danger Tell — 회피 전용**. 보스 Emissive 전용. **예약 범위: H 35°~65°, S 80%+, V 80%+** | P1 |
| 7 | **Stellar Cyan** | H 210°, S 90%, V 100% | `#0099FF` | Beta VFX, 퍼펙트 패링 플래시, 베타 게이지 충전 파티클. Tells와 양방향 150°+ 분리 | P2, P1 |

---

### 4.2 Semantic Color Usage Table

| 색 이름 | 의미 | 허용 맥락 | 금지 맥락 |
|---------|------|----------|----------|
| **Crimson Unblockable** | "패링 불가 — 회피 또는 방어" | 보스 Tell Emissive만 | HP 게이지, 환경, UI 아이콘, 히트 임팩트 |
| **Amber Warning** | "회피 전용 — 패링해도 데미지" | 보스 Tell Emissive만 | 베타 게이지, 보상 연출, 환경 조명 |
| **Stellar Cyan** | "베타 에너지 / 퍼펙트 패링 / 플레이어 능동 파워" | Beta VFX, 퍼펙트 패링 플래시, 베타 게이지 충전 | 보스 공격 연출, 환경 발광 |
| **Edge Platinum** | "플레이어 현존 / 금속 스페큘러" | 플레이어 PBR 하이라이트만 | 보스 머티리얼, UI 텍스트, 환경 |
| **HP White** (H 0°, S 0%, V 95%) | "남은 체력" | 플레이어 HP 게이지 필 | 보스 HP, 베타 게이지 |
| **Stagger Violet** (H 275°, S 70%, V 80%) | "스태거 압박 누적 — 보스를 포위하는 힘" | 스태거 게이지 UI만 (월드 VFX 확장 안 함) | 환경, 플레이어 능력 VFX, 보스 Tell |
| **Boss HP Ash** (H 0°, S 0%, V 55%) | "남은 위협" — 무채색 유지 (그라디언트 없음) | 보스 HP 게이지 필만 | 플레이어 HP, 베타 게이지 |
| **Hit Red (Differentiated)** (H 0°, S 70%, V 60%, opacity 60%) | "내가 맞았다" — Tell 색역(S 100%/V 100%)과 구분 | 플레이어 피격 화면 엣지 비네트만, 0.2초 fade | 화면 전체 페인트, 보스 Tell, 환경 |

**예약 색 범위 요약:**

| 범위 | 이유 |
|------|------|
| H 350°~10°, S 80%+, V 80%+ | Crimson Unblockable Tell 전용 |
| H 35°~65°, S 80%+, V 80%+ | Amber Warning Tell 전용 |
| H 35°~65°, S 30%+, V 85%+ | Forge Amber와 Tell 사이 완충 (환경 채도 상한) |

---

### 4.3 Per-State Color Temperature Map

| 상태 | 키 라이트 색온도 | 환경 앰비언트 | 지배적 색 편향 | 감정 |
|------|----------------|-------------|--------------|------|
| **Encounter Intro** | 6000~7000K (차가운 백) | 극저 | 중성 청백 | 냉정한 측정 |
| **Phase 1** (기준선) | 4500~5000K (따뜻한 중간) | 짙은 청회색 | 따뜻한 중성 | 날카로운 집중 |
| **Phase 2** | 4000~4500K (-500K) | -20% | 더 차가운 중성 | 조여드는 긴박감 |
| **Stagger Window** | Phase 1/2 유지 | 변화 없음 | 변화 없음 | 지배 (슬로우+줌으로 전달) |
| **Beta Burst** | 씬 변경 없음 | Stellar Cyan Emissive 채움 | 청백 폭발 | 능동적 해방 |
| **Victory** | +200~300K (깨끗) | +30% (밝아짐) | 중성 청백 | 정화된 고요 |
| **Defeat** | Desaturation 0.6 | -0.5 EV | 무채색 수렴 | 즉각 리셋 |

**색온도 진행 호**: 차가움(측정) → 따뜻함(집중) → 차가움(압박) → 깨끗한 차가움(해방). Beta Burst만 색온도 축이 아닌 VFX Emissive 색 축.

---

### 4.4 UI Palette

UI는 세계와 시각적으로 구분되되 지배하지 않는다. UI는 PBR 물질이 아닌 정보(Section 3.3).

**제약**: Tells 예약 침범 불가 / Arena Stone(V 22%)보다 밝아야 / Tells Emissive(V 100%)보다 어두워야 → **중간 밝기(V 60%~85%) 저~중채도** 영역 사용.

| UI 요소 | 색 이름 | HSV | HEX | 설명 |
|---------|---------|-----|-----|------|
| 플레이어 HP 필 | HP White | H 0°, S 0%, V 90% | `#E6E6E6` | 무채색. 양(길이)으로만 읽힘 |
| 플레이어 HP 배경 | HP Trough | H 0°, S 0%, V 20% | `#333333` | Arena Stone보다 약간 밝은 회색 |
| 베타 게이지 필 | Beta Cyan Fill | H 210°, S 85%, V 90% | `#16AEFF` | Stellar Cyan과 동일 색상. 세그먼트 단위 |
| 베타 게이지 빈 | Beta Empty | H 210°, S 20%, V 25% | `#313A40` | 어두운 청회색 홈 |
| 스태거 게이지 필 | Stagger Violet | H 275°, S 70%, V 80% | `#8F2ECC` | 보스 색역(H 270°)과 친족, "쌓이는 압박" |
| 스태거 완성 플래시 | Stagger Burst | H 275°, S 90%, V 100% | `#AA00FF` | 1~2프레임 순간 플래시 |
| 보스 HP 필 | Boss HP Ash | H 0°, S 0%, V 50% | `#808080` | **무채색 회색 유지 (그라디언트 없음)** |
| 보스 HP 페이즈 구획선 | Phase Divider | H 0°, S 0%, V 70% | `#B3B3B3` | 50% 페이즈 전환 표시 |
| UI 텍스트 (튜토리얼) | HUD Text | H 220°, S 5%, V 95% | `#EFF0F5` | 거의 흰색 약한 청기 |
| 플레이어 피격 비네트 | Hit Red (Diff) | H 0°, S 70%, V 60%, opacity 60% | `#993030` 60% | **Tell 색역과 차별화된 빨강**. 화면 엣지만, 0.2초 fade. 채도/명도 분리로 Tell 학습과 분리 |

---

### 4.5 퍼펙트 패링 성공 플래시 — 강렬 전화면 (Stellar Blade 레퍼런스)

Pillar 2 ("5연속 = 30~50배 임팩트")의 핵심 시각 구현.

| 입력 강도 | 플래시 처리 |
|----------|-----------|
| **단발 퍼펙트 패링** | 보스 접촉점 Cyan 스파크 + 화면 전체 약한 Cyan 림 (Stellar Cyan, opacity 30%, 0.15초) + Bloom Intensity 1.5 → 2.0 순간 증폭 |
| **3연속 퍼펙트 패링** | 위 + 화면 전체 Cyan 비네트 강화 (opacity 50%, 0.25초) + Bloom 2.5 |
| **5연속+ 퍼펙트 패링** | **전화면 Cyan 폭발 플래시** (opacity 80%, 0.4초) + Bloom 3.5 + Time Scale 0.6 (0.2초 슬로우) + 전용 SFX 폭발음 — 마스터리 카타르시스 정점 |
| **7연속+ 퍼펙트 패링** | 5연속 처리 + 카메라 셰이크 0.5 + Niagara 폭죽형 Cyan 입자 폭발 — "스텔라블레이드 7연속 패링" 그 순간을 직접 재현 |

**기하급수적 보상 곡선**: 1→3→5→7 연쇄가 각각 카테고리적으로 다른 시각 사건. Pillar 2 Design Test의 "선형 아닌 기하급수" 요구를 색·강도·시간 모두에서 명시적으로 구현.

---

### 4.6 Colorblind Safety — 4채널 동시 신호

**선택 사항이 아니다.** 이 게임 핵심 메커닉이 Red vs Yellow 구분에 절대 의존. 색각 이상 남성 ~8% 영향.

#### 색 쌍 충돌 분석

| 색 쌍 | 정상 | Deuter/Protan-opia | Tritanopia | Achromatopsia |
|-------|------|-------------------|------------|---------------|
| Crimson vs Amber Warning (핵심) | 즉각 구분 | **충돌 위험 높음** | 안전 | **완전 붕괴** |
| Stellar Cyan vs Tells | 즉각 구분 | 안전 | **Cyan 왜곡 가능** | 붕괴 |

#### 4채널 백업 — 모든 Tell은 색 + 형태 + 모션 + 오디오로 동시 신호

| 채널 | Crimson Unblockable | Amber Warning |
|------|---------------------|---------------|
| **색** | 빨강 H 0° Emissive | 노랑 H 50° Emissive |
| **형태** | **방사형 폭발 버스트(별형)** — Section 3.4 "기하학적 규칙 형태" | **맥동 원형 (닫히는 원호)** |
| **모션 패턴** | 단발 빠른 플래시 (0.1초 ON-OFF, 단속적) | 느린 맥동 (0.5초 주기 팽창-수축, 지속적) |
| **오디오** | 날카로운 금속 고음 틱 (전자음) | 낮은 드럼 울림 (유기음) — 음색·주파수 대역 분리 |
| **화면 엣지 인디케이터** | 뾰족한 화살표(↑) | 둥근 원형 테두리(○) |

**핵심 원칙**: 보조 큐는 "접근성 옵션"이 아닌 **기본 설계에 내장**. 색각 정상 플레이어도 형태·오디오 차이를 인식하면서 게임플레이 가독성이 전반적으로 향상됨.

#### MVP 필수 백업 큐

| 우선순위 | 항목 | 비용 | MVP 필수 |
|---------|------|------|---------|
| 1 | Tell 형태 차이 (방사형 vs 맥동 원호) | 낮음 (Niagara 파라미터) | ✅ |
| 2 | Tell 오디오 음색 차이 | 낮음 (SFX 2종) | ✅ |
| 3 | 화면 엣지 방향 인디케이터 형태 | 중 (UMG 위젯) | 권장 |
| 4 | 피격 비네트 차별화된 빨강 | 낮음 | ✅ (이미 반영) |

---

### 4.7 Section 4 색 결정 참조 요약

| 결정 | 근거 |
|------|------|
| 환경 베이스 청회색(H 215°) 저명도 | Tells 대비 최대화 + 보스 명도 계층 확보 |
| 환경 액센트 H 30° 저채도 | Tells 예약 사이 틈새 |
| 플레이어 액센트 Edge Platinum (저채도 고명도) | 림 없이 배경 분리, Tells와 채도 85p 분리 |
| 보스 베이스 H 270° 극저명도 보라 | Tells 대비 최대화, 인간 문법 반대 색역 |
| Beta VFX H 210° | Tells와 양방향 150°+ 분리 |
| Stagger UI 색을 H 275° 보라로 (게이지 한정) | 보스 색역과 친족 → "보스에 쌓이는 힘" 의미 연결 |
| 피격 비네트 차별화된 빨강 (H 0°, S 70%, V 60%) | Tell 색역(S 100%, V 100%)과 채도·명도 분리. Tell 학습 보호 |
| 퍼펙트 패링 1→3→5→7 카테고리 시각 차등 | Pillar 2 "기하급수 보상" 직접 구현 |
| Boss HP 무채색 (그라디언트 없음) | HP가 자체적 주의 끌지 않음. 시선은 보스·Tells에 집중 |
| Tell Backup Cue 4채널 동시 신호 | 색각 이상 ~8% 대응 + 정상 시야 가독성 향상 |

---

### 4.8 Section 4 Reference Anchors

| 레퍼런스 | Section 4에서 취하는 것 |
|----------|------------------------|
| **Stellar Blade** | Beta 청백색 언어, 퍼펙트 패링 강렬 전화면 플래시, 전투 상태별 색온도 변화 |
| **Sekiro** | Tell 색 예약 원칙 — 위험 큐만이 그 색을 독점 |
| **Hades** | UI 게이지 색이 세계 팔레트와 공명하되 구분 (Stagger Violet → Obsidian 색역 연결) |
| **Microsoft Inclusive Design Guidelines** | Colorblind 백업 큐 — 색에만 의존하는 신호는 만들지 않는다 |
