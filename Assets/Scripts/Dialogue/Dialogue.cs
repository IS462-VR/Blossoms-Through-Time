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
    private int index = 0;
    private bool dialogueStarted = false;
    private bool dialogueFinished = false;


    private void Awake() {
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
        if(_hasActiveDialogue && Input.GetMouseButtonDown(0)) {
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


    public void LoadDialogueLines(string[] newLinesToBeLoaded) {
        lines = newLinesToBeLoaded;
        //if (dialogueFinished)
        //{
        //    lines = new string[];
        //}
    }

    public void StartDialogue() {
        if (!dialogueStarted) {

            if (dialogueFinished)
            {
                return;
            }

            dialogueStarted = true;
            textComponent.text = string.Empty;
            Show();
            _hasActiveDialogue = true;
            if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
            _typeLineCoroutine = StartCoroutine(TypeLine());
        }
        else
        {
            
            if(index < lines.Length - 1)
            {
                index++;
                Show();
                textComponent.text = string.Empty;
                _hasActiveDialogue = true;
                if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
                _typeLineCoroutine = StartCoroutine(TypeLine());
                Debug.Log("under here. convo started before");
            }
            
           
        }
       
    }

    public void EndDialogue() {
        Debug.Log("dialogueended");
        if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
        Hide();
        _hasActiveDialogue = false;
        //dialogueStarted = false;
        // added this
        //lines = null;
        if (index == lines.Length)
        {
            dialogueFinished = true;
        }

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
        if(index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
            _typeLineCoroutine = StartCoroutine(TypeLine());
        }
        else { EndDialogue(); }
    }

}
