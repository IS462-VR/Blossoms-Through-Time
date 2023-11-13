using UnityEngine;

public class CuttingAction : MonoBehaviour
{
    public GameObject rosellePlant;
    public GameObject roselleBits;
    public GameObject roselleBitsUsed;
    public GameObject knife; // Reference to the Pestle GameObject.
    public GameObject obj;
    private RecipeSteps recipeSteps;



    public int hitsRequired = 3;

    private int hitCount = 0;
    private bool isRoselleVisible = true;

    private void Start()
    {
        recipeSteps = obj.GetComponent<RecipeSteps>();
        //soup.SetActive(false); // Initially hide the Soup object.
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the pestle and the required hits have not been achieved.
        if (other.CompareTag("Knife") && hitCount < hitsRequired && isRoselleVisible)
        {
            // Increment the hit count.
            hitCount++;
            Debug.Log(hitCount);

            if (hitCount >= hitsRequired)
            {
                // Transition to the "Soup" object and hide the "BowlWithPlant" object.
                TransitionToBits();
            }
        }
    }

    private void TransitionToBits()
    {
        // Hide the "BowlWithPlant" object.
        rosellePlant.SetActive(false);
        // Shoe roselle bits
        roselleBits.SetActive(true);
        roselleBitsUsed.SetActive(true);
        recipeSteps.NextStep();
        Debug.Log("Cut works");


        isRoselleVisible = false;
    }
}

