using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PotionResultsScreen : MonoBehaviour
{
    public GameObject resultPanel;
    public TextMeshProUGUI potionName;
    public TextMeshProUGUI potionDescription;
    public Image potionIcon;
    private bool Active;
    public void Start()
    {
        //StartCoroutine(PreloadPanelLayout());
    }
    private void Update()
    {
        if (resultPanel.activeSelf != Active)
        {
            Debug.LogWarning($"[PotionResultsScreen] resultPanel active state changed to: {Active}");
            Active = resultPanel.activeSelf;
        }
    }
    public void ShowPotionResult(string name, string description, Sprite Icon)
    {
        //Debug.Log($"[PotionResultsScreen] Showing result: {name}, desc: {description}, icon: {(Icon != null ? Icon.name : "null")}");
        potionName.text = name;
        potionDescription.text = description;
        potionIcon.sprite = Icon;
        Debug.LogWarning("[ShowPotionResult] Enabling resultPanel");
        resultPanel.SetActive(true);
        resultPanel.transform.SetAsLastSibling();
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(resultPanel.GetComponent<RectTransform>());
        resultPanel.transform.localScale = Vector3.one;
        resultPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        var canvasGroup = resultPanel.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            Debug.Log($"[CanvasGroup] Alpha: {canvasGroup.alpha}, Interactable: {canvasGroup.interactable}");
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        Debug.Log("[PotionResultsScreen] final panel display complete");
    }
    // private IEnumerator PreloadPanelLayout()
    // {
    //     resultPanel.SetActive(true);
    //     yield return new WaitForSeconds(0.5f);
    //     resultPanel.SetActive(false);
    // }
    public void HidePanel()
    {
        Debug.Log("HidePanel called");
        resultPanel.SetActive(false);
    }

}