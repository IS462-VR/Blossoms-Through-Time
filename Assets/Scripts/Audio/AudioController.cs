using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource audioSource;
    public Transform player;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Calculate the distance between the audio source's position and the player's position.
        float distance = Vector3.Distance(transform.position, player.position);

        // Adjust the audio volume based on the distance.
        float maxDistance = 10.0f; // Adjust this to your desired max distance.
        float minVolume = 0.1f;   // Minimum volume when the player is far away.

        float volume = 1.0f - (distance / maxDistance); // Linear falloff
        volume = Mathf.Clamp(volume, minVolume, 1.0f);   // Ensure it doesn't go below the minimum volume.

        audioSource.volume = volume;
    }
}
