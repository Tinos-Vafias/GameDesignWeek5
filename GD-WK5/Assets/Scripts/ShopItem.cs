using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public TMP_Text itemNameText;
    public TMP_Text itemDescriptionText;
    public TMP_Text itemPriceText;  
    public Button buyButton;

    private System.Action onPurchase;

    private int PRICE_INCREASE_FACTOR = 10;
    private int price;

    private int MAX_LEVEL = 5;
    private int level;

    // uncomment when we have upgrade functions
    // purchaseCallback is the function to be called on purchase. this would be the "upgrade" function that updates stats after purchase
    public void Setup(string name, string description, int price, int level, System.Action purchaseCallback)
    {
        itemNameText.text = name;
        itemDescriptionText.text = description;
    
        if (level == MAX_LEVEL) itemPriceText.text = "MAX LEVEL";
        else itemPriceText.text = $"${price}";
    
        this.price = price;
        this.level = level;
        onPurchase = purchaseCallback;
    
        buyButton.onClick.AddListener(BuyItem);
    }

    // use this before we have upgrade functions
    // public void Setup(string name, string description, int price)
    // {
    //     itemNameText.text = name;
    //     itemDescriptionText.text = description;
    //     itemPriceText.text = $"${price}";
    //
    //     this.price = price;
    //
    //     buyButton.onClick.AddListener(BuyItem);
    // }

    void UpdatePrice()
    {
        price *= PRICE_INCREASE_FACTOR;

        // uncomment later
        if (level == MAX_LEVEL) itemPriceText.text = "MAX LEVEL";
        else itemPriceText.text = $"${price}";

        itemPriceText.text = $"${price}";
    }

    void BuyItem()
    {
        // uncomment later
        if (MAX_LEVEL <= level) {
            Debug.Log("Max level reached.");
            return;
        }

        if (CoinManager.Instance.SpendCoins(price)) 
        {
            // uncomment this line when you have upgrade functions
            onPurchase?.Invoke();
            level++;
            ShopManager.Instance.UpdateUI();
            UpdatePrice();
        } 
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}