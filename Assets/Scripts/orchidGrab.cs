using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class orchidGrab : MonoBehaviour
{
    private Rigidbody orchidRb;
    public float delayBeforeLoad = 1.0f;
    public string sceneToLoad = "Scene 2";
    public GameObject teleportFX;

    public void OnGrabbed()
    {
        // Load the scene
        Debug.Log("Grabbed");
        orchidRb.isKinematic = false;
        orchidRb.useGravity = true;

        teleportFX.SetActive(true);

        StartCoroutine(WaitAndLoadScene());
    }

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
        orchidRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}