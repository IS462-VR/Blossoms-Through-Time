using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeClipboard : MonoBehaviour
{
    public string roselleTag = "Clipboard";
    public GameObject oldClipBoard;
    public GameObject newClipBoard;
    public GameObject neemPlant;
    public GameObject rosellePlant;
    public GameObject placeClipboardInstruction;


    private bool isSnapZoneEmpty = true;

    private void Start()
    {
        // Record the initial position of the "BowlWithPlant" object.
        //initialBowlWithPlantPosition = roselletea.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSnapZoneEmpty && other.CompareTag(roselleTag))
        {
            // Hide the old clipboard object.
            oldClipBoard.SetActive(false);

            // Activate the "Bowl with Plant" object and position it at the initial position.
            newClipBoard.SetActive(true);
            neemPlant.SetActive(true);
            rosellePlant.SetActive(true);
            placeClipboardInstruction.SetActive(false);

            //roselletea.transform.position = initialBowlWithPlantPosition;

            isSnapZoneEmpty = false;
        }
    }
}
