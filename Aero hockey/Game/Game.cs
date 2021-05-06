using System;
using SFML.Graphics;
using SFML.System;
using Project.Game.AeroHokey;
namespace Project.Game
{
    public class Game : GameLoop
    {
        public static Random random;
        private Scene currentScene;
        public Game() : base("Aero hokey")
        {
            random = new Random(DateTime.UtcNow.Second + DateTime.UtcNow.Minute * 60);
            currentScene = new Scene();
        }
        public override void Init()
        {
            currentScene.Init();
            CreateHokey();
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
        private void CreateHokey()
        {
            var bg = new Bg(currentScene, new RectangleShape(new Vector2f(Screen.widthWindow, Screen.heightWindow)));
            currentScene.Add(bg);
            var ball = new Ball(currentScene, new CircleShape(5)
            {
                FillColor = Color.Blue,
                Origin = new Vector2f(10, 10) / 2f
            });
            currentScene.Add(ball);
            ball = new Ball(currentScene, new CircleShape(7)
            {
                FillColor = Color.Red,
                Origin = new Vector2f(10, 10) / 2f
            });
            currentScene.Add(ball);
            ball = new Ball(currentScene, new CircleShape(6)
            {
                FillColor = Color.Black,
                Origin = new Vector2f(10, 10) / 2f
            });
            currentScene.Add(ball);
            var plate = new Plate(currentScene, new RectangleShape(new Vector2f(20, 100))
            {
                FillColor = Color.Black
            });
            currentScene.Add(plate);
            var bot = new PlateBot(currentScene, new RectangleShape(new Vector2f(20, 105))
            {
                FillColor = Color.Black
            });
            currentScene.Add(bot);
        }
    }
}
