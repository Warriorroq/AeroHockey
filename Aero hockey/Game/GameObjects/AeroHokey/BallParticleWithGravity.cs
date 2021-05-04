using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroHockey.Game
{
    class BallParticleWithGravity : BallParticle
    {
        public BallParticleWithGravity(Scene scene, Shape shape, Vector2f position) : base(scene, shape, position)
        {
            liveTime = 0.5f;
            var rigitBody = new RigidbodyComponent(this);
            _components.Add(rigitBody);
            rigitBody.SetVelocity(new Vector2f(Game.random.Next(-80, 80), Game.random.Next(-90, -10)));
        }
    }
}
