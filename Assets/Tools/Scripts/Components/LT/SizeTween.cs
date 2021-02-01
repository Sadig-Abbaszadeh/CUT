using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SizeTween : LT_Base
{
    [SerializeField]
    private Vector3 inSize = Vector3.one, outSize = Vector3.one * .8f;
    [SerializeField]
    private bool isTweenedIn = true;
    [SerializeField]
    private LeanTweenType inType, outType;

    [SerializeField]
    private UnityEvent beforeTweenIn, afterTweenOut;

    public void TweenIn()
    {
        beforeTweenIn.Invoke();
        isTweenedIn = true;

        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, inSize, animationTime).setIgnoreTimeScale(useUnscaledTime).setEase(inType);
    }

    public void TweenOut()
    {
        isTweenedIn = false;

        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, outSize, animationTime).setEase(outType).setIgnoreTimeScale(useUnscaledTime).setOnComplete(() => afterTweenOut.Invoke());
    }

    public void ToggleTween()
    {
        if (isTweenedIn)
            TweenOut();
        else
            TweenIn();
    }
}