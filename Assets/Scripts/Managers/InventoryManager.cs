using System.Collections.Generic;
using System.Linq;
using Structs;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class InventoryManager : MonoBehaviour
    {
        //Add 2d list or something here

        public List<InventoryItem> InventoryItems = new List<InventoryItem>();
        [SerializeField] public GameObject inventoryUI;
        [SerializeField] private Sprite woodImage;

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

        public void AddItemOne()
        {
            inventoryUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = woodImage;
        }
        
        public void RemoveItemOne()
        {
            inventoryUI.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = null;
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
