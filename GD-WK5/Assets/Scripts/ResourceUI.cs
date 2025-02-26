using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ironText;
    [SerializeField] private TMP_Text goldText;

    private void Update()
    {
        goldText.text = "Coins: " + PlayerManager.Instance.GetCoins();
    }
}
