using SFML.Graphics;
using SFML.System;
using System;

namespace AeroHockey.Game
{
    public class BallParticle : GameObject
    {
        protected float liveTime;
        private float _Timer;
        public BallParticle(Scene scene, Shape shape, Vector2f position) : base(scene, shape)
        {
            this.position = position;
            _Timer = 0f;
            liveTime = 0.5f;
        }
        protected override void OnUpdate()
        {
            _Timer += Time.deltaTime;
            ChangeColor();
            if(_Timer >= liveTime)
            {
                Destroy();
            }
        }
        private void ChangeColor()
        {
            var color = shape.FillColor;
            color.A = (byte)(255 - 255 * (_Timer / liveTime));
            shape.FillColor = color;
        }
        public override void Draw()
        {
            Screen.window.Draw(shape);
        }
    }
}
