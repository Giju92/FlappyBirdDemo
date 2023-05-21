using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : BaseObserver
{
    AudioSource audioSource;

    [SerializeField]
    AudioClip clipDoorPassed;

    [SerializeField]
    AudioClip clipEnd;

    [SerializeField]
    AudioClip clipStart;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    protected override void OnStartEvent()
    {
        base.OnObstaclePassedEvent();
        PlaySound(clipStart);
    }

    protected override void OnObstaclePassedEvent()
    {
        base.OnObstaclePassedEvent();
        PlaySound(clipDoorPassed);
    }

    protected override void OnEndEvent()
    {
        base.OnEndEvent();
        PlaySound(clipEnd);
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
