using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toBeBandaged : MonoBehaviour
{
    [SerializeField] ParticleSystem healingParticles = null; 
    [SerializeField] GameObject bandage = null;
    [SerializeField] float spawnWaitTime = 0;
    public GameObject socket;
    public GameObject obj;
    private RecipeSteps recipeSteps;

    private void Start()
    {
        recipeSteps = obj.GetComponent<RecipeSteps>();
        //soup.SetActive(false); // Initially hide the Soup object.
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Soldier")
        {
            socket.SetActive(true);
            StartCoroutine(PutBandage());
        }
    }
    
    IEnumerator PutBandage()
    {
        healingParticles.Play();
        yield return new WaitForSeconds(spawnWaitTime);
        bandage.SetActive(true);
        Destroy(gameObject);
        recipeSteps.NextStep();
        Debug.Log("works");

    }
}
