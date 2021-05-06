using SFML.Graphics;
using SFML.System;

namespace Project.Game.AeroHokey
{
    class BallParticleWithGravity : BallParticle
    {
        public BallParticleWithGravity(Scene scene, Shape shape, Vector2f position) : base(scene, shape, position)
        {
            liveTime = 3f;
            var rigitBody = new RigidbodyComponent(this);
            rigitBody.SetVelocity(new Vector2f(Game.random.Next(-80, 80), Game.random.Next(-90, -10)));
            AddComponent(new ColorLerp(this, shape, Color.Black, Color.Red, .6f) { speed = 4f });
            AddComponent(rigitBody);
        }
    }
}
