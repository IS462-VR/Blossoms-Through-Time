using UnityEngine;

public class SocketBehavior : MonoBehaviour
{
    public string plantTag = "Plant";
    public GameObject plant;
    public GameObject bowl;
    public GameObject bowlWithPlant;
    public GameObject obj;
    private RecipeSteps recipeSteps;

    private bool isSnapZoneEmpty = true;

    private Vector3 initialBowlWithPlantPosition;

    private void Start()
    {
        //recipeSteps = gameObject.GetComponent<RecipeSteps>();
        recipeSteps = obj.GetComponent<RecipeSteps>();
        // Record the initial position of the "BowlWithPlant" object.
        initialBowlWithPlantPosition = bowlWithPlant.transform.position;
        //recipeSteps = GetComponentInChildren<RecipeSteps>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSnapZoneEmpty && other.CompareTag(plantTag))
        {
            // Hide the plant and bowl objects.
            plant.SetActive(false);
            bowl.SetActive(false);

            // Activate the "Bowl with Plant" object and position it at the initial position.
            bowlWithPlant.SetActive(true);
            bowlWithPlant.transform.position = initialBowlWithPlantPosition;
            recipeSteps.NextStep();
            Debug.Log("works");
            

            isSnapZoneEmpty = false;
        }
    }
}
