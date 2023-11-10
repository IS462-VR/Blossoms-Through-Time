using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeSteps : MonoBehaviour
{
    private List<string[]> recipes = new List<string[]>();
    private int currentRecipeNumber = 0;
    private int currentStep = 0;

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
            "Use the bandage to wrap around the wound",
            "Recipe completed!"
        });

        // second recipe
        recipes.Add(new string[] {
            "Grab the Roselle and dissolve it in water",
            "Drink the Roselle water",
            "Hold the bowl and pour the paste onto the bandage",
            "Grab the bandage and wrap it around the wound",
            "Recipe completed!",
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

    void Update()
    {

        if(currentRecipeNumber == 0)
        {
            recipeNumberText.text = "Recipe 1";
        }
        else
        {
            recipeNumberText.text = "Recipe 2";
        }

        if(recipeStepText.text == "" && currentRecipeNumber == 1)
        {
            // transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

    }

    IEnumerator DelayedDisplayRecipeStep()
    {   if(currentStep == recipes[currentRecipeNumber].Length || (recipeStepText.text == "Recipe completed!" && currentRecipeNumber == 1))
        {
            strikethroughLine.SetActive(false);
        }
        else
        {
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
            recipeStepText.text = recipes[currentRecipeNumber][currentStep];
        }
        else
        {
            currentStep = 0;
            if(currentRecipeNumber == 0)
            {
                currentRecipeNumber++;
                recipeStepText.text = recipes[currentRecipeNumber][currentStep];
            }
            else
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

}