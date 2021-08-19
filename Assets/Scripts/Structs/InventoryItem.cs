using Managers;
using UnityEditor;
using UnityEngine;

namespace Structs
{
    public class InventoryItem
    {
        private Item itemInfo;
        private int quantity;

        public InventoryItem(Item item)
        {
            itemInfo = item;
            quantity = 1;
            InventoryManager.Instance.AddItemToUI(item.GameItem);
        }

        public void IncrementQuantity(int number)
        {
            quantity += number;
        }
        
        public void DecreaseQuantity(int number)
        {
            quantity -= number;

            if (quantity < 1)
            {
                InventoryManager.Instance.RemoveItemFromUI(itemInfo.GameItem);
                InventoryManager.Instance.InventoryItems.Remove(this);
            }
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public Item GetItem()
        {
            return itemInfo;
        }
    }
}