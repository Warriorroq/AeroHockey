using SFML.Graphics;
using SFML.System;
using System;

namespace AeroHockey.Game
{
    public class Ball : GameObject
    {
        public Vector2f direction;
        public Ball(Scene scene, Shape shape) : base(scene, shape)
        {
            _components.Add(new CollideComponent(this));
            _components.Add(new FollowParticlesEffectComponent(this, scene));
            _components.Add(new GravityParticlesCollideComponent(this, scene, 40));

            position = new Vector2f(200, 200 + Game.random.Next(50, 200));
            direction = new Vector2f(Game.random.Next(100, 700), Game.random.Next(100,500));
        }
        protected override void OnUpdate()
        {
            position += direction * Time.deltaTime;
            if (position.X > Screen.widthWindow || position.X < 0)
                direction.X *= -1f;

            if (position.Y > Screen.heightWindow || position.Y < 0)
                direction.Y *= -1f;
        }
        public override void OnCollisionWith(GameObject gameObject)
        {
            if (gameObject is Plate || gameObject is PlateBot)
            {
                GetComponent<GravityParticlesCollideComponent>().CreateParticles();
                direction.X *= -1;
                position.X += direction.X * 2 * Time.deltaTime;
            }
        }
    }
}
