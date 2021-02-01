using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// using MoreMountains.NiceVibrations;

public class CustomButton : Button
{
    // [SerializeField] private HapticTypes vibrationType;
    //[SerializeField] private SoundName soundType;
    [SerializeField] private bool /*vibrateOnPress,*/ playSoundOnPress, animate = true;

    //private AudioManager audioManager;

    protected override void Start()
    {
        base.Start();

        EventTrigger eventTrigger = GetComponent<EventTrigger>();

        // if (vibrateOnPress)
            // onClick.AddListener(() => VibrationManager.Vibrate(vibrationType));

        //if (playSoundOnPress)
        //{
        //    audioManager = AudioManager.Instance;
        //    onClick.AddListener(() => audioManager.Play(soundType));
        //}

        if(animate)
        {
            SizeTween tween = GetComponent<SizeTween>();

            EventTrigger.Entry tweenOutEntry = new EventTrigger.Entry(),
                tweenInEntry = new EventTrigger.Entry();

            tweenOutEntry.eventID = EventTriggerType.PointerDown;
            tweenOutEntry.callback.AddListener((BaseEventData data) => tween.TweenOut());

            tweenInEntry.eventID = EventTriggerType.PointerUp;
            tweenInEntry.callback.AddListener((BaseEventData data) => tween.TweenIn());

            eventTrigger.triggers.Add(tweenOutEntry);
            eventTrigger.triggers.Add(tweenInEntry);
        }
    }
}