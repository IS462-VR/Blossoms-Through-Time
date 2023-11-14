using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    // public Button startButton;
    // public Button quitButton;

    public List<GameObject> objectsToActivate;
    public List<GameObject> objectsToDeactivate;

    [SerializeField]
    private GameObject _naviScene;

    public void StartGame()
    {
        Debug.Log("Starting the game.");

        _naviScene.SetActive(true);

        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
        // startButton.interactable = false;
        // startButton.GetComponent<GraphicRaycaster>().enabled = false;
        // startButton.GetComponent<Button>().enabled = false;

    }

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
        // startButton.onClick.AddListener(StartGame);
        // quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
