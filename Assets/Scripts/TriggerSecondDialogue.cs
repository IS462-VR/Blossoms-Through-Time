using UnityEngine;

public class TriggerSecondDialogue : MonoBehaviour
{
    [SerializeField] private Scene4Dialogue _dialogue = null;

    public GameObject obj;

    private const string UI_TRIGGER_TAG = "Player";
    public AudioSource audioSource = null;
    private bool havestarted = true;
    public GameObject halo;

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
            halo.SetActive(false);



        }


    }
}






////{
////    [SerializeField] private Scene4Dialogue _dialogue = null;

////    public GameObject other;
////    public AudioSource audioSource = null;

////    private void Awake()
////    {
////        if (audioSource == null)
////        {
////            Debug.LogError("TriggerDialogue's audioSource for lineClips not assigned!");
////        }
////    }

////    public void TriggerDialogue()
////    {
////        //Debug.Log("OnTriggerEnter - UI trigger object");
////        DialogueText dialogueText = other.GetComponent<DialogueText>();
////        //Vector3 colliderPosition = other.transform.position;
////        //Debug.Log(colliderPosition);
////        if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
////        else
////        {
////            _dialogue.LoadDialogueData(dialogueText, audioSource);
////            _dialogue.StartDialogue();
////        }
////    }



////}

//{
//    [SerializeField] private Scene4Dialogue _dialogue = null;

//    public GameObject obj;

//    private const string UI_TRIGGER_TAG = "Player";
//    public AudioSource audioSource = null;
//    private bool havestarted = true;
//    public GameObject halo;

//private void OnTriggerEnter(Collider other)
//{

//    if (other.CompareTag(UI_TRIGGER_TAG) && havestarted)
//    {
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
//        havestarted = false;
//        halo.SetActive(false);



//    }


//}
//}
