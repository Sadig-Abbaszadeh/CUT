using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LT_Base : MonoBehaviour
{
    [SerializeField]
    protected float animationTime = 1;
    [SerializeField]
    protected bool useUnscaledTime = true;
}