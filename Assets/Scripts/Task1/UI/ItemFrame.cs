using UnityEngine;
using UnityEngine.EventSystems;

public class ItemFrame : MonoBehaviour, IDropHandler
{
    private ItemSlot slot;
    private ITradable tradable;

    public void InitializeSlot(ItemSlot slot, ITradable tradable)
    {
        this.slot = slot;
        this.tradable = tradable;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var item = eventData.pointerDrag.GetComponent<ItemShow>();
            if (Droped(item))
            {
                if (slot != item.slot)
                {
                    slot.SetItems(item.slot.item,item.slot.amount);
                    item.slot.Clear();

                    var previos = GetComponentInChildren<ItemShow>();
                    if (previos != null) previos.gameObject.SetActive(false);

                    item.UpdateInfo(slot, tradable);
                }
                eventData.pointerDrag.transform.SetParent(transform);
            }
            
        }
    }

    private bool Droped(ItemShow item)
    {
        if (!slot.ContainSomething() || slot.item == item.slot.item)
        {
            if (slot.item != null && slot.amount + item.slot.amount > slot.item.maxInStack) return false;
            if (item.tradable == tradable) return true;
            else
            {
                if (tradable.EnoughMoneyToBuy(item.slot, item.tradable.GetSellCoeff()))
                {
                    tradable.BuyItem(item.tradable, item.slot);
                    return true;
                }
                else return false;
            }
        }
        return false;
    }
}