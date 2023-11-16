using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoldierThankYou : MonoBehaviour
{
    [SerializeField] private SoldierDialogue _dialogue = null;

    public GameObject other;
    public AudioSource audioSource = null;

    private void Awake()
    {
        if (audioSource == null)
        {
            Debug.LogError("TriggerDialogue's audioSource for lineClips not assigned!");
        }
    }

    public void TriggerDialogue()
    {
        //Debug.Log("OnTriggerEnter - UI trigger object");
        DialogueText dialogueText = other.GetComponent<DialogueText>();
        //Vector3 colliderPosition = other.transform.position;
        //Debug.Log(colliderPosition);
        if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
        else
        {
            _dialogue.LoadDialogueData(dialogueText, audioSource);
            _dialogue.StartDialogue();
        }
    }
}