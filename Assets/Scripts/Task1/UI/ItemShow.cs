using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemShow : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI amount;

    public ItemSlot slot { get; private set; }
    public ITradable tradable { get; private set; }

    public void UpdateInfo(ItemSlot slot, ITradable tradable)
    {
        this.slot = slot;
        this.tradable = tradable;

        img.sprite = slot.item.sprite;
        if (slot.amount > 1) amount.text = slot.amount.ToString();
        else amount.text = "";
    }
}