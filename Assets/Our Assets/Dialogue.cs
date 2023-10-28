using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    public string[] lines;
    public float textSpeed;

    // to track which part of convo
    private int index;

    private bool inContact = false;  // Add this flag

    private bool dialogueStarted = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch something");

        if (other.CompareTag("Player"))
        {
            Debug.Log("touch player");

            inContact = true;
            //textComponent.text = string.Empty;
            StartDialogue();

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        inContact = false;  
    //    }
    //}

    private void Start()
    {
        textComponent.text = string.Empty;
        //StartDialogue();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && dialogueStarted )
        {
            if(textComponent.text == lines[index])
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


    void StartDialogue()
    {
        index = 0;
        dialogueStarted = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {

        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
