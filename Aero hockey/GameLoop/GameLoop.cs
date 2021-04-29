using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
namespace Aero_hockey
{
    public abstract class GameLoop
    {
        public const int FPS = 144;
        public const float updateTime = 1f / FPS;

        protected GameLoop(string nameOfTheWindow)
        {
            Screen.window = new RenderWindow(new VideoMode(Screen.widthWindow, Screen.heightWindow), nameOfTheWindow);
            Screen.window.Closed += WindowClosed;
            Time.SetTimer(new GameTimer());
        }
        public void Start()
        {

            LoadContent();
            Init();

            float totalTimeBeforeUpdate = 0f;
            float previosTimeElapsed = 0f;
            float deltaTime = 0f;
            float totalTimeElapsed = 0f;

            Clock clock = new Clock();
            while (Screen.window.IsOpen)
            {
                Screen.window.DispatchEvents();
                totalTimeElapsed = clock.ElapsedTime.AsSeconds();
                deltaTime = totalTimeElapsed - previosTimeElapsed;
                previosTimeElapsed = totalTimeElapsed;
                totalTimeBeforeUpdate += deltaTime;

                if (totalTimeBeforeUpdate >= updateTime)
                {
                    Time.GetTimer().Update(totalTimeBeforeUpdate, totalTimeElapsed);
                    totalTimeBeforeUpdate = 0f;

                    Update();

                    Screen.window.Clear(Color.White);
                    Draw();
                    Screen.window.Display();
                }
            }
        }
        private void WindowClosed(object sender, EventArgs e)
            => Screen.window.Close();

        public abstract void LoadContent();
        public abstract void Init();
        public abstract void Update();
        public abstract void Draw();
        public void Debug(object message)
            => DebugUtility.Message(message);
    }
}
