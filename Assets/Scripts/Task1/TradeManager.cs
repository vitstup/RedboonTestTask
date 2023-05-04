using UnityEngine;
using UnityEngine.Events;

public class TradeManager : MonoBehaviour
{
    public class TradeManagerTradersEvent : UnityEvent<ITradable, ITradable> { }
    public static TradeManagerTradersEvent UpdateTradeWidgetsEvent = new TradeManagerTradersEvent();
    [SerializeField] private Player player;
    [SerializeField] private Trader trader;

    private void Start()
    {
        UpdateTradeWidgetsEvent?.Invoke(player, trader);
    }
}