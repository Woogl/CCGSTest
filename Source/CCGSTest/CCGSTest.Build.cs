// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class CCGSTest : ModuleRules
{
	public CCGSTest(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"AIModule",
			"StateTreeModule",
			"GameplayStateTreeModule",
			"UMG",
			"Slate"
		});

		PrivateDependencyModuleNames.AddRange(new string[] { });

		PublicIncludePaths.AddRange(new string[] {
			"CCGSTest",
			"CCGSTest/Variant_Platforming",
			"CCGSTest/Variant_Platforming/Animation",
			"CCGSTest/Variant_Combat",
			"CCGSTest/Variant_Combat/AI",
			"CCGSTest/Variant_Combat/Animation",
			"CCGSTest/Variant_Combat/Gameplay",
			"CCGSTest/Variant_Combat/Interfaces",
			"CCGSTest/Variant_Combat/UI",
			"CCGSTest/Variant_SideScrolling",
			"CCGSTest/Variant_SideScrolling/AI",
			"CCGSTest/Variant_SideScrolling/Gameplay",
			"CCGSTest/Variant_SideScrolling/Interfaces",
			"CCGSTest/Variant_SideScrolling/UI"
		});

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
