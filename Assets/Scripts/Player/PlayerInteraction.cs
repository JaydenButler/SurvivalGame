using System;
using System.Linq;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private GameObject house;
        
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
            
                int woodIndex = InventoryManager.Instance.InventoryItems.FindIndex(x => x.GetItem().ItemName == "Wood");;
                
                if(Physics.Raycast (ray, out hit))
                {
                    if(hit.collider.CompareTag("Tree"))
                    {
                        TreeManager.Instance.PlayerHitTree(hit);
                    }
                    else if (hit.collider.CompareTag("Stone"))
                    {
                        StoneManager.Instance.PlayerHitStone(hit);
                    }

                    if (woodIndex != -1)
                    {
                        if (hit.transform.name == "Ground" && InventoryManager.Instance.InventoryItems[woodIndex].GetQuantity() >= 10)
                        {
                            var houseSpawnPoint = new Vector3(hit.point.x, 5, hit.point.z);
                            Instantiate(house, houseSpawnPoint, Quaternion.identity);
                            InventoryManager.Instance.InventoryItems[woodIndex].DecreaseQuantity(10);
                            woodIndex = InventoryManager.Instance.InventoryItems.FindIndex(x => x.GetItem().ItemName == "Wood");
                            if (woodIndex != -1)
                            {
                                InventoryManager.Instance.inventoryUI.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text =
                                    $"{InventoryManager.Instance.InventoryItems[woodIndex].GetQuantity()}";
                            }
                        }
                    }
                }
            }
        
        
        
        }
    }
}