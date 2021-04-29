using System;
using SFML.Graphics;
using SFML.System;
namespace Aero_hockey.Game
{
    public class AeroHokey : GameLoop
    {
        public static Random random = new Random(65_101);
        private Scene currentScene;
        public AeroHokey() : base("Aero hokey")
        {
            currentScene = new Scene();
        }
        public override void Init()
        {
            var ball = new Ball(currentScene, new RectangleShape(new Vector2f(10, 10)) {
                FillColor = Color.Black
            });
            var plate = new Plate(currentScene, new RectangleShape(new Vector2f(20, 100)) {
                FillColor = Color.Black
            });
            var bot = new PlateBot(currentScene, new RectangleShape(new Vector2f(20, 100)) {
                FillColor = Color.Black
            });

            currentScene.Init();
            currentScene.Add(ball);
            currentScene.Add(plate);
            currentScene.Add(bot);
        }
        public override void LoadContent()
        {
            DebugUtility.LoadContent(Fonts.CEAZAR);
        }
        public override void Update()
        {
            currentScene.Update();
        }
        public override void Draw()
        {
            currentScene.Draw();
            DebugFPS();
        }
        private void DebugFPS()
            => Debug($"FPS:{1 / Time.deltaTime:0.00}");
    }
}
