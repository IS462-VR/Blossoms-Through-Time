using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ToDrink : MonoBehaviour
{
    [SerializeField] ParticleSystem healingParticles = null;
    [SerializeField] float spawnWaitTime = 0;
    public GameObject obj;
    private RecipeSteps recipeSteps;
    //private string targetGameScene = "Scene 5";

    public GameObject _soldierAnim;
    public GameObject soldierObj;
    public TriggerSoldierThankYou trig;


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
        Debug.Log("Give Drink works");

        //SceneManager.LoadScene(targetGameScene);
        soldierObj.SetActive(false);
        _soldierAnim.SetActive(true);
        trig.TriggerDialogue();
    }
}

