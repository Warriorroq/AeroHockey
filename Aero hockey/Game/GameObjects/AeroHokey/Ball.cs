using SFML.Graphics;
using SFML.System;
namespace Project.Game.AeroHokey
{
    public class Ball : GameObject
    {
        public Vector2f direction;
        public Ball(Scene scene, Shape shape) : base(scene)
        {
            AddComponent(new CollideComponent(this));
            AddComponent(new FollowParticlesEffectComponent(this, scene));
            AddComponent(new GravityParticlesCollideComponent(this, scene, 40));
            AddComponent(new RenderComponent(this, shape, scene) { layer = 1 });
            position = new Vector2f(200, 200 + Game.random.Next(50, 200));
            direction = new Vector2f(Game.random.Next(100, 700), Game.random.Next(100,500));
        }
        protected override void OnUpdate()
        {
            position += direction * objTimer.deltaTime;
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
                position.X += direction.X * 2 * objTimer.deltaTime;
            }
        }
    }
}
