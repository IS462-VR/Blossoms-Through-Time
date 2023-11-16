using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using BNG;

public class menuManager : MonoBehaviour
{
    // public Button startButton;
    // public Button quitButton;

    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;

    public GameObject orchidObject;
    private Grabbable grabbableComponent;

    [SerializeField]
    private GameObject _naviScene;

    private bool gameStarted = false;

    public void StartGame()
    {
        if (!gameStarted)
        {
            Debug.Log("Starting the game.");

            _naviScene.SetActive(true);
            gameStarted = true;
        }
        

        StartCoroutine(AfterDelay(35.00f));

        // startButton.interactable = false;
        // startButton.GetComponent<GraphicRaycaster>().enabled = false;
        // startButton.GetComponent<Button>().enabled = false;
    }

    IEnumerator AfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        grabbableComponent.enabled = true;

        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        Debug.Log("Set Grabbable to true");
    }

    // IEnumerator EnableGrabbableAfterDelay(float delay)
    // {
    //     yield return new WaitForSeconds(delay);

    //     grabbableComponent.enabled = true;

    //     Debug.Log("Set Grabbable to true");
    // }

    void QuitGame()
    {
        Debug.Log("Quitting the game.");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // If running a build, this will quit the application
#endif
    }
    // Start is called before the first frame update
    void Start()
    {
        grabbableComponent = orchidObject.GetComponent<Grabbable>();
        // startButton.onClick.AddListener(StartGame);
        // quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
