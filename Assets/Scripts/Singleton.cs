using UnityEngine;

namespace BC.BestGame
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T One { get; protected set; }

        protected void Awake()
        {
            if (One != null && One != this)
            {
                Destroy(gameObject);
                return;
            }

            One = this as T;
            DontDestroyOnLoad(this);
            Init();
        }

        public virtual void Init()
        {
        }
    }
}