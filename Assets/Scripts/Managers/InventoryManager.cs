using System.Collections.Generic;
using System.Linq;
using Structs;
using UnityEngine;

namespace Managers
{
    public class InventoryManager : MonoBehaviour
    {
        //Add 2d list or something here

        public List<InventoryItem> InventoryItems = new List<InventoryItem>();

        private static InventoryManager _instance;

        public static InventoryManager Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void AddItem(InventoryItem item)
        {
            InventoryItems.Add(item);
        }

            // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
