using UnityEngine;

[System.Serializable]
public class Wallet 
{
    [field: SerializeField] public float money { get; private set; }

    public Wallet() { }

    public Wallet(float money)
    {
        this.money = money;
    }

    public void AddMoney(float money)
    {
        this.money += money;
        Debug.Log(string.Format("Added {0} money", money));
    }

    public void RemoveMoney(float money)
    {
        if (this.money >= money) 
        {
            this.money -= money;
            Debug.Log(string.Format("Removed {0} money", money));
        }
        else
        {
            this.money = 0;
            Debug.LogWarning("You're trying to remove more money than ypu have");
        }
    }
}