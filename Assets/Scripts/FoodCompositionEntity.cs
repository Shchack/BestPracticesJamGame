using System;
using UnityEngine;

namespace BC.BestGame
{
    public class FoodCompositionEntity : MonoBehaviour
    {
        [SerializeField] private string _name = "Food";
        [SerializeField] private string _taste = "Sweet";
        [SerializeField] private string _smell = "Good";
        [SerializeField] private string _color = "Green";

        [SerializeField] private FoodEffectComponent[] _effects;

        public void Use()
        {
            Debug.Log($"{_name}. Tastes {_taste}. Smells {_smell}. Color {_color}. Has effects:");

            foreach (var effect in _effects)
            {
                Debug.Log($"{effect.Name}. Strength: {effect.Strength}");
            }
        }

        [ContextMenu(nameof(DebugUse))]
        private void DebugUse()
        {
            Use();
        }
    }

    [Serializable]
    public class FoodEffectComponent
    {
        public string Name;
        public int Strength;
    }
}