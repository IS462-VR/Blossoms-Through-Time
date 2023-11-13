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
            //"Recipe completed!"
        });

        // second recipe
        recipes.Add(new string[] {
            "Retrieve hot water",
            "Place roselle bud on the center of the table",
            "Chop roselle bud into pieces",
            "Place roselle piece into water",
            "Serve to soldier",
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

        //if (recipeStepText.text == "" && currentRecipeNumber == 1)
        //{
        //    // transform.parent.gameObject.SetActive(false);
        //    gameObject.SetActive(false);
        //}

    }

    IEnumerator DelayedDisplayRecipeStep()
    //{   if(currentStep == recipes[currentRecipeNumber].Length || (recipeStepText.text == "Recipe completed!" && currentRecipeNumber == 1))
    {
        if (currentStep < recipes[currentRecipeNumber].Length)

        {
            Debug.Log(currentStep);
            strikethroughLine.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            //strikethroughLine.SetActive(false);
            //yield return new WaitForSeconds(1.5f);
        }
        //else
        //{
        //    strikethroughLine.SetActive(true);
        //    yield return new WaitForSeconds(1.5f);
        //}
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

            //if (currentRecipeNumber == 0)
            //{
            //    currentRecipeNumber++;
            //    recipeStepText.text = recipes[currentRecipeNumber][currentStep];
            //}
            //else
            //{
            //    transform.parent.gameObject.SetActive(false);
            //}
        }
    }

}


//void DisplayRecipeStep()
//    {
//        if (currentStep < recipes[currentRecipeNumber].Length)
//        {
//            recipeStepText.text = recipes[currentRecipeNumber][currentStep];
//        }
//        else if (currentStep == recipes[currentRecipeNumber].Length)
//        {
//            // Display "Recipe completed" for the last step
//            recipeStepText.text = "Recipe completed!";
//            //currentStep++;
//        }
//        else
//        {
//            // Move to the next recipe
//            currentStep = 0;
//            if (currentRecipeNumber == 0)
//            {
//                //currentRecipeNumber++;
//            }
//            else
//            {
//                // Hide the object or perform any other actions when both recipes are completed
//                gameObject.SetActive(false);
//                return;
//            }

//            // Display the first step of the new recipe
//            recipeStepText.text = recipes[currentRecipeNumber][currentStep];
//            //currentStep++;
//        }
//    }
//}