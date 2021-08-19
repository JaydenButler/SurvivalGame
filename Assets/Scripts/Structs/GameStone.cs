using UnityEngine;

namespace Structs
{
    public class GameStone
    {
        private int Health { get; set; }
        private GameObject StoneObject { get; set; }
        
        public GameStone(int amount, GameObject stoneObject)
        {
            Health = amount;
            StoneObject = stoneObject;
        }

        private void SetHealth(int amount)
        {
            Health = amount;
        }
        
        public int GetHealth()
        {
            return Health;
        }
        
        public void SetStoneObject(GameObject stoneObject)
        {
            StoneObject = stoneObject;
        }
        
        public GameObject GetStoneObject()
        {
            return StoneObject;
        }
        
        public void LowerStoneHealth(int amount)
        {
            SetHealth(GetHealth() - amount);
        }
    }
}