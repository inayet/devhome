﻿// Copyright (c) Microsoft Corporation and Contributors
// Licensed under the MIT license.

using System;
using System.Diagnostics.Tracing;
using DevHome.Telemetry;
using Microsoft.Diagnostics.Telemetry;
using Microsoft.Diagnostics.Telemetry.Internal;
using Microsoft.Management.Configuration;

namespace DevHome.SetupFlow.Common.TelemetryEvents;

[EventData]
internal class ConfigurationSetResultEvent : EventBase
{
    private readonly ConfigurationSet _configSet;

    private readonly ApplyConfigurationSetResult _setResult;

    public string SetName => _configSet.Name;

    public string SetInstanceIdentifier => _configSet.InstanceIdentifier.ToString();

    public int ExceptionHResult => _setResult.ResultCode?.HResult ?? 0;

    public override PartA_PrivTags PartA_PrivTags => PrivTags.ProductAndServiceUsage;

    public ConfigurationSetResultEvent(ConfigurationSet configSet, ApplyConfigurationSetResult setResult)
    {
        _configSet = configSet;
        _setResult = setResult;
    }

    public override void ReplaceSensitiveStrings(Func<string, string> replaceSensitiveStrings)
    {
        // No sensitive strings to replace.
    }
}
