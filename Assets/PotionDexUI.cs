using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PotionBookUI : MonoBehaviour
{
    [Header("Left Page (Icon + Name)")]
    public Image PotionIcon;
    public TextMeshProUGUI PotionName;
    public TextMeshProUGUI PotionDescription;
    [Header("Right Page (Description)")]
    public TextMeshProUGUI rightPotionDescription;
    [Header("Buttons")]
    public Button prevButton;
    public Button nextButton;

    [Header("Other")]
    public PotionInfoDisplay potionInfoDisplay;


 private List<PotionRecipes> discoveredPotions = new List<PotionRecipes>();
    private int currentPage = 0;
    private void OnEnable()
    {
        discoveredPotions = new List<PotionRecipes>(PotionDex.Instance.GetDiscoveredPotions());
        currentPage = 0;
        UpdatePage();
    }
    private void Start()
    {
        nextButton.onClick.AddListener(flipNext);
        prevButton.onClick.AddListener(flipPrev);
    }

    private void flipNext()
    {
        if (currentPage < discoveredPotions.Count - 1)
        {
            currentPage++;
            UpdatePage();
        }
    }
    private void flipPrev()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdatePage();
        }
    }
    private void UpdatePage()
    {
        if (discoveredPotions.Count == 0)
        {
            potionInfoDisplay.hideInfo();
            return;
        }
        PotionRecipes currentPotion = discoveredPotions[currentPage];
        potionInfoDisplay.ShowInfo(currentPotion);
    }
}
