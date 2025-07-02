using UnityEngine;
using UnityEngine.EventSystems;
public class IngredientClick : MonoBehaviour, IPointerClickHandler
{
    public IngredientInfo ingredientInfo;
    public IngredientInfoDisplay infoDisplay;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (ingredientInfo != null && infoDisplay != null)
        {
            infoDisplay.showInfo(ingredientInfo);
        }
        else
        {
            Debug.LogWarning("CauldronManager reference missing!");
        }
    }
}