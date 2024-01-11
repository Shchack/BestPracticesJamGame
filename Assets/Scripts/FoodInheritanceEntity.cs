using UnityEngine;

namespace BC.BestGame
{
    public class FoodInheritanceEntity : MonoBehaviour
    {
        [SerializeField] protected string _name = "Name";
        [SerializeField] protected string _taste = "Sweet";
        [SerializeField] protected string _smell = "Good";
        [SerializeField] protected string _color = "Green";

        public virtual void Use()
        {
            Debug.Log($"{_name} Tastes {_taste}. Smells {_smell}. Color {_color}");
        }

        [ContextMenu(nameof(DebugUse))]
        private void DebugUse()
        {
            Use();
        }
    }
}