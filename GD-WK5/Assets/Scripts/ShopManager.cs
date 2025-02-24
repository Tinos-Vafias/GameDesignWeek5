using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public TMP_Text playerGoldText;
    public ShopItem[] shopItems; 

    void Start()
    {
        UpdateUI();
        SetupShopItems();
    }

    void UpdateUI()
    {
        updateGold();
    }

    void SetupShopItems()
    {
        // TODO replace temp functions with actual upgrade functions
        shopItems[0].Setup("Shovel Strength", "Increases shovel strength", 20);
        shopItems[1].Setup("Shovel Range", "Increase shovel radius", 15);
        shopItems[2].Setup("Jetpack Strength", "Increase jetpack vertical strength", 25);
        shopItems[3].Setup("Light Range", "Increase light radius", 30);

        // shopItems[0].Setup("Shovel Strength", "Increases shovel strength", 20, () => {return temp_val*1;}, () => (Debug.Log("upgraded shovel strength")));
        // shopItems[1].Setup("Shovel Range", "Increase shovel radius", 15, () => (1), () => (Debug.Log("upgraded shovel range")));
        // shopItems[2].Setup("Jetpack Strength", "Increase jetpack vertical strength", 25, () => (1), () => (Debug.Log("upgraded jetpack strength")));
        // shopItems[3].Setup("Light Range", "Increase light radius", 30, () => (1), () => (Debug.Log("upgraded light range")));
    }

    void updateGold() 
    {
        playerGoldText.text = $"{GoldManager.Instance.GetGold()} G";
    }
}