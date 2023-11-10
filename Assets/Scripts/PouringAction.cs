using UnityEngine;

public class PouringAction : MonoBehaviour
{
    public Transform bowl;
    public GameObject puddle;
    public float tiltAngleThreshold = 30.0f; // Adjust the threshold as needed.

    private GameObject fullBowl;
    private GameObject emptyBowl;
    public GameObject socket;
    public GameObject obj;
    private RecipeSteps recipeSteps;


    private void Start()
    {
        recipeSteps = obj.GetComponent<RecipeSteps>();

        // Find the full and empty bowl child objects.
        fullBowl = bowl.Find("BowlwMedicine").gameObject;
        emptyBowl = bowl.Find("EmptyBowl").gameObject;

        // Initially, show the full bowl and hide the empty bowl and puddle.
        //fullBowl.SetActive(true);
        emptyBowl.SetActive(false);
        puddle.SetActive(false);
    }

    private void PourSoup()
    {
        // Hide the full bowl and show the empty bowl and puddle.
        fullBowl.SetActive(false);
        emptyBowl.SetActive(true);
        puddle.SetActive(true);
        socket.SetActive(true);
        recipeSteps.NextStep();
        Debug.Log("3rd Step Works");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the tag "PourZone" and interacts with the full bowl at the correct tilt angle.
        if (other.CompareTag("PourZone") && fullBowl.activeSelf && Vector3.Angle(Vector3.up, bowl.up) > tiltAngleThreshold)
        {
            PourSoup();
        }
    }
}
