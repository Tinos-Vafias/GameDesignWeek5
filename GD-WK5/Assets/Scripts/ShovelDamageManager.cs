using UnityEngine;
using UnityEngine.SceneManagement;

public class ShovelDamageManager : MonoBehaviour
{
    public static ShovelDamageManager Instance { get; private set; }

    private int damageLevel = 0;
    private int damageBasePrice = 10;
    private int currentDamage = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyDamageToPlayer();
    }

    public void UpgradeDamage()
    {
        damageLevel++;
        currentDamage++;
        Debug.Log("Damage Upgraded! New Damage: " + currentDamage + " | Level: " + damageLevel);
    }

    public int GetDamageLevel()
    {
        return damageLevel;
    }

    public int GetDamagePrice()
    {
        return damageBasePrice * (int)Mathf.Pow(10, damageLevel);
    }

    private void ApplyDamageToPlayer()
    {
        if (PlayerInfo.Instance != null)
        {
            PlayerInfo.Instance.damage = currentDamage;
            Debug.Log("Applied Damage to Player: " + currentDamage);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}