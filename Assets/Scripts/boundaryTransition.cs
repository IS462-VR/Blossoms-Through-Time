using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boundaryTransition : MonoBehaviour
{
    public string targetSceneName = "Scene 3";

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(targetSceneName);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
