using UnityEngine;
using UnityEngine.UI;

public class ContentSwitcher : MonoBehaviour
{
    public Button[] buttons;  // Reference to your three buttons
    public GameObject[] contentObjects;  // Reference to your content objects

    private void Start()
    {
        // Initialize the UI; hide all content except the first one
        ShowContent(0);
    }

    // Call this method to show the content for a specific button index
    public void ShowContent(int buttonIndex)
    {
        for (int i = 0; i < contentObjects.Length; i++)
        {
            if (i == buttonIndex)
            {
                contentObjects[i].SetActive(true);
            }
            else
            {
                contentObjects[i].SetActive(false);
            }
        }
    }

    // Assign this method to the OnClick event of each button in the Unity Inspector
    public void OnButtonClick(int buttonIndex)
    {
        ShowContent(buttonIndex);
    }
}
