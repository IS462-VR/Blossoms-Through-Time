using UnityEngine;

public class ScoopingWaterAction : MonoBehaviour
{
    public Transform rosellecup;

    //public GameObject cup;
    private GameObject water;

    private void Start()
    {
        // Find the full and empty bowl child objects.
        //cup = rosellecup.Find("Empty Cup").gameObject;
        water = rosellecup.Find("Water for Cup").gameObject;

        // Initially, hide the water.
        
        water.SetActive(false);
    }

    private void FillWater()
    {
        // Hide the full bowl and show the empty bowl and puddle.
        water.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the tag "PotWater".
        if (other.CompareTag("PotWater"))
        {
            FillWater();
        }
    }
}
