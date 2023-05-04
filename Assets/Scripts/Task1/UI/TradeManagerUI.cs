using UnityEngine;

public class TradeManagerUI : MonoBehaviour
{
    [SerializeField] private InventoryWidget leftWidget;
    [SerializeField] private InventoryWidget rightWidget;

    [SerializeField] private ItemShow itemPrefab;
    private MonoPool<ItemShow> itemsPool;

    private void Awake()
    {
        TradeManager.UpdateTradeWidgetsEvent.AddListener(UpdateInfo);
    }

    public void UpdateInfo(ITradable left, ITradable right)
    {
        leftWidget.InitializePanel(left, left.GetInventory());
        rightWidget.InitializePanel(right, right.GetInventory());

        if (itemsPool == null)
        {
            int poolCount = left.GetInventory().GetUsedSlotsCount() + right.GetInventory().GetUsedSlotsCount();
            itemsPool = new MonoPool<ItemShow>(itemPrefab, poolCount, true);
        }

        InitializeItems(left.GetInventory(), leftWidget, left);
        InitializeItems(right.GetInventory(), rightWidget, right);
    }

    private void InitializeItems(Inventory inventory, InventoryWidget widget, ITradable tradable)
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].ContainSomething())
            {
                var frame = widget.GetFrame(i);
                var item = itemsPool.GetElement(); 
                item.gameObject.SetActive(true);
                item.transform.SetParent(frame.transform, false);
                item.UpdateInfo(inventory.slots[i], tradable);
            }
        }
    }
}