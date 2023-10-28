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
    private bool dialogueStarted = false;

    private TriggerDialogue triggerDialogue; // Reference to the TriggerDialogue script

    public static Dialogue instance;

    private void Start()
    {
        Debug.Log("this dialogue running");
        //gameObject.SetActive(false);
        triggerDialogue = gameObject.AddComponent<TriggerDialogue>(); // Get a reference to the TriggerDialogue script
        Debug.Log(triggerDialogue);
    }

    private void Update()
    {

        Debug.Log(triggerDialogue.IsInContact());

        if(triggerDialogue != null && triggerDialogue.IsInContact() && Input.GetMouseButtonDown(0))
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


    public void StartDialogue()
    {
        Debug.Log("start dialogue is running");
        index = 0;
        dialogueStarted = true;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {

        foreach (char c in lines[index].ToCharArray())
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
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueStarted = false;
            textComponent.text = string.Empty;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }

            gameObject.SetActive(false);
        }
    }

}
