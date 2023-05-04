using TMPro;
using UnityEngine;

public class MoneyWidget : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI money;

    private void Awake()
    {
        Player.PlayerMoneyChangedEvent.AddListener(ChangeText);
    }

    private void ChangeText(float money)
    {
        this.money.text = ((int)money).ToString();
    }
}