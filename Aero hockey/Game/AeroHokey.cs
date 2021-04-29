using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace Aero_hockey.Game
{
    public class AeroHokey : GameLoop
    {
        Scene scene;
        Ball ball;
        public AeroHokey() : base("Aero hokey")
        {
            scene = new Scene();
        }
        public override void Init()
        {
            ball = new Ball(scene, new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = Color.Black
            });
            scene.Init();
            scene.Add(ball);
        }
        public override void LoadContent()
        {
            DebugUtility.LoadContent(Fonts.CEAZAR);
        }
        public override void Update()
        {
            scene.Update();
            if(Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                ball.direction = new Vector2f(0, 0);
            }
        }
        public override void Draw()
        {
            scene.Draw();
            DebugFPS();
        }
        private void DebugFPS()
            => Debug($"FPS:{1 / Time.deltaTime:0.0}");
    }
}
