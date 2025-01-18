using LuciferGamingStudio.InventorySystem;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCardViewGUI : MonoBehaviour
{
    public ItemSO item;
    public TMP_Text itemName;
    public Image itemIcon;
    public TMP_Text itemsInHolder;
    public TMP_Text itemAmountInInventory;

    private ItemsHolder itemsHolder;

    private void Start()
    {
        itemsHolder = GetComponentInParent<ItemsHolder>();

        itemName.text = item.itemName;
        itemIcon.sprite = item.itemIcon;
        UpdateItemCard();
    }

    public void UpdateItemCard()
    {
        itemsInHolder.text = itemsHolder.itemsInHolder[item.itemID].ToString();
        itemAmountInInventory.text = "Inventory : " + item.itemAmountInInventory.ToString();
    }

    public void AddItem()
    {
        if(item.itemAmountInInventory > 0)
            itemsHolder.AddItem(item.itemID);
    }
    public void RemoveItem()
    {
        if (itemsHolder.itemsInHolder[item.itemID] > 0)
            itemsHolder.RemoveItem(item.itemID);
    }
}
