using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{

    public string InteractionPrompt { get; }

    public bool Interact(Interactor interactor);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
