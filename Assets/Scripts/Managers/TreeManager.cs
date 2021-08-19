using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Managers;
using Player;
using Structs;
using UnityEngine;
using UnityEngine.UI;

public class TreeManager : MonoBehaviour
{
    public List<GameTree> Trees = new List<GameTree>();

    private static TreeManager _instance;

    public static TreeManager Instance { get { return _instance; } }

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
    
    public void SpawnTree(Vector3 spawnPoint)
    {
        var newTree = Instantiate(Resources.Load("Prefabs/Tree"), spawnPoint, Quaternion.identity) as GameObject;
        GameTree tree = new GameTree(10, newTree);
        Trees.Add(tree);
    }

    public void PlayerHitTree(RaycastHit hit)
    {
        int index = Trees.IndexOf(Trees.FirstOrDefault(p => p.GetTreeObject() == hit.transform.gameObject));
        Trees[index].LowerTreeHealth(1);

        if (Trees[index].GetHealth() <= 0)
        {
            Destroy(hit.transform.gameObject);
            Trees.Remove(Trees[index]);
        }
        
        int woodIndex = InventoryManager.Instance.InventoryItems.FindIndex(x => x.GetItem().ItemName == "Wood");
        
        if (woodIndex != -1)
        {
            InventoryManager.Instance.InventoryItems[woodIndex].IncrementQuantity(1);
        }
        else
        {
            Item newItem = new Item
            {
                ItemName = "Wood",
                GameItem = GameManager.GameItems.Wood
            };

            var newInventoryItem = new InventoryItem(newItem);  
            InventoryManager.Instance.InventoryItems.Add(newInventoryItem);
            Debug.Log("Added wood to inventory");
            
            woodIndex = InventoryManager.Instance.InventoryItems.FindIndex(x => x.GetItem().ItemName == "Wood");
        }

        InventoryManager.Instance.inventoryUI.transform.Find("InventoryBar").Find($"Item{woodIndex}").GetChild(0).gameObject.GetComponent<Text>().text =
            $"{InventoryManager.Instance.InventoryItems[woodIndex].GetQuantity()}";

        // woodAmount.text = $"Wood amount: {InventoryManager.Instance.InventoryItems[woodIndex].GetQuantity()}";
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            for (int x = 0; x < 30; x++)
            {
                var fakeI =  i * 10;
                var fakeX = x * 10;
                var spawnPoint = new Vector3(fakeI, 2, fakeX);
                SpawnTree(spawnPoint);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
