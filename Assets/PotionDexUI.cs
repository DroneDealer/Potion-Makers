using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PotionBookUI : MonoBehaviour
{
    [Header("Buttons")]
    public Button prevButton;
    public Button nextButton;

    [Header("Other")]
    public PotionInfoDisplay potionInfoDisplay;
    public GameObject wholeBookPanel;

    [Header("Audio")]
    public AudioClip pageFlipSound;
    private AudioSource audioSource;


 private List<PotionRecipes> discoveredPotions = new List<PotionRecipes>();
    private int currentPage = 0;
    private void OnEnable()
    {
        wholeBookPanel.SetActive(true);
        discoveredPotions = new List<PotionRecipes>(PotionDex.Instance.GetDiscoveredPotions());
        currentPage = 0;
        UpdatePage();
    }
    private void Start()
    {
        wholeBookPanel.SetActive(false);
        nextButton.onClick.AddListener(flipNext);
        prevButton.onClick.AddListener(flipPrev);
        audioSource = GetComponent<AudioSource>();
    }

    public void flipNext()
    {
        if (currentPage < discoveredPotions.Count - 1)
        {
            currentPage++;
            UpdatePage();
            audioSource.PlayOneShot(pageFlipSound);
        }
    }
    public void flipPrev()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdatePage();
            audioSource.PlayOneShot(pageFlipSound);
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
