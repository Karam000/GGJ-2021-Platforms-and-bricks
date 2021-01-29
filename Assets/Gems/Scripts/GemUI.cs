using UnityEngine;
using TMPro;
using SO.Events;
using SO;

public class GemUI : MonoBehaviour
{
    [SerializeField] EventSO onGemCollected;
    [SerializeField] TextMeshProUGUI gemText;
    VariableSO<int> gemsNumber;
    private void Awake()
    {
        gemsNumber = (VariableSO<int>)onGemCollected.Value;
    }
    public void UpdateGemsText()
    {
        gemText.text = gemsNumber.ToString();
    }
}
