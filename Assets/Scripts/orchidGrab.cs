using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class orchidGrab : MonoBehaviour
{
    public void OnGrabbed()
    {
        // Load the scene
        Debug.Log("Grabbed");
        SceneManager.LoadScene("Scene 2");   
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