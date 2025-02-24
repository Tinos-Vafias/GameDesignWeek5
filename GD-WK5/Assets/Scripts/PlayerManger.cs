using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance; // Singleton for easy access

    private Dictionary<string, int> resources = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddResource(string resourceType, int amount)
    {
        if (resources.ContainsKey(resourceType))
            resources[resourceType] += amount;
        else
            resources[resourceType] = amount;
    }

    public int GetResourceAmount(string resourceType)
    {
        return resources.ContainsKey(resourceType) ? resources[resourceType] : 0;
    }
}
