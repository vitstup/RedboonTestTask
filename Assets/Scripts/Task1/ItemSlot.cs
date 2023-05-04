using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    [field: SerializeField] public Item item { get; private set; } 
    [field: SerializeField] public int amount { get; private set; } 

    public bool ContainSomething()
    {
        return item != null && amount > 0;
    }

    public void Clear()
    {
        item = null;
        amount = 0;
    }

    public void SetItems(Item item, int amount)
    {
        this.item = item;
        this.amount += amount;
    }

    public void RemoveItems(int amount)
    {
        this.amount -= amount;
    }

    public float GetTotalPrice()
    {
        return amount * item.price;
    }
}