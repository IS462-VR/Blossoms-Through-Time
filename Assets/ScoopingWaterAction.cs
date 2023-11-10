using UnityEngine;

public class ScoopingWaterAction : MonoBehaviour
{
    public Transform rosellecup;
    

    //public GameObject cup;
    private GameObject water;
    public GameObject socket;
    public GameObject obj;
    private RecipeSteps recipeSteps;

    private void Start()
    {
        // Find the full and empty bowl child objects.
        //cup = rosellecup.Find("Empty Cup").gameObject;
        water = rosellecup.Find("Water for Cup").gameObject;
        recipeSteps = obj.GetComponent<RecipeSteps>();


        // Initially, hide the water.

        water.SetActive(false);
    }

    private void FillWater()
    {
        // Hide the full bowl and show the empty bowl and puddle.
        water.SetActive(true);
        socket.SetActive(true);
        recipeSteps.NextStep();
        Debug.Log("works");
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
