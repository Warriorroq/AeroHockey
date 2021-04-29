using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace Aero_hockey.Game
{
    public class AeroHokey : GameLoop
    {
        public static Random random = new Random(65_101);
        Scene scene;
        public AeroHokey() : base("Aero hokey")
        {
            scene = new Scene();
        }
        public override void Init()
        {
            var ball = new Ball(scene, new RectangleShape(new Vector2f(10, 10))
            {
                FillColor = Color.Black
            });
            var plate = new Plate(scene, new RectangleShape(new Vector2f(20, 100))
            {
                FillColor = Color.Black
            });
            var bot = new PlateBot(scene, new RectangleShape(new Vector2f(20, 100))
            {
                FillColor = Color.Black
            });

            scene.Init();
            scene.Add(ball);
            scene.Add(plate);
            scene.Add(bot);
        }
        public override void LoadContent()
        {
            DebugUtility.LoadContent(Fonts.CEAZAR);
        }
        public override void Update()
        {
            scene.Update();
        }
        public override void Draw()
        {
            scene.Draw();
        }
        private void DebugFPS()
            => Debug($"FPS:{1 / Time.deltaTime:0.0}");
    }
}
