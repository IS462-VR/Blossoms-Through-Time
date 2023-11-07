using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue = null;

    private const string UI_TRIGGER_TAG = "UITrigger";


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(UI_TRIGGER_TAG)) {
            Debug.Log("OnTriggerEnter - UI trigger object");
            DialogueText dialogueText = other.GetComponent<DialogueText>();
            if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
            else {
                _dialogue.LoadDialogueData(dialogueText);
                _dialogue.StartDialogue();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(UI_TRIGGER_TAG)) {
            Debug.Log("OnTriggerExit - UI trigger object");
            _dialogue.EndDialogue();
        }
    }
}
