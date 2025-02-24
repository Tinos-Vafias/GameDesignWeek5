using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;
    public TMP_Text itemPriceText;  
    public Button buyButton;

    private int basePrice;
    private int upgradeLevel;
    private System.Func<int> getUpgradeLevel;
    private System.Action onPurchase;

    // public void Setup(string name, string description, int basePrice, System.Func<int> getUpgradeLevel, System.Action purchaseCallback)
    public void Setup(string name, string description, int basePrice)
    {
        itemNameText.text = name;
        itemDescriptionText.text = description;
        this.basePrice = basePrice;
        // this.getUpgradeLevel = getUpgradeLevel;
        // onPurchase = purchaseCallback;

        // UpdatePrice();
        buyButton.onClick.AddListener(BuyItem);
    }

    void UpdatePrice()
    {
        int currentLevel = getUpgradeLevel();
        int price = basePrice + (currentLevel * 10);  // Example: Price increases by 10 per level
        itemPriceText.text = price.ToString() + " Coins";
    }

    void BuyItem()
    {
        GoldManager.Instance.SpendGold(basePrice);
    }
}