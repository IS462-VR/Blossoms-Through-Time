using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toBeBandaged : MonoBehaviour
{
    public GameObject obj;
    private RecipeSteps recipeSteps;

    [SerializeField] ParticleSystem healingParticles = null; 
    [SerializeField] GameObject bandage = null;
    [SerializeField] float spawnWaitTime = 0;

    private void Start()
    {
        recipeSteps = obj.GetComponent<RecipeSteps>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soldier")
        {
            StartCoroutine(PutBandage());
            recipeSteps.NextStep();
            Debug.Log("works");
        }
    }
    
    IEnumerator PutBandage()
    {
        healingParticles.Play();
        yield return new WaitForSeconds(spawnWaitTime);
        bandage.SetActive(true);
        Destroy(gameObject);
    }
}
