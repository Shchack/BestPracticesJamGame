using UnityEngine;

namespace BC.BestGame
{
    public class SpoiledFoodEntity : FoodInheritanceEntity
    {
        [SerializeField] private string _negativeEffect = "Poisoned";

        public override void Use()
        {
            Debug.Log($"Spoiled food. Negative effect: {_negativeEffect}");
        }
    }
}