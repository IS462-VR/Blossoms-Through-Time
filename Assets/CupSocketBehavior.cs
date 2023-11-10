using UnityEngine;

public class CupSocketBehavior : MonoBehaviour
{
    public string roselleTag = "RoselleBit";
    public GameObject water;
    public GameObject roselleBit;
    public GameObject roselletea;

    private bool isSnapZoneEmpty = true;

    private Vector3 initialBowlWithPlantPosition;

    private void Start()
    {
        // Record the initial position of the "BowlWithPlant" object.
        //initialBowlWithPlantPosition = roselletea.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSnapZoneEmpty && other.CompareTag(roselleTag))
        {
            // Hide the plant and bowl objects.
            water.SetActive(false);
            roselleBit.SetActive(false);

            // Activate the "Bowl with Plant" object and position it at the initial position.
            roselletea.SetActive(true);
            //roselletea.transform.position = initialBowlWithPlantPosition;

            isSnapZoneEmpty = false;
        }
    }
}
