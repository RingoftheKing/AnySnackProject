using UnityEngine;

public class ScheduledAudio : MonoBehaviour
{
    public AudioSource source;
    public double startTime;

    void Start()
    {
        startTime = AudioSettings.dspTime + 1.95f; // current DSP time + 3s
        source.PlayScheduled(startTime);
    }
}
