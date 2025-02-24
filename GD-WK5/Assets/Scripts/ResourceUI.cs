using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ironText;
    [SerializeField] private TMP_Text goldText;

    private void Update()
    {
        ironText.text = "Iron: " + PlayerManager.Instance.GetResourceAmount("Iron");
        goldText.text = "Gold: " + PlayerManager.Instance.GetResourceAmount("Gold");
    }
}
