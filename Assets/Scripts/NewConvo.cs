
using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewConvo : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private bool inContact = false;  // Add this flag

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            inContact = true;  // Set the flag when the player enters the trigger
            Debug.Log("In contact with the player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inContact = false;  // Reset the flag when the player exits the trigger
        }
    }

    private void Update()
    {
        if (inContact && Input.GetKeyDown(KeyCode.F))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}