using UnityEngine;
using UnityEngine.EventSystems;
public class IngredientClick : MonoBehaviour, IPointerClickHandler
{
    public IngredientInfo ingredientInfo;
    public IngredientInfoDisplay infoDisplay;
    public void OnPointerClick(PointerEventData eventData)
    {
        infoDisplay.showInfo(ingredientInfo);
    }
}
