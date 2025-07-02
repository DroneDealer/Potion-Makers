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
    public void AddIngredient(IngredientInfo ingredient)
    {
        currentIngredients.Add(ingredient);
        if (currentIngredients.Count == 2)
        {
            TryBrew();
        }
    }

    void TryBrew()
    {
        foreach (var recipe in recipes)
        {
            if (Matches(recipe.ingredientA, recipe.ingredientB))
            {
                ShowResult(recipe);
                currentIngredients.Clear();
                return;
            }
            ShowFailedBrew();
            currentIngredients.Clear();
        }
    }

    bool Matches(IngredientInfo a, IngredientInfo b)
    {
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
}