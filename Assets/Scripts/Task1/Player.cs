using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, ITradable
{
    public class PlayerMoneyEvent : UnityEvent<float> { }
    public static PlayerMoneyEvent PlayerMoneyChangedEvent = new PlayerMoneyEvent();

    [field: SerializeField] public Wallet wallet;
    [field: SerializeField] public Inventory inventory;

    private void Start()
    {
        PlayerMoneyChangedEvent?.Invoke(wallet.money);
    }

    public float GetSellCoeff()
    {
        return 0.9f;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public void BuyItem(ITradable seller, ItemSlot slot)
    {
        wallet.RemoveMoney(slot.GetTotalPrice() * seller.GetSellCoeff());
        PlayerMoneyChangedEvent?.Invoke(wallet.money);
    }
    public void GetSellReward(float reward)
    {
        wallet.AddMoney(reward);
        PlayerMoneyChangedEvent?.Invoke(wallet.money);
    }

    public bool EnoughMoneyToBuy(ItemSlot slot, float sellCoef)
    {
        return slot.item.price * slot.amount * sellCoef <= wallet.money;
    }
}