using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHumanDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue = null;

    private const string UI_TRIGGER_TAG = "Player";
    public AudioSource audioSource = null;
    public GameObject obj;
    private bool hasplayed = true;

    private void Awake()
    {
        if (audioSource == null)
        {
            Debug.LogError("TriggerDialogue's audioSource for lineClips not assigned!");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(UI_TRIGGER_TAG) && hasplayed)
        {
            Debug.Log("OnTriggerEnter - UI trigger object");
            DialogueText dialogueText = obj.GetComponent<DialogueText>();
            Vector3 colliderPosition = other.transform.position;
            //Debug.Log(colliderPosition);
            if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
            else
            {
                _dialogue.LoadDialogueData(dialogueText, audioSource, colliderPosition);
                _dialogue.StartDialogue();

            }
            hasplayed = false;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag(UI_TRIGGER_TAG))
    //    {
    //        Debug.Log("OnTriggerExit - UI trigger object");
    //        _dialogue.EndDialogue();
    //    }
    //}
}
