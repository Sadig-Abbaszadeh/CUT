using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtensions
{
    public static void DoAfterOneFrame(this MonoBehaviour mb, Action action) => mb.StartCoroutine(ActionAfterFrame(action));
    public static void DoAfterTime(this MonoBehaviour mb, float time, Action action) => mb.StartCoroutine(ActionAfterTime(time, action));
    public static void DoAfterUnscaledTime(this MonoBehaviour mb, float time, Action action) => mb.StartCoroutine(ActionAfterUnscaledTime(time, action));
    public static void DoWhile(this MonoBehaviour mb, Func<bool> waitCondition, Action action) => mb.StartCoroutine(DoWhileTrue(waitCondition, action));
    public static void DoAfterConditionIsTrue(this MonoBehaviour mb, Func<bool> condition, Action action) => mb.StartCoroutine(DoAfterTrue(condition, action));

    public static Vector2 XZ(this Vector3 v) => new Vector2(v.x, v.z);
    

    private static IEnumerator ActionAfterFrame(Action action)
    {
        yield return null;
        action();
    }

    private static IEnumerator ActionAfterTime(float time, Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    private static IEnumerator ActionAfterUnscaledTime(float time, Action action)
    {
        yield return new WaitForSecondsRealtime(time);
        action();
    }

    private static IEnumerator DoWhileTrue(Func<bool> condition, Action action)
    {
        while(condition())
        {
            action();
            yield return null;
        }
    }

    private static IEnumerator DoAfterTrue(Func<bool> condition, Action action)
    {
        yield return new WaitUntil(condition);
        action();
    }
}
