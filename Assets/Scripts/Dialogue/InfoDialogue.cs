using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public bool isGrabbed = false;
    

    public string[] lines;
    public float textSpeed;

    // to track which line
    private int index;

    // private void Awake() {
    //     _canvasGrp = GetComponent<CanvasGroup>();
    //     Hide();

    //     _hasActiveDialogue = false;
    // }

    // private void Show() { _canvasGrp.alpha = 1.0f; }
    // private void Hide() { _canvasGrp.alpha = 0.0f; }

    // private bool _hasActiveDialogue = false;
    // private Coroutine _typeLineCoroutine = null;
    void Start() 
    {   
        textComponent.text = string.Empty;
    }
    private void Update()
    {
        // if(_hasActiveDialogue && Input.GetMouseButtonDown(0)) {
        // if(Input.GetMouseButtonDown(0)) {
        //     //Debug.Log(textComponent.text);
        //     if (textComponent.text == lines[index])
        //     {
        //         NextLine();
        //     }
        //     else
        //     {
        //         StopAllCoroutines();
        //         textComponent.text = lines[index];
        //     }
        // }
        
        // if gameobject is grabbed
        // grabber = GameObject.Find("RightHandAnchor").GetComponent<OVRGrabber>();
        // if (grabber.grabbedObject == gameObject)
        // {
        //     gameObject.activeSelf = true;
        // }
    }

    public void CanGrab() 
    {
        isGrabbed = true;
        textComponent.text = string.Empty;
        StartInfo();
    }
    public void StartInfo() {
        // Debug.Log("start dialogue is running");
        index = 0;
        StartCoroutine(TypeLine());
        // dialogueStarted = true;
        // textComponent.text = string.Empty;
        // Show();
        // _hasActiveDialogue = true;
        // if (_typeLineCoroutine != null) StopCoroutine(_typeLineCoroutine);
        // _typeLineCoroutine = StartCoroutine(TypeLine());
    }


    IEnumerator TypeLine()
    {
        while (index < lines.Length)
        {
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            } 
            
            yield return new WaitForSeconds(1.5f);
            index++;
            textComponent.text = string.Empty;
        }
        if (index == lines.Length)
        {
            StartInfo();
        }

    }

}
