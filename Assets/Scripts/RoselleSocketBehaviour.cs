using UnityEngine;

public class RoselleSocketBehaviour : MonoBehaviour
{
    public string roselleTag = "Roselle";
    public GameObject roselle;
    public GameObject placedRoselle;
    public GameObject obj;
    private RecipeSteps recipeSteps;

    private bool isSnapZoneEmpty = true;

    //private Vector3 initialBowlWithPlantPosition;

    private void Start()
    {
        recipeSteps = obj.GetComponent<RecipeSteps>();
        // Record the initial position of the "BowlWithPlant" object.
        //initialBowlWithPlantPosition = bowlWithPlant.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSnapZoneEmpty && other.CompareTag(roselleTag))
        {
            // Hide the plant and bowl objects.
            roselle.SetActive(false);

            // Activate the "Bowl with Plant" object and position it at the initial position.
            placedRoselle.SetActive(true);
            //bowlWithPlant.transform.position = initialBowlWithPlantPosition;

            isSnapZoneEmpty = false;
            recipeSteps.NextStep();
            Debug.Log("putting roselle works");
        }
    }
}
