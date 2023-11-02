using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class creditsManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI developerTitleText;
    public TextMeshProUGUI specialThanksTitleText;
    public TextMeshProUGUI[] developerNamesText;
    public TextMeshProUGUI[] specialThanksNamesText;
    public TextMeshProUGUI thankYouText;
    public float fadeDuration = 2f;
    public float displayDuration = 3f;
    public float typeSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowCreditsRoutine());
    }

    private IEnumerator ShowCreditsRoutine()
    {
        yield return new WaitForSeconds(1f);

        // Fade in title
        yield return FadeIn(titleText);
        yield return new WaitForSeconds(displayDuration);
        yield return FadeOut(titleText);

        // Wait for a moment (optional)
        yield return new WaitForSeconds(1f);

        // Fade in developer names
        yield return FadeIn(developerTitleText);
        // yield return new WaitForSeconds(displayDuration);
        foreach (var devText in developerNamesText)
        {
            yield return TypeText(devText);
            yield return new WaitForSeconds(typeSpeed * 2);
        }

        yield return new WaitForSeconds(displayDuration);
        StartCoroutine(FadeOut(developerTitleText));
        foreach (var devText in developerNamesText)
        {
            StartCoroutine(FadeOut(devText));
        }
        yield return new WaitForSeconds(fadeDuration);

        yield return FadeIn(specialThanksTitleText);
        // yield return new WaitForSeconds(displayDuration);
        foreach (var thanksText in specialThanksNamesText)
        {
            yield return TypeText(thanksText);
            yield return new WaitForSeconds(typeSpeed * 2);
        }
        yield return new WaitForSeconds(displayDuration);
        StartCoroutine(FadeOut(specialThanksTitleText));
        foreach (var thanksText in specialThanksNamesText)
        {
            StartCoroutine(FadeOut(thanksText));
        }
        yield return new WaitForSeconds(fadeDuration);

        yield return FadeIn(thankYouText);
        yield return new WaitForSeconds(displayDuration);
        yield return FadeOut(thankYouText);
        // Load next scene or end the game (optional)
        SceneManager.LoadScene("Scene 1");
    }

    private IEnumerator FadeIn(TextMeshProUGUI textElement)
    {
        float startTime = Time.time;
        Color startColor = textElement.color;

        while (Time.time < startTime + fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            textElement.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(0, 1, t));
            yield return null;
        }
        textElement.color = new Color(startColor.r, startColor.g, startColor.b, 1);
    }

    private IEnumerator FadeOut(TextMeshProUGUI textElement)
    {
        float startTime = Time.time;
        Color startColor = textElement.color;

        while (Time.time < startTime + fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            textElement.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(1, 0, t));
            yield return null;
        }
        textElement.color = new Color(startColor.r, startColor.g, startColor.b, 0);
    }

    private IEnumerator TypeText(TextMeshProUGUI textElement)
    {
        textElement.text = "";
        string fullText = textElement.GetParsedText();

        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 1);

        for (int i = 0; i <= fullText.Length; i++)
        {
            textElement.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
