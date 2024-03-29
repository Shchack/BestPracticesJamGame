namespace BC.BestGame
{
    public class GameHub : Singleton<GameHub>
    {
        public GameEventSystem Events { get; private set; }
        public GameStorageSystem Storage { get; private set; }
        public IAudioSystem Audio { get; private set; }

        public bool IsInitialized { get; private set; }

        public override void Init()
        {
            Events = new GameEventSystem();
            Storage = new GameStorageSystem();

            if (TryGetComponent(out IAudioSystem audioSystem))
            {
                Audio = audioSystem;
            }

            IsInitialized = true;
        }

        private void OnDisable()
        {
            IsInitialized = false;
        }
    }
}