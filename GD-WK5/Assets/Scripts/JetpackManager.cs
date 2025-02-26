using UnityEngine;
using UnityEngine.SceneManagement;

public class JetpackManager : MonoBehaviour
{
    public static JetpackManager Instance { get; private set; }

    private int jetpackLevel = 0;
    private int jetpackBasePrice = 10;
    private float jetpackFlyTime = 1.5f;

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
        ApplyJetpackToPlayer();
    }

    public void UpgradeJetpack()
    {
        jetpackLevel++;
        jetpackFlyTime += 0.5f;
        Debug.Log("Jetpack Upgraded! New Fly Time: " + jetpackFlyTime + " | Level: " + jetpackLevel);
    }

    public int GetJetpackLevel()
    {
        return jetpackLevel;
    }

    public int GetJetpackPrice()
    {
        return jetpackBasePrice * (int)Mathf.Pow(10, jetpackLevel);
    }

    private void ApplyJetpackToPlayer()
    {
        if (PlayerInfo.Instance != null)
        {
            PlayerInfo.Instance.maxFlyTime = jetpackFlyTime;
            Debug.Log("Applied Jetpack Fly Time to Player: " + jetpackFlyTime);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}