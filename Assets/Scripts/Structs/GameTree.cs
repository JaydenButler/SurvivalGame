using UnityEngine;

namespace Structs
{
    public class GameTree
    {
        private int Health { get; set; }
        private GameObject TreeObject { get; set; }
        
        public GameTree(int amount, GameObject treeObject)
        {
            Health = amount;
            TreeObject = treeObject;
        }

        private void SetHealth(int amount)
        {
            Health = amount;
        }
        
        public int GetHealth()
        {
            return Health;
        }
        
        public void SetTreeObject(GameObject treeObject)
        {
            TreeObject = treeObject;
        }
        
        public GameObject GetTreeObject()
        {
            return TreeObject;
        }
        
        public void LowerTreeHealth(int amount)
        {
            SetHealth(GetHealth() - amount);
        }
    }
}