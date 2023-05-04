using UnityEngine;

public class Trader : MonoBehaviour, ITradable
{
    [field: SerializeField] public Inventory inventory;

    public float GetSellCoeff()
    {
        return 1.1f;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public void BuyItem(ITradable seller, ItemSlot slot)
    {
        seller.GetSellReward(slot.GetTotalPrice() * seller.GetSellCoeff());
    }

    public void GetSellReward(float reward)
    {
        //
    }

    public bool EnoughMoneyToBuy(ItemSlot slot, float sellCoef)
    {
        return true;
    }
}