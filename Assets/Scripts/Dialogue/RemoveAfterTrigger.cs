using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasCollided)
        {
            hasCollided = true;
            Debug.Log("in contact");
            //Destroy(GetComponent<DialogueText>());
            //gameObject.tag = "Untagged";

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollided)
        {
            hasCollided = true;
            //Destroy(GetComponent<DialogueText>());
            //gameObject.tag = "Untagged";

        }
    }
}
