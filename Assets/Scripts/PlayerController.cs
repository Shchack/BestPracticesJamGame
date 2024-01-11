using UnityEngine;

namespace BC.BestGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private float _moveSpeed = 1f;

        private void Update()
        {
            Move();
        }

        public void PickupItem(ItemData data)
        {
            _inventory.AddItem(data);
        }

        private void Move()
        {
            var movement = Vector2.zero;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                movement = Vector3.right;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                movement = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                movement = Vector3.down;
            }

            if (movement != Vector2.zero)
            {
                transform.Translate(_moveSpeed * Time.deltaTime * movement);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact(this);
            }
        }
    }
}