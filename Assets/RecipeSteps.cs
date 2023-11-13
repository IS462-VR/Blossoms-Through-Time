using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeSteps : MonoBehaviour
{
    private List<string[]> recipes = new List<string[]>();
    public int currentRecipeNumber = 0;
    public int currentStep = 0;

    public GameObject strikethroughLine;
    public TextMeshProUGUI recipeNumberText;

    public TextMeshProUGUI recipeStepText;

    void Start()
    {
        // first recipe
        recipes.Add(new string[] {
            "Place the Neem Leaf in the mortar",
            "Crush or mash the Neem Leaf into a pulp",
            "Pour the pulp onto the bandage",
            "Use the bandage to wrap around the wound of soldier"
        });

        // second recipe
        recipes.Add(new string[] {
            "Retrieve hot water",
            "Place roselle bud on the center of the table",
            "Chop roselle bud into pieces",
            "Place roselle piece into water",
            "Serve to soldier",
            "Completed!",
            ""
        });

        strikethroughLine.SetActive(false);

        DisplayRecipeStep();
    }

    public void NextStep()
    {
        currentStep++;
        StartCoroutine(DelayedDisplayRecipeStep());
    }

    public void NextRecipe()
    {
        currentRecipeNumber++;
        StartCoroutine(DelayedDisplayRecipeStep());
    }

    void Update()
    {

        if (currentRecipeNumber == 0)
        {
            recipeNumberText.text = "Neem Compress";
        }
        else
        {
            recipeNumberText.text = "Roselle Tea";
        }


    }

    IEnumerator DelayedDisplayRecipeStep()
    {
        if (currentStep < recipes[currentRecipeNumber].Length)

        {
            Debug.Log(currentStep);
            strikethroughLine.SetActive(true);
            yield return new WaitForSeconds(1.5f);
        }

        DisplayRecipeStep();
        strikethroughLine.SetActive(false);
    }

    void DisplayRecipeStep()
    {
        if (currentStep < recipes[currentRecipeNumber].Length)
        {
            Debug.Log("Current Step:" + currentStep);
            Debug.Log("Total Recipe Step:" + recipes[currentRecipeNumber].Length);
            recipeStepText.text = recipes[currentRecipeNumber][currentStep];

        }
        if (currentStep == recipes[currentRecipeNumber].Length - 1)
        {
            Debug.Log("Current Step:" + currentStep);
            Debug.Log("Total Recipe Step:" + recipes[currentRecipeNumber].Length);
            recipeStepText.text = recipes[currentRecipeNumber][currentStep];
            currentStep = 0;
            Debug.Log("New Current Step:" + currentStep);

            
        }
    }

}


