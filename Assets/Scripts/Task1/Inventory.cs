using UnityEngine;

[System.Serializable]
public class Inventory 
{
    [field: SerializeField] public string inventoryName { get; private set; }
    [field: SerializeField] public ItemSlot[] slots { get; private set; }

    public Inventory(int slotsAmount)
    { 
        slots = new ItemSlot[slotsAmount];
    }

    public Inventory(ItemSlot[] slots)
    {
        this.slots = slots;
    }

    public int GetUsedSlotsCount()
    {
        int used = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].ContainSomething()) used++;
        }
        return used;
    }

    public void RemoveOverStackItems()
    {
        
    }
}