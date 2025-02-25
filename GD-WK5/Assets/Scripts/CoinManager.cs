using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }
    public int coin = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool SpendCoins(int amount)
    {
        if (coin >= amount)
        {
            coin -= amount;
            return true;
        }
        return false;
    }

    public void EarnCoins(int amount)
    {
        coin += amount;
    }

    public int GetCoins()
    {
        return coin;
    }
}