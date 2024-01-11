using UnityEngine;

namespace BC.BestGame
{
    public class CraftStationEntity : MonoBehaviour, IInteractable
    {
        public void Interact(PlayerController player)
        {
            GameHub.One.Events.OpenInventory.Notify();
            Debug.Log("Crafting!");
        }
    }
}