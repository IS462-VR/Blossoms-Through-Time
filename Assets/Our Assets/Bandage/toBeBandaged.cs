using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toBeBandaged : MonoBehaviour
{
    [SerializeField] ParticleSystem healingParticles = null; 
    [SerializeField] GameObject bandage = null;
    [SerializeField] float spawnWaitTime = 0;
    public GameObject obj;
    private RecipeSteps recipeSteps;
    //public TriggerSecondDialogue trig;

    public GameObject _naviToTable;
    public GameObject _naviToSoldier;
    public GameObject halo;

    private void Start()
    {
        recipeSteps = obj.GetComponent<RecipeSteps>();
        halo.SetActive(false);
        //soup.SetActive(false); // Initially hide the Soup object.
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Soldier")
        {
            StartCoroutine(PutBandage());
        }
    }
    
    IEnumerator PutBandage()
    {
        healingParticles.Play();
        yield return new WaitForSeconds(spawnWaitTime);
        bandage.SetActive(true);
        Destroy(gameObject);
        //trig.TriggerDialogue();
        recipeSteps.NextRecipe();
        Debug.Log("Give Bandage works");
        _naviToSoldier.SetActive(false);
        _naviToTable.SetActive(true);
        halo.SetActive(true);

    }
}
