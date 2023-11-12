using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryRemoval : MonoBehaviour
{
    public GameObject initialBoundary;
    public GameObject clipboardInstruction;

    private bool clipboardGrabbed = false;

    public void onGrabbed()
    {
        clipboardGrabbed = true;

        if (initialBoundary != null)
        {
            initialBoundary.SetActive(false);
            clipboardInstruction.SetActive(false);
        }
    }

    public void onReleased()
    {
        clipboardGrabbed = false;

        if (initialBoundary != null)
        {
            initialBoundary.SetActive(true);
            clipboardInstruction.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
