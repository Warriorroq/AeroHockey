using SFML.Graphics;
using SFML.System;
using System;
namespace Project.Game.AeroHokey
{
    public class PlateBot : GameObject
    {
        protected float _speed = Screen.heightWindow;
        protected float _deltaSpeed = 10f;
        public PlateBot(Scene scene, Shape shape) : base(scene)
        {
            AddComponent(new CollideComponent(this));
            AddComponent(new RenderComponent(this, shape, scene) { layer = 1 });
            position = new Vector2f(1030, 300);
        }
        protected override void OnUpdate()
        {
            ChangeDirection();
            if (position.Y + _deltaSpeed + 100 > Screen.heightWindow)
                _deltaSpeed = -_speed * Time.deltaTime;
            
            else if(position.Y + _deltaSpeed < 0)
                _deltaSpeed = _speed * Time.deltaTime;
            
            position.Y += _deltaSpeed;
        }
        private void ChangeDirection()
        {
            if(Game.random.Next(0, 1000) < 1)
                _deltaSpeed = -_deltaSpeed;
            
            if (_deltaSpeed == 0)
                _deltaSpeed = _speed * Time.deltaTime;
        }
    }
}
