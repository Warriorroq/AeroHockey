using SFML.Graphics;
using SFML.System;
namespace Project.Game
{
    public class BallParticle : GameObject
    {
        protected float liveTime;
        private float _Timer;
        private RenderComponent render;
        public BallParticle(Scene scene, Shape shape, Vector2f position) : base(scene)
        {
            render = new RenderComponent(this, shape, scene);
            AddComponent(render);
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
            var color = render.shape.FillColor;
            color.A = (byte)(255 - 255 * (_Timer / liveTime));
            render.shape.FillColor = color;
        }
    }
}
