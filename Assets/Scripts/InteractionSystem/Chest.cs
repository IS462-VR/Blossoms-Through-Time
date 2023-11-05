using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{

    [SerializeField] private string _prompt;
    //public string InteractionPrompt => throw new System.NotImplementedException();
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        //throw new System.NotImplementedException();
        Debug.Log("In contact w flower1");
        return true;
    }

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
            // Remove the Chest script component
            Destroy(GetComponent<Chest>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasCollided)
        {
            hasCollided = true;
            // Remove the Chest script component
            Destroy(GetComponent<Chest>());
        }
    }
}
