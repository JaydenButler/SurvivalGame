using Managers;
using UnityEngine;

namespace Structs
{
    public class Item
    {
        public string ItemName { get; set; }
        public GameManager.GameItems GameItem { get; set; }
        public Sprite Icon { get; set; }
    }
}