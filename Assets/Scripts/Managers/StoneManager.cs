using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Managers;
using Player;
using Structs;
using UnityEngine;
using UnityEngine.UI;

public class StoneManager : MonoBehaviour
{
    public List<GameStone> Stones = new List<GameStone>();

    private static StoneManager _instance;

    public static StoneManager Instance { get { return _instance; } }

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
    
    public void SpawnStone(Vector3 spawnPoint)
    {
        var newStone = Instantiate(Resources.Load("Prefabs/Stone"), spawnPoint, Quaternion.identity) as GameObject;
        GameStone stone = new GameStone(10, newStone);
        Stones.Add(stone);
    }

    //TODO: for some reason this makes wood go up
    public void PlayerHitStone(RaycastHit hit)
    {
        int index = Stones.IndexOf(Stones.FirstOrDefault(p => p.GetStoneObject() == hit.transform.gameObject));
        Stones[index].LowerStoneHealth(1);

        if (Stones[index].GetHealth() <= 0)
        {
            Destroy(hit.transform.gameObject);
            Stones.Remove(Stones[index]);
        }

        int stoneIndex = InventoryManager.Instance.InventoryItems.FindIndex(x => x.GetItem().ItemName == "Stone");
        
        if (stoneIndex != -1)
        {
            InventoryManager.Instance.InventoryItems[stoneIndex].IncrementQuantity(1);
        }
        else
        {
            Item newItem = new Item
            {
                ItemName = "Stone",
                GameItem = GameManager.GameItems.Stone
            };

            var newInventoryItem = new InventoryItem(newItem);  
            InventoryManager.Instance.InventoryItems.Add(newInventoryItem);
            Debug.Log("Added stone to inventory");
            
            stoneIndex = InventoryManager.Instance.InventoryItems.FindIndex(x => x.GetItem().ItemName == "Stone");
        }

        InventoryManager.Instance.inventoryUI.transform.Find("InventoryBar").Find($"Item{stoneIndex}").GetChild(0).gameObject.GetComponent<Text>().text =
            $"{InventoryManager.Instance.InventoryItems[stoneIndex].GetQuantity()}";

        // stoneAmount.text = $"Stone amount: {InventoryManager.Instance.InventoryItems[stoneIndex].GetQuantity()}";
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i > -30; i--)
        {
            for (int x = 0; x > -30; x--)
            {
                var fakeI =  i * 10;
                var fakeX = x * 10;
                var spawnPoint = new Vector3(fakeI, 2, fakeX);
                SpawnStone(spawnPoint);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
