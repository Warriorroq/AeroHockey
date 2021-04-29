using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aero_hockey.Game
{
    public class BallEffectComponent : Component
    {
        private Action CreateBall;
        private float _timer;
        private float _deltaTime;
        public BallEffectComponent(GameObject parent, Scene scene) : base(parent)
        {
            CreateBall = () => scene.Add(new BallEffect(scene,
            new RectangleShape(new Vector2f(10, 10)) {
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
