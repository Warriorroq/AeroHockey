using SFML.System;

namespace Project
{
    public class Timer
    {
        public float deltaTime;
        public float TimeScale;
        public float TotalTimeElapsed 
            => _clock.ElapsedTime.AsSeconds();
        private float _totalTimeBeforeUpdate;
        private float _updateTime;
        private float _previosTimeElapsed;
        private Clock _clock;
        public Timer()
        {
            deltaTime = 0f;
            _totalTimeBeforeUpdate = 0f;
            _previosTimeElapsed = 0f;
            TimeScale = 1f;
            _clock = new Clock();
        }
        public void Init(float updateTime)
        {
            _updateTime = updateTime;
        }
        public bool Update()
        {
            _totalTimeBeforeUpdate += TotalTimeElapsed - _previosTimeElapsed;
            _previosTimeElapsed = TotalTimeElapsed;
            if (_totalTimeBeforeUpdate >= _updateTime)
            {
                deltaTime = _totalTimeBeforeUpdate * TimeScale;
                _totalTimeBeforeUpdate = 0;
                return true;
            }
            return false;
        }
    }
}
