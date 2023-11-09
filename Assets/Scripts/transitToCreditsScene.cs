using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitToCreditsScene : MonoBehaviour
{
    public float delayBeforeLoad = 1.0f;
    public string sceneToLoad = "CreditScene";

    IEnumerator WaitAndLoadScene()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeLoad);

        // Load the new scene
        SceneManager.LoadScene(sceneToLoad);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
