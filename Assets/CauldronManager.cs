using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class CauldronManager : MonoBehaviour
{
    public PotionResultsScreen resultScreen;
    public PotionDatabase potionDatabase;
    public Image potionIcon;
    public TextMeshProUGUI potionName;
    public TextMeshProUGUI potionDescription;
    private List<IngredientInfo> currentIngredients = new List<IngredientInfo>();
    public GameObject cauldronObject;
    public GameObject restartButton;
    public IngredientInfoDisplay infoDisplay;
    public PotionDexUI potionDexUI;

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
        if (potionDatabase == null || potionDatabase.recipes == null)
        {
            Debug.LogWarning("Potion database or recipes list is null!");
            return;
        }

        Debug.Log($"Trying to brew with {currentIngredients.Count} ingredients and {potionDatabase.recipes.Count} recipes.");

        foreach (var recipe in potionDatabase.recipes)
        {
            if (Matches(recipe.ingredientA, recipe.ingredientB))
            {
                ShowResult(recipe);
                currentIngredients.Clear();
                return;
            }
        }
        Debug.Log("No matching recipe found.");
        currentIngredients.Clear();
    }

    bool Matches(IngredientInfo a, IngredientInfo b)
    {
        if (currentIngredients.Count < 2 || currentIngredients[0] == null || currentIngredients[1] == null || a == null || b == null)
        {
            Debug.LogWarning("Null or insufficient ingredients detected in Matches");
            return false;
        }

        //Debug.Log($"Comparing: {currentIngredients[0].IngredientName} + {currentIngredients[1].IngredientName}  with  {a.IngredientName} + {b.IngredientName}");
        return (currentIngredients[0] == a && currentIngredients[1] == b) || (currentIngredients[0] == b && currentIngredients[1] == a);
    }
    void ShowResult(PotionRecipes recipe)
    {
        resultScreen.ShowPotionResult(recipe.potionName, recipe.potionDescription, recipe.potionIcon);
        restartButton.SetActive(true);
        Debug.Log("Brewed: " + recipe.potionName);
        // Register to the PotionDex
        if (PotionDex.Instance != null)
        {
            PotionDex.Instance.RegisterPotion(recipe);
        }
        if (infoDisplay != null && infoDisplay.IsVisible())
        {
            infoDisplay.hideInfo();
        }
        if (potionDexUI != null)
        {
            Debug.Log("[ShowResult] Forcing PotionDexUI refresh...");
            potionDexUI.ForceRefresh();
        }
    }

    private IEnumerator DelayedRefresh()
    {
        yield return null;
        potionDexUI.RefreshBook();
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