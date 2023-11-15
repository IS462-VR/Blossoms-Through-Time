using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TriggerScene4 : MonoBehaviour
{
    [SerializeField] private Scene4Dialogue _dialogue = null;

    public GameObject obj;

    private const string UI_TRIGGER_TAG = "Player";
    public AudioSource audioSource = null;
    private bool havestarted = true;

    //private void Start()
    //{

    //        Debug.LogError("TriggerDialogue's audioSource for lineClips not assigned!");
    //        //Debug.Log("OnTriggerEnter - UI trigger object");
    //        DialogueText dialogueText = obj.GetComponent<DialogueText>();
    //        //Vector3 colliderPosition = other.transform.position;
    //        //Debug.Log(colliderPosition);
    //        if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
    //        else
    //        {
    //            _dialogue.LoadDialogueData(dialogueText, audioSource);
    //            _dialogue.StartDialogue();
    //        }

    //}
    //}


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(UI_TRIGGER_TAG) && havestarted)
        {
            //Debug.Log("OnTriggerEnter - UI trigger object");
            DialogueText dialogueText = obj.GetComponent<DialogueText>();
            //Vector3 colliderPosition = other.transform.position;
            //Debug.Log(colliderPosition);
            if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
            else
            {
                _dialogue.LoadDialogueData(dialogueText, audioSource);
                _dialogue.StartDialogue();
            }
            havestarted = false;


            //Debug.LogError("TriggerDialogue's audioSource for lineClips not assigned!");
            ////Debug.Log("OnTriggerEnter - UI trigger object");
            //DialogueText dialogueText = obj.GetComponent<DialogueText>();
            ////Vector3 colliderPosition = other.transform.position;
            ////Debug.Log(colliderPosition);
            //if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
            //else
            //{
            //    _dialogue.LoadDialogueData(dialogueText, audioSource);
            //    _dialogue.StartDialogue();
            //}
        }


    }
}

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag(UI_TRIGGER_TAG))
//        {
//            Debug.Log("OnTriggerExit - UI trigger object");
//            _dialogue.EndDialogue();
//        }
//    }
//}
