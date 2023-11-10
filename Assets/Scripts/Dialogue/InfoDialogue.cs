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

    void Start() 
    {   
        textComponent.text = string.Empty;
    }
    private void Update()
    {
    }

    public void CanGrab() 
    {
        isGrabbed = true;
        textComponent.text = string.Empty;
        StartInfo();
    }
    public void StartInfo() {
        index = 0;
        StartCoroutine(TypeLine());
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
            if (index == 0)
            {
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return new WaitForSeconds(3f);
            }
            index++;
            textComponent.text = string.Empty;
        }
        if (index == lines.Length)
        {
            StartInfo();
        }

    }

}
