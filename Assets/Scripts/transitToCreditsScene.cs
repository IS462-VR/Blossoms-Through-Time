using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transitToCreditsScene : MonoBehaviour
{
    public float delayBeforeLoad = 25.0f;
    public float delayForFade = 15.0f;
    public string sceneToLoad = "CreditScene";
    public Image[] imagesToFade;
    private float startTime;
    private Color startColor;
    private bool isFading = false;

    IEnumerator WaitAndLoadScene()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delayBeforeLoad);

        isFading = true;

        startTime = Time.time;

        while (isFading)
        {
            float t = (Time.time - startTime) / delayForFade;

            if (t >= 3f)
            {
                isFading = false;
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Color newColor = startColor;
                newColor.a = Mathf.Lerp(0f, 1f, t);

                foreach (Image image in imagesToFade)
                {
                    image.color = newColor;
                }
                yield return null;
            }
        }

        // Load the new scene
        // SceneManager.LoadScene(sceneToLoad);
    }
    // Start is called before the first frame update
    void Start()
    {
        // startTime = Time.time;
        startColor = imagesToFade[0].color;
        StartCoroutine(WaitAndLoadScene());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
