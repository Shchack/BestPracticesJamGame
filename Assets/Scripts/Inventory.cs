using UnityEngine;

namespace BC.BestGame
{
    public class Inventory : MonoBehaviour
    {
        private void Start()
        {
            GameHub.One.Events.OpenInventory.Subscribe(Open);
        }

        private void OnDestroy()
        {
            if (GameHub.One.IsInitialized)
            {
                GameHub.One.Events.OpenInventory.Unsubscribe(Open);
            }
        }

        private void Open()
        {
            Debug.Log("Inventory opened!");
        }

        public void AddItem(ItemData item)
        {

        }
    }
}