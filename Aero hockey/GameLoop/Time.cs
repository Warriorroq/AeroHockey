namespace AeroHockey 
{ 
    public static class Time
    {
        private static GameTimer _timer = null;
        public static float deltaTime
        {
            get => _timer.DeltaTime;
        }
        public static GameTimer GetTimer()
            => _timer;
        public static void SetTimer(GameTimer gameTime)
        {
            _timer = gameTime;
        }
    }
}
