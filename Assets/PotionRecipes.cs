using UnityEngine;

[System.Serializable]
public class PotionRecipes
{
    public int potionNumber;
    public IngredientInfo ingredientA;
    public IngredientInfo ingredientB;
    public string potionName;
    public Sprite potionIcon;
    [TextArea]
    public string potionDescription;
}
