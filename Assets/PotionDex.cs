using System.Collections.Generic;
using UnityEngine;

public class PotionDex : MonoBehaviour
{
    public static PotionDex Instance;
    private HashSet<PotionRecipes> discoveredPotions = new HashSet<PotionRecipes>();
    private void Awake()
    {
        Debug.Log("Potion Awake called!");
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //Debugging
    public void OnEnable()
    {
        if (PotionDex.Instance == null)
        {
            Debug.Log("No Instance Called!");
        }
    }
    //Debugging
    public void RegisterPotion(PotionRecipes newPotion)
    {
        Debug.Log("Registering: " + newPotion.potionName + " | Total: " + discoveredPotions.Count);
        if (!discoveredPotions.Contains(newPotion))
        {
            discoveredPotions.Add(newPotion);
            //add an exclamation: "NEW!" in the UI panel when a new potion is discovered
            Debug.Log("New potion discovered: " + newPotion.potionName);
        }
    }
    public bool IsPotionDiscovered(PotionRecipes potion)
    {
        return discoveredPotions.Contains(potion);
    }
    public IEnumerable<PotionRecipes> GetDiscoveredPotions()
    {
        return discoveredPotions;
    }

}