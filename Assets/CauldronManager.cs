using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class CauldronManager : MonoBehaviour
{
    public PotionResultsScreen resultScreen;
    public List<PotionRecipes> recipes;
    public Image potionIcon;
    public TextMeshProUGUI potionName;
    public TextMeshProUGUI potionDescription;
    private List<IngredientInfo> currentIngredients = new List<IngredientInfo>();

    public GameObject cauldronObject;
    public GameObject restartButton;
    public void AddIngredient(IngredientInfo ingredient)
    {
        Debug.Log("Trying to add ingredient");
        currentIngredients.Add(ingredient);
        if (currentIngredients.Count == 2)
        {
            TryBrew();
        }
    }

    void TryBrew()
    {
        Debug.Log($"Trying to brew with {currentIngredients.Count} ingredients and {recipes.Count} recipes.");
        if (cauldronObject != null)
        {
            cauldronObject.transform.SetAsFirstSibling(); // send to back of parent canvas
        }
        foreach (var recipe in recipes)
        {
            if (Matches(recipe.ingredientA, recipe.ingredientB))
            {
                ShowResult(recipe);
                currentIngredients.Clear();
                return;
            }
        }
        ShowFailedBrew();
        currentIngredients.Clear();
        return;
    }

    bool Matches(IngredientInfo a, IngredientInfo b)
    {
        Debug.Log($"Comparing: {currentIngredients[0].IngredientName} + {currentIngredients[1].IngredientName}  with  {a.IngredientName} + {b.IngredientName}");
        return (currentIngredients[0] == a && currentIngredients[1] == b) || (currentIngredients[0] == b && currentIngredients[1] == a);
    }

    void ShowResult(PotionRecipes recipes)
    {
        resultScreen.ShowPotionResult(recipes.potionName, recipes.potionDescription, recipes.potionIcon);
        Debug.Log("Brewed: " + recipes.potionName);
    }
    void ShowFailedBrew()
    {
        potionIcon.sprite = null;
        potionName.text = "Failed brew";
        potionDescription.text = "The potion fizzles... and does absolutely nothing. Good thing it didn't explode though.";
        Debug.Log("No matching recipe!");
    }
    public void RestartGame()
    {
        currentIngredients.Clear();
        resultScreen.HidePanel();
        restartButton.SetActive(false);
        cauldronObject.SetActive(true);
        Debug.Log("Game Restarted!");
    }
}