using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeTween : LT_Base
{
    [SerializeField]
    Vector3 activeSize = Vector3.one, inactiveSize = Vector3.one * .8f;
    [SerializeField]
    LeanTweenType inType, outType;

    public void TweenIn()
    {
        gameObject.SetActive(true);
        LeanTween.scale(gameObject, activeSize, animationTime).setIgnoreTimeScale(useUnscaledTime).setEase(inType);
    }

    public void TweenOut()
    {
        LeanTween.scale(gameObject, inactiveSize, animationTime).setEase(outType).setIgnoreTimeScale(useUnscaledTime).setOnComplete(() => gameObject.SetActive(false));
    }

    public void ToggleTween()
    {
        if (gameObject.activeSelf)
            TweenOut();
        else
            TweenIn();
    }
}
