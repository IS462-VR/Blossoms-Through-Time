using UnityEngine;

public class BowlWithPlantBehavior : MonoBehaviour
{
    public GameObject bowlwplant;
    public GameObject soup;   // Reference to the Soup object.
    public GameObject bowlwcontent;
    public GameObject pestle; // Reference to the Pestle GameObject.
    public int hitsRequired = 3;

    private int hitCount = 0;
    private bool isBowlWithPlantVisible = true;

    private void Start()
    {
        //soup.SetActive(false); // Initially hide the Soup object.
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the pestle and the required hits have not been achieved.
        if (other.CompareTag("Pestle") && hitCount < hitsRequired && isBowlWithPlantVisible)
        {
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
        bowlwcontent.SetActive(true);
        // Show the "Soup" object.
        soup.SetActive(true);

        isBowlWithPlantVisible = false;
    }
}
