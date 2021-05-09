using SFML.Graphics;
using SFML.System;
using System;
namespace Project.Game.AeroHokey
{
    public class FollowParticlesEffectComponent : Component
    {
        private float _timer;
        private float _deltaTime;
        private Scene _scene;
        public FollowParticlesEffectComponent(GameObject parent, Scene scene) : base(parent)
        {
            _scene = scene;
            _timer = 0.05f;
        }
        public void CreateBall()
        {
            _scene.Add(new BallParticle(
                _scene,
                new CircleShape(5)
                {
                    FillColor = Color.Black,
                    Origin = new Vector2f(10, 10) / 2f
                }, 
                parent.position)
                );
        }
        public override void Update(float deltaTime)
        {
            _deltaTime += deltaTime;
            if(_deltaTime > _timer)
            {
                _deltaTime = 0;
                CreateBall();
            }
        }
    }
}
