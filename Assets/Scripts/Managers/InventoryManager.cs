using System.Collections.Generic;
using System.Linq;
using Structs;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class InventoryManager : MonoBehaviour
    {
        public List<InventoryItem> InventoryItems = new List<InventoryItem>();
        [SerializeField] public GameObject inventoryUI;

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

        public void AddItemToUI(GameManager.GameItems item)
        {
            var nextAvailableSlot = Instance.InventoryItems.Count;
            if (item == GameManager.GameItems.Wood)
            {
                inventoryUI.transform.Find("InventoryBar").Find($"Item{nextAvailableSlot}").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Wood");
                inventoryUI.transform.Find("InventoryBar").Find($"Item{nextAvailableSlot}").gameObject.SetActive(true);
            }
            else if (item == GameManager.GameItems.Stone)
            {
                inventoryUI.transform.Find("InventoryBar").Find($"Item{nextAvailableSlot}").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Stone");
                inventoryUI.transform.Find("InventoryBar").Find($"Item{nextAvailableSlot}").gameObject.SetActive(true);
            }
        }
        
        public void RemoveItemFromUI(GameManager.GameItems item)
        {
            Debug.Log($"Target item: {item}");
            int index = Instance.InventoryItems.FindIndex(x => x.GetItem().GameItem ==  item);
            Debug.Log(index);
            inventoryUI.transform.Find("InventoryBar").Find($"Item{index}").GetComponent<Image>().sprite = null;
            inventoryUI.transform.Find("InventoryBar").Find($"Item{index}").gameObject.SetActive(false);
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
