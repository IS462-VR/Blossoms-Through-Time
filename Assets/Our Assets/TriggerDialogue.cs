using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    private bool inContact = false;

    public bool IsInContact()
    {
        return this.inContact;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.inContact = true;
            Debug.Log("in contact w player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.inContact = false;
            Debug.Log("left contact w player");
        }
    }
}
