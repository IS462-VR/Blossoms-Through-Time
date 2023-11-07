using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour
{
    public enum eAudioType { Navi, Human }

    public string[] lines;
    public bool hasDialogueStarted = false;
    public bool hasDialogueFinished = false;
    public int lineIndex = 0;
    private AudioSource _audioSource;
    public AudioSource audioSource { get { return _audioSource; } }
    public eAudioType audioType; 

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}
