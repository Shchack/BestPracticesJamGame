using UnityEngine;

namespace BC.BestGame
{
    public class Pickable : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemData _data;

        public void Interact(PlayerController player)
        {
            Debug.Log($"Picked up {gameObject.name}");
            player.PickupItem(_data);
        }
    }
}