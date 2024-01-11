using UnityEngine;

namespace BC.BestGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private float _moveSpeed = 1f;

        private int _coins;
        private Vector3 _moveDirection = Vector3.zero;

        private void Start()
        {
            _coins = GameHub.One.Storage.GetCoins();
        }

        private void Update()
        {
            Move();
        }

        public void PickupItem(ItemData data)
        {
            _inventory.AddItem(data);
        }

        public void PickupCoin()
        {
            _coins += 1;
            GameHub.One.Storage.SetCoins(_coins);
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
                _moveDirection = movement;
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

        [ContextMenu(nameof(Give1000Coins))]
        private void Give1000Coins()
        {
            _coins = 1000;
            GameHub.One.Storage.SetCoins(_coins);
        }

        private void Respawn()
        {
            transform.position = Vector3.zero;
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + _moveDirection * 4);
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0f, 0f, 100f, 20f));
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Respawn"))
            {
                Respawn();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
    }
}