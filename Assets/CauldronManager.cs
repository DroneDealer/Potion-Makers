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
            if (Matches(recipe.ingredientA, recipe.ingredientB) || Matches(recipe.ingredientA, recipe.ingredientB))
            {
                ShowResult(recipe);
                currentIngredients.Clear();
                return;
            }
        }
    }

    bool Matches(IngredientInfo a, IngredientInfo b)
    {
        return currentIngredients[0] == a && currentIngredients[1] == b;
    }

    void ShowResult(PotionRecipes recipes)
    {
        potionIcon.sprite = recipes.potionIcon;
        potionName.text = recipes.potionName;
        potionDescription.text = recipes.potionDescription;

        Debug.Log("Brewed: " + recipes.potionName);
    }
}