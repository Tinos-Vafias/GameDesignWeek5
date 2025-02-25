using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ironText;
    [SerializeField] private TMP_Text goldText;

    private void Update()
    {
        //keep receiving errors
        //goldText.text = "Coins: " + PlayerManager.Instance.GetResourceAmount("Gold");
    }
}
