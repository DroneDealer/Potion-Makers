using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PotionInfoDisplay : MonoBehaviour
{
    public GameObject potionBookPanel;
    public TextMeshProUGUI potionNameText;
    public TextMeshProUGUI potionDescriptionText;
    public Image potionIconImage;
    private PotionRecipes currentPotion = null;
    private void Start()
    {
        if (potionBookPanel != null)
        {
            potionBookPanel.SetActive(false);
        }
    }
    public void ShowInfo(PotionRecipes potion)
    {
        currentPotion = potion;
        potionNameText.text = potion.potionName;
        potionDescriptionText.text = potion.potionDescription;
        potionIconImage.sprite = potion.potionIcon;
        if (potionBookPanel != null)
        {
            potionBookPanel.SetActive(true);
        }
    }

    public void hideInfo()
    {
        if (potionBookPanel != null)
        {
            potionBookPanel.SetActive(false);
            currentPotion = null;
        }
    }

    public void ToggleInfo()
    {
        potionBookPanel.SetActive(!potionBookPanel.activeSelf);
    }

    public bool IsVisible()
    {
        return potionBookPanel != null && potionBookPanel.activeSelf;
    }

    public PotionRecipes GetCurrentPotion()
    {
        return currentPotion;
    }
}
