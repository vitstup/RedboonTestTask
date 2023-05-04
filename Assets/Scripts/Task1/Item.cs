using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [field: SerializeField] public float price { get; private set; }   
    [field: SerializeField] public Sprite sprite { get; private set; }   
    [field: SerializeField] public int maxInStack { get; private set; }   
}