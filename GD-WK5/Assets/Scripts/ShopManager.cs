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

        // example shop item setup when you have upgrade functions
        // shopItems[0].Setup(
        //     "Shovel Strength", // name
        //     "Increases shovel strength", // description
        //     Player.Instance.GetShovelStrengthPrice(), // current price, if level 1 may be 10, if level 2 may be 100 
        //     Player.Instance.GetShovelStrengthLevel(), // current level, helps shop item stop player from buying past max level
        //     () => Player.Instance.UpgradeShovelStrength()); // method to be called after purcahse. should upgrade stats
    }

    void UpdateCoins() 
    {
        playerCoinsText.text = $"${CoinManager.Instance.GetCoins()}";
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene("Map"); 
    }
}