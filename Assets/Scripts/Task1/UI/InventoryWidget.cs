using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWidget : MonoBehaviour
{
    [SerializeField] private ItemFrame framePrefab;
    [SerializeField] private Transform framesParent;
    [SerializeField] private GridLayoutGroup layoutGroup;
    [SerializeField] private TextMeshProUGUI inventoryName;

    private ItemFrame[] frames;

    public void InitializePanel(ITradable tradable, Inventory inventory)
    {
        inventoryName.text = inventory.inventoryName;

        frames = new ItemFrame[inventory.slots.Length];
        layoutGroup.enabled = true;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            frames[i] = Instantiate(framePrefab, framesParent);

            frames[i].InitializeSlot(inventory.slots[i], tradable);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.transform as RectTransform);
        layoutGroup.enabled = false;
    }

    public ItemFrame GetFrame(int id)
    {
        return frames[id];
    }
}