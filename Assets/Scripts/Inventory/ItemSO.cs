using UnityEngine;

namespace LuciferGamingStudio.InventorySystem
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class ItemSO : ScriptableObject
    {
        public ItemType itemType;
        public string itemName;
        public Sprite itemIcon;
        public float purchasePrice;
        public float sellPrice;
    }
}
