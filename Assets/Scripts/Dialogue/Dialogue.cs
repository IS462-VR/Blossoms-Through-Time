using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private CanvasGroup _canvasGrp = null;

    public string[] lines;
    public float textSpeed;

    // to track which part of convo
    private int index;
    private bool dialogueStarted = false;

    private void Awake()
    {
        _canvasGrp = GetComponent<CanvasGroup>();
        Hide();

        _hasActiveDialogue = false;
    }

    private void Show() { _canvasGrp.alpha = 1.0f; }
    private void Hide() { _canvasGrp.alpha = 0.0f; }

    private bool _hasActiveDialogue = false;
    private Coroutine _typeLineCoroutine = null;
    private void Update()
    {
        if (_hasActiveDialogue && Input.GetMouseButtonDown(0))
        {
            //Debug.Log(textComponent.text);
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

    }


    public void LoadDialogueLines(string[] newLinesToBeLoaded)
    {
        lines = newLinesToBeLoaded;
    }

    public void StartDialogue()
    {
        Debug.Log("start dialogue is running");
        index = 0;
        dialogueStarted = true;
        textComponent.text = string.Empty;
        Show();
        _hasActiveDialogue = true;
        if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
        _typeLineCoroutine = StartCoroutine(TypeLine());
    }

    public void EndDialogue()
    {
        if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
        Hide();
        _hasActiveDialogue = false;
        dialogueStarted = false;
    }


    IEnumerator TypeLine()
    {

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
            _typeLineCoroutine = StartCoroutine(TypeLine());
        }
        else { EndDialogue(); }
    }

}
