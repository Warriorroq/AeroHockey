using SFML.System;

namespace Project
{
    public class Timer
    {
        public float deltaTime;
        public float TotalTimeElapsed { 
            get => _clock.ElapsedTime.AsSeconds();
        }
        private float _totalTimeBeforeUpdate;
        private float _updateTime;
        private float _previosTimeElapsed;
        private Clock _clock;
        public Timer()
        {
            deltaTime = 0f;
            _totalTimeBeforeUpdate = 0f;
            _previosTimeElapsed = 0f;
            _clock = new Clock();
        }
        public void Init(float updateTime)
        {
            _updateTime = updateTime;
        }
        public bool Update()
        {
            deltaTime = TotalTimeElapsed - _previosTimeElapsed;
            _previosTimeElapsed = TotalTimeElapsed;
            _totalTimeBeforeUpdate += deltaTime;
            if(_totalTimeBeforeUpdate >= _updateTime)
            {
                deltaTime = _totalTimeBeforeUpdate;
                _totalTimeBeforeUpdate = 0;
                return true;
            }
            return false;
        }
    }
}
