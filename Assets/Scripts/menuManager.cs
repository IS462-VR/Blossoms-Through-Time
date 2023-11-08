using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    [SerializeField]
    private GameObject _naviScene;

    void StartGame()
    {
        Debug.Log("Starting the game.");

        _naviScene.SetActive(true);
        startButton.interactable = false;
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
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
