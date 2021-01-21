using System;
using UnityEngine;

/// <summary>
/// Wait until the provided func returns true
/// </summary>
public class WaitUntil : CustomYieldInstruction
{
    private Func<bool> condition;

    public override bool keepWaiting => !condition();

    public WaitUntil(Func<bool> condition)
    {
        this.condition = condition;
    }
}