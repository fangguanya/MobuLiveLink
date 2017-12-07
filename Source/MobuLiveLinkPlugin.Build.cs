﻿// Copyright 1998-2017 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class MobuLiveLinkPlugin : ModuleRules
{
	public MobuLiveLinkPlugin(ReadOnlyTargetRules Target) : base(Target)
	{
        bEnforceIWYU = false;

        // For LaunchEngineLoop.cpp include.  You shouldn't need to add anything else to this line.
        PrivateIncludePaths.AddRange( new string[] { "Runtime/Launch/Public", "Runtime/Launch/Private" }  );

		// Unreal dependency modules
		PrivateDependencyModuleNames.AddRange( new string[] 
		{
			"Core",
            "CoreUObject",
            "ApplicationCore",
            "Projects",
            "UdpMessaging",
            "LiveLinkInterface",
            "LiveLinkMessageBusFramework",
		} );

        //
        // Mobu SDK setup
        //

        {
            string MobuVersionString = "2017";
            string MobuInstallFolder = @"D:\Programs\Autodesk\MotionBuilder " + MobuVersionString;
            string QtFolder = Path.GetFullPath(Path.Combine(ModuleDirectory, "../ThirdPartyIncludes/Qt/Mobu " + MobuVersionString));

            // Make sure this version of Mobu is actually installed
            if (Directory.Exists(MobuInstallFolder))
            {
                PrivateIncludePaths.Add(Path.Combine(MobuInstallFolder, "OpenRealitySDK/include"));
                PrivateIncludePaths.Add(Path.Combine(QtFolder, "include"));
                PrivateIncludePaths.Add(Path.GetFullPath(Path.Combine(ModuleDirectory, "../MOC")));

                if (Target.Platform == UnrealTargetPlatform.Win64)  // @todo: Support other platforms?
                {
                    PublicLibraryPaths.Add(Path.Combine(MobuInstallFolder, "OpenRealitySDK/lib/x64"));
                    PublicLibraryPaths.Add(Path.Combine(QtFolder, "lib"));

                    // Mobu and Qt libraries we're depending on
                    PublicAdditionalLibraries.AddRange(new string[]
                        {
                            "fbsdk.lib",
                            "QtCore4.lib",
                            "QtGui4.lib"
                        }
                    );
                }
            }
			else
            {
                throw new BuildException("Couldn't find Autodesk MotionBuilder " + MobuVersionString + " in folder '" + MobuInstallFolder + "'.  This version of MotionBuilder must be installed for us to find the MotionBuilder SDK files.");
            }
		}
	}
}