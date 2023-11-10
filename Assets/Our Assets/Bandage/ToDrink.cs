using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToDrink : MonoBehaviour
{
    [SerializeField] ParticleSystem healingParticles = null;
    [SerializeField] float spawnWaitTime = 0;
    public GameObject obj;
    private RecipeSteps recipeSteps;
    private string targetGameScene = "Scene 5";


    private void Start()
    {
        recipeSteps = obj.GetComponent<RecipeSteps>();
        //soup.SetActive(false); // Initially hide the Soup object.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soldier")
        {
            StartCoroutine(GiveDrink());
        }
    }

    IEnumerator GiveDrink()
    {
        healingParticles.Play();
        yield return new WaitForSeconds(spawnWaitTime);
        Destroy(gameObject);
        recipeSteps.NextStep();
        Debug.Log("works");

        SceneManager.LoadScene(targetGameScene);
    }
}

