using LuciferGamingStudio.InventorySystem;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public ItemSO[] drinks;
    public ItemSO[] chips;
    public ItemSO[] cigarettes;
    public ItemSO[] candies;
    public ItemSO[] lotteryTickets;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void AddItem(ItemType type, int itemID, int amount)
    {
        switch (type)
        {
            case ItemType.Drink:
                drinks[itemID].itemAmountInInventory += amount;
                break;
            case ItemType.Chips:
                chips[itemID].itemAmountInInventory += amount;
                break;
            case ItemType.Ciggarette:
                cigarettes[itemID].itemAmountInInventory += amount;
                break;
            case ItemType.Candies:
                candies[itemID].itemAmountInInventory += amount;
                break;
            case ItemType.LotteryTicket:
                lotteryTickets[itemID].itemAmountInInventory += amount;
                break;
        }
    }

    public void RemoveItem(ItemType type, int itemID)
    {
        switch (type)
        {
            case ItemType.Drink:
                drinks[itemID].itemAmountInInventory--;
                break;
            case ItemType.Chips:
                chips[itemID].itemAmountInInventory--;
                break;
            case ItemType.Ciggarette:
                cigarettes[itemID].itemAmountInInventory--;
                break;
            case ItemType.Candies:
                candies[itemID].itemAmountInInventory--;
                break;
            case ItemType.LotteryTicket:
                lotteryTickets[itemID].itemAmountInInventory--;
                break;
        }
    }
}
