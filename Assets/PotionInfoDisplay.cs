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
    public void ShowInfo(PotionRecipes potion, int index)
    {
        if (potion == null)
        {
            Debug.LogWarning("[ShowInfo] Received null potion.");
            return;
        }

        currentPotion = potion;
        potionNameText.text = $"#{index + 1}: {potion.potionName}";
        potionDescriptionText.text = potion.potionDescription;
        potionIconImage.sprite = potion.potionIcon;

        if (potionBookPanel != null && !potionBookPanel.activeSelf)
        {
            potionBookPanel.SetActive(true);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(potionNameText.rectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(potionDescriptionText.rectTransform);
    }


    public void hideInfo()
    {
        if (potionBookPanel != null)
        {
            potionBookPanel.SetActive(false);
            currentPotion = null;
        }
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
