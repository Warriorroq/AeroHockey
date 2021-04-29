using SFML.Graphics;
using SFML.System;
using System;

namespace Aero_hockey.Game
{
    public class BallEffect : GameObject
    {
        private float _Timer;
        private float _liveTime;
        public BallEffect(Scene scene, Shape shape, Vector2f position) : base(scene, shape)
        {
            this.position = position;
            _Timer = 0f;
            _liveTime = 0.5f;
        }
        public override void OnUpdate()
        {
            _Timer += Time.deltaTime;
            ChangeColor();
            if(_Timer >= _liveTime)
            {
                Destroy();
            }
        }
        private void ChangeColor()
        {
            var color = shape.FillColor;
            color.A = (byte)(255 - 255 * (_Timer / _liveTime));
            shape.FillColor = color;
        }
        public override void Draw()
        {
            Screen.window.Draw(shape);
        }
    }
}
