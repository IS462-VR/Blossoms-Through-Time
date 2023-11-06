using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TriggerAudio : MonoBehaviour
{
    AudioClip myAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit player");
            Vocals.instance.Say(myAudioClip);

            //Vocals.instance.Say(clipToPlay);
        }
    }
}