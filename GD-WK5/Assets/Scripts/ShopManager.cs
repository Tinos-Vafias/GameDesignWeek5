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

    void Update()
    {
        UpdateUI();
    }


    public void UpdateUI()
    {
        UpdateCoins();
    }

    void SetupShopItems()
    {
        shopItems[0].Setup(
            "Shovel Strength", 
            "Increases shovel strength", 
            ShovelDamageManager.Instance.GetDamagePrice(), 
            ShovelDamageManager.Instance.GetDamageLevel(), 
            ShovelDamageManager.Instance.UpgradeDamage);

        shopItems[1].Setup(
            "Shovel Range", 
            "Increase shovel radius", 
            Hurtboxes.Instance.GetRangePrice(), 
            Hurtboxes.Instance.GetRangeLevel(), 
            Hurtboxes.Instance.UpgradeRange);  

        shopItems[2].Setup(
            "Jetpack Strength", 
            "Increase jetpack flight time", 
            JetpackManager.Instance.GetJetpackPrice(), 
            JetpackManager.Instance.GetJetpackLevel(), 
            JetpackManager.Instance.UpgradeJetpack);

        shopItems[3].Setup(
            "Light Range", 
            "Increase light radius", 
            LightManager.Instance.GetPrice(), 
            LightManager.Instance.GetLevel(), 
            LightManager.Instance.UpgradeLightRadius);
    }

    void UpdateCoins() 
    {
        playerCoinsText.text = $"${PlayerManager.Instance.GetCoins()}";
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene("Map"); 
    }
}