using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    private AudioSource source;
    public static Vocals instance;
    public float audioStartTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Say(AudioClip audioClip)
    {
        if (source.isPlaying)
        {
            source.Stop();
        }

        audioStartTime = Time.time;

        source.PlayOneShot(audioClip);
    }
}
