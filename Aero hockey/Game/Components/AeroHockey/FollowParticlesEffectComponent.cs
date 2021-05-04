using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroHockey.Game
{
    public class FollowParticlesEffectComponent : Component
    {
        private Action CreateBall;
        private float _timer;
        private float _deltaTime;
        public FollowParticlesEffectComponent(GameObject parent, Scene scene) : base(parent)
        {
            CreateBall = () => scene.Add(new BallParticle(scene,
            new CircleShape(5) {
                FillColor = Color.Black,
                Origin = new Vector2f(10, 10) / 2f
            }, parent.position));
            _timer = 0.05f;
        }
        public override void Update()
        {
            _deltaTime += Time.deltaTime;
            if(_deltaTime > _timer)
            {
                _deltaTime = 0;
                CreateBall();
            }
        }
    }
}
