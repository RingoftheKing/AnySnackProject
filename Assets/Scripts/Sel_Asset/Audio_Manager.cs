using UnityEngine;

public class ScheduledAudio : MonoBehaviour
{
    public AudioSource source;
    public double startTime = 1.9f;

    void Start()
    {
        source.PlayScheduled(startTime);
    }
}
