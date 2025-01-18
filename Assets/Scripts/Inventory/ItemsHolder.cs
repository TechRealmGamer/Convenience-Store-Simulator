using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

namespace LuciferGamingStudio.InventorySystem
{
    public class ItemsHolder : MonoBehaviour
    {
        public ItemType itemsType;
        public int maxCapacity;
        public int currentCapacity;

        public int[] itemsInHolder;

        public TMP_Text holderCapacity;

        private void Awake()
        {
            itemsInHolder = new int[12];
        }

        private void OnEnable()
        {
            InputManager.Instance.canMove = false;
            InputManager.Instance.SetCursorState(false);
        }

        public void AddItem(int itemID)
        {
            if (currentCapacity < maxCapacity)
            {
                itemsInHolder[itemID]++;
                currentCapacity++;
                Inventory.Instance.RemoveItem(itemsType, itemID);
                UpdateGUI();
            }
        }

        public void RemoveItem(int itemID)
        {
            if(itemsInHolder[itemID] > 0)
            {
                itemsInHolder[itemID]--;
                currentCapacity--;
                Inventory.Instance.AddItem(itemsType, itemID, 1);
                UpdateGUI();
            }
        }

        public void UpdateGUI()
        {
            holderCapacity.text = currentCapacity + " / " + maxCapacity;
            foreach (ItemCardViewGUI itemCard in GetComponentsInChildren<ItemCardViewGUI>())
            {
                itemCard.UpdateItemCard();
            }
        }

        public void CloseGUI()
        {
            gameObject.SetActive(false);
            InputManager.Instance.canMove = true;
            InputManager.Instance.SetCursorState(true);
        }
    }
}
