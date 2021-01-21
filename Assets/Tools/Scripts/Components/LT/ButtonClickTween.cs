using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ButtonClickTween : LT_Base
{
    [SerializeField]
    private Vector3 midWayScale = new Vector3(.9f, .9f, 1);

    private Vector3 initialScale;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    public void Animate()
    {
        Scale(midWayScale, () => Scale(initialScale, () => { }));
    }

    private void Scale(Vector3 toScale, Action onComplete)
    {
        LeanTween.scale(gameObject, toScale, animationTime / 2).setIgnoreTimeScale(useUnscaledTime).setOnComplete(onComplete);
    }
}