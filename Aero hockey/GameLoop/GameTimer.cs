namespace AeroHockey
{
    public class GameTimer
    {
        private float _deltaTime = 0f;
        private float _timeScale = 1f;

        public float TimeScale
        {
            get => _timeScale;
            set => _timeScale = value;
        }
        public float DeltaTime
        {
            get => _deltaTime * _timeScale;
            set => _deltaTime = value;
        }
        public float DeltaTimeUnscaled
        {
            get => _deltaTime;
        }
        public float TotalAmountOfTime
        {
            get;
            private set;
        }
        public void Update(float deltaTime, float totalTimeElapsed)
        {
            this._deltaTime = deltaTime;
            TotalAmountOfTime = totalTimeElapsed;
        }
    }
}
