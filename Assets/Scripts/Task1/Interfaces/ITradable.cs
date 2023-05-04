public interface ITradable 
{
    public float GetSellCoeff();

    public Inventory GetInventory();

    public void BuyItem(ITradable seller, ItemSlot slot);

    public void GetSellReward(float reward);

    public bool EnoughMoneyToBuy(ItemSlot slot, float sellCoef);
}