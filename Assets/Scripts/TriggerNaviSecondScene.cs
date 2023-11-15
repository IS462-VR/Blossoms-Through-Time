using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TriggerNaviSecondScene : MonoBehaviour
{
   
    [SerializeField] private NaviDialoguescene2part2 _dialogue = null;

    public GameObject obj;

    private const string UI_TRIGGER_TAG = "Player";
    public AudioSource audioSource = null;
    private bool havestarted = true;
    public GameObject halo;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(UI_TRIGGER_TAG) && havestarted)
        {
            Debug.Log("THIS IS RUNNINGNGGGGG!!!!!");
            //Debug.Log("OnTriggerEnter - UI trigger object");
            DialogueText dialogueText = obj.GetComponent<DialogueText>();
            Vector3 colliderPosition = other.transform.position;
            //Debug.Log(colliderPosition);
            if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
            else
            {
                _dialogue.LoadDialogueData(dialogueText, audioSource, colliderPosition);
                _dialogue.StartDialogue();
            }
            havestarted = false;
            //halo.SetActive(true);



        }


    }
}

