using SFML.Graphics;
using SFML.System;
namespace Aero_hockey.Game
{
    public class Ball : GameObject
    {
        public Vector2f direction;
        public Ball(Scene scene, Shape shape) : base(scene, shape)
        {
            position = new Vector2f(200, 200);
            direction = new Vector2f(200, 100);
            this.shape.Origin = new Vector2f(10, 10) / 2f;
        }
        public override void OnUpdate()
        {
            position += direction * Time.deltaTime;
            if (position.X > Screen.widthWindow || position.X < 0)
                direction.X = -direction.X * (AeroHokey.random.Next(8, 14) / 10f);
            
            if (position.Y > Screen.heightWindow || position.Y < 0)
                direction.Y = -direction.Y * (AeroHokey.random.Next(8, 14) / 10f);
            
        }
        public override void OnCollisionWith(GameObject gameObject)
        {
            if(gameObject is Plate || gameObject is PlateBot) {
                direction.X = -direction.X;
                position.X += direction.X * 2 * Time.deltaTime;
            }
        }
    }
}
