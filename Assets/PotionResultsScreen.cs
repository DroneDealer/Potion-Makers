using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PotionResultsScreen : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI potionName;
    public TextMeshProUGUI potionDescription;
    public Image potionIcon;
    public void Start()
    {
        resultPanel.SetActive(false);
    }

    public void ShowPotionResult(string name, string description, Sprite Icon)
    {
        potionName.text = name;
        potionDescription.text = description;
        potionIcon.sprite = Icon;
        resultPanel.SetActive(true);
    }

    public void HidePanel()
    {
        resultPanel.SetActive(false);
    }

}