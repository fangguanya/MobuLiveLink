﻿// Copyright Epic Games, Inc. All Rights Reserved.

#pragma once

#include "MobuLiveLinkCommon.h"


// Pure Abstract class. Inherit from this to support streaming.
// If you create a new Stream Object then make sure to register it in MobuLiveLinkStreamObject.h
class IStreamObject
{
public:
	// Interface for modifying and accessing stream parameters
	virtual ~IStreamObject() {}

	virtual const bool ShouldShowInUI() const = 0;

	virtual const FString GetStreamOptions() const = 0;

	virtual FName GetSubjectName() const = 0;

	virtual void UpdateSubjectName(FName NewSubjectName) = 0;

	virtual int GetStreamingMode() const = 0;

	virtual void UpdateStreamingMode(int NewStreamingMode) = 0;

	virtual bool GetActiveStatus() const = 0;

	virtual void UpdateActiveStatus(bool bIsNowActive) = 0;

	virtual bool GetSendAnimatableStatus() const = 0;

	virtual void UpdateSendAnimatableStatus(bool bNewSendAnimatable) = 0;

	virtual const FBModel* GetModelPointer() const = 0;
	
	virtual const FString GetRootName() const = 0;

	virtual bool IsValid() const = 0;

	// Interface for object streaming

	virtual void Refresh(const TSharedPtr<ILiveLinkProvider> Provider) = 0;

	virtual void UpdateSubjectFrame(const TSharedPtr<ILiveLinkProvider> Provider, FLiveLinkWorldTime WorldTime, FQualifiedFrameTime QualifiedFrameTime) = 0;
};