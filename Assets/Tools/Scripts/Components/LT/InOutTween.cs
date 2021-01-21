using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutTween : LT_Base
{
    [SerializeField]
    private Vector3 inScale, outScale;
    [SerializeField, Tooltip("true if the animation cycle will zoom in first, else false")]
    private bool scaleInFirst = true;

    private void Start()
    {
        transform.localScale = scaleInFirst ? outScale : inScale;
        Zoom(scaleInFirst);
    }

    public void Zoom(bool scaleIn)
    {
        LeanTween.scale(gameObject, scaleIn ? inScale : outScale, animationTime).setIgnoreTimeScale(useUnscaledTime).setOnComplete(() => Zoom(!scaleIn));
    }
}