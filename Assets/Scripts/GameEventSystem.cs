using System;

namespace BC.BestGame
{
    public class GameEventSystem
    {
        public SimpleGameEvent OpenInventory { get; private set; }
        public SimpleGameEvent CloseDeliveryTerminal { get; private set; }

        public GameEventSystem()
        {
            OpenInventory = new SimpleGameEvent();
            CloseDeliveryTerminal = new SimpleGameEvent();
        }

        public class SimpleGameEvent
        {
            private event Action _onEvent;

            public void Notify()
            {
                _onEvent?.Invoke();
            }

            public void Subscribe(Action handler) => _onEvent += handler;
            public void Unsubscribe(Action handler) => _onEvent -= handler;
        }
    }
}