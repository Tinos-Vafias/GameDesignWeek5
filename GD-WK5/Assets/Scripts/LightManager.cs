using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using System;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance { get; private set; }

    private Light2D light2D;
    private float radiusIncreaseAmount = 1f;
    private float currentRadius = 2f;
    private int level = 0;
    private int basePrice = 10;

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
        Debug.Log("Scene Loaded: " + scene.name);
        FindLight2D();
        LoadLight();
    }

    public void UpgradeLightRadius()
    {
        currentRadius += radiusIncreaseAmount;
        level += 1;
        Debug.Log("Upgraded Light Radius: " + currentRadius);
    }

    public float GetLightRadius()
    {
        return light2D != null ? light2D.pointLightOuterRadius : 0f;
    }

    private void FindLight2D()
    {
        Debug.Log("Finding Player Light2D...");
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null)
        {
            light2D = player.GetComponentInChildren<Light2D>(); 
            if (light2D == null)
            {
                Debug.LogWarning("No Light2D found on Player!");
            }
            else
            {
                Debug.Log("LightManager found Light2D on Player.");
            }
        }
        else
        {
            Debug.LogWarning("No Player found in the scene!");
        }
    }

    private void LoadLight()
    {
        if (light2D != null)
        {
            light2D.pointLightOuterRadius = currentRadius;
            Debug.Log("Applied Saved Light Radius: " + currentRadius);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public int GetLevel() {
        return level;
    }

    public int GetPrice() {
        return basePrice * (int)Math.Pow(10, level);
    }
}