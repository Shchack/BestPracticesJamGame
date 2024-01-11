using UnityEngine;

namespace BC.BestGame
{
    public class CoinPickable : MonoBehaviour, IInteractable
    {
        [SerializeField] private ItemData _data;

        public void Interact(PlayerController player)
        {
            Debug.Log($"Coin picked up {gameObject.name}");
            player.PickupCoin();
        }
    }
}