# Unreal Engine — Version Reference

| Field | Value |
|-------|-------|
| **Engine Version** | Unreal Engine 5.7 |
| **Release Date** | December 2025 |
| **Project Pinned** | 2026-05-04 |
| **Last Docs Verified** | 2026-05-04 |
| **LLM Knowledge Cutoff** | January 2026 (approximate) |
| **Risk Level** | HIGH — multiple post-cutoff versions |

## Knowledge Gap Warning

The LLM's training data likely covers Unreal Engine up to ~5.3. Versions 5.4, 5.5,
5.6, and 5.7 introduced significant changes that the model does NOT know about.
Always cross-reference this directory before suggesting Unreal API calls.

## Post-Cutoff Version Timeline

| Version | Release | Risk Level | Key Theme |
|---------|---------|------------|-----------|
| 5.4 | April 2024 | MEDIUM | Animator UI, Motion Matching, Mover prototype, rendering perf |
| 5.5 | November 2024 | HIGH | Animation authoring overhaul, Megalights, ICVFX production, Mover beta |
| 5.6 | June 2025 | HIGH | Open-world 60Hz, unified animation pipeline (no more nativization), new templates |
| 5.7 | December 2025 | HIGH | Substrate/PCG production, Nanite Foliage, Linux SDL2→SDL3, EOS default Offline |

## Hotfix Tracking

UE 5.7 has hotfixes (5.7.1, 5.7.2, 5.7.3, 5.7.4 as of pin date). Use the
latest hotfix for stability. Hotfix changes do not affect API surface and do
not require this VERSION.md update.

## Major Changes from UE 5.3 to UE 5.7

### Breaking Changes
- **Substrate Material System**: New material framework (replaces legacy materials)
- **PCG (Procedural Content Generation)**: Production-ready, major API changes
- **Megalights**: New lighting system (millions of dynamic lights)
- **Animation Authoring**: New rigging and animation tools
- **AI Assistant**: In-editor AI guidance (experimental)

### New Features (Post-Cutoff)
- **Megalights**: Dynamic lighting at massive scale (millions of lights)
- **Substrate Materials**: Production-ready modular material system
- **PCG Framework**: Procedural world generation (production-ready in 5.7)
- **Enhanced Virtual Production**: MetaHuman integration, deeper VP workflows
- **Animation Improvements**: Better rigging, blending, procedural animation
- **AI Assistant**: In-editor AI help (experimental)

### Deprecated Systems
- **Legacy Material System**: Migrate to Substrate for new projects
- **Old PCG API**: Use new production-ready PCG API (5.7+)

## Verified Sources

- Official docs: https://docs.unrealengine.com/5.7/
- UE 5.7 release notes: https://dev.epicgames.com/documentation/en-us/unreal-engine/unreal-engine-5-7-release-notes
- What's new in 5.7: https://dev.epicgames.com/documentation/en-us/unreal-engine/whats-new
- UE 5.7 announcement: https://www.unrealengine.com/en-US/news/unreal-engine-5-7-is-now-available
- UE 5.5 blog: https://www.unrealengine.com/en-US/blog/unreal-engine-5-5-is-now-available
- Migration guides: https://docs.unrealengine.com/5.7/en-US/upgrading-projects/
