using UnityEngine;

namespace LuciferGamingStudio.InventorySystem
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class ItemSO : ScriptableObject
    {
        public ItemType itemType;
        public int itemID;
        public string itemName;
        public int itemAmountInInventory;
        public float purchasePrice;
        public float sellPrice;
        public Sprite itemIcon;
        public GameObject itemPrefab;
    }
}
