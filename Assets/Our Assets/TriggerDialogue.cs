using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue;

    private const string UI_TRIGGER_TAG = "UITrigger";
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(UI_TRIGGER_TAG)) {
            DialogueText dialogueText = other.GetComponent<DialogueText>();
            if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
            else {
                _dialogue.LoadDialogueLines(dialogueText.lines);
                _dialogue.StartDialogue();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(UI_TRIGGER_TAG)) {
            _dialogue.EndDialogue();
        }
    }
}
