using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }  

    public TMP_Text playerCoinsText;
    public ShopItem[] shopItems; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        UpdateUI();
        SetupShopItems();
    }

    public void UpdateUI()
    {
        UpdateCoins();
    }

    void SetupShopItems()
    {
        shopItems[0].Setup("Shovel Strength", "Increases shovel strength", 20);
        shopItems[1].Setup("Shovel Range", "Increase shovel radius", 15);
        shopItems[2].Setup("Jetpack Strength", "Increase jetpack vertical strength", 25);
        shopItems[3].Setup("Light Range", "Increase light radius", 30);
    }

    void UpdateCoins() 
    {
        playerCoinsText.text = $"${CoinManager.Instance.GetCoins()}";
    }

    public void GoToNextScene()
    {
        Debug.Log("here");
        SceneManager.LoadScene("Map"); 
    }
}