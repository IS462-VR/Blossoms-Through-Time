using UnityEngine;

public class TriggerSecondDialogue : MonoBehaviour
{
    [SerializeField] private Scene4Dialogue _dialogue = null;

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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag(UI_TRIGGER_TAG))
    //    {
    //        Debug.Log("OnTriggerEnter - UI trigger object");
    //        DialogueText dialogueText = other.GetComponent<DialogueText>();
    //        Debug.Log(colliderPosition);
    //        if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
    //        else
    //        {
    //            _dialogue.LoadDialogueData(dialogueText, audioSource, colliderPosition);
    //            _dialogue.StartDialogue();
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag(UI_TRIGGER_TAG))
    //    {
    //        Debug.Log("OnTriggerExit - UI trigger object");
    //        _dialogue.EndDialogue();
    //    }
    //}
}
