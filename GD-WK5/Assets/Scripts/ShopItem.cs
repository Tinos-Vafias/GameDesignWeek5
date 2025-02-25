using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;
    public TMP_Text itemPriceText;  
    public Button buyButton;

    private int price;
    private int upgradeLevel;
    private System.Func<int> getUpgradeLevel;
    private System.Action onPurchase;

    // public void Setup(string name, string description, int basePrice, System.Func<int> getUpgradeLevel, System.Action purchaseCallback)
    public void Setup(string name, string description, int price)
    {
        itemNameText.text = name;
        itemDescriptionText.text = description;
        itemPriceText.text = $"${price}";

        this.price = price;
        // this.getUpgradeLevel = getUpgradeLevel;
        // onPurchase = purchaseCallback;

        // UpdatePrice();
        buyButton.onClick.AddListener(BuyItem);
    }

    void UpdatePrice()
    {
        
    }

    void BuyItem()
    {
        CoinManager.Instance.SpendCoins(price);
        ShopManager.Instance.UpdateUI();
    }
}