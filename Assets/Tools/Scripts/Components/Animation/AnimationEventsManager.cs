using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationEventsManager : MonoBehaviour
{
    [SerializeField]
    int eventCount;
    private Action[] stateEndEvents;

    private void Awake()
    {
        stateEndEvents = new Action[eventCount];
    }

    public void Subscribe(int stateIndex, Action action) => stateEndEvents[stateIndex] += action;

    public void Broadcast(int stateIndex) => stateEndEvents[stateIndex]?.Invoke();
}
