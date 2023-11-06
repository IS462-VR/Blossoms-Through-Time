using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TriggerDialogue : MonoBehaviour
{
    [SerializeField] private Dialogue _dialogue = null;

    private const string UI_TRIGGER_TAG = "UITrigger";
    [SerializeField] private AudioSource audioSource;


    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(UI_TRIGGER_TAG)) {
            Debug.Log("in contact w UI trigger object");
            DialogueText dialogueText = other.GetComponent<DialogueText>();
            if (dialogueText == null) Debug.LogError("No DialogueText found for UITrigger tagged collider. Possibly you forgot to add it!!!");
            else {
                _dialogue.LoadDialogueLines(dialogueText.lines);
                _dialogue.StartDialogue();
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(UI_TRIGGER_TAG)) {
            Debug.Log("left contact w UI trigger object");
            _dialogue.EndDialogue();
            audioSource.Stop();
        }
    }
}
