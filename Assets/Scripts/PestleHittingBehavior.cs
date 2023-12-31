using UnityEngine;

public class BowlWithPlantBehavior : MonoBehaviour
{
    public GameObject bowlwplant;
    public GameObject soup;   // Reference to the Soup object.
    public GameObject pestle; // Reference to the Pestle GameObject.
    public int hitsRequired = 3;
    public GameObject obj;
    public GameObject hitBowlSound;
    private RecipeSteps recipeSteps;

    private int hitCount = 0;
    private bool isBowlWithPlantVisible = true;

    private void Start()
    {
        soup.SetActive(false); // Initially hide the Soup object.
        recipeSteps = obj.GetComponent<RecipeSteps>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the pestle and the required hits have not been achieved.
        if (other.CompareTag("Pestle") && hitCount < hitsRequired && isBowlWithPlantVisible)
        {
            hitBowlSound.GetComponent<AudioSource>().Play();

            // Increment the hit count.
            hitCount++;

            if (hitCount >= hitsRequired)
            {
                // Transition to the "Soup" object and hide the "BowlWithPlant" object.
                TransitionToSoup();
            }
        }
    }

    private void TransitionToSoup()
    {
        // Hide the "BowlWithPlant" object.
        bowlwplant.SetActive(false);

        // Show the "Soup" object.
        soup.SetActive(true);

        isBowlWithPlantVisible = false;
        recipeSteps.NextStep();
        Debug.Log("hitting works");
    }
}
