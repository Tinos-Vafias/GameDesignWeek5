using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    private Light2D light2D;
    private float radiusIncreaseAmount = 2f;  // Amount to increase radius by

    void Start()
    {
        light2D = GetComponent<Light2D>();
        
        if (light2D == null)
        {
            Debug.LogError("Light2D component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        // Increase light radius when pressing the 'L' key (for testing)
        if (Input.GetKeyDown(KeyCode.L))
        {
            UpgradeLightRadius();
        }
    }

    public void UpgradeLightRadius()
    {
        if (light2D != null)
        {
            light2D.pointLightOuterRadius += radiusIncreaseAmount
        }
    }

    public float GetLightRadius()
    {
        return light2D != null ? light2D.pointLightOuterRadius : 0f;
    }
}