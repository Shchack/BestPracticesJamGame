using UnityEngine;

namespace BC.BestGame
{
    public class Readable : MonoBehaviour, IInteractable
    {
        public void Interact(PlayerController player)
        {
            Debug.Log($"Read {gameObject.name}");
        }
    }
}